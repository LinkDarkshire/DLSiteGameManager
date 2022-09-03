using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameManager {
    public partial class GameEditControl : UserControl {
        //The game that is being either displayed or edited
        private Game game;
        private bool controlLoaded = false;
        private bool inEditMode = false;
        private CancellationTokenSource downloadCanceller;

        //Extra controls that can't be added in design mode
        private RatingEditor ratingEditor = new RatingEditor { TabIndex = 9 };
        private RatingEditor dlsRatingEditor = new RatingEditor { TabIndex = 10 };
        private Label ratingLabel = new Label { Anchor = AnchorStyles.Left, Font = Settings.Instance.GlobalFont, TextAlign = System.Drawing.ContentAlignment.MiddleLeft, AutoEllipsis = true };
        private Label dlsRatingLabel = new Label { Anchor = AnchorStyles.Left, Font = Settings.Instance.GlobalFont, Padding = new Padding(0, 2, 1, 0), TextAlign = System.Drawing.ContentAlignment.MiddleLeft, AutoEllipsis = true };

        //The changes that should be applied when the 'apply' button is pressed
        private volatile bool circleEdited = false;
        private volatile Circle selectedCircle;
        private bool imagesEdited = false;
        private bool isOnJapaneseDLSite;
        private bool isOnEnglishDLSite;
        private bool isReleasedOnJapaneseDLSite;
        private bool isReleasedOnEnglishDLSite;
		private bool isOnHVDB;
        private bool isRpgMakerGame;
        private string wolfRpgMakerVersion;
        
        public ImageViewControl ImageViewer { private set; get; }

        /// <summary>
        /// This delegate is periodically called to report download progress.
        /// </summary>
        public Action<string> ReportDownloadProgress { get; set; }

        public GameEditControl() {
            InitializeComponent();
            ImageViewer = imageViewControl;

            foreach (Control c in Controls) {
                c.Font = Settings.Instance.GlobalFont;
            }

            bottomContainer.Controls.Add(ratingEditor, 2, bottomContainer.GetRow(ratingHeader));
            bottomContainer.Controls.Add(dlsRatingEditor, 2, bottomContainer.GetRow(dlsRatingHeader));

            imageViewControl.Height = Settings.Instance.ImageSizeInPanel.Height + 8;
            categoryBox.Width = 180;
            languageBox.Width = 180;

            Settings.Instance.Saved += (settings, e) => {
                imageViewControl.Height = Settings.Instance.ImageSizeInPanel.Height + 8;
            };

            SetGame(null);
        }

        //Sets the splitter distance after the constructor has run to circumvent a .NET bug 
        private void GameEditControl_Load(object sender, EventArgs e) {
            if (Settings.Instance.EditPanelYPosition >= splitContainer.Panel1MinSize) {
                splitContainer.SplitterDistance = Settings.Instance.EditPanelYPosition;
            }
            splitContainer.SplitterMoved += splitContainer_SplitterMoved;
            controlLoaded = true;
        }

        //Sets the size of labels manually each time the control is resized because the autosize property
        //does not work properly for labels in table cells
        private void GameEditControl_SizeChanged(object sender, EventArgs e) {
            if (controlLoaded) {
                var newWidth = (int)(bottomContainer.Width - bottomContainer.ColumnStyles[0].Width);

                foreach (var control in bottomContainer.Controls) {
                    var label = control as Label;

                    if (label != null) {
                        label.Width = newWidth;
                    }
                }
            }
        }

        /// <summary>
        /// Sets whether or not the fields in the game edit control should be editable.
        /// </summary>
        private void SetMode(bool editMode) {
            bottomContainer.SuspendLayout();

            inEditMode = editMode;
            circleEdited = false;
            imagesEdited = false;

            if (editMode) {
                UpdateCategories();
                UpdateLanguages();

                //Collapse the table column containing the non-editable fields and reveal the one containing the editable ones
                bottomContainer.ColumnStyles[1].Width = 0;
                bottomContainer.ColumnStyles[2].Width = 100;

                circleContainer.Controls.Clear();
                circleContainer.Controls.Add(circleLabel);
                circleContainer.Controls.Add(editCircleButton);

                editButton.Text = "Cancel";
                circleLabel.AutoSize = true;
                applyButton.Visible = true;
                downloadButton.Visible = true;
                downloadButton.Enabled = true;
                applyButton.Enabled = true;
                updateSize.Enabled = true;
            }
            else {
                bottomContainer.ColumnStyles[1].Width = 100;
                bottomContainer.ColumnStyles[2].Width = 0;
                bottomContainer.Controls.Add(circleLabel, 1, bottomContainer.GetRow(circleHeader));

                editButton.Text = "Edit";
                applyButton.Visible = false;
                downloadButton.Visible = false;
                circleLabel.AutoSize = false;
                circleLabel.Width = (int)(bottomContainer.Width - bottomContainer.ColumnStyles[0].Width);
            }

            UpdateCellVisibility();
            bottomContainer.ResumeLayout();
        }

        /// <summary>
        /// Sets the game that should be either edited or viewed depending on the current mode.
        /// </summary>
        /// <param name="game">The game that should be shown in the control. Pass null to empty out all fields. </param>
        public void SetGame(Game game) {
            this.game = game;
            bottomContainer.SuspendLayout();

            //Cancel ongoing downloads
            if (downloadCanceller != null) {
                downloadCanceller.Cancel();
            }

            if (imagesEdited) {
                var previouslyDisplayedImages = ImageViewer.DisplayedImages.ToArray();
                imageViewControl.SetGame(game);

                //Dispose of any unsaved leftover images from a cancelled download
                foreach (GameImage image in previouslyDisplayedImages) {
                    if (image.ImageID == null) {
                        image.Dispose();
                    }
                }
            }
            else {
                imageViewControl.SetGame(game);
            }

            SetMode(false);

            if (game == null) {
                rjCodeLabel.Text = titleLabel.Text = categoryLabel.Text = languageLabel.Text = circleLabel.Text = timePlayedLabel.Text = timesPlayedLabel.Text = dlsRatingLabel.Text = "";
                ratingLabel.Text = pathLabel.Text = lastPlayedLabel.Text = releasedLabel.Text = tagsLabel.Text = hvdbtagsLabel.Text = cvsLabel.Text = commentsLabel.Text = sizeLabel.Text = "";
                ratingImage.Image = dlsRatingImage.Image = null;
            }
            else {
                Debug.Assert(game.GameID.HasValue, "Games must have an ID before being edited.");

                UpdateGameInformation(game);

                if (Settings.Instance.ShowRatingsAsImage) {
                    bottomContainer.Controls.Remove(ratingLabel);
                    bottomContainer.Controls.Remove(dlsRatingLabel);
                    bottomContainer.Controls.Add(ratingImage, 1, bottomContainer.GetRow(ratingHeader));
                    bottomContainer.Controls.Add(dlsRatingImage, 1, bottomContainer.GetRow(dlsRatingHeader));
                }
                else {
                    bottomContainer.Controls.Remove(ratingImage);
                    bottomContainer.Controls.Remove(dlsRatingImage);
                    bottomContainer.Controls.Add(ratingLabel, 1, bottomContainer.GetRow(ratingHeader));
                    bottomContainer.Controls.Add(dlsRatingLabel, 1, bottomContainer.GetRow(dlsRatingHeader));
                }
            }
            bottomContainer.ResumeLayout();
        }

        /// <summary>
        /// Updates the values of labels and text boxes to match the specified game. 
        /// </summary>
        private void UpdateGameInformation(Game game) {
            rjCodeBox.Text = rjCodeLabel.Text = game.RJCode;
            titleBox.Text = titleLabel.Text = game.Title;
            circleLabel.Text = game.Author != null ? game.Author.Name : "";
            categoryBox.Text = categoryLabel.Text = game.Category;
            languageBox.Text = languageLabel.Text = game.Language;
            pathBox.Text = game.Path;
            pathLabel.Text = "";
            isOnJapaneseDLSite = game.IsOnJapaneseDLSite;
            isOnEnglishDLSite = game.IsOnEnglishDLSite;
            isReleasedOnJapaneseDLSite = game.IsReleasedOnJapaneseDLSite;
            isReleasedOnEnglishDLSite = game.IsReleasedOnEnglishDLSite;
			isOnHVDB = game.IsOnHVDB;
			isRpgMakerGame = game.IsRpgMakerGame;
			wolfRpgMakerVersion = game.WolfRpgMakerVersion;

            if (game.Path != null) {
                var normalizedPath = game.Path.Replace('/', '\\');
                
                if (Settings.Instance.DisplayPathsAsRelativeToGameFolder && Settings.Instance.GameFolder != null) {
                    var normalizedGameFolderPath = Settings.Instance.GameFolder.Replace('/', '\\');
                    var path = normalizedPath;

                    if (path.StartsWith(normalizedGameFolderPath)) {
                        path = normalizedPath.Substring(normalizedPath.FirstDifference(normalizedGameFolderPath));
                    }

                    if (path.Length > 2 && path[0] == '\\') {
                        pathLabel.Text = path.Substring(1);
                    }
                    else {
                        pathLabel.Text = path;
                    }
                }
                else {
                    pathLabel.Text = normalizedPath;
                }
            }

            sizeBox.Text = game.Size != null ? game.Size.ToString() : "";
            sizeLabel.Text = game.Size != null ? game.Size.ToString() + " MB" : "";

            timesPlayedBox.Value = game.TimesPlayed;
            timesPlayedLabel.Text = game.TimesPlayed.ToString();
            timePlayedBox.Text = timePlayedLabel.Text = game.TimePlayed.ToString("c", CultureInfo.InvariantCulture);
            lastPlayedBox.Text = lastPlayedLabel.Text = !game.LastPlayedDate.HasValue ? "" : game.LastPlayedDate.Value.ToString("g");
            releasedBox.Text = releasedLabel.Text = !game.ReleaseDate.HasValue ? "" : game.ReleaseDate.Value.ToShortDateString();
            tagsLabel.Text = tagsBox.Text = game.Tags;
			hvdbtagsLabel.Text = hvdbtagsBox.Text = game.HVDBTags;
			cvsLabel.Text = cvsBox.Text = game.CVs;
            commentsLabel.Text = commentsBox.Text = game.Comments;

            ratingEditor.SelectedRating = game.Rating;
            ratingImage.Image = game.Rating.HasValue ? RatingEditor.Images[game.Rating.Value] : null;
            ratingLabel.Text = game.Rating.ToString();

            dlsRatingEditor.SelectedRating = game.DLSRating;
            dlsRatingImage.Image = game.DLSRating.HasValue ? RatingEditor.Images[game.DLSRating.Value] : null;
            dlsRatingLabel.Text = game.DLSRating.ToString();
        }

        /// <summary>
        /// Hides and shows cells according to the current settings.
        /// </summary>
        private void UpdateCellVisibility() {
            bool noRowsVisible = true;
            bottomContainer.SuspendLayout();

            //If more cells have been added since the last time the program was run, add the new cells while preserving the visibility of the old ones
            if (Settings.Instance.VisibleEditPanelRows.Length == 14) {
                var newArray = new List<bool>(Settings.Instance.VisibleEditPanelRows);
                newArray.Insert(4, false);
                Settings.Instance.VisibleEditPanelRows = newArray.ToArray();
            }
            if (Settings.Instance.VisibleEditPanelRows.Length == 15) {
                var newArray = new List<bool>(Settings.Instance.VisibleEditPanelRows);
                newArray.Insert(13, true);
				newArray.Insert(14, true);
                Settings.Instance.VisibleEditPanelRows = newArray.ToArray();
            }

            for (int row = 0; row < bottomContainer.RowCount; row++) {
                for (int col = 0; col < bottomContainer.ColumnCount; col++) {
                    var rowVisible = Settings.Instance.VisibleEditPanelRows[row];
                    var control = bottomContainer.GetControlFromPosition(col, row);

                    ((ToolStripMenuItem)tableOptions.Items[row]).Checked = rowVisible;
                    bottomContainer.RowStyles[row].Height = rowVisible ? 30 : 0;

					
					if (row == 13 || row == 14 || row == 15 || row == 1 || row == 5) {
						bottomContainer.RowStyles[row].SizeType = SizeType.AutoSize;
					}

                    if (control != null) {
                        control.Visible = rowVisible && (col == 0 || (col == 1 && !inEditMode) || (col == 2 && inEditMode));
                    }

                    if (rowVisible) {
                        noRowsVisible = false;
                    }
                }
            }
            editButton.Visible = inEditMode || (!noRowsVisible && game != null);
            bottomContainer.ResumeLayout();
        }

        private void UpdateCategories() {
            categoryBox.BeginUpdate();
            categoryBox.Items.Clear();

            foreach (var game in Game.GetGames()) {
                if (game.Category != null && !categoryBox.Items.Contains(game.Category)) {
                    categoryBox.Items.Add(game.Category);
                }
            }
            categoryBox.EndUpdate();
        }

        private void UpdateLanguages() {
            languageBox.BeginUpdate();
            languageBox.Items.Clear();

            foreach (var game in Game.GetGames()) {
                if (game.Language != null && !languageBox.Items.Contains(game.Language)) {
                    languageBox.Items.Add(game.Language);
                }
            }
            languageBox.EndUpdate();
        }

        private void editButton_Click(object sender, EventArgs e) {
            if (!inEditMode) {
                //Enable edit mode
                SetMode(true);
            }
            else {
                //Reset field values and disable edit mode
                SetGame(game);
            }
        }

        /// <summary>
        /// Tries to parse a nullable date time object from a string.
        /// Returns false and displays an error message on failure.
        /// </summary>
        private bool TryParseNullableDateTime(string str, out DateTime? dateTime) {
            DateTime tmp;
            dateTime = null;

            if (String.IsNullOrWhiteSpace(str)) {
                return true;
            }
            else if (DateTime.TryParse(str, out tmp)) {
                dateTime = tmp;
                return true;
            }

            var message = String.Format("\"{0}\" is not a valid date. Valid dates are formatted as \"{1}\".",
                                        str, CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private void applyButton_Click(object sender, EventArgs e) {
            string rjCode = null;
            int size = 0;
            TimeSpan timePlayed = TimeSpan.Zero;
            DateTime? lastPlayed, released;

            //Validate RJCode
            if (String.IsNullOrWhiteSpace(rjCodeBox.Text) || rjCodeBox.Text.Length < 3) {
                game.RJCode = null;
            }
            else if (!DLSitePage.IsValidRjCode(rjCodeBox.Text)) {
                MessageBox.Show(this, rjCodeBox.Text + " is not a valid DLSite code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else {
                rjCode = rjCodeBox.Text;
            }

            //Validate time played
            if (!String.IsNullOrWhiteSpace(timePlayedBox.Text) && !TimeSpan.TryParse(timePlayedBox.Text, CultureInfo.InvariantCulture, out timePlayed)) {
                var message = String.Format("\"{0}\" is not a valid time. Valid times are formatted as \"{1}\".",
                                            timePlayedBox.Text, "hh:mm:ss");
                MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Validate dates
            if (!TryParseNullableDateTime(lastPlayedBox.Text, out lastPlayed) || 
                    !TryParseNullableDateTime(releasedBox.Text, out released)) {
                return;
            }

            if (int.TryParse(sizeBox.Text, out size)) {
                game.Size = size;
            }
            else {
                game.Size = null;
            }

            game.RJCode = rjCode;
            game.LastPlayedDate = lastPlayed;
            game.ReleaseDate = released;
            game.Title = String.IsNullOrWhiteSpace(titleBox.Text) ? null : titleBox.Text;
            game.Category = String.IsNullOrWhiteSpace(categoryBox.Text) ? null : categoryBox.Text;
            game.Language = String.IsNullOrWhiteSpace(languageBox.Text) ? null : languageBox.Text;
            game.Tags = tagsBox.Text;
			game.HVDBTags = hvdbtagsBox.Text;
			game.CVs = String.IsNullOrWhiteSpace(cvsBox.Text) ? null : cvsBox.Text;
            game.Comments = commentsBox.Text;
            game.Path = pathBox.Text;
            game.Rating = ratingEditor.SelectedRating;
            game.DLSRating = dlsRatingEditor.SelectedRating;
            game.TimesPlayed = (int)timesPlayedBox.Value;
            game.TimePlayed = timePlayed;
            game.IsOnJapaneseDLSite = isOnJapaneseDLSite;
            game.IsOnEnglishDLSite = isOnEnglishDLSite;
            game.IsReleasedOnJapaneseDLSite = isReleasedOnJapaneseDLSite;
            game.IsReleasedOnEnglishDLSite = isReleasedOnEnglishDLSite;
			game.IsOnHVDB = isOnHVDB;
			game.IsRpgMakerGame = isRpgMakerGame;
			game.WolfRpgMakerVersion = wolfRpgMakerVersion;
			
            if (circleEdited) {
                game.Author = selectedCircle;
            }

            if (imagesEdited) {
                var displayedImages = ImageViewer.DisplayedImages;

                //Delete any images that the user removed from the list
                foreach (var image in game.Images) {
                    if (!displayedImages.Contains(image)) {
                        image.Delete();
                    }
                }

                if (game.ListImage != null && !displayedImages.Contains(game.ListImage)) {
                    game.ListImage.Delete();
                }

                //Add the new sample images
                game.Images.Clear();
                game.Images.AddRange(displayedImages.Where(image => !image.IsListImage));

                //Add the new list image if there is one
                game.ListImage = displayedImages.FirstOrDefault(image => image.IsListImage);

                if (game.ListImage != null && game.ListImage.IsCoverImage) {
                    game.CoverImage = game.ListImage;
                }
                else {
                    game.CoverImage = displayedImages.FirstOrDefault(image => image.IsCoverImage);
                }

                //Copy custom images added by the user to the game's image folder
                foreach (var image in displayedImages.Where(img => Path.IsPathRooted(img.ImagePath))) {
                    string absolutePath = Path.Combine(Settings.ProgramDirectoryPath, image.ImagePath);

                    if (File.Exists(absolutePath)) {
                        string newPath = Path.Combine(game.RelativeImageFolderPath, Path.GetFileName(image.ImagePath));
                        string newAbsolutePath = Path.Combine(Settings.ProgramDirectoryPath, newPath);

                        if (File.Exists(newAbsolutePath)) {
                            newPath = newPath.Replace(Path.GetFileNameWithoutExtension(newPath), Path.GetFileNameWithoutExtension(Path.GetRandomFileName()));
                            newAbsolutePath = Path.Combine(Settings.ProgramDirectoryPath, newPath);
                        }

                        if (!Directory.Exists(Path.GetDirectoryName(newAbsolutePath))) {
                            Directory.CreateDirectory(Path.GetDirectoryName(newAbsolutePath));
                        }

                        File.Copy(absolutePath, newAbsolutePath);
                        image.ImagePath = newPath;
                    }
                }

                game.SaveImages();
            }
            game.Save();
        }

        private void editCircleButton_Click(object sender, EventArgs e) {
            using (var editor = new CircleEditor()) {
                editor.SelectedCircle = game.Author;
                editor.ShowDialog(this);

                if (!editor.Cancelled) {
                    circleLabel.Text = editor.SelectedCircle != null ? editor.SelectedCircle.Name : "";
                    selectedCircle = editor.SelectedCircle;
                    circleEdited = true;
                }
            }
        }

        private void downloadButton_Click(object sender, EventArgs e) {
            if (!DLSitePage.IsValidRjCode(rjCodeBox.Text)) {
                MessageBox.Show(rjCodeBox.Text + " is not a valid DLSite code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (imagesEdited) {
                var previouslyDisplayedImages = ImageViewer.DisplayedImages.ToArray();
                imageViewControl.ClearImages();

                //Dispose of any leftover images from previous downloads
                foreach (GameImage image in previouslyDisplayedImages) {
                    if (image.ImageID == null) {
                        image.Dispose();
                    }
                }
            }
            else {
                imageViewControl.ClearImages();
            }

            downloadCanceller = new CancellationTokenSource();
            var cancellationToken = downloadCanceller.Token;

            downloadButton.Enabled = false;
            applyButton.Enabled = false;

            var downloader = Task.Factory.StartNew(() => {
                //A temporary game object used to hold the downloaded fields
                var tmpGame = game.Copy();
                tmpGame.RJCode = rjCodeBox.Text;
                tmpGame.Images = new List<GameImage>();
                tmpGame.DownloadInfo(true, ReportDownloadProgress, cancellationToken);

                cancellationToken.ThrowIfCancellationRequested();

                //Update the UI
                BeginInvoke(new MethodInvoker(() => {
                    if (tmpGame.Title == null && Settings.Instance.GetTitleFromPath && game.Path != null) {
						string path = game.Path;
						if (File.Exists(path)) {
							path = System.IO.Path.GetDirectoryName(path);
						}
                        tmpGame.Title = new DirectoryInfo(path).Name;
                    }

                    UpdateGameInformation(tmpGame);
                    selectedCircle = tmpGame.Author;
                    circleEdited = true;
                }));

                BeginInvoke(new MethodInvoker(() => {
                    imageViewControl.SetGame(tmpGame);
                }));
            }, cancellationToken);

            //Handle unsuccessful attempt to access DLSite
            downloader.ContinueWith(failedTask => {
                if (failedTask.Exception.InnerException is PageNotFoundException || failedTask.Exception.InnerException is UriFormatException) {
                    BeginInvoke(new MethodInvoker(() => {
                        MessageBox.Show(this, failedTask.Exception.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
                else if (failedTask.Exception.InnerException is WebException) {
                    BeginInvoke(new MethodInvoker(() => {
                        MessageBox.Show(this, "Failed to connect to DLSite.com. Please check your internet connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
                else {
                    Logger.LogException(failedTask.Exception);

                    BeginInvoke(new MethodInvoker(() => {
                        MessageBox.Show(this, "Failed to connect to DLSite.com. See " + Settings.RelativeLogPath + " for details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
            }, TaskContinuationOptions.OnlyOnFaulted);

            //Enable the previously disabled buttons and clear the status bar
            downloader.ContinueWith(completedTask => {
                BeginInvoke(new MethodInvoker(() => {
                    imagesEdited = true;
                    downloadButton.Enabled = true;
                    applyButton.Enabled = true;

                    if (ReportDownloadProgress != null) {
                        ReportDownloadProgress("");
                    }
                }));
            });
        }

        //Enlarges the tag box when it is focused
        private void tagsBox_Enter(object sender, EventArgs e) {
           bottomContainer.RowStyles[bottomContainer.GetRow(tagsBox)].SizeType = SizeType.Absolute;
		   bottomContainer.RowStyles[bottomContainer.GetRow(tagsBox)].Height = 60;
        }

        private void hvdbtagsBox_Enter(object sender, EventArgs e) {
			bottomContainer.RowStyles[bottomContainer.GetRow(hvdbtagsBox)].SizeType = SizeType.Absolute;
            bottomContainer.RowStyles[bottomContainer.GetRow(hvdbtagsBox)].Height = 60;
        }

        private void cvsBox_Enter(object sender, EventArgs e) {
			bottomContainer.RowStyles[bottomContainer.GetRow(cvsBox)].SizeType = SizeType.Absolute;
            bottomContainer.RowStyles[bottomContainer.GetRow(cvsBox)].Height = 60;
        }

        private void commentsBox_Enter(object sender, EventArgs e) {
            bottomContainer.RowStyles[bottomContainer.GetRow(commentsBox)].Height = 100;
        }

        private void splitContainer_SplitterMoved(object sender, SplitterEventArgs e) {
            Settings.Instance.EditPanelYPosition = splitContainer.SplitterDistance;
        }

        private void tableOptions_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            var clickedItem = (ToolStripMenuItem)e.ClickedItem;
            clickedItem.Checked = !clickedItem.Checked;

            for (int i = 0; i < tableOptions.Items.Count; i++) {
                var menuItem = (ToolStripMenuItem)tableOptions.Items[i];

                Settings.Instance.VisibleEditPanelRows[i] = menuItem.Checked;
            }

            UpdateCellVisibility();
        }

        private void tableOptions_Closing(object sender, ToolStripDropDownClosingEventArgs e) {
            e.Cancel = e.CloseReason == ToolStripDropDownCloseReason.ItemClicked;
        }

        private void browseButton_Click(object sender, EventArgs e) {
            if (File.Exists(pathBox.Text) || Directory.Exists(pathBox.Text)) {
				string path = pathBox.Text;
				if (File.Exists(path)) {
					path = System.IO.Path.GetDirectoryName(path);
				}
				addGameDialog.InitialDirectory = path;
			}
            var result = addGameDialog.ShowDialog(this);

            if (result == DialogResult.OK) {
                pathBox.Text = addGameDialog.FileName;
            }
        }

        private void updateSize_Click(object sender, EventArgs e) {
            if (File.Exists(pathBox.Text) || Directory.Exists(pathBox.Text)) {
				string path = pathBox.Text;
				if (File.Exists(path)) {
					if (!String.IsNullOrEmpty(rjCodeBox.Text)) {
						path = IOUtility.GetWorksFolderFromPath(path, rjCodeBox.Text);
					}
					else {
						path = Path.GetDirectoryName(path);
					}
				}				
                var currentGame = game;
                bottomContainer.Focus();
                updateSize.Enabled = false;

                Task.Factory.StartNew(() => {
                    var size = IOUtility.GetDirectorySize(path) / 1024;

                    //Check if the user is still editing the relevant game
                    if (currentGame == game) {
                        this.InvokeIfRequired(() => {
                            sizeBox.Text = size.ToString();
                            updateSize.Enabled = true;
                        });
                    }
                });
            }
            else {
                MessageBox.Show(this, "\"" + pathBox.Text + "\" does not exist.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void imageViewControl_ImageCollectionAltered(object sender, ImageViewControl.ImageCollectionAlteredEventArgs e) {
            imagesEdited = true;

            if (!inEditMode) {
                SetMode(true);
                imagesEdited = true;

                //If the only thing changed was the list image, immediately apply the changes
                if (e.ListImageChanged && !e.ImagesAdded && !e.ImageRemoved) {
                    applyButton_Click(applyButton, EventArgs.Empty);
                }
            }
        }
    }
}
