namespace GameManager {
    partial class GameScannerForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }

            if (disposing) {
                folderBrowserDialog.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lookForRJCodeInPath = new System.Windows.Forms.CheckBox();
			this.lookForRJCodeInNames = new System.Windows.Forms.CheckBox();
            this.lookForRJCodeInFile = new System.Windows.Forms.CheckBox();
            this.downloadAverageRating = new System.Windows.Forms.CheckBox();
            this.useAlternativeDLSiteLanguage = new System.Windows.Forms.CheckBox();
            this.downloadCoverImage = new System.Windows.Forms.CheckBox();
            this.downloadSampleImages = new System.Windows.Forms.CheckBox();
            this.useGoogleTranslate = new System.Windows.Forms.CheckBox();
            this.tablessControl = new GameManager.TablessControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cancelButton1 = new System.Windows.Forms.Button();
            this.startScanButton = new System.Windows.Forms.Button();
            this.infoLabel1 = new System.Windows.Forms.Label();
            this.scanOptionsGroup = new System.Windows.Forms.GroupBox();
            this.selectedFolderPath = new GameManager.TweakedTextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.downloadOptionsGroup = new System.Windows.Forms.GroupBox();
            this.downloadTags = new System.Windows.Forms.CheckBox();
			this.downloadReviewTags = new System.Windows.Forms.CheckBox();
			this.downloadHVDBInfo = new System.Windows.Forms.CheckBox();
			this.preferHVDBEnglishTitle = new System.Windows.Forms.CheckBox();
			this.filterCVs = new System.Windows.Forms.CheckBox();
			this.autoSetCategory = new System.Windows.Forms.CheckBox();
            this.gameTitleGroup = new System.Windows.Forms.GroupBox();
            this.useNeitherDLSite = new System.Windows.Forms.RadioButton();
            this.useJapaneseDLSite = new System.Windows.Forms.RadioButton();
            this.useEnglishDLSite = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.statusMessage = new System.Windows.Forms.Label();
            this.infoLabel2 = new System.Windows.Forms.Label();
            this.cancelButton2 = new System.Windows.Forms.Button();
            this.addGamesButton = new System.Windows.Forms.Button();
            this.errorMessage = new System.Windows.Forms.Label();
            this.GamesFound = new BrightIdeasSoftware.FastObjectListView();
            this.hiddenColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.rjCodeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.pathColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tablessControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.scanOptionsGroup.SuspendLayout();
            this.downloadOptionsGroup.SuspendLayout();
            this.gameTitleGroup.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GamesFound)).BeginInit();
            this.SuspendLayout();
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Select a folder containing works";
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 20000;
            this.toolTip.InitialDelay = 600;
            this.toolTip.ReshowDelay = 100;
            // 
            // lookForRJCodeInPath
            // 
            this.lookForRJCodeInPath.AutoSize = true;
            this.lookForRJCodeInPath.Checked = true;
            this.lookForRJCodeInPath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lookForRJCodeInPath.Location = new System.Drawing.Point(12, 60);
            this.lookForRJCodeInPath.Margin = new System.Windows.Forms.Padding(5);
            this.lookForRJCodeInPath.Name = "lookForRJCodeInPath";
            this.lookForRJCodeInPath.Size = new System.Drawing.Size(287, 21);
            this.lookForRJCodeInPath.TabIndex = 4;
            this.lookForRJCodeInPath.Text = "Look for RJCode in folder paths";
            this.toolTip.SetToolTip(this.lookForRJCodeInPath, "The scanner should search every folder path in the specified folder for valid RJCodes.\r\n" +
        "RJ, RE, VJ or BJ followed by four or more digits is considered a valid RJCode.");
            this.lookForRJCodeInPath.UseVisualStyleBackColor = true;
            // 
            // lookForRJCodeInNames
            // 
            this.lookForRJCodeInNames.AutoSize = true;
            //this.lookForRJCodeInNames.Checked = true;
            this.lookForRJCodeInNames.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lookForRJCodeInNames.Location = new System.Drawing.Point(12, 82);
            this.lookForRJCodeInNames.Margin = new System.Windows.Forms.Padding(5);
            this.lookForRJCodeInNames.Name = "lookForRJCodeInNames";
            this.lookForRJCodeInNames.Size = new System.Drawing.Size(287, 21);
            this.lookForRJCodeInNames.TabIndex = 5;
            this.lookForRJCodeInNames.Text = "Look for RJCode in file and folder names";
            this.toolTip.SetToolTip(this.lookForRJCodeInNames, "The scanner should search every path in the specified folder for valid RJCodes.\r\n" +
        "RJ, RE, VJ or BJ followed by four or more digits is considered a valid RJCode.");
            this.lookForRJCodeInNames.UseVisualStyleBackColor = true;
            // 
            // lookForRJCodeInFile
            // 
            this.lookForRJCodeInFile.AutoSize = true;
            this.lookForRJCodeInFile.Location = new System.Drawing.Point(12, 104);
            this.lookForRJCodeInFile.Margin = new System.Windows.Forms.Padding(5, 5, 5, 10);
            this.lookForRJCodeInFile.Name = "lookForRJCodeInFile";
            this.lookForRJCodeInFile.Size = new System.Drawing.Size(228, 21);
            this.lookForRJCodeInFile.TabIndex = 6;
            this.lookForRJCodeInFile.Text = "Look for RJCode inside .txt files";
            this.toolTip.SetToolTip(this.lookForRJCodeInFile, "The scanner should open and look for valid RJCodes in all text files in each work\'s" +
        " directory.");
            this.lookForRJCodeInFile.UseVisualStyleBackColor = true;
            // 
            // downloadAverageRating
            // 
            this.downloadAverageRating.AutoSize = true;
            this.downloadAverageRating.Location = new System.Drawing.Point(12, 289);
            this.downloadAverageRating.Margin = new System.Windows.Forms.Padding(5, 5, 5, 10);
            this.downloadAverageRating.Name = "downloadAverageRating";
            this.downloadAverageRating.Size = new System.Drawing.Size(188, 21);
            this.downloadAverageRating.TabIndex = 5;
            this.downloadAverageRating.Text = "Download average rating";
            this.toolTip.SetToolTip(this.downloadAverageRating, "Download the average user score of each work.");
            this.downloadAverageRating.UseVisualStyleBackColor = true;
            // 
            // useAlternativeDLSiteLanguage
            // 
            this.useAlternativeDLSiteLanguage.AutoSize = true;
            this.useAlternativeDLSiteLanguage.Checked = true;
            this.useAlternativeDLSiteLanguage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useAlternativeDLSiteLanguage.Location = new System.Drawing.Point(5, 70);
            this.useAlternativeDLSiteLanguage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.useAlternativeDLSiteLanguage.Name = "useAlternativeDLSiteLanguage";
            this.useAlternativeDLSiteLanguage.Size = new System.Drawing.Size(416, 21);
            this.useAlternativeDLSiteLanguage.TabIndex = 6;
            this.useAlternativeDLSiteLanguage.Text = "Get title and tags in Japanese if English ones are unavailable";
            this.useAlternativeDLSiteLanguage.UseVisualStyleBackColor = true;
            this.useAlternativeDLSiteLanguage.CheckedChanged += new System.EventHandler(this.useAlternativeDLSiteLanguage_CheckedChanged);
            // 
            // downloadCoverImage
            // 
            this.downloadCoverImage.AutoSize = true;
            this.downloadCoverImage.Checked = true;
            this.downloadCoverImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.downloadCoverImage.Location = new System.Drawing.Point(12, 180);
            this.downloadCoverImage.Margin = new System.Windows.Forms.Padding(5);
            this.downloadCoverImage.Name = "downloadCoverImage";
            this.downloadCoverImage.Size = new System.Drawing.Size(338, 21);
            this.downloadCoverImage.TabIndex = 1;
            this.downloadCoverImage.Text = "Download the DLSite cover image for each work";
            this.toolTip.SetToolTip(this.downloadCoverImage, "Automatically download and save every work\'s front page image from DLSite.\r\nThis " +
        "amounts to ~200 KB per game.");
            this.downloadCoverImage.UseVisualStyleBackColor = true;
            // 
            // downloadSampleImages
            // 
            this.downloadSampleImages.AutoSize = true;
            this.downloadSampleImages.Checked = true;
            this.downloadSampleImages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.downloadSampleImages.Location = new System.Drawing.Point(12, 208);
            this.downloadSampleImages.Margin = new System.Windows.Forms.Padding(5, 5, 5, 10);
            this.downloadSampleImages.Name = "downloadSampleImages";
            this.downloadSampleImages.Size = new System.Drawing.Size(355, 21);
            this.downloadSampleImages.TabIndex = 2;
            this.downloadSampleImages.Text = "Download the DLSite sample images for each work";
            this.toolTip.SetToolTip(this.downloadSampleImages, "Automatically download and save every work\'s preview image collection.\r\nThis amou" +
        "nts to ~800 KB per game.");
            this.downloadSampleImages.UseVisualStyleBackColor = true;
            // 
            // useGoogleTranslate
            // 
            this.useGoogleTranslate.AutoSize = true;
            this.useGoogleTranslate.Checked = true;
            this.useGoogleTranslate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useGoogleTranslate.Location = new System.Drawing.Point(5, 98);
            this.useGoogleTranslate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.useGoogleTranslate.Name = "useGoogleTranslate";
            this.useGoogleTranslate.Size = new System.Drawing.Size(402, 21);
            this.useGoogleTranslate.TabIndex = 7;
            this.useGoogleTranslate.Text = "Use Google Translate to translate Japanese titles";
            this.useGoogleTranslate.UseVisualStyleBackColor = true;
            // 
            // tablessControl
            // 
            this.tablessControl.Controls.Add(this.tabPage1);
            this.tablessControl.Controls.Add(this.tabPage2);
            this.tablessControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablessControl.Location = new System.Drawing.Point(0, 0);
            this.tablessControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tablessControl.Name = "tablessControl";
            this.tablessControl.SelectedIndex = 0;
            this.tablessControl.Size = new System.Drawing.Size(592, 609);
            this.tablessControl.TabIndex = 5;
            this.tablessControl.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.cancelButton1);
            this.tabPage1.Controls.Add(this.startScanButton);
            this.tabPage1.Controls.Add(this.infoLabel1);
            this.tabPage1.Controls.Add(this.scanOptionsGroup);
            this.tabPage1.Controls.Add(this.downloadOptionsGroup);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(584, 580);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // cancelButton1
            // 
            this.cancelButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton1.Location = new System.Drawing.Point(485, 543);
            this.cancelButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancelButton1.Name = "cancelButton1";
            this.cancelButton1.Size = new System.Drawing.Size(83, 30);
            this.cancelButton1.TabIndex = 31;
            this.cancelButton1.Text = "Cancel";
            this.cancelButton1.UseVisualStyleBackColor = true;
            this.cancelButton1.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // startScanButton
            // 
            this.startScanButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.startScanButton.Enabled = false;
            this.startScanButton.Location = new System.Drawing.Point(396, 543);
            this.startScanButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startScanButton.Name = "startScanButton";
            this.startScanButton.Size = new System.Drawing.Size(83, 30);
            this.startScanButton.TabIndex = 30;
            this.startScanButton.Text = "Scan";
            this.startScanButton.UseVisualStyleBackColor = true;
            this.startScanButton.Click += new System.EventHandler(this.startScanButton_Click);
            // 
            // infoLabel1
            // 
            this.infoLabel1.AutoSize = true;
            this.infoLabel1.Location = new System.Drawing.Point(12, 14);
            this.infoLabel1.Margin = new System.Windows.Forms.Padding(5, 10, 5, 0);
            this.infoLabel1.Name = "infoLabel1";
            this.infoLabel1.Size = new System.Drawing.Size(531, 34);
            this.infoLabel1.TabIndex = 17;
            this.infoLabel1.Text = "The specified folder and all of its subfolders will be scanned for works. \r\n" +
    "The scanner will also look for RJCodes and use them to download info from DLSite" +
    ".";
            // 
            // scanOptionsGroup
            // 
            this.scanOptionsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scanOptionsGroup.Controls.Add(this.lookForRJCodeInPath);
			this.scanOptionsGroup.Controls.Add(this.lookForRJCodeInNames);
            this.scanOptionsGroup.Controls.Add(this.lookForRJCodeInFile);
            this.scanOptionsGroup.Controls.Add(this.selectedFolderPath);
            this.scanOptionsGroup.Controls.Add(this.browseButton);
            this.scanOptionsGroup.Location = new System.Drawing.Point(15, 57);
            this.scanOptionsGroup.Margin = new System.Windows.Forms.Padding(11, 10, 11, 5);
            this.scanOptionsGroup.Name = "scanOptionsGroup";
            this.scanOptionsGroup.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.scanOptionsGroup.Size = new System.Drawing.Size(553, 130);
            this.scanOptionsGroup.TabIndex = 0;
            this.scanOptionsGroup.TabStop = false;
            this.scanOptionsGroup.Text = "Folder to scan";
            // 
            // selectedFolderPath
            // 
            this.selectedFolderPath.Location = new System.Drawing.Point(12, 28);
            this.selectedFolderPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 10);
            this.selectedFolderPath.Name = "selectedFolderPath";
            this.selectedFolderPath.Size = new System.Drawing.Size(188, 22);
            this.selectedFolderPath.TabIndex = 1;
            this.selectedFolderPath.TextChanged += new System.EventHandler(this.selectedFolderPath_TextChanged);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(205, 29);
            this.browseButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(85, 25);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // downloadOptionsGroup
            // 
            this.downloadOptionsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadOptionsGroup.Controls.Add(this.downloadTags);
			this.downloadOptionsGroup.Controls.Add(this.downloadReviewTags);
			this.downloadOptionsGroup.Controls.Add(this.downloadHVDBInfo);
			this.downloadOptionsGroup.Controls.Add(this.preferHVDBEnglishTitle);
			this.downloadOptionsGroup.Controls.Add(this.filterCVs);
			this.downloadOptionsGroup.Controls.Add(this.autoSetCategory);
            this.downloadOptionsGroup.Controls.Add(this.downloadAverageRating);
            this.downloadOptionsGroup.Controls.Add(this.gameTitleGroup);
            this.downloadOptionsGroup.Controls.Add(this.downloadCoverImage);
            this.downloadOptionsGroup.Controls.Add(this.downloadSampleImages);
            this.downloadOptionsGroup.Location = new System.Drawing.Point(15, 195);
            this.downloadOptionsGroup.Margin = new System.Windows.Forms.Padding(11, 10, 11, 5);
            this.downloadOptionsGroup.Name = "downloadOptionsGroup";
            this.downloadOptionsGroup.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.downloadOptionsGroup.Size = new System.Drawing.Size(553, 341);
            this.downloadOptionsGroup.TabIndex = 1;
            this.downloadOptionsGroup.TabStop = false;
            this.downloadOptionsGroup.Text = "Download options";
            // 
            // downloadTags
            // 
            this.downloadTags.AutoSize = true;
            this.downloadTags.Location = new System.Drawing.Point(12, 235);
            this.downloadTags.Margin = new System.Windows.Forms.Padding(5, 5, 5, 10);
            this.downloadTags.Name = "downloadTags";
            this.downloadTags.Size = new System.Drawing.Size(123, 21);
            this.downloadTags.TabIndex = 3;
            this.downloadTags.Text = "Download tags";
            this.downloadTags.UseVisualStyleBackColor = true;
            // 
            // downloadReviewTags
            // 
            this.downloadReviewTags.AutoSize = true;
            this.downloadReviewTags.Location = new System.Drawing.Point(12, 262);
            this.downloadReviewTags.Margin = new System.Windows.Forms.Padding(5, 5, 5, 10);
            this.downloadReviewTags.Name = "downloadReviewTags";
            this.downloadReviewTags.Size = new System.Drawing.Size(123, 21);
            this.downloadReviewTags.TabIndex = 4;
            this.downloadReviewTags.Text = "Download review tags";
            this.downloadReviewTags.UseVisualStyleBackColor = true;
            // 
            // downloadHVDBInfo
            // 
            this.downloadHVDBInfo.AutoSize = true;
            this.downloadHVDBInfo.Location = new System.Drawing.Point(292, 262);
            this.downloadHVDBInfo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 10);
            this.downloadHVDBInfo.Name = "downloadHVDBInfo";
            this.downloadHVDBInfo.Size = new System.Drawing.Size(123, 21);
            this.downloadHVDBInfo.TabIndex = 5;
            this.downloadHVDBInfo.Text = "Download HVDB info";
            this.downloadHVDBInfo.UseVisualStyleBackColor = true;
            //
			// preferHVDBEnglishTitle
            // 
            this.preferHVDBEnglishTitle.AutoSize = true;
            this.preferHVDBEnglishTitle.Location = new System.Drawing.Point(292, 316);
            this.preferHVDBEnglishTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 8);
            this.preferHVDBEnglishTitle.Name = "preferHVDBEnglishTitle";
            this.preferHVDBEnglishTitle.Size = new System.Drawing.Size(97, 17);
            this.preferHVDBEnglishTitle.TabIndex = 7;
            this.preferHVDBEnglishTitle.Text = "Prefer HVDB English title";
            this.preferHVDBEnglishTitle.UseVisualStyleBackColor = true;
            //
			// filterCVs
            // 
            this.filterCVs.AutoSize = true;
            this.filterCVs.Location = new System.Drawing.Point(292, 289);
            this.filterCVs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 8);
            this.filterCVs.Name = "filterCVs";
            this.filterCVs.Size = new System.Drawing.Size(97, 17);
            this.filterCVs.TabIndex = 6;
            this.filterCVs.Text = "Filter CVs";
            this.filterCVs.UseVisualStyleBackColor = true;
            // 
            // autoSetCategory
            // 
            this.autoSetCategory.AutoSize = true;
            this.autoSetCategory.Location = new System.Drawing.Point(12, 316);
            this.autoSetCategory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 8);
            this.autoSetCategory.Name = "autoSetCategory";
            this.autoSetCategory.Size = new System.Drawing.Size(97, 17);
            this.autoSetCategory.TabIndex = 4;
            this.autoSetCategory.Text = "Auto set category from DLSite";
            this.autoSetCategory.UseVisualStyleBackColor = true;
            // 
            // gameTitleGroup
            // 
            this.gameTitleGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameTitleGroup.Controls.Add(this.useGoogleTranslate);
            this.gameTitleGroup.Controls.Add(this.useAlternativeDLSiteLanguage);
            this.gameTitleGroup.Controls.Add(this.useNeitherDLSite);
            this.gameTitleGroup.Controls.Add(this.useJapaneseDLSite);
            this.gameTitleGroup.Controls.Add(this.useEnglishDLSite);
            this.gameTitleGroup.Location = new System.Drawing.Point(12, 35);
            this.gameTitleGroup.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.gameTitleGroup.Name = "gameTitleGroup";
            this.gameTitleGroup.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gameTitleGroup.Size = new System.Drawing.Size(524, 130);
            this.gameTitleGroup.TabIndex = 0;
            this.gameTitleGroup.TabStop = false;
            this.gameTitleGroup.Text = "Download work\'s information from";
            // 
            // useNeitherDLSite
            // 
            this.useNeitherDLSite.AutoSize = true;
            this.useNeitherDLSite.Location = new System.Drawing.Point(276, 32);
            this.useNeitherDLSite.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.useNeitherDLSite.Name = "useNeitherDLSite";
            this.useNeitherDLSite.Size = new System.Drawing.Size(75, 21);
            this.useNeitherDLSite.TabIndex = 2;
            this.useNeitherDLSite.Text = "Neither";
            this.useNeitherDLSite.UseVisualStyleBackColor = true;
            this.useNeitherDLSite.CheckedChanged += new System.EventHandler(this.useNeitherDLSite_CheckedChanged);
            // 
            // useJapaneseDLSite
            // 
            this.useJapaneseDLSite.AutoSize = true;
            this.useJapaneseDLSite.Location = new System.Drawing.Point(133, 32);
            this.useJapaneseDLSite.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.useJapaneseDLSite.Name = "useJapaneseDLSite";
            this.useJapaneseDLSite.Size = new System.Drawing.Size(137, 21);
            this.useJapaneseDLSite.TabIndex = 0;
            this.useJapaneseDLSite.Text = "Japanese DLSite";
            this.useJapaneseDLSite.UseVisualStyleBackColor = true;
            this.useJapaneseDLSite.CheckedChanged += new System.EventHandler(this.useJapaneseDLSite_CheckedChanged);
            // 
            // useEnglishDLSite
            // 
            this.useEnglishDLSite.AutoSize = true;
            this.useEnglishDLSite.Checked = true;
            this.useEnglishDLSite.Location = new System.Drawing.Point(5, 32);
            this.useEnglishDLSite.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.useEnglishDLSite.Name = "useEnglishDLSite";
            this.useEnglishDLSite.Size = new System.Drawing.Size(121, 21);
            this.useEnglishDLSite.TabIndex = 1;
            this.useEnglishDLSite.TabStop = true;
            this.useEnglishDLSite.Text = "English DLSite";
            this.useEnglishDLSite.UseVisualStyleBackColor = true;
            this.useEnglishDLSite.CheckedChanged += new System.EventHandler(this.useEnglishDLSite_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.statusMessage);
            this.tabPage2.Controls.Add(this.infoLabel2);
            this.tabPage2.Controls.Add(this.cancelButton2);
            this.tabPage2.Controls.Add(this.addGamesButton);
            this.tabPage2.Controls.Add(this.errorMessage);
            this.tabPage2.Controls.Add(this.GamesFound);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(584, 580);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // statusMessage
            // 
            this.statusMessage.AutoSize = true;
            this.statusMessage.Location = new System.Drawing.Point(12, 491);
            this.statusMessage.Name = "statusMessage";
            this.statusMessage.Size = new System.Drawing.Size(0, 17);
            this.statusMessage.TabIndex = 10;
            // 
            // infoLabel2
            // 
            this.infoLabel2.AutoSize = true;
            this.infoLabel2.Location = new System.Drawing.Point(12, 14);
            this.infoLabel2.Margin = new System.Windows.Forms.Padding(5, 10, 5, 0);
            this.infoLabel2.Name = "infoLabel2";
            this.infoLabel2.Size = new System.Drawing.Size(268, 34);
            this.infoLabel2.TabIndex = 9;
            this.infoLabel2.Text = "Double click an RJCode to edit\r\nSelect a row and press \'delete\' to remove";
            // 
            // cancelButton2
            // 
            this.cancelButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton2.Location = new System.Drawing.Point(475, 543);
            this.cancelButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancelButton2.Name = "cancelButton2";
            this.cancelButton2.Size = new System.Drawing.Size(93, 30);
            this.cancelButton2.TabIndex = 8;
            this.cancelButton2.Text = "Cancel";
            this.cancelButton2.UseVisualStyleBackColor = true;
            this.cancelButton2.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // addGamesButton
            // 
            this.addGamesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addGamesButton.Enabled = false;
            this.addGamesButton.Location = new System.Drawing.Point(376, 543);
            this.addGamesButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addGamesButton.Name = "addGamesButton";
            this.addGamesButton.Size = new System.Drawing.Size(93, 30);
            this.addGamesButton.TabIndex = 7;
            this.addGamesButton.Text = "Add works";
            this.addGamesButton.UseVisualStyleBackColor = true;
            this.addGamesButton.Click += new System.EventHandler(this.addGamesButton_Click);
            // 
            // errorMessage
            // 
            this.errorMessage.AutoSize = true;
            this.errorMessage.Location = new System.Drawing.Point(12, 510);
            this.errorMessage.Name = "errorMessage";
            this.errorMessage.Size = new System.Drawing.Size(0, 17);
            this.errorMessage.TabIndex = 5;
            // 
            // GamesFound
            // 
            this.GamesFound.AllColumns.Add(this.hiddenColumn);
            this.GamesFound.AllColumns.Add(this.rjCodeColumn);
            this.GamesFound.AllColumns.Add(this.pathColumn);
            this.GamesFound.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.GamesFound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GamesFound.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.GamesFound.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hiddenColumn,
            this.rjCodeColumn,
            this.pathColumn});
            this.GamesFound.FullRowSelect = true;
            this.GamesFound.GridLines = true;
            this.GamesFound.Location = new System.Drawing.Point(15, 57);
            this.GamesFound.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.GamesFound.Name = "GamesFound";
            this.GamesFound.SelectColumnsOnRightClick = false;
            this.GamesFound.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.GamesFound.ShowGroups = false;
            this.GamesFound.Size = new System.Drawing.Size(553, 424);
            this.GamesFound.TabIndex = 1;
            this.GamesFound.UseAlternatingBackColors = true;
            this.GamesFound.UseCompatibleStateImageBehavior = false;
            this.GamesFound.UseOverlays = false;
            this.GamesFound.View = System.Windows.Forms.View.Details;
            this.GamesFound.VirtualMode = true;
            this.GamesFound.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.pathsFound_CellEditFinishing);
            this.GamesFound.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pathsFound_KeyDown);
            // 
            // hiddenColumn
            // 
            this.hiddenColumn.CellPadding = null;
            this.hiddenColumn.DefaultSortOrder = System.Windows.Forms.SortOrder.None;
            this.hiddenColumn.IsVisible = false;
            this.hiddenColumn.MaximumWidth = 0;
            this.hiddenColumn.MinimumWidth = 0;
            this.hiddenColumn.Width = 0;
            // 
            // rjCodeColumn
            // 
            this.rjCodeColumn.AspectName = "RJCode";
            this.rjCodeColumn.AutoCompleteEditor = false;
            this.rjCodeColumn.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.rjCodeColumn.CellPadding = null;
            this.rjCodeColumn.DefaultSortOrder = System.Windows.Forms.SortOrder.Descending;
            this.rjCodeColumn.Text = "RJCode";
            this.rjCodeColumn.Width = 81;
            // 
            // pathColumn
            // 
            this.pathColumn.AspectName = "Path";
            this.pathColumn.AutoCompleteEditor = false;
            this.pathColumn.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.pathColumn.CellPadding = null;
            this.pathColumn.DefaultSortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.pathColumn.FillsFreeSpace = true;
            this.pathColumn.IsEditable = false;
            this.pathColumn.Text = "Path";
            this.pathColumn.Width = 148;
            // 
            // GameScannerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(592, 609);
            this.ControlBox = false;
            this.Controls.Add(this.tablessControl);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GameScannerForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Game Scanner";
            this.tablessControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.scanOptionsGroup.ResumeLayout(false);
            this.scanOptionsGroup.PerformLayout();
            this.downloadOptionsGroup.ResumeLayout(false);
            this.downloadOptionsGroup.PerformLayout();
            this.gameTitleGroup.ResumeLayout(false);
            this.gameTitleGroup.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GamesFound)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button cancelButton1;
        private TablessControl tablessControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private BrightIdeasSoftware.OLVColumn hiddenColumn;
        private BrightIdeasSoftware.OLVColumn rjCodeColumn;
        private BrightIdeasSoftware.OLVColumn pathColumn;
        private System.Windows.Forms.Label errorMessage;
        private System.Windows.Forms.Button addGamesButton;
        private System.Windows.Forms.CheckBox downloadSampleImages;
        private System.Windows.Forms.CheckBox downloadCoverImage;
        private System.Windows.Forms.CheckBox lookForRJCodeInFile;
        private System.Windows.Forms.CheckBox lookForRJCodeInPath;
		private System.Windows.Forms.CheckBox lookForRJCodeInNames;
        private System.Windows.Forms.Button startScanButton;
        private System.Windows.Forms.Button cancelButton2;
        private System.Windows.Forms.GroupBox gameTitleGroup;
        private System.Windows.Forms.RadioButton useJapaneseDLSite;
        private System.Windows.Forms.RadioButton useEnglishDLSite;
        private System.Windows.Forms.CheckBox useAlternativeDLSiteLanguage;
        private System.Windows.Forms.GroupBox downloadOptionsGroup;
        private System.Windows.Forms.GroupBox scanOptionsGroup;
        private System.Windows.Forms.Label infoLabel1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label statusMessage;
        private System.Windows.Forms.Label infoLabel2;
        internal BrightIdeasSoftware.FastObjectListView GamesFound;
        private System.Windows.Forms.RadioButton useNeitherDLSite;
        private TweakedTextBox selectedFolderPath;
        private System.Windows.Forms.CheckBox downloadTags;
		private System.Windows.Forms.CheckBox downloadReviewTags;
		private System.Windows.Forms.CheckBox downloadHVDBInfo;
		private System.Windows.Forms.CheckBox preferHVDBEnglishTitle;
		private System.Windows.Forms.CheckBox filterCVs;
		private System.Windows.Forms.CheckBox autoSetCategory;
        private System.Windows.Forms.CheckBox downloadAverageRating;
        private System.Windows.Forms.CheckBox useGoogleTranslate;
    }
}
