using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace GameManager {
    /// <summary>
    /// A form that allows the user to scan a specific folder for executable files.
    /// The results of this scan can then be directly added to the main form.
    /// </summary>
    public partial class GameScannerForm : Form {
        private List<string> excludedPaths;
        private CancellationTokenSource scanCanceller = new CancellationTokenSource();

        public string StatusMessage {
            get { 
                return statusMessage.Text; 
            }
            private set {
                if (IsHandleCreated) {
                    this.InvokeIfRequired(() => statusMessage.Text = value);
                }
            }
        }

        public string ErrorMessage {
            get {
                return errorMessage.Text;
            }
            private set {
                if (IsHandleCreated) {
                    this.InvokeIfRequired(() => errorMessage.Text = value);
                }
            }
        }

        /// <summary>
        /// Creates a new game scanner form.
        /// </summary>
        /// <param name="pathsToExclude">The paths that should be excluded from the scan</param>
        public GameScannerForm(IEnumerable<string> pathsToExclude = null) {
            InitializeComponent();
            excludedPaths = pathsToExclude != null ? pathsToExclude.ToList() : new List<string>();

            foreach (Control c in Controls) {
                c.Font = Settings.Instance.GlobalFont;
            }

            useGoogleTranslate.Checked = Settings.Instance.UseGoogleTranslateOnTitleAndTags;
            lookForRJCodeInPath.Checked = Settings.Instance.LookForRJCodeInPath;
			lookForRJCodeInNames.Checked = Settings.Instance.LookForRJCodeInNames;
            lookForRJCodeInFile.Checked = Settings.Instance.LookForRJCodeInTextFiles;
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

            rjCodeColumn.AspectToStringConverter = code => String.IsNullOrWhiteSpace((string)code) ? null : "" + code;

            pathColumn.AspectToStringConverter = path => {
                if (path != null) {
                    if (selectedFolderPath.Text != "" && (string)path != selectedFolderPath.Text) {
                        return ((string)(path)).Substring(selectedFolderPath.Text.TrimEnd('/', '\\').Length + 1);
                    }
                    else {
                        return (string)path;
                    }
                }
                return null;
            };

            //Cancel any ongoing scans when the form closes
            FormClosing += (sender, e) => {
                scanCanceller.Cancel();
            };
        }

        /// <summary>
        /// Scans for for executable files in the specified directory paths
        /// </summary>
        public void ScanDirectories(params string[] directories) {
            //Progress to the next tab
            tablessControl.SelectedIndex = 1;

            var gameScanner = Task.Factory.StartNew(() => {
                try {
                    int omittedPaths = 0;
                    IAsyncResult lastOperation = null; //The last list insertion operation
                    Action<string> onAccessDenied = path => ErrorMessage = "Error: Access to " + path + " denied. This folder will not be scanned.";
                    Action<Game> onGameFound = game => lastOperation = BeginInvoke(new MethodInvoker(() => {
                        if (!excludedPaths.Contains(game.Path, StringComparer.InvariantCultureIgnoreCase)) {
                            GamesFound.AddObject(game);
                        }
                        else {
                            ErrorMessage = String.Format("{0} game{1} omitted because {2} already exist{3} in the game list.",
                                                         ++omittedPaths, omittedPaths > 1 ? "s" : "", 
                                                         omittedPaths > 1 ? "they" : "it", omittedPaths > 1 ? "" : "s");
                        }
                    }));

                    StatusMessage = "Scanning for executable files...";

                    IOUtility.FindGames(directories, scanCanceller.Token, onGameFound, onAccessDenied);

                    //Wait for all paths to be inserted into the list
                    if (lastOperation != null) {
                        EndInvoke(lastOperation);
                    }

                    var rjCodesFound = 0;
                    scanCanceller.Token.ThrowIfCancellationRequested();

                    if (lookForRJCodeInPath.Checked || lookForRJCodeInNames.Checked || lookForRJCodeInFile.Checked) {
                        StatusMessage = "Scanning for RJCodes...";

                        //Look for RJCodes
                        foreach (var game in new BrightIdeasSoftware.TypedObjectListView<Game>(GamesFound).Objects) {
                            if (game.RJCode == null) {
                                game.RJCode = IOUtility.FindRJCode(game.Path);
                            }

                            if (game.RJCode != null) {
                                var gameCopy = game;
                                rjCodesFound++;

                                scanCanceller.Token.ThrowIfCancellationRequested();

                                if (IsHandleCreated) {
                                    BeginInvoke(new MethodInvoker(() => GamesFound.RefreshObject(game)));
                                }
                            }
                        }
                    }
                    StatusMessage = String.Format("Found {0} games and {1} RJCodes.", GamesFound.Items.Count, rjCodesFound);
                }
                catch (Exception ex) {
                    if (ex is OperationCanceledException) {
                        throw;
                    }
                    else {
                        Logger.LogException(ex);
                        MessageBox.Show("Scan aborted due to some unknown error. See " + Settings.RelativeLogPath + " for details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }, scanCanceller.Token);

            //Enable the 'add games' button after the scan has completed
            gameScanner.ContinueWith(x => this.InvokeIfRequired(() => addGamesButton.Enabled = GamesFound.Items.Count > 0), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        private void startScanButton_Click(object sender, EventArgs e) {
            if (!Directory.Exists(selectedFolderPath.Text)) {
                MessageBox.Show(selectedFolderPath.Text + " does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (selectedFolderPath.Text.Length == 2) {
                //For some reason, the EnumerateFiles function returns unexpected results if the path is exactly 2 characters (for example 'c:') 
                selectedFolderPath.Text = selectedFolderPath.Text + Path.DirectorySeparatorChar;
            }

            ScanDirectories(selectedFolderPath.Text);

            //Save the previous tab's checkbox values to the database
            Settings.Instance.UseGoogleTranslateOnTitleAndTags = useGoogleTranslate.Checked;
            Settings.Instance.LookForRJCodeInPath = lookForRJCodeInPath.Checked;
			Settings.Instance.LookForRJCodeInNames = lookForRJCodeInNames.Checked;
            Settings.Instance.LookForRJCodeInTextFiles = lookForRJCodeInFile.Checked;
            Settings.Instance.DownloadCoverImage = downloadCoverImage.Checked;
            Settings.Instance.DownloadSampleImages = downloadSampleImages.Checked;
            Settings.Instance.DownloadTags = downloadTags.Checked;
			Settings.Instance.DownloadReviewTags = downloadReviewTags.Checked;
			Settings.Instance.DownloadHVDBInfo = downloadHVDBInfo.Checked;
			Settings.Instance.PreferHVDBEnglishTitle = preferHVDBEnglishTitle.Checked;
			Settings.Instance.FilterCVs = filterCVs.Checked;
			Settings.Instance.AutoSetCategory = autoSetCategory.Checked;
            Settings.Instance.DownloadRating = downloadAverageRating.Checked;
            Settings.Instance.UseAlternativeDLSiteLanguages = useAlternativeDLSiteLanguage.Checked;
            Settings.Instance.AutoDownloadGameInfo = !useNeitherDLSite.Checked;
            Settings.Instance.DLSiteLanguage = useJapaneseDLSite.Checked ? DLSitePage.Language.Japanese : DLSitePage.Language.English;

            if (String.IsNullOrWhiteSpace(Settings.Instance.GameFolder)) {
                Settings.Instance.GameFolder = selectedFolderPath.Text;
            }
        }

        private void selectedFolderPath_TextChanged(object sender, EventArgs e) {
            startScanButton.Enabled = !String.IsNullOrWhiteSpace(selectedFolderPath.Text);
        }

        private void browseButton_Click(object sender, EventArgs e) {
            folderBrowserDialog.ShowDialog();
            selectedFolderPath.Text = folderBrowserDialog.SelectedPath;
        }

        private void addGamesButton_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }

        private void pathsFound_CellEditFinishing(object sender, BrightIdeasSoftware.CellEditEventArgs e) {
            if (e.Column == rjCodeColumn && e.NewValue != null) {
                e.NewValue = String.IsNullOrWhiteSpace((string)e.NewValue) ? null : e.NewValue;
            }
        }

        private void pathsFound_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete) {
                EventHandler<BeforeSortingEventArgs> cancelSorting = (sender2, e2) => e2.Canceled = true;

                //Prevent automatically re-sorting the list after removing an item because this shuffles the other items
                GamesFound.BeforeSorting += cancelSorting;
                GamesFound.RemoveObjects(GamesFound.SelectedObjects);
                GamesFound.BeforeSorting -= cancelSorting;

                if (GamesFound.Items.Count < 1) {
                    addGamesButton.Enabled = false;
                }

                int rjCodesFound = 0;

                foreach (var game in GamesFound.Objects) {
                    if (((Game)game).RJCode != null) {
                        rjCodesFound++;
                    }
                }
                StatusMessage = String.Format("Found {0} games and {1} RJCodes.", GamesFound.Items.Count, rjCodesFound);
            }
        }

        private void useEnglishDLSite_CheckedChanged(object sender, EventArgs e) {
            useGoogleTranslate.Enabled = useAlternativeDLSiteLanguage.Checked && useEnglishDLSite.Checked;

            if (!useGoogleTranslate.Enabled) {
                useGoogleTranslate.Checked = false;
            }

            if (useEnglishDLSite.Checked) {
                useAlternativeDLSiteLanguage.Text = "Get title and tags in Japanese if English ones are unavailable";
            }
        }

        private void useJapaneseDLSite_CheckedChanged(object sender, EventArgs e) {
            useGoogleTranslate.Enabled = useAlternativeDLSiteLanguage.Checked && useEnglishDLSite.Checked;

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
    }
}
