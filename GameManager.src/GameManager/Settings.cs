using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace GameManager {
    [Serializable]
    public sealed class Settings {
        public readonly static string ProgramVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
        public readonly static string ProgramDirectoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public readonly static string RelativeImageFolderPath = "Images";
        public readonly static string RelativeSettingsPath = "Settings.xml";
        public readonly static string RelativeDatabasePath = "Games.db";
        public readonly static string RelativeLogPath = "Error.log";

        private static TypeConverter FontConverter = TypeDescriptor.GetConverter(typeof(Font));
        private static XmlSerializer serializer = new XmlSerializer(typeof(Settings));
        private static Settings instance = null;

        /// <summary>
        /// Gets the only instance of the settings class.
        /// </summary>
        public static Settings Instance {
            set { instance = value; }
            get {
                if (instance == null) {
                    try {
                        var path = Path.Combine(ProgramDirectoryPath, RelativeSettingsPath);
                        instance = Deserialize(File.ReadAllText(path, Encoding.UTF8));

                        //Using Google translate on Japanese title and tags without downloading them doesn't make sense. So either set both to true or both to false depending on language
                        if (instance.UseGoogleTranslateOnTitleAndTags && !instance.UseAlternativeDLSiteLanguages) {
                            if (instance.DLSiteLanguage == DLSitePage.Language.English) {
                                instance.UseAlternativeDLSiteLanguages = true;
                            }
                            else {
                                instance.UseGoogleTranslateOnTitleAndTags = false;
                            }
                        }
                    }
                    catch (FileNotFoundException) {
                        instance = new Settings();
                    }
                }
                return instance;
            }
        }

        #region Serialization
        /// <summary>
        /// Serializes the current settings into an XML string.
        /// </summary>
        public string Serialize() {
            using (MemoryStream serializedSettings = new MemoryStream()) {
                serializer.Serialize(serializedSettings, instance);
                return Encoding.UTF8.GetString(serializedSettings.ToArray());
            }
        }

        /// <summary>
        /// Deserializes the XML string into a settings object.
        /// </summary>
        public static Settings Deserialize(string xmlString) {
            using (MemoryStream serializedSettings = new MemoryStream(Encoding.UTF8.GetBytes(xmlString))) {
                try {
                    return (Settings)serializer.Deserialize(serializedSettings);
                }
                catch (InvalidOperationException e) {
                    Logger.LogException(e);

                    var msg = String.Format("{0} contains invalid data. Please delete {0} or correct the errors specified in {1} and run this program again.", RelativeSettingsPath, RelativeLogPath);
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(1);
                    return null;
                }
            }
        }

        /// <summary>
        /// Serializes the settings singleton to an XML file.
        /// </summary>
        public void Save() {
            Save(Path.Combine(ProgramDirectoryPath, RelativeSettingsPath));
        }

        /// <summary>
        /// Serializes the settings singleton to an XML file located at the specified path.
        /// </summary>
        public void Save(string path) {
            File.WriteAllText(path, Serialize(), Encoding.UTF8);
            OnSaved(EventArgs.Empty);
        }
        #endregion

        #region Events
        /// <summary>
        /// This event is triggered after the settings instance has been saved to the database.
        /// </summary>
        public event EventHandler Saved;

        private void OnSaved(EventArgs e) {
            var handler = Saved;

            if (handler != null) {
                handler(instance, e);
            }
        }
        #endregion

        #region The settings
        //General
        public string GameFolder { get; set; }
		public string RenameTemplate { get; set; }
		public bool RenameOrganize { get; set; }
		public string NoCategory { get; set; }
		public string NoCircle { get; set; }
		public string NoCVs { get; set; }
		public string FileManagerPath { get; set; }
		public string FileManagerArgs { get; set; }
		public string Extensions { get; set; }
		public string FilesToIgnore { get; set; }
        public bool? AutoMoveToGameFolder { get; set; }
        public bool LookForRJCodeInPath { get; set; }
		public bool LookForRJCodeInNames { get; set; }
        public bool LookForRJCodeInTextFiles { get; set; }

        //Appearance
        public bool UseCoverImageAsListImage { get; set; }
        public bool ShowRatingsAsImage { get; set; }
        public bool DisplayPathsAsRelativeToGameFolder { get; set; }
        public bool ApplyListFontToTiles { get; set; }
        public bool ShowImageScrollButtons { get; set; }
        public int RowHeight { get; set; }
        public bool HighlightRowUnderCursor { get; set; }
        public Size ImageSizeInList { get; set; }
        public Size ImageSizeInTile { get; set; }
        public Size ImageSizeInPanel { get; set; }
        public bool WordWrapTitle { get; set; }
        public bool WordWrapTags { get; set; }
		public bool WordWrapHVDBTags { get; set; }
		public bool WordWrapCVs { get; set; }
        public bool WindowPlacementSaved { get; set; }
        public WINDOWPLACEMENT WindowPlacement { get; set; }
        public int EditPanelYPosition { get; set; }
        public int GameListWidth { get; set; }
        public bool[] VisibleEditPanelRows { get; set; }
        [XmlIgnore] public Color TileBackgroundColor { get; set; }
        [XmlIgnore] public Color TileTextColor { get; set; }
        [XmlIgnore] public Font ListFont { get; set; }
        [XmlIgnore] public Font GlobalFont { get; set; }

        //Behavior
        public bool DoubleClickGameToRun { get; set; }
        public PostExtractionAction PostCgExtractionAction { get; set; }
        public ScreenResolution DefaultResolution { get; set; }
        public bool RevertResolutionOnExit { get; set; }
        public bool AutoUpdateGameSize { get; set; }

        //AGTH
        public string AgthPath { get; set; }
        public string ChiiTransPath { get; set; }
        public string AgthDefaultParameters { get; set; }
        public bool UseHCodeForWolfGames { get; set; }
        public string TranslatorPath { get; set; }
        public bool LaunchGamesWithAgth { get; set; }
        public bool LaunchGamesWithChiiTrans { get; set; }
        public bool AutoExitTranslator { get; set; }

        //DLSite
        public bool AutoDownloadGameInfo { get; set; }
        public bool DownloadCoverImage { get; set; }
        public bool DownloadSampleImages { get; set; }
        public bool DownloadTags { get; set; }
		public bool DownloadReviewTags { get; set; }
		public bool DownloadHVDBInfo { get; set; }
		public bool PreferHVDBEnglishTitle { get; set; }
		public bool FilterCVs { get; set; }
		public bool AutoSetCategory { get; set; }
        public bool DownloadRating { get; set; }
        public DLSitePage.Language DLSiteLanguage { get; set; }
        public bool UseAlternativeDLSiteLanguages { get; set; }
        public bool UseGoogleTranslateOnTitleAndTags { get; set; }
        public bool GetTitleFromPath { get; set; }

        /// <summary>
        /// A string wrapper that makes the global font serializable.
        /// Do not access this member directly.
        /// </summary>
        [XmlElement("GlobalFont")]
        public string GlobalFontString {
            get { return GlobalFont == null ? null : FontConverter.ConvertToInvariantString(GlobalFont); }
            set { GlobalFont = (Font)FontConverter.ConvertFromInvariantString(value); }
        }

        [XmlElement("ListFont")]
        public string ListFontString {
            get { return ListFont == null ? null : FontConverter.ConvertToInvariantString(ListFont); }
            set { ListFont = (Font)FontConverter.ConvertFromInvariantString(value); }
        }

        [XmlElement("TileBackgroundColor")]
        public string TileBackgroundColorString {
            get { return ColorTranslator.ToHtml(TileBackgroundColor); }
            set { try { TileBackgroundColor = ColorTranslator.FromHtml(value); } catch (Exception) { } }
        }

        [XmlElement("TileTextColor")]
        public string TileTextColorString {
            get { return ColorTranslator.ToHtml(TileTextColor); }
            set { try { TileTextColor = ColorTranslator.FromHtml(value); } catch (Exception) { } }
        }

        public byte[] ListState { get; set; }
        #endregion

        #region Default values
        /// <summary>
        /// Resets all general settings to their default values.
        /// </summary>
        public void ResetGeneralSettings() {
            GameFolder = null;
            AutoMoveToGameFolder = null;
            LookForRJCodeInPath = true;
			LookForRJCodeInNames = false;
            LookForRJCodeInTextFiles = false;
			RenameTemplate = "[{circle}] {rjcode} {title}";
			RenameOrganize = false;
			NoCategory = "Uncategorized";
			NoCircle = "Unknown";
			NoCVs = "Unknown";
			FileManagerPath = "explorer.exe";
			FileManagerArgs = "\"{0}\"";
			Extensions = ".exe|.m3u|.m3u8|.pls|.aimppl|.aimppl4|.cue";
			FilesToIgnore = "config|unins|cliploger|EnigmaVBUnpacker|RPGMakerMVGame Hook patcher|agth|RPGMakerTrans|decrypter|MVPluginPatcher|setup";
        }

        /// <summary>
        /// Resets all settings related to appearance to their default values.
        /// </summary>
        public void ResetAppearanceSettings() {
            UseCoverImageAsListImage = false;
            ShowRatingsAsImage = true;
            DisplayPathsAsRelativeToGameFolder = true;
            ShowImageScrollButtons = false;
            ApplyListFontToTiles = true;
            RowHeight = 28;
            ImageSizeInList = new Size(25, 25);
            ImageSizeInTile = new Size(100, 100);
            ImageSizeInPanel = new Size(140, 105);
            HighlightRowUnderCursor = true;
            WordWrapTitle = false;
            WordWrapTags = false;
			WordWrapHVDBTags = false;
			WordWrapCVs = false;
            WindowPlacementSaved = false;
            GameListWidth = -1;
            EditPanelYPosition = 0;
            ListState = null;
            TileBackgroundColor = Color.FromArgb(Color.WhiteSmoke.ToArgb());
            TileTextColor = Color.FromArgb(68, 68, 68);
            VisibleEditPanelRows = new[] { true, true, true, true, false, true, true, true, true, false, false, false, true, true, true, true, true };
            GlobalFont = SystemFonts.MessageBoxFont;
            ListFont = SystemFonts.MessageBoxFont;
        }

        /// <summary>
        /// Resets all settings related to behaviour to their default values.
        /// </summary>
        public void ResetBehaviorSettings() {
            DoubleClickGameToRun = true;
            PostCgExtractionAction = PostExtractionAction.Ask;
            DefaultResolution = null;
            RevertResolutionOnExit = true;
            AutoUpdateGameSize = true;
        }
        
        /// <summary>
        /// Resets all settings related to AGTH to their default values.
        /// </summary>
        public void ResetAgthSettings() {
            AgthPath = null;
            AgthDefaultParameters = "/c";
            UseHCodeForWolfGames = true;
            TranslatorPath = null;
            LaunchGamesWithAgth = true;
            LaunchGamesWithChiiTrans = false;
            AutoExitTranslator = true;
        }

        /// <summary>
        /// Resets all settings related to DLSite to their default values.
        /// </summary>
        public void ResetDLSiteSettings() {
            AutoDownloadGameInfo = true;
            DownloadCoverImage = true;
            DownloadSampleImages = true;
            DownloadTags = true;
			DownloadReviewTags = true;
			DownloadHVDBInfo = true;
			PreferHVDBEnglishTitle = true;
			FilterCVs = true;
			AutoSetCategory = true;
            DownloadRating = true;
            DLSiteLanguage = DLSitePage.Language.English;
            UseAlternativeDLSiteLanguages = true;
            UseGoogleTranslateOnTitleAndTags = true;
            GetTitleFromPath = true;
        }
    #endregion

        private Settings() {
            ResetGeneralSettings();
            ResetAppearanceSettings();
            ResetBehaviorSettings();
            ResetAgthSettings();
            ResetDLSiteSettings();
        }

        /// <summary>
        /// Returns a copy of the current settings.
        /// </summary>
        /// <returns></returns>
        public static Settings Copy() {
            return (Settings)Instance.MemberwiseClone();
        }
    }
}

#region Window placement
//RECT structure required by WINDOWPLACEMENT structure
[Serializable]
[StructLayout(LayoutKind.Sequential)]
public struct RECT {
    public int Left;
    public int Top;
    public int Right;
    public int Bottom;
}

//POINT structure required by WINDOWPLACEMENT structure
[Serializable]
[StructLayout(LayoutKind.Sequential)]
public struct POINT {
    public int X;
    public int Y;
}

//WINDOWPLACEMENT stores the position, size, and state of a window
[Serializable]
[StructLayout(LayoutKind.Sequential)]
public struct WINDOWPLACEMENT {
    public int length;
    public int flags;
    public int showCmd;
    public POINT minPosition;
    public POINT maxPosition;
    public RECT normalPosition;
}
#endregion
