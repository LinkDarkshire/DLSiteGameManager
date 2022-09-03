using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GameManager {
    public partial class SettingsForm : Form {
        private bool formInitialized = false;
        Settings oldSettings = Settings.Copy();

        public SettingsForm() {
            InitializeComponent();
            InitializeResolutionList();

            foreach (Control c in Controls) {
                c.Font = Settings.Instance.GlobalFont;
            }

            SetGeneralSettings();
            SetAppearanceSettings();
            SetBehaviorSettings();
            SetAgthSettings();
            SetDLSiteSettings();
            formInitialized = true;
        }

        private static List<ScreenResolution> supportedResolutions = ScreenUtility.GetSupportedResolutions().Reverse().ToList();

        private void InitializeResolutionList() {
            toolTip.SetToolTip(resolutionList, toolTip.GetToolTip(resolutionGroup));
            resolutionList.Items.Add("No change");

            foreach (var resolution in supportedResolutions) {
                resolutionList.Items.Add(resolution.ToString());
            }

            if (Settings.Instance.DefaultResolution == null) {
                resolutionList.SelectedIndex = 0;
            }
            else {
                int index = resolutionList.Items.IndexOf(Settings.Instance.DefaultResolution.ToString());
                resolutionList.SelectedIndex = index == -1 ? 0 : index;
            }
        }

        /// <summary>
        /// Updates the value of the controls in the general tab to reflect the current settings.
        /// </summary>
        private void SetGeneralSettings() {
            gameFolder.Text = Settings.Instance.GameFolder;
			renameTemplate.Text = Settings.Instance.RenameTemplate;
			renameOrganize.Checked = Settings.Instance.RenameOrganize;
            alwaysMove.Checked = Settings.Instance.AutoMoveToGameFolder.GetValueOrDefault();
            askIfMove.Checked = !Settings.Instance.AutoMoveToGameFolder.HasValue;
            neverMove.Checked = !alwaysMove.Checked && !askIfMove.Checked;
            lookForRJCodeInPath.Checked = Settings.Instance.LookForRJCodeInPath;
			lookForRJCodeInNames.Checked = Settings.Instance.LookForRJCodeInNames;
            lookForRJCodeInFile.Checked = Settings.Instance.LookForRJCodeInTextFiles;
        }


        /// <summary>
        /// Updates the value of the controls in the appearance tab to reflect the current settings.
        /// </summary>
        private void SetAppearanceSettings() {
            useCoverImageAsListImage.Checked = Settings.Instance.UseCoverImageAsListImage;
            ratingAsImage.Checked = Settings.Instance.ShowRatingsAsImage;
            disableRowHighlighting.Checked = !Settings.Instance.HighlightRowUnderCursor;
            wordWrapRowText.Checked = Settings.Instance.WordWrapTitle && Settings.Instance.WordWrapTags && Settings.Instance.WordWrapHVDBTags && Settings.Instance.WordWrapCVs;
            applyListFontToTiles.Checked = Settings.Instance.ApplyListFontToTiles;

            thumbnailWidth.Value = Settings.Instance.ImageSizeInPanel.Width;
            thumbnailHeight.Value = Settings.Instance.ImageSizeInPanel.Height;
            listImageWidth.Value = Settings.Instance.ImageSizeInList.Width;
            listImageHeight.Value = Settings.Instance.ImageSizeInList.Height;
            tileImageWidth.Value = Settings.Instance.ImageSizeInTile.Width;
            tileImageHeight.Value = Settings.Instance.ImageSizeInTile.Height;
            rowHeight.Value = Settings.Instance.RowHeight;
        }

        /// <summary>
        /// Updates the value of the controls in the behavior tab to reflect the current settings.
        /// </summary>
        public void SetBehaviorSettings() {
            disableGameSizeCalculation.Checked = !Settings.Instance.AutoUpdateGameSize;
            doubleClickToRun.Checked = Settings.Instance.DoubleClickGameToRun;
            alwaysDelete.Checked = Settings.Instance.PostCgExtractionAction == PostExtractionAction.Delete;
            alwaysRename.Checked = Settings.Instance.PostCgExtractionAction == PostExtractionAction.Rename;
            askIfDelete.Checked = Settings.Instance.PostCgExtractionAction == PostExtractionAction.Ask;
            neverDelete.Checked = Settings.Instance.PostCgExtractionAction == PostExtractionAction.Nothing;
        }

        /// <summary>
        /// Updates the value of the controls in the AGTH tab to reflect the current settings.
        /// </summary>
        public void SetAgthSettings() {
            agthPath.Text = Settings.Instance.AgthPath;
            chiiTransPath.Text = Settings.Instance.ChiiTransPath;
            agthDefaultParameters.Text = Settings.Instance.AgthDefaultParameters;
            useHCodeForWolfGames.Checked = Settings.Instance.UseHCodeForWolfGames;
            translatorPath.Text = Settings.Instance.TranslatorPath;
            launchWithAgth.Checked = Settings.Instance.LaunchGamesWithAgth;
            launchWithChiiTrans.Checked = Settings.Instance.LaunchGamesWithChiiTrans;
            autoExitTranslator.Checked = Settings.Instance.AutoExitTranslator;
        }

        /// <summary>
        /// Updates the value of the controls in the DLSite tab to reflect the current settings.
        /// </summary>
        public void SetDLSiteSettings() {
            useGoogleTranslate.Checked = Settings.Instance.UseGoogleTranslateOnTitleAndTags;
            downloadCoverImage.Checked = Settings.Instance.DownloadCoverImage;
            downloadSampleImages.Checked = Settings.Instance.DownloadSampleImages;
            downloadTags.Checked = Settings.Instance.DownloadTags;
			downloadReviewTags.Checked = Settings.Instance.DownloadReviewTags;
			downloadHVDBInfo.Checked = Settings.Instance.DownloadHVDBInfo;
			preferHVDBEnglishTitle.Checked = Settings.Instance.PreferHVDBEnglishTitle;
			filterCVs.Checked = Settings.Instance.FilterCVs;
			autoSetCategory.Checked = Settings.Instance.AutoSetCategory;
            downloadAverageRating.Checked = Settings.Instance.DownloadRating;
            useAlternativeDLSiteLanguage.Checked = Settings.Instance.UseAlternativeDLSiteLanguages;
            useNeitherDLSite.Checked = !Settings.Instance.AutoDownloadGameInfo;
            useEnglishDLSite.Checked = Settings.Instance.DLSiteLanguage == DLSitePage.Language.English && Settings.Instance.AutoDownloadGameInfo;
            useJapaneseDLSite.Checked = Settings.Instance.DLSiteLanguage == DLSitePage.Language.Japanese && Settings.Instance.AutoDownloadGameInfo;
        }

        /// <summary>
        /// Applies the current settings to the main form.
        /// </summary>
        /// <param name="updateIfTileView">If false, the main form will not be updated if it's in tile view.</param>
        private void UpdateParent(bool updateIfTileView) {
            var parentForm = Owner as MainForm;

            if (formInitialized && parentForm != null && (updateIfTileView || parentForm.ListView != View.Tile)) {
                parentForm.Rebuild();
            }
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e) {
            //If the form was closed or cancelled, revert back to the old settings
            if (DialogResult != DialogResult.OK) {
                Settings.Instance = oldSettings;
            }
        }

        private void okButton_Click(object sender, EventArgs e) {
            if (!String.IsNullOrWhiteSpace(gameFolder.Text) && !Directory.Exists(gameFolder.Text)) {
                MessageBox.Show(this, gameFolder.Text + " is not a valid directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Save general settings
            Settings.Instance.GameFolder = gameFolder.Text;
			Settings.Instance.RenameTemplate = renameTemplate.Text;
			Settings.Instance.RenameOrganize = renameOrganize.Checked;
			
			
            Settings.Instance.AutoMoveToGameFolder = askIfMove.Checked ? null : (bool?)alwaysMove.Checked;
            Settings.Instance.LookForRJCodeInPath = lookForRJCodeInPath.Checked;
			Settings.Instance.LookForRJCodeInNames = lookForRJCodeInNames.Checked;
            Settings.Instance.LookForRJCodeInTextFiles = lookForRJCodeInFile.Checked;

            //Save behavior settings
            Settings.Instance.AutoUpdateGameSize = !disableGameSizeCalculation.Checked;
            Settings.Instance.DoubleClickGameToRun = doubleClickToRun.Checked;
            Settings.Instance.PostCgExtractionAction = alwaysDelete.Checked ? PostExtractionAction.Delete : alwaysRename.Checked ? PostExtractionAction.Rename : askIfDelete.Checked ? PostExtractionAction.Ask : PostExtractionAction.Nothing;
            Settings.Instance.DefaultResolution = resolutionList.SelectedIndex < 1 ? null : supportedResolutions[resolutionList.SelectedIndex - 1];

            //Save DLSite settings
            Settings.Instance.UseGoogleTranslateOnTitleAndTags = useGoogleTranslate.Checked;
            Settings.Instance.AutoDownloadGameInfo = !useNeitherDLSite.Checked;
            Settings.Instance.DownloadCoverImage = downloadCoverImage.Checked;
            Settings.Instance.DownloadSampleImages = downloadSampleImages.Checked;
            Settings.Instance.DownloadRating = downloadAverageRating.Checked;
            Settings.Instance.DownloadTags = downloadTags.Checked;
			Settings.Instance.DownloadReviewTags = downloadReviewTags.Checked;
			Settings.Instance.DownloadHVDBInfo = downloadHVDBInfo.Checked;
			Settings.Instance.PreferHVDBEnglishTitle = preferHVDBEnglishTitle.Checked;
			Settings.Instance.FilterCVs = filterCVs.Checked;
			Settings.Instance.AutoSetCategory = autoSetCategory.Checked;
            Settings.Instance.DLSiteLanguage = useJapaneseDLSite.Checked ? DLSitePage.Language.Japanese : DLSitePage.Language.English;
            Settings.Instance.UseAlternativeDLSiteLanguages = useAlternativeDLSiteLanguage.Checked;

            //Save AGTH settings
            Settings.Instance.AgthPath = agthPath.Text;
            Settings.Instance.ChiiTransPath = chiiTransPath.Text;
            Settings.Instance.AgthDefaultParameters = agthDefaultParameters.Text;
            Settings.Instance.UseHCodeForWolfGames = useHCodeForWolfGames.Checked;
            Settings.Instance.TranslatorPath = translatorPath.Text;
            Settings.Instance.LaunchGamesWithAgth = launchWithAgth.Checked;
            Settings.Instance.LaunchGamesWithChiiTrans = launchWithChiiTrans.Checked;
            Settings.Instance.AutoExitTranslator = autoExitTranslator.Checked;

            //Save appearance settings
            Settings.Instance.HighlightRowUnderCursor = !disableRowHighlighting.Checked;
            Settings.Instance.ImageSizeInPanel = new Size((int)thumbnailWidth.Value, (int)thumbnailHeight.Value);
            Settings.Instance.ImageSizeInList = new Size((int)listImageWidth.Value, (int)listImageHeight.Value);
            Settings.Instance.ImageSizeInTile = new Size((int)tileImageWidth.Value, (int)tileImageHeight.Value);

            Settings.Instance.Save();
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }

        private void ratingAsImage_CheckedChanged(object sender, EventArgs e) {
            Settings.Instance.ShowRatingsAsImage = ((CheckBox)sender).Checked;
            UpdateParent(true);
        }

        private void wordWrapRowText_CheckedChanged(object sender, EventArgs e) {
            Settings.Instance.WordWrapTitle = ((CheckBox)sender).Checked;
            Settings.Instance.WordWrapTags = ((CheckBox)sender).Checked;
			Settings.Instance.WordWrapHVDBTags = ((CheckBox)sender).Checked;
			Settings.Instance.WordWrapCVs = ((CheckBox)sender).Checked;
            UpdateParent(false);
        }

        private void applyListFontToTiles_CheckedChanged(object sender, EventArgs e) {
            Settings.Instance.ApplyListFontToTiles = ((CheckBox)sender).Checked;
            UpdateParent(true);
        }

        private void rowHeight_ValueChanged(object sender, EventArgs e) {
            Settings.Instance.RowHeight = (int)rowHeight.Value;
            UpdateParent(false);
        }

        private void thumbnailWidth_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                thumbnailHeight.Value = (int)((int)thumbnailWidth.Value * 0.75);
                e.SuppressKeyPress = true;
            }
        }

        private void thumbnailHeight_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                thumbnailWidth.Value = (int)(((int)thumbnailHeight.Value * 4) / 3);
                e.SuppressKeyPress = true;
            }
        }

        private void listImageHeight_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                listImageWidth.Value = (int)(((int)listImageHeight.Value * 4) / 3);
                e.SuppressKeyPress = true;
            }
        }

        private void listImageWidth_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                listImageHeight.Value = (int)((int)listImageWidth.Value * 0.75);
                e.SuppressKeyPress = true;
            }
        }

        private void tileImageWidth_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                tileImageHeight.Value = (int)((int)tileImageWidth.Value * 0.75);
                e.SuppressKeyPress = true;
            }
        }

        private void tileImageHeight_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                tileImageWidth.Value = (int)(((int)tileImageHeight.Value * 4) / 3);
                e.SuppressKeyPress = true;
            }
        }

        private void restoreAppearanceButton_Click(object sender, EventArgs e) {
            formInitialized = false;
            Settings.Instance.ResetAppearanceSettings();
            SetAppearanceSettings();
            formInitialized = true;
            UpdateParent(true);
        }

        private void browseButton_Click(object sender, EventArgs e) {
            folderBrowserDialog.ShowDialog(this);
            gameFolder.Text = folderBrowserDialog.SelectedPath;
        }

        private void agthBrowseButton_Click(object sender, EventArgs e) {
            openFileDialog.ShowDialog(this);
            agthPath.Text = openFileDialog.FileName;
        }

        private void translatorBrowseButton_Click(object sender, EventArgs e) {
            openFileDialog.ShowDialog(this);
            translatorPath.Text = openFileDialog.FileName;
        }

        private void chiiTransBrowseButton_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog(this);
            chiiTransPath.Text = openFileDialog.FileName;
        }

        private void agthHelpButton_Click(object sender, EventArgs e) {
            GamePropertiesForm.ShowAgthParameterList(this);
        }

        private void useEnglishDLSite_CheckedChanged(object sender, EventArgs e) {
            useGoogleTranslate.Enabled = useAlternativeDLSiteLanguage.Checked && useEnglishDLSite.Checked;
			DLSitePage.htmlfs = "";

            if (!useGoogleTranslate.Enabled) {
                useGoogleTranslate.Checked = false;
            }

            if (useEnglishDLSite.Checked) {
                useAlternativeDLSiteLanguage.Text = "Get title and tags in Japanese if English ones are unavailable";
            }
        }

        private void useJapaneseDLSite_CheckedChanged(object sender, EventArgs e) {
            useGoogleTranslate.Enabled = useAlternativeDLSiteLanguage.Checked && useEnglishDLSite.Checked;
			DLSitePage.htmlfs = "";

            if (!useGoogleTranslate.Enabled) {
                useGoogleTranslate.Checked = false;
            }

            if (useJapaneseDLSite.Checked) {
                useAlternativeDLSiteLanguage.Text = "Get title and tags in English if Japanese ones are unavailable";
            }
        }

        private void useNeitherDLSite_CheckedChanged(object sender, EventArgs e) {
            SuspendLayout();

            useAlternativeDLSiteLanguage.Enabled = !useNeitherDLSite.Checked;
            downloadCoverImage.Enabled = !useNeitherDLSite.Checked;
            downloadSampleImages.Enabled = !useNeitherDLSite.Checked;
            downloadSampleImages.Enabled = !useNeitherDLSite.Checked;
            downloadTags.Enabled = !useNeitherDLSite.Checked;
			downloadReviewTags.Enabled = !useNeitherDLSite.Checked;
			downloadHVDBInfo.Enabled = !useNeitherDLSite.Checked;
			preferHVDBEnglishTitle.Enabled = !useNeitherDLSite.Checked;
			filterCVs.Enabled = !useNeitherDLSite.Checked;
			autoSetCategory.Enabled = !useNeitherDLSite.Checked;
            downloadAverageRating.Enabled = !useNeitherDLSite.Checked;
            useGoogleTranslate.Enabled = useAlternativeDLSiteLanguage.Checked && useEnglishDLSite.Checked;

            ResumeLayout();
        }

        private void useAlternativeDLSiteLanguage_CheckedChanged(object sender, EventArgs e) {
            useGoogleTranslate.Enabled = useAlternativeDLSiteLanguage.Checked && useEnglishDLSite.Checked;

            if (!useGoogleTranslate.Enabled) {
                useGoogleTranslate.Checked = false;
            }
        }

        private void openListFontDialogButton_Click(object sender, EventArgs e) {
            listFontDialog.Font = Settings.Instance.ListFont;
            var result = listFontDialog.ShowDialog(this);

            if (result == DialogResult.OK) {
                Settings.Instance.ListFont = listFontDialog.Font;
                UpdateParent(true);
            }
        }

        private void useCoverImageAsListImage_CheckedChanged(object sender, EventArgs e) {
            if (!formInitialized) {
                return;
            }

            Settings.Instance.UseCoverImageAsListImage = useCoverImageAsListImage.Checked;

            if (Settings.Instance.UseCoverImageAsListImage) {
                if (listImageHeight.Value == 25 && listImageWidth.Value == 25) {
                    listImageHeight.Value = 25;
                    listImageWidth.Value = 33;
                }

                if (tileImageHeight.Value == 100 && tileImageWidth.Value == 100) {
                    tileImageHeight.Value = 105;
                    tileImageWidth.Value = 140;
                }
            }
            else {
                if (listImageHeight.Value == 25 && listImageWidth.Value == 33) {
                    listImageHeight.Value = 25;
                    listImageWidth.Value = 25;
                }

                if (tileImageHeight.Value == 105 && tileImageWidth.Value == 140) {
                    tileImageHeight.Value = 100;
                    tileImageWidth.Value = 100;
                }
            }

            Settings.Instance.ImageSizeInList = new Size((int)listImageWidth.Value, (int)listImageHeight.Value);
            Settings.Instance.ImageSizeInTile = new Size((int)tileImageWidth.Value, (int)tileImageHeight.Value);
            UpdateParent(true);
        }

        private void launchWithAgth_CheckedChanged(object sender, EventArgs e)
        {
            if (launchWithAgth.Checked)
                launchWithChiiTrans.Checked = false;
        }

        private void launchWithChiiTrans_CheckedChanged(object sender, EventArgs e)
        {
            if (launchWithChiiTrans.Checked)
                launchWithAgth.Checked = false;
        }

        

    }
}
