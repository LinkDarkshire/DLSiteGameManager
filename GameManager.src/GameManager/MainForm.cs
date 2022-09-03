using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace GameManager {
    public partial class MainForm : Form {
        private GameListFilter filter;
        private PictureBox enlargedGameImage;
        private bool listInitialized = false;
        private bool listHadFocusBeforeShowingImage = false;
        private bool enlargedImageIsThumb = false;
        private bool arcConvCreated = false;
        private readonly string arcConvPath = Path.Combine(Path.GetTempPath(), "arc_conv_r54.exe");

        public View ListView { get { return gameList.View; } }

        public string StatusBarText {
            set {
                if (InvokeRequired) {
                    BeginInvoke(new MethodInvoker(() => statusStripLabel.Text = value));
                }
                else {
                    statusStripLabel.Text = value;
                }
            }
            get {
                return statusStripLabel.Text;
            }
        }

        public MainForm() {
            InitializeComponent();
            Icon = Properties.Resources.DLSIconVectorized;

            foreach (Control c in Controls) {
                c.Font = Settings.Instance.GlobalFont;
            }

            //Move the window to where it was in the previous session
            if (Settings.Instance.WindowPlacementSaved) {
                var placement = Settings.Instance.WindowPlacement;
                placement.flags = 0;
                placement.showCmd = placement.showCmd == 2 ? 1 : placement.showCmd; //Prevents the window from ever opening as minimized
                SetWindowPlacement(Handle, ref placement);
            }

            //When a game image is hovered, replace the game list in the main form with an enlarged version of the hovered image
            gameEditControl.ImageViewer.GameImageMouseHover += (sender, e) => {
                if (enlargedGameImage == null) {
                    enlargedGameImage = new PictureBox { BackColor = gameList.BackColor, BorderStyle = BorderStyle.FixedSingle, Visible = false };
                    splitContainer.Panel1.Controls.Add(enlargedGameImage);
                    enlargedGameImage.BringToFront();
                }

                if (enlargedGameImage.Image != null && enlargedImageIsThumb) {
                    enlargedGameImage.Image.Dispose();
                }

                var image = e.HoveredImage.ImageData;

                if (image == null || image.Width == 0 || image.Height == 0) {
                    return;
                }

                //Shrink the image to fit inside the game list if needed
                if (image.Width > gameList.Width || image.Height > gameList.Height) {
                    float aspectRatio = Math.Min(gameList.Width / (float)image.Width, gameList.Height / (float)image.Height);
                    var result = new Size((int)(image.Width * aspectRatio), (int)(image.Height * aspectRatio));
                    image = image.GetHighQualityThumbnail(result.Width, result.Height);
                    enlargedImageIsThumb = true;
                }
                else {
                    enlargedImageIsThumb = false;
                }

                listHadFocusBeforeShowingImage = gameList.Focused;
                enlargedGameImage.Image = image;
                enlargedGameImage.Size = gameList.Size;
                gameList.Visible = false;
                enlargedGameImage.Visible = true;
            };

            //When a game image is unhovered, reshow and focus the game list
            gameEditControl.ImageViewer.GameImageMouseLeave += (sender, e) => {
                if (enlargedGameImage != null) {
                    enlargedGameImage.Visible = false;
                    gameList.Visible = true;

                    if (enlargedGameImage.Image != null && enlargedImageIsThumb) {
                        enlargedGameImage.Image.Dispose();
                    }
                    enlargedGameImage.Image = null;

                    if (listHadFocusBeforeShowingImage) {
                        gameList.Focus();
                    }
                }
            };

            //Make the game edit control report progress to the status bar in this form
            gameEditControl.ReportDownloadProgress = progress => StatusBarText = progress;

            InitializeGameList();
        }

        /// <summary>
        /// Gets the list of games from the database and inserts them into the game list.
        /// </summary>
        private void InitializeGameList() {
            gameList.Freeze();
            gameList.SuspendLayout();

            gameList.PrimarySortColumn = addedColumn;
            gameList.PrimarySortOrder = SortOrder.Descending;

            //Restore the list layout from the previous session
            if (Settings.Instance.ListState != null) {
                gameList.RestoreState(Settings.Instance.ListState);
                viewDetails.Checked = gameList.View == View.Details;
                viewTiles.Checked = gameList.View == View.Tile;
            }
            else {
                //The initially visible game list columns are determined this late to preserve display indices
                rjCodeColumn.IsVisible = dlSiteRatingColumn.IsVisible = timePlayedColumn.IsVisible = sizeColumn.IsVisible = categoryColumn.IsVisible = languageColumn.IsVisible = false;
                addedColumn.IsVisible = timesPlayedColumn.IsVisible = lastPlayedColumn.IsVisible = releasedColumn.IsVisible = commentsColumn.IsVisible = ratingColumn.IsVisible = false;
            }

            //Set the column used to resolve equal comparisons when sorting the list 
            gameList.SecondarySortColumn = titleColumn;
            gameList.SecondarySortOrder = SortOrder.Descending;

            //Set the filter used when searching the list
            filter = new GameListFilter(this, gameList);
            gameList.ModelFilter = filter;

            //Set the group key for non-rated games to "0" to ensure that they are sorted below the rated games
            ratingColumn.GroupKeyGetter = game => ((Game)game).Rating != null ? ((Game)game).Rating.ToString() : "0";
            dlSiteRatingColumn.GroupKeyGetter = game => ((Game)game).DLSRating != null ? ((Game)game).DLSRating.ToString() : "0";

            //Make the "0" group key display as "Not Rated"
            ratingColumn.GroupKeyToTitleConverter = dlSiteRatingColumn.GroupKeyToTitleConverter = key => (string)key == "0" ? "Not Rated" : (string)key;

            circleColumn.GroupKeyToTitleConverter = cvsColumn.GroupKeyToTitleConverter = languageColumn.GroupKeyToTitleConverter = key => (string)key ?? "Unknown";
			
			

            titleColumn.GroupKeyToTitleConverter = key => (string)key ?? "";

            //Ensure that idential categories and languages with different case are grouped together
            //The easiest way to do this is to convert all categories to lower case but this way preserves the user's case
            categoryColumn.GroupKeyGetter = g => {
                var g1 = g as Game;

                if (g1.Category != null) {
                    var firstMatch = Game.GetGames().FirstOrDefault(g2 => g1.Category.Equals(g2.Category, StringComparison.OrdinalIgnoreCase));
                    return firstMatch == null ? null : firstMatch.Category;
                }
                else {
                    return "0";
                }
            };

            categoryColumn.GroupKeyToTitleConverter = key => (string)key == "0" ? "Uncategorized" : (string)key;

            //Group all date columns on month
            Func<DateTime?, DateTime?> filterDate = date => date.HasValue ? new DateTime?(new DateTime(date.Value.Year, date.Value.Month, 1)) : DateTime.MinValue;
            releasedColumn.GroupKeyGetter = game => filterDate(((Game)game).ReleaseDate);
            lastPlayedColumn.GroupKeyGetter = game => filterDate(((Game)game).LastPlayedDate);
            addedColumn.GroupKeyGetter = game => filterDate(((Game)game).AddedDate);

            //Display only the month for date groups
            Func<DateTime?, string> dateToMonthString = date => date != DateTime.MinValue ? date.Value.ToString("MMMM yyyy") : null;
            releasedColumn.GroupKeyToTitleConverter = addedColumn.GroupKeyToTitleConverter = date => dateToMonthString((DateTime?)date) ?? "Unknown";
            lastPlayedColumn.GroupKeyToTitleConverter = date => dateToMonthString((DateTime?)date) ?? "Not Played";

            imageColumn.Renderer = new ImageColumnRenderer();

            //This custom renderer will draw the game list when tile view is enabled
            gameList.ItemRenderer = new TileViewRenderer(gameList);

            //Ensure that the event handler is notified when a game is saved
            Game.GetGames().ForEach(game => game.Saved += game_Saved);

            //Add the games in the database to the list
            gameList.SetObjects(Game.GetGames().ToArray());

            releasedColumn.AspectToStringConverter = date => {
                if (date != null) {
                    return ((DateTime?)date).Value.ToShortDateString();
                }
                return null;
            };

            //Draw the list
            Rebuild();
            gameList.RebuildColumns();
            gameList.Unfreeze();
            gameList.ResumeLayout();
            listInitialized = true;
        }

        /// <summary>
        /// Rebuilds the main form according to the current settings.
        /// </summary>
        public void Rebuild() {
            bool rebuildRequired = false;

            titleColumn.WordWrap = Settings.Instance.WordWrapTitle;
            tagsColumn.WordWrap = Settings.Instance.WordWrapTags;
			hvdbtagsColumn.WordWrap = Settings.Instance.WordWrapHVDBTags;
			cvsColumn.WordWrap = Settings.Instance.WordWrapCVs;
            gameList.UseHotItem = gameList.UseTranslucentHotItem = Settings.Instance.HighlightRowUnderCursor;

            int extraTileSize = Settings.Instance.ApplyListFontToTiles ? (int)Settings.Instance.ListFont.Size : 10;
            var oldTileSize = gameList.TileSize;

            gameList.TileSize = new Size(Settings.Instance.ImageSizeInTile.Width + 4 + extraTileSize,
                                         Settings.Instance.ImageSizeInTile.Height + 20 + extraTileSize);

            if (gameList.View == View.Tile && gameList.TileSize != oldTileSize) {
                rebuildRequired = true;
            }

            if (!gameList.Font.Equals(Settings.Instance.ListFont)) {
                rebuildRequired = true;
                gameList.Font = Settings.Instance.ListFont;
            }

            if (Settings.Instance.ShowRatingsAsImage == (ratingColumn.ImageGetter == null)) {
                rebuildRequired = true;
            }

            if (Settings.Instance.RowHeight >= 20) {
                gameList.RowHeight = Settings.Instance.RowHeight;
            }

            if (Settings.Instance.ShowRatingsAsImage) {
                //Replace the column contents with a graphical representation of the game's rating
                ratingColumn.ImageGetter = row => ((Game)row).Rating != null ? RatingEditor.Images[(int)((Game)row).Rating] : null;
                dlSiteRatingColumn.ImageGetter = row => ((Game)row).DLSRating != null ? RatingEditor.Images[(int)((Game)row).DLSRating] : null;
                ratingColumn.AspectName = null;
                dlSiteRatingColumn.AspectName = null;
            }
            else {
                ratingColumn.ImageGetter = null;
                dlSiteRatingColumn.ImageGetter = null;
                ratingColumn.AspectName = "Rating";
                dlSiteRatingColumn.AspectName = "DLSRating";

                ratingColumn.CellPadding = dlSiteRatingColumn.CellPadding = null;
            }

            if (Settings.Instance.UseCoverImageAsListImage && imageColumn.Width == 28) {
                imageColumn.Width = 36;
            }
            else if (!Settings.Instance.UseCoverImageAsListImage && imageColumn.Width == 36) {
                imageColumn.Width = 28;
            }

            if (rebuildRequired && listInitialized) {
                gameList.BuildList(true);
            }
        }

        /// <summary>
        /// Adds a new game to the list of games.
        /// </summary>
        public void AddGame(Game game) {
            AddGames(new Game[] { game });

            //Select and scroll to the added game
            this.InvokeIfRequired(() => {
                gameList.SelectedObject = game;
                gameList.EnsureVisible(gameList.SelectedIndex);
            });
        }

        /// <summary>
        /// Adds an array of games to the game list.
        /// </summary>
        public void AddGames(Game[] games) {
            foreach (var game in games) {
                game.Saved += game_Saved;
            }

            gameList.AddObjects(games);
        }

        /// <summary>
        /// Removes the specified games from the database and the list of games.
        /// </summary>
        private void DeleteGames(Game[] games) {
            if (games != null) {
                gameEditControl.SetGame(null);
                gameList.RemoveObjects(games);

                foreach (var game in games) {
                    game.Delete();
                    game.DeleteImages();
                    game.Saved -= game_Saved;
                }
            }
        }

        /// <summary>
        /// Filters the list of games to only include games matching the specified search text
        /// </summary>
        private void FilterList(string text) {
            text = text ?? "";

            filter.FilterText = text;
            gameList.BuildList(true);

            if (text != "") {
                gameList.SelectedIndex = 0;
            }

            //Clears the right panel if the filter text matches no games
            if (gameList.SelectedIndex == -1) {
                UpdateRightPanel();
            }
            else {
                gameList.EnsureVisible(gameList.SelectedIndex);
            }
        }

        /// <summary>
        /// Finds a game's RJCode and uses this code to download information from DLSite.
        /// </summary>
        private Task DownloadGameInfoAsync(Game game, bool findRjCode, bool downloadImagesInParallel, Action<string> reportProgress = null, CancellationTokenSource downloadCanceller = null) {
            var downloader = Task.Factory.StartNew(() => {
                downloadCanceller = downloadCanceller ?? new CancellationTokenSource();

                if (game.RJCode == null && findRjCode) {
                    game.RJCode = IOUtility.FindRJCode(game.Path);
                }

                if (game.RJCode != null && Settings.Instance.AutoDownloadGameInfo) {
                    try {
                        game.DownloadInfo(downloadImagesInParallel, reportProgress, downloadCanceller.Token);
                    }
                    catch (Exception e) {
                        if (e is PageNotFoundException || e is UriFormatException) {
                            StatusBarText = e.Message;
                        }
                        else if (e is WebException && !downloadCanceller.IsCancellationRequested) {
                            downloadCanceller.Cancel();
                            this.InvokeIfRequired(() => MessageBox.Show(this, "Failed to connect to DLSite. Please check your internet connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error));
                        }
                        else if (!downloadCanceller.IsCancellationRequested) {
                            downloadCanceller.Cancel();
                            Logger.LogException(e);
                            this.InvokeIfRequired(() => MessageBox.Show(this, "Failed to connect to DLSite. See " + Settings.RelativeLogPath + " for details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error));
                        }
                    }
                }
            });

            return downloader;
        }

        /// <summary>
        /// Downloads game information for several games in parallel
        /// </summary>
        private Task<Game>[] DownloadGameInfoAsync(Game[] games, Action<string> reportProgress = null, CancellationTokenSource downloadCanceller = null) {
            var tasks = new Task<Game>[games.Length];
            int dlSitePagesDownloaded = 0;
            int gamesWithRjCode = games.Count(game => game.RJCode != null);
            bool downloadImagesInParallel = gamesWithRjCode <= 5;

            if (gamesWithRjCode != 0 && Settings.Instance.AutoDownloadGameInfo) {
                reportProgress("0/" + gamesWithRjCode + " DLSite pages downloaded.");
            }

            for (int i = 0; i < games.Length; i++) {
                var game = games[i];

                if (game.RJCode != null && Settings.Instance.AutoDownloadGameInfo) {
                    var downloader = DownloadGameInfoAsync(game, false, downloadImagesInParallel, null, downloadCanceller);

                    tasks[i] = downloader.ContinueWith(_ => {
                        reportProgress(++dlSitePagesDownloaded + "/" + gamesWithRjCode + " DLSite pages downloaded.");
                        return game;
                    });
                }
                else {
                    tasks[i] = Task.Factory.StartNew(() => game);
                }
            }
            return tasks;
        }

        /// <summary>
        /// Starts a new task that extracts a .zip archive to the game folder and searches for the game executable.
        /// If a game executable is found, a valid game object is returned. Else, null is returned.
        /// </summary>
        /// <param name="archivePath"></param>
        /// <returns></returns>
        private Task<Game> ExtractGameAsync(string archivePath) {
            string destination;

            if (Directory.Exists(Settings.Instance.GameFolder)) {
                destination = Settings.Instance.GameFolder;
            }
            else {
                destination = Path.GetDirectoryName(archivePath);
            }

            var extractor = Task.Factory.StartNew(() => {
                Game extractedGame = null;
                string gamePath = null;
                IOUtility.ExtractArchive(archivePath, destination, out gamePath, str => StatusBarText = str);

                if (gamePath != null) {
                    extractedGame = new Game {
                        RJCode = IOUtility.ExtractRJCode(archivePath),
                        Path = gamePath
                    };
                }
                return extractedGame;
            });

            extractor.ContinueWith(failedTask => BeginInvoke(new MethodInvoker(() => {
                Logger.LogException(failedTask.Exception);
                MessageBox.Show("Failed to extract " + Path.GetFileName(archivePath) + ". See " + Settings.RelativeLogPath + " for details.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            })), TaskContinuationOptions.OnlyOnFaulted);

            return extractor;
        }

        /// <summary>
        /// Ask the user if a game should be moved to the game directory and move it.
        /// </summary>
        private void MoveGameIfRequired(Game game) {
			
			// var dirPath = game.Path;
			// if (File.Exists(game.Path)) {
				// dirPath = System.IO.Path.GetDirectoryName(game.Path);
			// }
			var dirPath = IOUtility.GetWorksFolderFromPath(game.Path, game.RJCode);
			var relPath = game.Path.Replace(dirPath, "").Trim(Path.DirectorySeparatorChar);

            //If the selected game isn't already in the game directory, ask if it should be moved there
            if (Settings.Instance.GameFolder != null && !dirPath.StartsWith(Settings.Instance.GameFolder)) {
                bool moveGame = false;

                if (!Settings.Instance.AutoMoveToGameFolder.HasValue) {
                    var message = "Move the folder \"" + dirPath + "\" to \"" + Settings.Instance.GameFolder + "\"?";

                    using (var messageBox = new CustomMessageBox(message, "Move folder")) {
                        this.InvokeIfRequired(() => messageBox.ShowDialog(this));
                        moveGame = messageBox.Result == CustomMessageBox.MessageBoxResult.Yes;

                        if (messageBox.DontAskAgainChecked) {
                            Settings.Instance.AutoMoveToGameFolder = moveGame;
                        }
                    }
                }
                else {
                    moveGame = Settings.Instance.AutoMoveToGameFolder.Value;
                }

                //If the user is trying to move a system folder, abort
                if (moveGame && new DirectoryInfo(dirPath).IsSpecialFolder()) {
                    var message = "Failed to move folder " + dirPath + ". Permission denied";
                    MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (moveGame) {
                    StatusBarText = "Moving...";

                    try {
                        game.Path = Path.Combine(IOUtility.MoveOrCopy(dirPath, Settings.Instance.GameFolder), relPath);
                    }
                    catch (Exception ex) {
                        Logger.LogException(ex);
                        MessageBox.Show(this, String.Format("Failed to move {0} to {1}. See {2} for details", dirPath, Settings.Instance.GameFolder, Settings.RelativeLogPath),
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally {
                        StatusBarText = "";
                    }
                }
            }
        }

        /// <summary>
        /// Executes the string in the specified game's path.
        /// </summary>
        private void RunGame(Game game) {
            if (String.IsNullOrEmpty(game.Path)) {
                MessageBox.Show(this, game.ToString() + " has no path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!File.Exists(game.Path)) {
				if (Directory.Exists(game.Path)){
					Process.Start(Settings.Instance.FileManagerPath, string.Format(Settings.Instance.FileManagerArgs, game.Path));
				}
				else {
					MessageBox.Show(this, game.ToString() + "'s path is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
            }
            else {
                var gameProcessInfo = new ProcessStartInfo();
                var translatorProcessInfo = new ProcessStartInfo();
                var resolutionChanged = false;
                var screenResolution = game.UseCustomResolution ? game.CustomResolution : Settings.Instance.DefaultResolution;

                //Only change resolution by default when launching executable files
                if (!game.UseCustomResolution && Path.GetExtension(game.Path).ToLower() != ".exe") {
                    screenResolution = null;
                }

                //Check if the game should be run with AGTH and a translator or alone
                if (!String.IsNullOrWhiteSpace(Settings.Instance.AgthPath) && (game.RunWithAgth.HasValue ? game.RunWithAgth.Value : Settings.Instance.LaunchGamesWithAgth) && game.Path.EndsWith(".exe")) {
                    gameProcessInfo.FileName = Settings.Instance.AgthPath;
                    translatorProcessInfo.FileName = Settings.Instance.TranslatorPath;

                    if (!File.Exists(gameProcessInfo.FileName)) {
                        MessageBox.Show(this, "AGTH path invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!String.IsNullOrWhiteSpace(translatorProcessInfo.FileName) && !File.Exists(translatorProcessInfo.FileName)) {
                        MessageBox.Show(this, "Translator path invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (game.AgthParameters == null) {
                        gameProcessInfo.Arguments = Settings.Instance.AgthDefaultParameters;

                        if (Settings.Instance.UseHCodeForWolfGames && game.WolfRpgMakerVersion != null) {
                            if (game.WolfRpgMakerVersion == "Unknown") {
                                game.WolfRpgMakerVersion = IOUtility.GetWolfRpgVersion(game.Path);
                            }
                            
                            if (game.WolfRpgMakerVersion != null) {
                                gameProcessInfo.Arguments += " " + IOUtility.GetWolfRpgAgthParams(game.WolfRpgMakerVersion);
                            }
                        }
                    }
                    else {
                        gameProcessInfo.Arguments = game.AgthParameters;
                    }

                    gameProcessInfo.Arguments += " \"" + game.Path + '"';
                }
                else if (!String.IsNullOrWhiteSpace(Settings.Instance.ChiiTransPath) && (game.RunWithChiiTrans.HasValue ? game.RunWithChiiTrans.Value : Settings.Instance.LaunchGamesWithChiiTrans) && game.Path.EndsWith(".exe"))
                {
                    gameProcessInfo.FileName = Settings.Instance.ChiiTransPath;
                    translatorProcessInfo.FileName = game.Path; //Settings.Instance.TranslatorPath;

                    if (!File.Exists(gameProcessInfo.FileName))
                    {
                        MessageBox.Show(this, "ChiiTrans path invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!String.IsNullOrWhiteSpace(translatorProcessInfo.FileName) && !File.Exists(translatorProcessInfo.FileName))
                    {
                        MessageBox.Show(this, "Translator path invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    /*
                    if (game.AgthParameters == null)
                    {
                        gameProcessInfo.Arguments = Settings.Instance.AgthDefaultParameters;

                        if (Settings.Instance.UseHCodeForWolfGames && game.WolfRpgMakerVersion != null)
                        {
                            if (game.WolfRpgMakerVersion == "Unknown")
                            {
                                game.WolfRpgMakerVersion = IOUtility.GetWolfRpgVersion(game.Path);
                            }

                            if (game.WolfRpgMakerVersion != null)
                            {
                                gameProcessInfo.Arguments += " " + IOUtility.GetWolfRpgAgthParams(game.WolfRpgMakerVersion);
                            }
                        }
                    }
                    else
                    {
                        gameProcessInfo.Arguments = game.AgthParameters;
                    }
                    */
                    gameProcessInfo.Arguments += " \"" + game.Path + '"';
                }
                else {
                    gameProcessInfo.FileName = game.Path;
                }

                gameProcessInfo.WorkingDirectory = Path.GetDirectoryName(game.Path);

                //Change screen resolution if requested
                if (screenResolution != null) {
                    try {
                        ScreenUtility.ChangeResolution(screenResolution);
                        resolutionChanged = true;
                    }
                    catch (ScreenUtility.ResolutionChangeFailedException ex) {
                        ScreenUtility.RestoreInitialResolution();
                        Logger.LogException(ex);
                        StatusBarText = "Failed to change screen resolution";
                    }
                }

                Process gameProcess = null;
                Process translatorProcess = null;

                //Start translator process
                if (!String.IsNullOrWhiteSpace(translatorProcessInfo.FileName)) {
                    translatorProcessInfo.WorkingDirectory = Path.GetDirectoryName(translatorProcessInfo.FileName);

                    try {
                        translatorProcess = Process.Start(translatorProcessInfo);
                    }
                    catch (Win32Exception e) {
                        Logger.LogException(e);
                    }
                }

                //Start game process
                try {
                    gameProcess = Process.Start(gameProcessInfo);
                }
                catch (Win32Exception e) {
                    Logger.LogException(e);
                    StatusBarText = "Failed to start process " + Path.GetFileName(gameProcessInfo.FileName);
                }

                if (gameProcess != null) {
                    game.LastPlayedDate = DateTime.Now;
                    game.TimesPlayed++;
                    game.Save();

                    try {
                        //This throws an exception if we are not allowed to handle process events
                        gameProcess.EnableRaisingEvents = true;

                        //Update time played and exit the translator when the user quits the game
                        gameProcess.Exited += new EventHandler((sender2, e2) => {
                            if (Settings.Instance.AutoExitTranslator && translatorProcess != null && !translatorProcess.HasExited) {
                                translatorProcess.CloseMainWindow();
                            }

                            if (resolutionChanged) {
                                ScreenUtility.RestoreInitialResolution();
                            }

                            game.LastPlayedDate = DateTime.Now;
                            var timePlayed = game.LastPlayedDate.Value - gameProcess.StartTime;
                            game.TimePlayed = game.TimePlayed.Add(new TimeSpan(timePlayed.Days, timePlayed.Hours, timePlayed.Minutes, timePlayed.Seconds));
                            game.Save();
                        });
                    }
                    catch (Exception) {
                        //Ignore this exception
                    }
                }
            }
        }

        /// <summary>
        /// Decrypts an RPG maker archive asynchronously.
        /// </summary>
        private Task DecryptRpgMakerArchiveAsync(string archivePath) {
            int filesExtracted = 0;

            var extractor = Task.Factory.StartNew(() => {
                var archive = new RPGMakerArchive(archivePath);
                float size = archive.Size;

                RPGMakerArchive.ProgressReporter reportProgress = (path, progress) => {
                    StatusBarText = String.Format("({1}%) {0}...", path, (int)(progress / size * 100));
                };

                filesExtracted = archive.Extract(Path.GetDirectoryName(archivePath), CancellationToken.None, reportProgress);
            });

            extractor.ContinueWith(task => Invoke(new MethodInvoker(() => {
                PostExtractionAction action;
                StatusBarText = filesExtracted + " files extracted from \"" + 
                                new DirectoryInfo(Path.GetDirectoryName(archivePath)).Name + 
                                Path.DirectorySeparatorChar + Path.GetFileName(archivePath) + "\".";

                if (Settings.Instance.PostCgExtractionAction == PostExtractionAction.Ask) {
                    var message = "Delete the successfully extracted archive \"" + archivePath + "\"?\nThe game will still run after the archive is deleted.";

                    using (var dialog = new PostExtractionMessageBox(message, "Delete or rename archive")) {
                        dialog.ShowDialog(this);
                        action = dialog.Result;

                        if (dialog.DontAskAgainChecked) {
                            Settings.Instance.PostCgExtractionAction = action;
                        }
                    }
                }
                else {
                    action = Settings.Instance.PostCgExtractionAction;
                }

                if (action == PostExtractionAction.Delete) {
                    try {
                        File.Delete(archivePath);
                    }
                    catch (Exception e) {
                        Logger.LogException(e);
                        StatusBarText = "Failed to delete the successfully extracted archive.";
                    }
                }
                else if (action == PostExtractionAction.Rename) {
                    try {
                        File.Move(archivePath, Path.Combine(Path.GetDirectoryName(archivePath),
                                                            "unused" + Path.GetFileName(archivePath)));
                    }
                    catch (Exception e) {
                        Logger.LogException(e);
                        StatusBarText = "Failed to rename the successfully extracted archive.";
                    }
                }
            })), TaskContinuationOptions.OnlyOnRanToCompletion);

            extractor.ContinueWith(task => Invoke(new MethodInvoker(() => {
                StatusBarText = "";

                if (task.Exception.InnerException is ArgumentException) {
                    MessageBox.Show(this, task.Exception.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    Logger.LogException(task.Exception.InnerException);
                    MessageBox.Show(this, "Failed to decrypt " + archivePath + ". See " + Settings.RelativeLogPath + " for details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            })), TaskContinuationOptions.OnlyOnFaulted);

            return extractor;
        }

        /// <summary>
        /// Opens the arc_conv program to decrypt a Wolf RPG maker archive asynchronously.
        /// </summary>
        private Task DecryptWolfArchiveAsync(string archivePath) {
            var tcs = new TaskCompletionSource<string>();

            if (File.Exists(archivePath)) {
                if (!File.Exists(arcConvPath) || !arcConvCreated) {
                    File.WriteAllBytes(arcConvPath, Properties.Resources.arc_conv);
                    arcConvCreated = true;
                }

                StatusBarText = "Launching arc_conv...";
                var arcConv = Process.Start(arcConvPath, '"' + archivePath + '"');

                try {
                    arcConv.EnableRaisingEvents = true;

                    arcConv.Exited += (sender, e) => {
                        if (Directory.Exists(archivePath + "~")) {
                            StatusBarText = "Archive successfully extracted to " + archivePath + "~";
                            tcs.SetResult(archivePath + "~");
                        }
                        else {
                            StatusBarText = "No files extracted";
                            tcs.SetResult(null);
                        }
                    };
                }
                catch (Exception) {
                    tcs.SetResult(null);
                }
            }
            else {
                tcs.SetResult(null);
            }
            return tcs.Task;
        }

        /// <summary>
        /// Updates the the second split container panel with the currently selected game.
        /// </summary>
        private void UpdateRightPanel() {
            gameEditControl.SetGame((Game)gameList.SelectedObject);
        }

        #region Event handlers
        //Called when a game is saved
        private void game_Saved(object sender, EventArgs e) {
            /*TODO: Find a way to only refresh the row containing the updated game
              The problem with only refreshing one row, is that several rows must be refreshed if a circle name has changed*/
            this.InvokeIfRequired(() => gameList.BuildList(true));
        }

        private void MainForm_Load(object sender, EventArgs e) {
            //The recorded splitter distance must be set after the constructor has run to circumvent an annoying .NET 'bug'
            if (Settings.Instance.GameListWidth >= splitContainer.Panel1MinSize && Settings.Instance.GameListWidth <= splitContainer.Width - splitContainer.Panel2MinSize) {
                splitContainer.SplitterDistance = Settings.Instance.GameListWidth;
            }
            else {
                splitContainer.SplitterDistance = (int)(Width / 1.58);
            }
        }

        //Called when the program is exited
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
            if (Settings.Instance.RevertResolutionOnExit) {
                ScreenUtility.RestoreInitialResolution();
            }

            //Save the current placement of the main form
            var placement = new WINDOWPLACEMENT();
            placement.length = Marshal.SizeOf(placement.GetType());
            GetWindowPlacement(Handle, out placement);
            Settings.Instance.WindowPlacement = placement;
            Settings.Instance.WindowPlacementSaved = true;

            //Save the current layout of the game list
            Settings.Instance.ListState = gameList.SaveState();
            Settings.Instance.GameListWidth = splitContainer.SplitterDistance;
            Settings.Instance.Save();

            //Try to delete arc_conv if it was ever created
            if (File.Exists(arcConvPath)) {
                try {
                    File.Delete(arcConvPath);
                }
                catch (Exception) { }
            }

            if (File.Exists(IOUtility.UnrarPath)) {
                try {
                    File.Delete(IOUtility.UnrarPath);
                }
                catch (Exception) { }
            }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e) {
            var files = new List<string>();
            var directories = new List<string>();
            var archives = new List<string>();
            var games = new List<Game>();
			bool txtFlag = false;
			var rjcodes = gameList.Objects.Cast<Game>().Select(game => game.RJCode).ToList();

            foreach (string path in (string[])e.Data.GetData(DataFormats.FileDrop)) {
                if (IOUtility.IsArchive(path)) {
                    archives.Add(path);
                }
                else if (Directory.Exists(path)) {
                    directories.Add(path);
                }
                else if (File.Exists(path)) {
                    files.Add(path);
                }
            }

            if (files.Count == 1 && directories.Count + archives.Count == 0) {
				if (files[0].ToLower().EndsWith(".txt")) {
					string text = File.ReadAllText(files[0]);
					var list = IOUtility.ExtractAllRJCodes(text);
					foreach (var rjcode in list) {
						if (!String.IsNullOrEmpty(rjcode) && !rjcodes.Contains(rjcode)) {
							games.Add(new Game() {RJCode = rjcode,});
							rjcodes.Add(rjcode);
						}						
					}
					txtFlag = true;					
				}
				else {
					var game = new Game { Path = files[0] };
					game.RJCode = IOUtility.FindRJCode(game.Path);
					MoveGameIfRequired(game);

					var downloader = DownloadGameInfoAsync(game, true, true, s => StatusBarText = s);

					downloader.ContinueWith(_ => {
						game.Save();
						game.SaveImages();
						AddGame(game);
						StatusBarText = Path.GetFileNameWithoutExtension(game.Path) + " successfully added.";
					});
					
					return;					
				}
				
            }

            if (files.Count > 0 && !txtFlag) {
                foreach (var path in files) {
                    games.Add(new Game() {
                        RJCode = IOUtility.FindRJCode(path),
                        Path = path,
                    });
                }
            }

            var gameScanner = Task.Factory.StartNew(() => {
                if (directories.Count > 0) {
                    Action<string> onAccessDenied = path => Invoke(new MethodInvoker(() => StatusBarText = "Access to " + path + " denied. This folder will not be scanned..."));

                    StatusBarText = "Scanning for works...";
                    var gamesFound = IOUtility.FindGames(directories, CancellationToken.None, null, onAccessDenied);
                    StatusBarText = "";

                    foreach (var game in gamesFound) {
                        game.RJCode = IOUtility.FindRJCode(game.Path);
                    }

                    //If the dropped directory only contains one game, ask the user if it should be moved
                    if (games.Count == 0 && gamesFound.Count() == 1) {
                        MoveGameIfRequired(gamesFound.First());
                    }
                    games.AddRange(gamesFound);
                }
            });

            //Extracts all the archive paths in the drop source
            //The archives will not be extracted in parallel
            Action extractArchives = () => {
                var downloadCanceller = new CancellationTokenSource();
                int gamesAdded = 0;

                for (int i = 0; i < archives.Count; i++) {
                    ExtractGameAsync(archives[i]).ContinueWith(gameExtractor => {
                        if (gameExtractor.Result != null) {
                            //Let the success message display for 1.5 seconds
                            Thread.Sleep(1500);
                            var downloader = DownloadGameInfoAsync(gameExtractor.Result, true, true, s => StatusBarText = s, downloadCanceller);

                            downloader.ContinueWith(_ => {
                                gameExtractor.Result.Save();
                                gameExtractor.Result.SaveImages();
                                AddGame(gameExtractor.Result);
                            });

                            gamesAdded++;
                            downloader.Wait();
                        }
                    }, TaskContinuationOptions.OnlyOnRanToCompletion).Wait();

                    //If the download was cancelled, an error has occurred
                    if (downloadCanceller.IsCancellationRequested && i != archives.Count - 1) {
                        DialogResult result = DialogResult.No;
                        this.InvokeIfRequired(() => result = MessageBox.Show(this, "Continue extracting?", "Download error", MessageBoxButtons.YesNo, MessageBoxIcon.Question));

                        if (result != DialogResult.Yes) {
                            break;
                        }
                    }
                }

                if (gamesAdded > 0) {
                    StatusBarText = String.Format("{0} {1} successfully extracted and added.", gamesAdded, "game" + (gamesAdded > 1 ? "s" : ""));
                }
            };

            gameScanner.ContinueWith(x => {
                if (games.Count > 0) {
                    StatusBarText = "Adding games...";
                    var gameArray = games.ToArray();
                    var downloaders = DownloadGameInfoAsync(gameArray, str => StatusBarText = str, new CancellationTokenSource());

                    for (int i = 0; i < downloaders.Length; i++) {
                        downloaders[i] = downloaders[i].ContinueWith(task => {
                            var game = task.Result;
                            game.Save();
                            game.SaveImages();

                            //Unload the recently saved images from memory
                            if (game.Images != null) {
                                foreach (var image in game.Images) {
                                    image.UnloadImageData();
                                }
                            }
                            return game;
                        });
                    }

                    Task.Factory.ContinueWhenAll(downloaders, _ => {
                        AddGames(gameArray);
                        StatusBarText = gameArray.Length + " games successfully added.";
                        Thread.Sleep(1500);
                        extractArchives();
                    });
                }
                else {
                    Task.Factory.StartNew(extractArchives);
                }
            });
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.F5) {
                Rebuild();
            }
        }

        //Called when a game is clicked
        private void gameList_SelectionChanged(object sender, EventArgs e) {
            UpdateRightPanel();
        }

        private void gameList_CellClick(object sender, CellClickEventArgs e) {
            //Check if a row containing a game was double clicked
            if (e.ClickCount == 2 && gameList.SelectedObject != null && Settings.Instance.DoubleClickGameToRun) {
                //On some systems one click invokes this function multiple times
                //The double-click-to-run setting is disabled to prevent creating more than one process
                Settings.Instance.DoubleClickGameToRun = false;
                RunGame((Game)gameList.SelectedObject);
                Settings.Instance.DoubleClickGameToRun = true;
            }
        }

		private void gameList_CellEditStarting(object sender, CellEditEventArgs	e) {
			// Ignore edit events for other columns
			if (e.Column != this.ratingColumn) {
				return;
			}
			Game game = (Game)e.RowObject;
			RatingEditor cb = new RatingEditor();
			cb.Bounds = e.ListViewItem.GetSubItemBounds(e.SubItemIndex);
			cb.Top += (int)(0.5 * e.ListViewItem.GetSubItemBounds(e.SubItemIndex).Height - 0.5 * cb.Height);
			cb.SelectedRating = game.Rating;
            cb.SelectedIndexChanged += delegate(object o, EventArgs args) {
                game.Rating = cb.SelectedRating;
				game.Save();
				gameEditControl.SetGame(game);
            };
			e.Control = cb;
		}

		private void gameList_CellEditFinishing(object sender, CellEditEventArgs e) {
			((ObjectListView)sender).RefreshItem(e.ListViewItem);
			e.Cancel = true;
		}
		
        //Called when the user drags the border of the main form
        private void gameList_SizeChanged(object sender, EventArgs e) {
            //Repaint the split container when the list is resized to prevent the draggable bar from disappearing
            splitContainer.Invalidate();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e) {
            var oldTileSize = Settings.Instance.ImageSizeInTile;

            using (var settingsDialog = new SettingsForm()) {
                settingsDialog.ShowDialog(this);
                Rebuild();
            }
        }

        private void extractCgGameToolStripMenuItem_Click(object sender, EventArgs e) {
            var result = extractionFileDialog.ShowDialog();

            if (result == DialogResult.OK) {
                var extension = Path.GetExtension(extractionFileDialog.FileName).ToLower();

                if (extension == ".rgssad" || extension == ".rgss2a" || extension == ".rgss3a") {
                    DecryptRpgMakerArchiveAsync(extractionFileDialog.FileName);
                }
                else {
                    DecryptWolfArchiveAsync(extractionFileDialog.FileName);
                }
            }
        }

        private void findDuplicatesToolStripMenuItem_Click(object sender, EventArgs e) {
            var dupeDetector = new DupeDetectionForm();

            if (dupeDetector.DupeCount > 0) {
                dupeDetector.Location = new Point(Location.X + (Width - dupeDetector.Width) / 2, Location.Y + (Height - dupeDetector.Height) / 2);
                dupeDetector.Show(this);
            }
            else {
                MessageBox.Show(this, "No duplicate works found!", "Dupe Detection Tool", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void addGameToolStripMenuItem_Click(object sender, EventArgs e) {
            var result = addGameDialog.ShowDialog();

            if (result == DialogResult.OK) {
                if (IOUtility.IsArchive(addGameDialog.FileName)) {
                    ExtractGameAsync(addGameDialog.FileName).ContinueWith(gameExtractor => {
                        //Give the success message 1.5 seconds to display
                        Thread.Sleep(1500);

                        if (gameExtractor.Result != null) {
                            var downloader = DownloadGameInfoAsync(gameExtractor.Result, true, true, s => StatusBarText = s);

                            downloader.ContinueWith(_ => {
                                gameExtractor.Result.Save();
                                gameExtractor.Result.SaveImages();
                                AddGame(gameExtractor.Result);
                            }).ContinueWith(task => StatusBarText = "1 game successfully extracted and added.");
                        }
                    }, TaskContinuationOptions.OnlyOnRanToCompletion);
                }
                else {
                    var game = new Game { Path = addGameDialog.FileName };
					game.RJCode = IOUtility.FindRJCode(game.Path);
                    MoveGameIfRequired(game);

                    var downloader = DownloadGameInfoAsync(game, true, true, s => StatusBarText = s);

                    downloader.ContinueWith(_ => {
                        game.Save();
                        game.SaveImages();
                        AddGame(game);
                        StatusBarText = Path.GetFileNameWithoutExtension(game.Path) + " successfully added.";
                    });
                }
            }
        }

        private void addGamesToolStripMenuItem_Click(object sender, EventArgs e) {
            using (var gameScanner = new GameScannerForm(gameList.Objects.Cast<Game>().Select(game => game.Path))) {
                gameScanner.FormClosing += (sender2, e2) => {
                    if (gameScanner.DialogResult == DialogResult.OK) {
                        var games = gameScanner.GamesFound.Objects.Cast<Game>().ToArray();

                        if (games.Length > 0) {
                            StatusBarText = "Adding games...";
                            var downloaders = DownloadGameInfoAsync(games, str => StatusBarText = str, new CancellationTokenSource());
                            
                            for (int i = 0; i < downloaders.Length; i++) {
                                downloaders[i] = downloaders[i].ContinueWith(task => {
                                    var game = task.Result;
                                    game.Save();
                                    game.SaveImages();

                                    if (game.Images != null) {
                                        foreach (var image in game.Images) {
                                            image.UnloadImageData();
                                        }
                                    }
                                    return game;
                                });
                            }

                            Task.Factory.ContinueWhenAll(downloaders, _ => {
                                AddGames(games);
                                StatusBarText = games.Length + " games successfully added.";
                            });
                        }
                    }
                };

                gameScanner.ShowDialog(this);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            using (var about = new AboutDialog()) {
                about.ShowDialog(this);
            }
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e) {
            double totalSize = 0;
            string sizeUnit = "MB";
            int gamesPlayed = 0;
            TimeSpan timePlayed = new TimeSpan();

            foreach (Game game in Game.GetGames()) {
                totalSize += (game.Size.HasValue ? game.Size.Value : 0);

                if (game.TimePlayed.TotalSeconds > 0) {
                    timePlayed += game.TimePlayed;
                    gamesPlayed++;
                }
            }

            if (totalSize >= 1024) {
                totalSize /= 1024;
                sizeUnit = "GB";
            }

            if (totalSize >= 1024) {
                totalSize /= 1024;
                sizeUnit = "TB";
            }

            string text = String.Format("Number of works: {0}\n" +
                                        "Size of works: {1:0.00} {2}\n" +
                                        "Games played: {3}\n" +
                                        "Time played: {4} hours and {5} minutes",
                                        Game.GetGames().Count, totalSize, sizeUnit, gamesPlayed,
                                        (timePlayed.TotalDays > 1 ? timePlayed.Days + " days, " : "") + timePlayed.Hours,
                                        timePlayed.Minutes);

            MessageBox.Show(this, text, "Statistics", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e) {
            int selectedItemsCount = gameList.SelectedItems.Count;

            if (selectedItemsCount < 1) {
                e.Cancel = true;
            }
            else {
                Game selectedGame = (Game)gameList.SelectedObjects[0];

                filterOnCircleToolStripMenuItem.Visible = selectedItemsCount == 1;
                openEngDLSiteToolStripMenuItem.Visible = selectedItemsCount == 1;
                openJpDLSiteToolStripMenuItem.Visible = selectedItemsCount == 1;
				openHVDBToolStripMenuItem.Visible = selectedItemsCount == 1;
                runToolStripMenuItem.Visible = selectedItemsCount == 1;
                openInExplorerMenuItem.Visible = selectedItemsCount == 1;
                propertiesToolStripMenuItem.Visible = selectedItemsCount == 1;
                toolStripSeparator1.Visible = selectedItemsCount == 1;
                toolStripSeparator2.Visible = selectedItemsCount == 1;
                toolStripSeparator3.Visible = selectedItemsCount == 1;
                toolStripSeparator4.Visible = selectedItemsCount == 1;
                toolStripSeparator6.Visible = selectedItemsCount == 1;

                filterOnCircleToolStripMenuItem.Enabled = selectedGame.Author != null;
                openEngDLSiteToolStripMenuItem.Enabled = selectedGame.RJCode != null && selectedGame.IsOnEnglishDLSite;
                openJpDLSiteToolStripMenuItem.Enabled = selectedGame.RJCode != null && selectedGame.IsOnJapaneseDLSite;
				openHVDBToolStripMenuItem.Enabled = selectedGame.RJCode != null && selectedGame.IsOnHVDB;
                extractCgToolStripMenuItem.Enabled = selectedGame.IsRpgMakerGame || selectedGame.WolfRpgMakerVersion != null;

                if (selectedGame.Author != null && selectedGame.Author.Name == searchBar.SearchBox.Text) {
                    filterOnCircleToolStripMenuItem.Text = "Unfilter on circle";
                }
                else {
                    filterOnCircleToolStripMenuItem.Text = "Filter on circle";
                }
            }
         }

        private void runToolStripMenuItem_Click(object sender, EventArgs e) {
            if (gameList.SelectedObject != null) {
                RunGame((Game)gameList.SelectedObject);
            }
        }

        private void openInExplorerMenuItem_Click(object sender, EventArgs e) {
            var game = gameList.SelectedObject as Game;

            if (game != null) {
				var dirPath = game.Path;
				if (File.Exists(dirPath)) {
					dirPath = System.IO.Path.GetDirectoryName(dirPath);
				}

                if (!Directory.Exists(dirPath)) {
                    MessageBox.Show(this, game.ToString() + "'s path is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
					Process.Start(Settings.Instance.FileManagerPath, string.Format(Settings.Instance.FileManagerArgs, dirPath));
                }
            }
        }

        private void OpenWebPage(string url) {
            try {
                Cursor = Cursors.AppStarting;
                Process.Start(url);
            }
            catch (Exception e) {
                Logger.LogException(e);
            }
            finally {
                Cursor = null;
            }
        }

        private void openEngDLSiteToolStripMenuItem_Click(object sender, EventArgs e) {
            var selectedGame = gameList.SelectedObject as Game;

            if (selectedGame != null && selectedGame.RJCode != null && selectedGame.IsOnEnglishDLSite) {
                var page = new EnglishDLSitePage(selectedGame.RJCode);
                page.ReleasePageExists = selectedGame.IsReleasedOnEnglishDLSite;
                OpenWebPage(page.Url);
            }
        }

        private void openJpDLSiteToolStripMenuItem_Click(object sender, EventArgs e) {
            var selectedGame = gameList.SelectedObject as Game;

            if (selectedGame != null && selectedGame.RJCode != null && selectedGame.IsOnJapaneseDLSite) {
                var page = new JapaneseDLSitePage(selectedGame.RJCode);
                page.ReleasePageExists = selectedGame.IsReleasedOnJapaneseDLSite;
                OpenWebPage(page.Url);
            }
        }

        private void openHVDBToolStripMenuItem_Click(object sender, EventArgs e) {
            var selectedGame = gameList.SelectedObject as Game;

            if (selectedGame != null && selectedGame.RJCode != null && selectedGame.IsOnHVDB) {
                //var page = new JapaneseDLSitePage(selectedGame.RJCode);
                //page.ReleasePageExists = selectedGame.IsReleasedOnJapaneseDLSite;
                OpenWebPage("http://hvdb.me/Dashboard/Details/" + selectedGame.RJCode.RemoveNonDigits());
            }
        }

        private void filterOnCircleToolStripMenuItem_Click(object sender, EventArgs e) {
            var selectedGame = gameList.SelectedObject as Game;

            if (selectedGame != null && selectedGame.Author != null && selectedGame.Author.Name != null) {
                if (searchBar.SearchBox.Text != selectedGame.Author.Name) {
                    searchBar.Visible = true;
                    searchBar.SearchBox.Text = selectedGame.Author.Name;
                    gameList.Focus();
                }
                else {
                    searchBar.Visible = false;
                }
            }
        }

        private void translateToolStripMenuItem_Click(object sender, EventArgs e) {
            var selectedGames = gameList.SelectedObjects.Cast<Game>();
            var tasks = new List<Task>();

            foreach (var g in selectedGames) {
                var game = g;
                var task = game.TranslateTitleAndTags();

                tasks.Add(task);

                task.ContinueWith(_ => {
                    game.Save(false);
                });
            }

            if (tasks.Count > 0) {
                StatusBarText = "Translating text...";

                //Refresh the list and scroll to the first translated item when the translation is complete
                Task.Factory.ContinueWhenAll(tasks.ToArray(), _ => {
                    StatusBarText = "";

                    this.InvokeIfRequired(() => {
                        gameList.BuildList(true);

                        if (gameList.SelectedObjects.Count > 0) {
                            gameList.EnsureModelVisible(gameList.SelectedObjects[0]);
                        }
                    });
                });
            }
        }

        private void updatePathToolStripMenuItem_Click(object sender, EventArgs e) {
            var selectedGames = gameList.SelectedObjects.Cast<Game>();
			foreach (var game in selectedGames) {
				IOUtility.UpdatePath(game);
			}
			StatusBarText = "Path update finished";
        }

        private void renameWorksFolderToolStripMenuItem_Click(object sender, EventArgs e) {
            var selectedGames = gameList.SelectedObjects.Cast<Game>();
			foreach (var game in selectedGames) {
				IOUtility.RenameWorksFolder(game);
			}
			StatusBarText = "Renaming finished";
        }

        private void downloadInfoToolStripMenuItem_Click(object sender, EventArgs e) {
			StatusBarText = "";
			gameEditControl.SetGame(null);			
            var selectedGames = gameList.SelectedObjects.Cast<Game>();
			foreach (var game in selectedGames) {
				if (!String.IsNullOrWhiteSpace(game.RJCode)) {
					game.DeleteImages();
					game.DownloadInfo(true, null, new CancellationToken?());
					game.Save();
					game.SaveImages();
				}
			}
			StatusBarText = selectedGames.Count().ToString() + " works info successfully downloaded.";
			if (selectedGames.Count() == 1) {
				gameEditControl.SetGame(selectedGames.First());
			}			
       }
		
        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e) {
            var selectedGame = gameList.SelectedObject as Game;

            if (selectedGame != null) {
                using (var properties = new GamePropertiesForm(selectedGame)) {
                    properties.ShowDialog(this);
                }
            }
        }

        private void extractCgToolStripMenuItem_Click(object sender, EventArgs e) {
            var selectedObjects = gameList.SelectedObjects.Cast<Game>().ToArray();

            if (selectedObjects.Length > 0) {
                Task.Factory.StartNew(() => {
                    foreach (var game in selectedObjects) {
                        if (!game.IsRpgMakerGame && game.WolfRpgMakerVersion == null) {
                            continue;
                        }
                        if (game.Path == null) {
                            BeginInvoke(new MethodInvoker(() => MessageBox.Show(this, game.ToString() + " does not have a path.",
                                                                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)));
                        }
                        else {
                            string archivePath = null;
                            bool archiveIsRpgMaker = false;
                            string gameFolder = Path.GetDirectoryName(game.Path);

                            if (Directory.Exists(gameFolder)) {
                                foreach (string file in IOUtility.EnumerateFilesSafely(gameFolder, "*", SearchOption.AllDirectories)) {
                                    string name = Path.GetFileName(file).ToLower();
                                    string extension = Path.GetExtension(file).ToLower();

                                    if (extension == ".rgssad" || extension == ".rgss2a" || extension == ".rgss3a") {
                                        archivePath = file;
                                        archiveIsRpgMaker = true;
                                        break;
                                    }
                                    else if (name == "data.wolf" || name == "evcg.wolf") {
                                        archivePath = file;
                                        break;
                                    }
                                }
                            }

                            if (archivePath == null) {
                                BeginInvoke(new MethodInvoker(() => MessageBox.Show(this, "No extractable archives found in \"" + gameFolder + "\"",
                                                                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)));
                            }
                            else {
                                if (archiveIsRpgMaker) {
                                    DecryptRpgMakerArchiveAsync(archivePath).Wait();
                                }
                                else {
                                    DecryptWolfArchiveAsync(archivePath).Wait();
                                }
                                Thread.Sleep(3000);
                            }
                        }
                    }
                });
            }
        }

        private void removeFromListToolStripMenuItem_Click(object sender, EventArgs e) {
            string msgText = null;
            var selectedObjects = gameList.SelectedObjects.Cast<Game>().ToArray();

            if (selectedObjects.Length < 1) {
                return;
            }
            else if (selectedObjects.Length == 1) {
                var gameTitle = selectedObjects[0].Title;

                msgText = String.Format("Really delete {0} and all of its images?", String.IsNullOrWhiteSpace(gameTitle) ? "the selected game" : gameTitle);
            }
            else {
                msgText = String.Format("Really delete {0} games and all of their images?", selectedObjects.Length);
            }

            if (MessageBox.Show(this, msgText, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                DeleteGames(selectedObjects);
            }
        }

        private void removeFromDiskToolStripMenuItem_Click(object sender, EventArgs e) {
            var selectedObjects = gameList.SelectedObjects;

            if (selectedObjects.Count > 0) {
                var gamesToDelete = new List<Game>(selectedObjects.Count);

                foreach (var game in selectedObjects) {
					string path = IOUtility.GetWorksFolderFromPath(((Game)game).Path, ((Game)game).RJCode);

                    bool folderDeleted = IOUtility.DeleteFolder(path);

                    if (folderDeleted) {
                        gamesToDelete.Add((Game)game);
                    }
                }

                if (gamesToDelete.Count > 0) {
                    DeleteGames(gamesToDelete.ToArray());
                }
            }
        }

        private void gameList_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                if (gameList.SelectedObject != null) {
                    RunGame((Game)gameList.SelectedObject);
                }
            }
            else {
                string keyCode = new KeysConverter().ConvertToString(e.KeyCode);

                //If the user pressed a character on the keyboard, select and display the first game title that begins with that character
                if (keyCode.Length == 1) {
                    //The matching games are sorted by the order in which they are displayed to the user
                    var matchingItems = new SortedList<int, OLVListItem>();

                    foreach (OLVListItem item in gameList.Items) {
                        var game = (Game)item.RowObject;

                        if (!String.IsNullOrEmpty(game.Title) && game.Title[0] == keyCode[0]) {
                            matchingItems.Add(gameList.GetDisplayOrderOfItemIndex(item.Index), item);
                        }
                    }

                    if (matchingItems.Any()) {
                        int selectedIndex = -1;

                        for (int i = 0; i < matchingItems.Count - 1; i++) {
                            if (matchingItems.Values[i].Selected) {
                                selectedIndex = i;
                                break;
                            }
                        }

                        var matchingItem = matchingItems.Values[selectedIndex + 1];
                        gameList.SelectedIndices.Clear();
                        matchingItem.Selected = true;
                        matchingItem.EnsureVisible();
                        e.SuppressKeyPress = true;
                    }
                }
            }
        }

        private void viewSearchBar_Click(object sender, EventArgs e) {
            searchBar.Visible = !searchBar.Visible;
        }

        private void viewDetails_Click(object sender, EventArgs e) {
            if (gameList.View != View.Details) {
                gameList.View = View.Details;
                viewDetails.Checked = true;
                viewTiles.Checked = false;
            }
        }

        private void viewTiles_Click(object sender, EventArgs e) {
            if (gameList.View != View.Tile) {
                gameList.View = View.Tile;
                viewTiles.Checked = true;
                viewDetails.Checked = false;
            }
        }

        private void searchBar_SearchTextChanged(object sender, EventArgs e) {
            FilterList(searchBar.SearchBox.Text);
        }

        //Gives the game list focus and executes hidden commands when the enter key is pressed
        private void searchBar_CommandKeyPressed(object sender, KeyEventArgs e) {
            e.SuppressKeyPress = true;
            gameList.Focus();
			
			switch (searchBar.SearchBox.Text) {
				
				case "/createfiles":
					//Creates a file in each game's directory containing the game's RJCode, title, circle, release date and where it can be found on DLSite
					foreach (var game in Game.GetGames()) {
						if (game.Path != null) {
							string path = game.Path;
							if (File.Exists(path)) {
								path = System.IO.Path.GetDirectoryName(path);
							}
							File.WriteAllText(Path.Combine(path, "Info.txt"),
											  (game.RJCode != null ? game.RJCode : "") +
											  (game.Title != null ? Environment.NewLine + game.Title : "") +
											  (game.Author != null ? Environment.NewLine + game.Author.Name : "") + 
											  (game.ReleaseDate.HasValue ? Environment.NewLine + game.ReleaseDate.Value.ToShortDateString() : "") +
											  (game.IsOnJapaneseDLSite ? Environment.NewLine + new JapaneseDLSitePage(game.RJCode) { ReleasePageExists = game.IsReleasedOnJapaneseDLSite }.Url : "") +
											  (game.IsOnEnglishDLSite ? Environment.NewLine + new EnglishDLSitePage(game.RJCode) { ReleasePageExists = game.IsReleasedOnEnglishDLSite }.Url : ""),
											  System.Text.Encoding.UTF8);
						}
					}
					StatusBarText = "Game information saved to info.txt";
					break;

				case "/deletefiles":
					//Deletes "Info.txt" files in each game's directory
					foreach (var game in Game.GetGames()) {
						if (game.Path != null) {
							string path = game.Path;
							if (File.Exists(path)) {
								path = System.IO.Path.GetDirectoryName(path);
							}
							File.Delete(Path.Combine(path, "Info.txt"));
						}
					}
					StatusBarText = "Deleted all game information files";
					break;
				
				case "/updatepathforall":
					foreach (var game in Game.GetGames()) {
						IOUtility.UpdatePath(game);
					}
					StatusBarText = "Path update finished";
					break;
				
			}
        }

        private void searchBar_VisibleChanged(object sender, EventArgs e) {
            SearchBar bar = (SearchBar)sender;

            if (bar.Visible) {
                bar.SearchBox.Focus();
            }
            else {
                bar.SearchBox.Text = null;
                FilterList(null);
                gameList.Focus();
            }
        }
        #endregion

        #region Custom renderers
        /// <summary>
        /// This renderer is responsible for drawing the image column when the game list is in details view.
        /// </summary>
        private class ImageColumnRenderer : BaseRenderer {
            private Pen BorderPen = new Pen(Color.FromArgb(0x33, 0x33, 0x33));

            public override void Render(Graphics g, Rectangle rect) {
                base.Render(g, rect);

                if (Column.Width > 0) {
                    var gameImage = ((Game)RowObject).ListImage;
                    var imageSize = Settings.Instance.ImageSizeInList;

                    if (Settings.Instance.UseCoverImageAsListImage) {
                        gameImage = ((Game)RowObject).CoverImage;
                    }

                    if (gameImage != null && gameImage.Exists() && gameImage.ImageSize.Width > 0 && gameImage.ImageSize.Height > 0 && imageSize.Width > 0 && imageSize.Height > 0) {
                        var image = gameImage.GetThumbnail(Settings.Instance.ImageSizeInList);
                        var imageRect = new Rectangle(rect.Left + rect.Width / 2 - imageSize.Width / 2,
                                                      rect.Top + rect.Height / 2 - imageSize.Height / 2,
                                                      imageSize.Width, imageSize.Height);
                        g.DrawImageUnscaled(image, imageRect);
                        g.DrawRectangle(BorderPen, imageRect);
                    }
                }
            }
        }

        /// <summary>
        /// This custom renderer is responsible for drawing the object list view when it is in tile view.
        /// </summary>
        private class TileViewRenderer : AbstractRenderer {
            private static Pen BorderPen = new Pen(Color.FromArgb(68, 68, 68));
            private static Font TextFont = new Font("Arial", 8.5f);
            private static Color TextColor = Settings.Instance.TileTextColor;
            private static Brush BackgroundBrush = new SolidBrush(Settings.Instance.TileBackgroundColor);

            private ObjectListView listView;
            private Brush HighlightBrush;

            public TileViewRenderer(ObjectListView listView) {
                this.listView = listView;

                var c = listView.HighlightBackgroundColorOrDefault;
                HighlightBrush = new SolidBrush(Color.FromArgb(140, c.R, c.G, c.B));
            }

            public override bool RenderItem(DrawListViewItemEventArgs e, Graphics g, Rectangle tileBounds, object rowObject) {
                var font = Settings.Instance.ApplyListFontToTiles ? Settings.Instance.ListFont : TextFont;

                if (listView.View == View.Tile) {
                    var game = (Game)rowObject;
                    var imageSize = Settings.Instance.ImageSizeInTile;

                    if (e.Item.Selected) {
                        g.FillRectangle(HighlightBrush, tileBounds);
                    }
                    else {
                        g.FillRectangle(BackgroundBrush, tileBounds);
                    }

                    var listImage = game.ListImage;

                    if (Settings.Instance.UseCoverImageAsListImage) {
                        listImage = game.CoverImage;
                    }

                    //Draw list image
                    if (listImage != null && listImage.Exists() && listImage.ImageSize.Width > 0 && listImage.ImageSize.Height > 0 && imageSize.Width > 0 && imageSize.Height > 0) {
                        var image = listImage.GetThumbnail(imageSize);
                        var imageRect = new Rectangle(tileBounds.Left + tileBounds.Width / 2 - imageSize.Width / 2,
                                                      tileBounds.Top + 5,
                                                      imageSize.Width, imageSize.Height);

                        g.DrawImageUnscaled(image, imageRect);
                        g.DrawRectangle(BorderPen, imageRect);
                    }
                    
                    int titleX = tileBounds.X + (int)(font.Size * (font.Size <= 12 ? 0.4 : 0.3));
                    int titleY = tileBounds.Top + imageSize.Height + (int)(font.Size < 12 ? 16 - font.Size : 8 - font.Size * 0.4);
                    var titlePosition = new Rectangle(titleX, titleY, tileBounds.Width - 4, tileBounds.Height);

                    //Draw title
                    TextRenderer.DrawText(g, game.ToString(), font, titlePosition, TextColor, TextFormatFlags.NoPadding | TextFormatFlags.SingleLine | TextFormatFlags.EndEllipsis);

                    return true;
                }
                return false;
            }
        }
        #endregion

        #region Search filter
        /// <summary>
        /// A custom ObjectListView filter used to filter the list of games based on a search string.
        /// </summary>
        private class GameListFilter : IModelFilter {
            /// <summary>
            /// The form containing references to the list view's columns.
            /// </summary>
            public MainForm Form { set; get; }

            /// <summary>
            /// The list view upon this filter will work.
            /// </summary>
            public ObjectListView ListView { set; get; }

            /// <summary>
            /// The string to filter on.
            /// </summary>
            public string FilterText { set; get; }

            /// <summary>
            /// Matches re, rj, bj or vj followed by zero or more digits as well as the beginning of such a string
            /// </summary>
            private static Regex potentialRjCode = new Regex(@"^(rj|re|vj|bj?)?\d*$", RegexOptions.IgnoreCase);

            /// <summary>
            /// Creates a new filter used to filter the game list.
            /// </summary>
            public GameListFilter(MainForm form, ObjectListView listView) {
                Form = form;
                ListView = listView;
            }

            /// <summary>
            /// Returns true if the specified model object should be shown in the list.
            /// Called by an ObjectListView when it is rebuilt. 
            /// </summary>
            public bool Filter(object modelObject) {
                var game = modelObject as Game;

                if (game == null || Form == null || ListView == null || String.IsNullOrEmpty(FilterText)) {
                    return true;
                }

                //If the filter text is one character and a number, assume the user is searching for a rating
                if (FilterText.Length == 1 && char.GetNumericValue(FilterText[0]) != -1) {
                    return char.GetNumericValue(FilterText[0]) == game.Rating.GetValueOrDefault(10);
                }

                foreach (var column in ListView.AllColumns) {
                    if (column.Searchable) {
                        string cellText = column.GetStringValue(modelObject);

                        if (!String.IsNullOrEmpty(cellText)) {
                            if (column == Form.rjCodeColumn) {
                                if (potentialRjCode.IsMatch(FilterText) && (cellText.ToLower().StartsWith(FilterText.ToLower()) 
                                                                            || cellText.RemoveNonDigits().StartsWith(FilterText.RemoveNonDigits()))) {
                                    return true;
                                }
                            }
                            //If the filter text contains a comma, assume that the user is searching for several tags
                            else if (column == Form.tagsColumn && FilterText.Contains(',')) {
                                var gameTags = cellText.Split(',').Select(tag => tag.Trim());
                                var tagsToFind = FilterText.Split(',').Select(tag => tag.Trim());

                                //Returns true if all tags in the filter text also exist in the model object's tags
                                if (tagsToFind.All(tagToFind => gameTags.Any(tag => tag.Contains(tagToFind, StringComparison.OrdinalIgnoreCase)))) {
                                    return true;
                                }
                            }
                            else if (cellText.Contains(FilterText, StringComparison.OrdinalIgnoreCase)) {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
        }
        #endregion

        [DllImport("user32.dll")]
        private static extern bool SetWindowPlacement(IntPtr hWnd, [In] ref WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll")]
        private static extern bool GetWindowPlacement(IntPtr hWnd, out WINDOWPLACEMENT lpwndpl);
    }
}
