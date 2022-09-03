namespace GameManager {
    partial class SettingsForm {
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.generalTab = new System.Windows.Forms.TabPage();
            this.deleteArchiveGroup = new System.Windows.Forms.GroupBox();
            this.alwaysRename = new System.Windows.Forms.RadioButton();
            this.askIfDelete = new System.Windows.Forms.RadioButton();
            this.neverDelete = new System.Windows.Forms.RadioButton();
            this.alwaysDelete = new System.Windows.Forms.RadioButton();
            this.resolutionGroup = new System.Windows.Forms.GroupBox();
            this.resolutionList = new System.Windows.Forms.ComboBox();
            this.gameFolderGroup = new System.Windows.Forms.GroupBox();
			this.renameTemplateGroup = new System.Windows.Forms.GroupBox();	
            this.moveGamesGroup = new System.Windows.Forms.GroupBox();
            this.askIfMove = new System.Windows.Forms.RadioButton();
            this.neverMove = new System.Windows.Forms.RadioButton();
            this.alwaysMove = new System.Windows.Forms.RadioButton();
            this.gameFolder = new GameManager.TweakedTextBox();
			this.renameTemplate = new GameManager.TweakedTextBox();
			this.renameOrganize = new System.Windows.Forms.CheckBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.appearanceTab = new System.Windows.Forms.TabPage();
            this.useCoverImageAsListImage = new System.Windows.Forms.CheckBox();
            this.openListFontDialogButton = new System.Windows.Forms.Button();
            this.aspectRatioLabel = new System.Windows.Forms.Label();
            this.doubleClickToRun = new System.Windows.Forms.CheckBox();
            this.restoreAppearanceButton = new System.Windows.Forms.Button();
            this.tileImageSizeGroup = new System.Windows.Forms.GroupBox();
            this.tileImageHeight = new System.Windows.Forms.NumericUpDown();
            this.tileImageWidth = new System.Windows.Forms.NumericUpDown();
            this.tileImageHeightLabel = new System.Windows.Forms.Label();
            this.tileImageWidthLabel = new System.Windows.Forms.Label();
            this.listImageSizeGroup = new System.Windows.Forms.GroupBox();
            this.listImageHeight = new System.Windows.Forms.NumericUpDown();
            this.listImageWidth = new System.Windows.Forms.NumericUpDown();
            this.listImageHeightLabel = new System.Windows.Forms.Label();
            this.listImageWidthLabel = new System.Windows.Forms.Label();
            this.applyListFontToTiles = new System.Windows.Forms.CheckBox();
            this.wordWrapRowText = new System.Windows.Forms.CheckBox();
            this.thumbnailSizeGroup = new System.Windows.Forms.GroupBox();
            this.thumbnailHeight = new System.Windows.Forms.NumericUpDown();
            this.thumbnailWidth = new System.Windows.Forms.NumericUpDown();
            this.thumbnailHeightLabel = new System.Windows.Forms.Label();
            this.thumbnailWidthLabel = new System.Windows.Forms.Label();
            this.rowHeight = new System.Windows.Forms.NumericUpDown();
            this.rowHeightLabel = new System.Windows.Forms.Label();
            this.ratingAsImage = new System.Windows.Forms.CheckBox();
            this.agthTab = new System.Windows.Forms.TabPage();
            this.launchWithChiiTrans = new System.Windows.Forms.CheckBox();
            this.chiiTransBox = new System.Windows.Forms.GroupBox();
            this.chiiTransPath = new GameManager.TweakedTextBox();
            this.chiiTransBrowseButton = new System.Windows.Forms.Button();
            this.useHCodeForWolfGames = new System.Windows.Forms.CheckBox();
            this.autoExitTranslator = new System.Windows.Forms.CheckBox();
            this.translatorGroup = new System.Windows.Forms.GroupBox();
            this.translatorPath = new GameManager.TweakedTextBox();
            this.translatorBrowseButton = new System.Windows.Forms.Button();
            this.agthPathGroup = new System.Windows.Forms.GroupBox();
            this.defaultParametersGroup = new System.Windows.Forms.GroupBox();
            this.agthHelpButton = new System.Windows.Forms.Button();
            this.agthDefaultParameters = new GameManager.TweakedTextBox();
            this.agthPath = new GameManager.TweakedTextBox();
            this.agthBrowseButton = new System.Windows.Forms.Button();
            this.launchWithAgth = new System.Windows.Forms.CheckBox();
            this.dlSiteTab = new System.Windows.Forms.TabPage();
            this.rjCodeGroup = new System.Windows.Forms.GroupBox();
            this.lookForRJCodeInPath = new System.Windows.Forms.CheckBox();
			this.lookForRJCodeInNames = new System.Windows.Forms.CheckBox();
            this.lookForRJCodeInFile = new System.Windows.Forms.CheckBox();
            this.downloadTags = new System.Windows.Forms.CheckBox();
			this.downloadReviewTags = new System.Windows.Forms.CheckBox();
			this.downloadHVDBInfo = new System.Windows.Forms.CheckBox();
			this.preferHVDBEnglishTitle = new System.Windows.Forms.CheckBox();
			this.filterCVs = new System.Windows.Forms.CheckBox();
			this.autoSetCategory = new System.Windows.Forms.CheckBox();
            this.downloadAverageRating = new System.Windows.Forms.CheckBox();
            this.gameTitleGroup = new System.Windows.Forms.GroupBox();
            this.useGoogleTranslate = new System.Windows.Forms.CheckBox();
            this.useAlternativeDLSiteLanguage = new System.Windows.Forms.CheckBox();
            this.useNeitherDLSite = new System.Windows.Forms.RadioButton();
            this.useJapaneseDLSite = new System.Windows.Forms.RadioButton();
            this.useEnglishDLSite = new System.Windows.Forms.RadioButton();
            this.downloadSampleImages = new System.Windows.Forms.CheckBox();
            this.downloadCoverImage = new System.Windows.Forms.CheckBox();
            this.performanceTab = new System.Windows.Forms.TabPage();
            this.disableGameSizeCalculation = new System.Windows.Forms.CheckBox();
            this.disableRowHighlighting = new System.Windows.Forms.CheckBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.listFontDialog = new System.Windows.Forms.FontDialog();
            this.tabControl.SuspendLayout();
            this.generalTab.SuspendLayout();
            this.deleteArchiveGroup.SuspendLayout();
            this.resolutionGroup.SuspendLayout();
            this.gameFolderGroup.SuspendLayout();
			this.renameTemplateGroup.SuspendLayout();			
            this.moveGamesGroup.SuspendLayout();
            this.appearanceTab.SuspendLayout();
            this.tileImageSizeGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tileImageHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileImageWidth)).BeginInit();
            this.listImageSizeGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listImageHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listImageWidth)).BeginInit();
            this.thumbnailSizeGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnailHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnailWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowHeight)).BeginInit();
            this.agthTab.SuspendLayout();
            this.chiiTransBox.SuspendLayout();
            this.translatorGroup.SuspendLayout();
            this.agthPathGroup.SuspendLayout();
            this.defaultParametersGroup.SuspendLayout();
            this.dlSiteTab.SuspendLayout();
            this.rjCodeGroup.SuspendLayout();
            this.gameTitleGroup.SuspendLayout();
            this.performanceTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.generalTab);
            this.tabControl.Controls.Add(this.appearanceTab);
            this.tabControl.Controls.Add(this.agthTab);
            this.tabControl.Controls.Add(this.dlSiteTab);
            this.tabControl.Controls.Add(this.performanceTab);
            this.tabControl.Location = new System.Drawing.Point(10, 10);
            this.tabControl.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(371, 402);
            this.tabControl.TabIndex = 0;
            // 
            // generalTab
            // 
            this.generalTab.Controls.Add(this.deleteArchiveGroup);
            this.generalTab.Controls.Add(this.resolutionGroup);
            this.generalTab.Controls.Add(this.gameFolderGroup);
			this.generalTab.Controls.Add(this.renameTemplateGroup);			
            this.generalTab.Location = new System.Drawing.Point(4, 22);
            this.generalTab.Margin = new System.Windows.Forms.Padding(2);
            this.generalTab.Name = "generalTab";
            this.generalTab.Padding = new System.Windows.Forms.Padding(2);
            this.generalTab.Size = new System.Drawing.Size(363, 376);
            this.generalTab.TabIndex = 3;
            this.generalTab.Text = "General";
            this.generalTab.UseVisualStyleBackColor = true;
            // 
            // deleteArchiveGroup
            // 
            this.deleteArchiveGroup.Controls.Add(this.alwaysRename);
            this.deleteArchiveGroup.Controls.Add(this.askIfDelete);
            this.deleteArchiveGroup.Controls.Add(this.neverDelete);
            this.deleteArchiveGroup.Controls.Add(this.alwaysDelete);
            this.deleteArchiveGroup.Location = new System.Drawing.Point(8, 218);
            this.deleteArchiveGroup.Margin = new System.Windows.Forms.Padding(2);
            this.deleteArchiveGroup.Name = "deleteArchiveGroup";
            this.deleteArchiveGroup.Padding = new System.Windows.Forms.Padding(2);
            this.deleteArchiveGroup.Size = new System.Drawing.Size(335, 54);
            this.deleteArchiveGroup.TabIndex = 21;
            this.deleteArchiveGroup.TabStop = false;
            this.deleteArchiveGroup.Text = "After sucessfully extracting a CG archive";
            // 
            // alwaysRename
            // 
            this.alwaysRename.AutoSize = true;
            this.alwaysRename.Location = new System.Drawing.Point(105, 26);
            this.alwaysRename.Margin = new System.Windows.Forms.Padding(2);
            this.alwaysRename.Name = "alwaysRename";
            this.alwaysRename.Size = new System.Drawing.Size(103, 17);
            this.alwaysRename.TabIndex = 3;
            this.alwaysRename.TabStop = true;
            this.alwaysRename.Text = "Rename archive";
            this.alwaysRename.UseVisualStyleBackColor = true;
            // 
            // askIfDelete
            // 
            this.askIfDelete.AutoSize = true;
            this.askIfDelete.Location = new System.Drawing.Point(280, 26);
            this.askIfDelete.Margin = new System.Windows.Forms.Padding(2);
            this.askIfDelete.Name = "askIfDelete";
            this.askIfDelete.Size = new System.Drawing.Size(43, 17);
            this.askIfDelete.TabIndex = 2;
            this.askIfDelete.TabStop = true;
            this.askIfDelete.Text = "Ask";
            this.askIfDelete.UseVisualStyleBackColor = true;
            // 
            // neverDelete
            // 
            this.neverDelete.AutoSize = true;
            this.neverDelete.Location = new System.Drawing.Point(215, 26);
            this.neverDelete.Margin = new System.Windows.Forms.Padding(2);
            this.neverDelete.Name = "neverDelete";
            this.neverDelete.Size = new System.Drawing.Size(59, 17);
            this.neverDelete.TabIndex = 1;
            this.neverDelete.TabStop = true;
            this.neverDelete.Text = "Neither";
            this.neverDelete.UseVisualStyleBackColor = true;
            // 
            // alwaysDelete
            // 
            this.alwaysDelete.AutoSize = true;
            this.alwaysDelete.Location = new System.Drawing.Point(4, 26);
            this.alwaysDelete.Margin = new System.Windows.Forms.Padding(2);
            this.alwaysDelete.Name = "alwaysDelete";
            this.alwaysDelete.Size = new System.Drawing.Size(94, 17);
            this.alwaysDelete.TabIndex = 0;
            this.alwaysDelete.TabStop = true;
            this.alwaysDelete.Text = "Delete archive";
            this.alwaysDelete.UseVisualStyleBackColor = true;
            // 
            // resolutionGroup
            // 
            this.resolutionGroup.Controls.Add(this.resolutionList);
            this.resolutionGroup.Location = new System.Drawing.Point(8, 147);
            this.resolutionGroup.Name = "resolutionGroup";
            this.resolutionGroup.Size = new System.Drawing.Size(335, 54);
            this.resolutionGroup.TabIndex = 20;
            this.resolutionGroup.TabStop = false;
            this.resolutionGroup.Text = "Desktop resolution while running games";
            this.toolTip.SetToolTip(this.resolutionGroup, "If set, the screen resolution will automatically be changed when launching a game" +
                    ". \r\nThe screen resolution will be reverted back when the game or this program is" +
                    " closed.");
            // 
            // resolutionList
            // 
            this.resolutionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resolutionList.FormattingEnabled = true;
            this.resolutionList.Location = new System.Drawing.Point(6, 22);
            this.resolutionList.Name = "resolutionList";
            this.resolutionList.Size = new System.Drawing.Size(99, 21);
            this.resolutionList.TabIndex = 1;
            // 
            // renameTemplateGroup
            // 
            this.renameTemplateGroup.Controls.Add(this.renameTemplate);
			this.renameTemplateGroup.Controls.Add(this.renameOrganize);
            this.renameTemplateGroup.Location = new System.Drawing.Point(8, 290);
            this.renameTemplateGroup.Name = "renameTemplateGroup";
            this.renameTemplateGroup.Size = new System.Drawing.Size(335, 74);
            this.renameTemplateGroup.TabIndex = 23;
            this.renameTemplateGroup.TabStop = false;
            this.renameTemplateGroup.Text = "Renaming template";
            this.toolTip.SetToolTip(this.renameTemplateGroup, "Valid tags: {rjcode}, {circle}, {cvs}, {title}, {category}, {foldername}" +
                    ". \r\nMust contain at least {rjcode} or {foldername}" +
					". \r\nExample: {rjcode} [{circle}] {title}");
            // 
            // renameTemplate
            // 
            this.renameTemplate.Location = new System.Drawing.Point(10, 22);
            this.renameTemplate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 8);
            this.renameTemplate.Name = "renameTemplate";
            this.renameTemplate.Size = new System.Drawing.Size(295, 20);
            this.renameTemplate.TabIndex = 1;
            this.toolTip.SetToolTip(this.renameTemplate, "Valid tags: {rjcode}, {circle}, {cvs}, {title}, {category}, {foldername}" +
                    ". \r\nMust contain at least {rjcode} or {foldername}" +
					". \r\nExample: {rjcode} [{circle}] {title}");
            // 
            // renameOrganize
            // 
            this.renameOrganize.AutoSize = true;
            this.renameOrganize.Location = new System.Drawing.Point(10, 52);
            this.renameOrganize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 8);
            this.renameOrganize.Name = "renameOrganize";
            this.renameOrganize.Size = new System.Drawing.Size(97, 17);
            this.renameOrganize.TabIndex = 2;
            this.renameOrganize.Text = "Use \\ to organize in folders (relative to Main Folder)";
            this.renameOrganize.UseVisualStyleBackColor = true;
            this.toolTip.SetToolTip(this.renameOrganize, "When checked, \\ can be used to specify folder structure relative to Main Folder" +
                    ". \r\nExample: {category}\\{circle}\\{rjcode} {title}" +
					". \r\nIf unchecked or Main Folder is not set or work\'s folder is outside of Main Folder, only part of the template after last \\ will be used for renaming");
            // 
            // gameFolderGroup
            // 
            this.gameFolderGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gameFolderGroup.Controls.Add(this.moveGamesGroup);
            this.gameFolderGroup.Controls.Add(this.gameFolder);
            this.gameFolderGroup.Controls.Add(this.browseButton);
            this.gameFolderGroup.Location = new System.Drawing.Point(8, 8);
            this.gameFolderGroup.Margin = new System.Windows.Forms.Padding(9, 8, 9, 4);
            this.gameFolderGroup.Name = "gameFolderGroup";
            this.gameFolderGroup.Padding = new System.Windows.Forms.Padding(4, 8, 4, 4);
            this.gameFolderGroup.Size = new System.Drawing.Size(335, 123);
            this.gameFolderGroup.TabIndex = 17;
            this.gameFolderGroup.TabStop = false;
            this.gameFolderGroup.Text = "Main folder";
            this.toolTip.SetToolTip(this.gameFolderGroup, "The folder that contains your DLSite works.\r\nGame archives will be extracted to t" +
                    "his folder.");
            // 
            // moveGamesGroup
            // 
            this.moveGamesGroup.Controls.Add(this.askIfMove);
            this.moveGamesGroup.Controls.Add(this.neverMove);
            this.moveGamesGroup.Controls.Add(this.alwaysMove);
            this.moveGamesGroup.Location = new System.Drawing.Point(10, 52);
            this.moveGamesGroup.Margin = new System.Windows.Forms.Padding(2);
            this.moveGamesGroup.Name = "moveGamesGroup";
            this.moveGamesGroup.Padding = new System.Windows.Forms.Padding(2);
            this.moveGamesGroup.Size = new System.Drawing.Size(310, 56);
            this.moveGamesGroup.TabIndex = 3;
            this.moveGamesGroup.TabStop = false;
            this.moveGamesGroup.Text = "Move new works to the main folder";
            // 
            // askIfMove
            // 
            this.askIfMove.AutoSize = true;
            this.askIfMove.Location = new System.Drawing.Point(186, 26);
            this.askIfMove.Margin = new System.Windows.Forms.Padding(2);
            this.askIfMove.Name = "askIfMove";
            this.askIfMove.Size = new System.Drawing.Size(43, 17);
            this.askIfMove.TabIndex = 2;
            this.askIfMove.TabStop = true;
            this.askIfMove.Text = "Ask";
            this.askIfMove.UseVisualStyleBackColor = true;
            // 
            // neverMove
            // 
            this.neverMove.AutoSize = true;
            this.neverMove.Location = new System.Drawing.Point(98, 26);
            this.neverMove.Margin = new System.Windows.Forms.Padding(2);
            this.neverMove.Name = "neverMove";
            this.neverMove.Size = new System.Drawing.Size(83, 17);
            this.neverMove.TabIndex = 1;
            this.neverMove.TabStop = true;
            this.neverMove.Text = "Never move";
            this.neverMove.UseVisualStyleBackColor = true;
            // 
            // alwaysMove
            // 
            this.alwaysMove.AutoSize = true;
            this.alwaysMove.Location = new System.Drawing.Point(4, 26);
            this.alwaysMove.Margin = new System.Windows.Forms.Padding(2);
            this.alwaysMove.Name = "alwaysMove";
            this.alwaysMove.Size = new System.Drawing.Size(87, 17);
            this.alwaysMove.TabIndex = 0;
            this.alwaysMove.TabStop = true;
            this.alwaysMove.Text = "Always move";
            this.alwaysMove.UseVisualStyleBackColor = true;
            // 
            // gameFolder
            // 
            this.gameFolder.Location = new System.Drawing.Point(10, 22);
            this.gameFolder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 8);
            this.gameFolder.Name = "gameFolder";
            this.gameFolder.Size = new System.Drawing.Size(237, 20);
            this.gameFolder.TabIndex = 1;
            this.toolTip.SetToolTip(this.gameFolder, "The folder that contains your DLSite works.\r\nGame archives will be extracted to t" +
                    "his folder.");
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(250, 22);
            this.browseButton.Margin = new System.Windows.Forms.Padding(2);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(68, 22);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // appearanceTab
            // 
            this.appearanceTab.Controls.Add(this.useCoverImageAsListImage);
            this.appearanceTab.Controls.Add(this.openListFontDialogButton);
            this.appearanceTab.Controls.Add(this.aspectRatioLabel);
            this.appearanceTab.Controls.Add(this.doubleClickToRun);
            this.appearanceTab.Controls.Add(this.restoreAppearanceButton);
            this.appearanceTab.Controls.Add(this.tileImageSizeGroup);
            this.appearanceTab.Controls.Add(this.listImageSizeGroup);
            this.appearanceTab.Controls.Add(this.applyListFontToTiles);
            this.appearanceTab.Controls.Add(this.wordWrapRowText);
            this.appearanceTab.Controls.Add(this.thumbnailSizeGroup);
            this.appearanceTab.Controls.Add(this.rowHeight);
            this.appearanceTab.Controls.Add(this.rowHeightLabel);
            this.appearanceTab.Controls.Add(this.ratingAsImage);
            this.appearanceTab.Location = new System.Drawing.Point(4, 22);
            this.appearanceTab.Margin = new System.Windows.Forms.Padding(2);
            this.appearanceTab.Name = "appearanceTab";
            this.appearanceTab.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.appearanceTab.Size = new System.Drawing.Size(363, 376);
            this.appearanceTab.TabIndex = 0;
            this.appearanceTab.Text = "UI Settings";
            this.appearanceTab.UseVisualStyleBackColor = true;
            // 
            // useCoverImageAsListImage
            // 
            this.useCoverImageAsListImage.AutoSize = true;
            this.useCoverImageAsListImage.Location = new System.Drawing.Point(12, 12);
            this.useCoverImageAsListImage.Name = "useCoverImageAsListImage";
            this.useCoverImageAsListImage.Size = new System.Drawing.Size(295, 17);
            this.useCoverImageAsListImage.TabIndex = 22;
            this.useCoverImageAsListImage.Text = "Display cover images instead of list images next to works";
            this.toolTip.SetToolTip(this.useCoverImageAsListImage, "If checked, a bigger image with 4:3 aspect ratio will be displayed next to works\r" +
                    "\ninstead of the smaller list image");
            this.useCoverImageAsListImage.UseVisualStyleBackColor = true;
            this.useCoverImageAsListImage.CheckedChanged += new System.EventHandler(this.useCoverImageAsListImage_CheckedChanged);
            // 
            // openListFontDialogButton
            // 
            this.openListFontDialogButton.Location = new System.Drawing.Point(126, 129);
            this.openListFontDialogButton.Margin = new System.Windows.Forms.Padding(2);
            this.openListFontDialogButton.Name = "openListFontDialogButton";
            this.openListFontDialogButton.Size = new System.Drawing.Size(112, 25);
            this.openListFontDialogButton.TabIndex = 5;
            this.openListFontDialogButton.Text = "Choose list font...";
            this.openListFontDialogButton.UseVisualStyleBackColor = true;
            this.openListFontDialogButton.Click += new System.EventHandler(this.openListFontDialogButton_Click);
            // 
            // aspectRatioLabel
            // 
            this.aspectRatioLabel.AutoSize = true;
            this.aspectRatioLabel.Location = new System.Drawing.Point(126, 249);
            this.aspectRatioLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.aspectRatioLabel.Name = "aspectRatioLabel";
            this.aspectRatioLabel.Size = new System.Drawing.Size(129, 39);
            this.aspectRatioLabel.TabIndex = 21;
            this.aspectRatioLabel.Text = "Press Enter after entering \r\na value to maintain a\r\n4:3 aspect ratio\r\n";
            // 
            // doubleClickToRun
            // 
            this.doubleClickToRun.AutoSize = true;
            this.doubleClickToRun.Location = new System.Drawing.Point(12, 34);
            this.doubleClickToRun.Name = "doubleClickToRun";
            this.doubleClickToRun.Size = new System.Drawing.Size(180, 17);
            this.doubleClickToRun.TabIndex = 0;
            this.doubleClickToRun.Text = "Double clicking a work will run or open it";
            this.doubleClickToRun.UseVisualStyleBackColor = true;
            // 
            // restoreAppearanceButton
            // 
            this.restoreAppearanceButton.Location = new System.Drawing.Point(13, 310);
            this.restoreAppearanceButton.Margin = new System.Windows.Forms.Padding(2);
            this.restoreAppearanceButton.Name = "restoreAppearanceButton";
            this.restoreAppearanceButton.Size = new System.Drawing.Size(106, 25);
            this.restoreAppearanceButton.TabIndex = 9;
            this.restoreAppearanceButton.Text = "Restore defaults";
            this.restoreAppearanceButton.UseVisualStyleBackColor = true;
            this.restoreAppearanceButton.Click += new System.EventHandler(this.restoreAppearanceButton_Click);
            // 
            // tileImageSizeGroup
            // 
            this.tileImageSizeGroup.Controls.Add(this.tileImageHeight);
            this.tileImageSizeGroup.Controls.Add(this.tileImageWidth);
            this.tileImageSizeGroup.Controls.Add(this.tileImageHeightLabel);
            this.tileImageSizeGroup.Controls.Add(this.tileImageWidthLabel);
            this.tileImageSizeGroup.Location = new System.Drawing.Point(128, 162);
            this.tileImageSizeGroup.Margin = new System.Windows.Forms.Padding(4);
            this.tileImageSizeGroup.Name = "tileImageSizeGroup";
            this.tileImageSizeGroup.Padding = new System.Windows.Forms.Padding(2);
            this.tileImageSizeGroup.Size = new System.Drawing.Size(106, 69);
            this.tileImageSizeGroup.TabIndex = 7;
            this.tileImageSizeGroup.TabStop = false;
            this.tileImageSizeGroup.Text = "Tile image size";
            // 
            // tileImageHeight
            // 
            this.tileImageHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tileImageHeight.Location = new System.Drawing.Point(52, 39);
            this.tileImageHeight.Margin = new System.Windows.Forms.Padding(2);
            this.tileImageHeight.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.tileImageHeight.Name = "tileImageHeight";
            this.tileImageHeight.Size = new System.Drawing.Size(42, 20);
            this.tileImageHeight.TabIndex = 3;
            this.tileImageHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tileImageHeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tileImageHeight_KeyDown);
            // 
            // tileImageWidth
            // 
            this.tileImageWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tileImageWidth.Location = new System.Drawing.Point(52, 17);
            this.tileImageWidth.Margin = new System.Windows.Forms.Padding(2);
            this.tileImageWidth.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.tileImageWidth.Name = "tileImageWidth";
            this.tileImageWidth.Size = new System.Drawing.Size(42, 20);
            this.tileImageWidth.TabIndex = 2;
            this.tileImageWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tileImageWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tileImageWidth_KeyDown);
            // 
            // tileImageHeightLabel
            // 
            this.tileImageHeightLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tileImageHeightLabel.AutoSize = true;
            this.tileImageHeightLabel.Location = new System.Drawing.Point(9, 42);
            this.tileImageHeightLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tileImageHeightLabel.Name = "tileImageHeightLabel";
            this.tileImageHeightLabel.Size = new System.Drawing.Size(41, 13);
            this.tileImageHeightLabel.TabIndex = 1;
            this.tileImageHeightLabel.Text = "Height:";
            // 
            // tileImageWidthLabel
            // 
            this.tileImageWidthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tileImageWidthLabel.AutoSize = true;
            this.tileImageWidthLabel.Location = new System.Drawing.Point(9, 21);
            this.tileImageWidthLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.tileImageWidthLabel.Name = "tileImageWidthLabel";
            this.tileImageWidthLabel.Size = new System.Drawing.Size(38, 13);
            this.tileImageWidthLabel.TabIndex = 0;
            this.tileImageWidthLabel.Text = "Width:";
            // 
            // listImageSizeGroup
            // 
            this.listImageSizeGroup.Controls.Add(this.listImageHeight);
            this.listImageSizeGroup.Controls.Add(this.listImageWidth);
            this.listImageSizeGroup.Controls.Add(this.listImageHeightLabel);
            this.listImageSizeGroup.Controls.Add(this.listImageWidthLabel);
            this.listImageSizeGroup.Location = new System.Drawing.Point(13, 162);
            this.listImageSizeGroup.Margin = new System.Windows.Forms.Padding(4);
            this.listImageSizeGroup.Name = "listImageSizeGroup";
            this.listImageSizeGroup.Padding = new System.Windows.Forms.Padding(2);
            this.listImageSizeGroup.Size = new System.Drawing.Size(106, 69);
            this.listImageSizeGroup.TabIndex = 6;
            this.listImageSizeGroup.TabStop = false;
            this.listImageSizeGroup.Text = "List image size";
            // 
            // listImageHeight
            // 
            this.listImageHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listImageHeight.Location = new System.Drawing.Point(52, 39);
            this.listImageHeight.Margin = new System.Windows.Forms.Padding(2);
            this.listImageHeight.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.listImageHeight.Name = "listImageHeight";
            this.listImageHeight.Size = new System.Drawing.Size(42, 20);
            this.listImageHeight.TabIndex = 3;
            this.listImageHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.listImageHeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listImageHeight_KeyDown);
            // 
            // listImageWidth
            // 
            this.listImageWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listImageWidth.Location = new System.Drawing.Point(52, 17);
            this.listImageWidth.Margin = new System.Windows.Forms.Padding(2);
            this.listImageWidth.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.listImageWidth.Name = "listImageWidth";
            this.listImageWidth.Size = new System.Drawing.Size(42, 20);
            this.listImageWidth.TabIndex = 2;
            this.listImageWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.listImageWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listImageWidth_KeyDown);
            // 
            // listImageHeightLabel
            // 
            this.listImageHeightLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listImageHeightLabel.AutoSize = true;
            this.listImageHeightLabel.Location = new System.Drawing.Point(9, 42);
            this.listImageHeightLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.listImageHeightLabel.Name = "listImageHeightLabel";
            this.listImageHeightLabel.Size = new System.Drawing.Size(41, 13);
            this.listImageHeightLabel.TabIndex = 1;
            this.listImageHeightLabel.Text = "Height:";
            // 
            // listImageWidthLabel
            // 
            this.listImageWidthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listImageWidthLabel.AutoSize = true;
            this.listImageWidthLabel.Location = new System.Drawing.Point(9, 21);
            this.listImageWidthLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.listImageWidthLabel.Name = "listImageWidthLabel";
            this.listImageWidthLabel.Size = new System.Drawing.Size(38, 13);
            this.listImageWidthLabel.TabIndex = 0;
            this.listImageWidthLabel.Text = "Width:";
            // 
            // applyListFontToTiles
            // 
            this.applyListFontToTiles.AutoSize = true;
            this.applyListFontToTiles.Location = new System.Drawing.Point(12, 98);
            this.applyListFontToTiles.Margin = new System.Windows.Forms.Padding(4);
            this.applyListFontToTiles.Name = "applyListFontToTiles";
            this.applyListFontToTiles.Size = new System.Drawing.Size(121, 17);
            this.applyListFontToTiles.TabIndex = 3;
            this.applyListFontToTiles.Text = "Apply list font to tiles";
            this.toolTip.SetToolTip(this.applyListFontToTiles, "If checked, the font selected below will also apply \r\nto game titles when viewing" +
                    " the list in tile view.");
            this.applyListFontToTiles.UseVisualStyleBackColor = true;
            this.applyListFontToTiles.CheckedChanged += new System.EventHandler(this.applyListFontToTiles_CheckedChanged);
            // 
            // wordWrapRowText
            // 
            this.wordWrapRowText.AutoSize = true;
            this.wordWrapRowText.Location = new System.Drawing.Point(12, 77);
            this.wordWrapRowText.Margin = new System.Windows.Forms.Padding(4);
            this.wordWrapRowText.Name = "wordWrapRowText";
            this.wordWrapRowText.Size = new System.Drawing.Size(118, 17);
            this.wordWrapRowText.TabIndex = 2;
            this.wordWrapRowText.Text = "Word wrap row text";
            this.toolTip.SetToolTip(this.wordWrapRowText, "If checked, the text in the title and tags colums may span multiple lines");
            this.wordWrapRowText.UseVisualStyleBackColor = true;
            this.wordWrapRowText.CheckedChanged += new System.EventHandler(this.wordWrapRowText_CheckedChanged);
            // 
            // thumbnailSizeGroup
            // 
            this.thumbnailSizeGroup.Controls.Add(this.thumbnailHeight);
            this.thumbnailSizeGroup.Controls.Add(this.thumbnailWidth);
            this.thumbnailSizeGroup.Controls.Add(this.thumbnailHeightLabel);
            this.thumbnailSizeGroup.Controls.Add(this.thumbnailWidthLabel);
            this.thumbnailSizeGroup.Location = new System.Drawing.Point(12, 236);
            this.thumbnailSizeGroup.Margin = new System.Windows.Forms.Padding(4);
            this.thumbnailSizeGroup.Name = "thumbnailSizeGroup";
            this.thumbnailSizeGroup.Padding = new System.Windows.Forms.Padding(2);
            this.thumbnailSizeGroup.Size = new System.Drawing.Size(106, 69);
            this.thumbnailSizeGroup.TabIndex = 8;
            this.thumbnailSizeGroup.TabStop = false;
            this.thumbnailSizeGroup.Text = "Thumbnail size";
            // 
            // thumbnailHeight
            // 
            this.thumbnailHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.thumbnailHeight.Location = new System.Drawing.Point(52, 39);
            this.thumbnailHeight.Margin = new System.Windows.Forms.Padding(2);
            this.thumbnailHeight.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.thumbnailHeight.Name = "thumbnailHeight";
            this.thumbnailHeight.Size = new System.Drawing.Size(42, 20);
            this.thumbnailHeight.TabIndex = 3;
            this.thumbnailHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.thumbnailHeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thumbnailHeight_KeyDown);
            // 
            // thumbnailWidth
            // 
            this.thumbnailWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.thumbnailWidth.Location = new System.Drawing.Point(52, 17);
            this.thumbnailWidth.Margin = new System.Windows.Forms.Padding(2);
            this.thumbnailWidth.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.thumbnailWidth.Name = "thumbnailWidth";
            this.thumbnailWidth.Size = new System.Drawing.Size(42, 20);
            this.thumbnailWidth.TabIndex = 2;
            this.thumbnailWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.thumbnailWidth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.thumbnailWidth_KeyDown);
            // 
            // thumbnailHeightLabel
            // 
            this.thumbnailHeightLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.thumbnailHeightLabel.AutoSize = true;
            this.thumbnailHeightLabel.Location = new System.Drawing.Point(9, 42);
            this.thumbnailHeightLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.thumbnailHeightLabel.Name = "thumbnailHeightLabel";
            this.thumbnailHeightLabel.Size = new System.Drawing.Size(41, 13);
            this.thumbnailHeightLabel.TabIndex = 1;
            this.thumbnailHeightLabel.Text = "Height:";
            // 
            // thumbnailWidthLabel
            // 
            this.thumbnailWidthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.thumbnailWidthLabel.AutoSize = true;
            this.thumbnailWidthLabel.Location = new System.Drawing.Point(9, 21);
            this.thumbnailWidthLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.thumbnailWidthLabel.Name = "thumbnailWidthLabel";
            this.thumbnailWidthLabel.Size = new System.Drawing.Size(38, 13);
            this.thumbnailWidthLabel.TabIndex = 0;
            this.thumbnailWidthLabel.Text = "Width:";
            // 
            // rowHeight
            // 
            this.rowHeight.Location = new System.Drawing.Point(77, 130);
            this.rowHeight.Margin = new System.Windows.Forms.Padding(1, 4, 4, 4);
            this.rowHeight.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.rowHeight.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.rowHeight.Name = "rowHeight";
            this.rowHeight.Size = new System.Drawing.Size(42, 20);
            this.rowHeight.TabIndex = 4;
            this.rowHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rowHeight.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.rowHeight.ValueChanged += new System.EventHandler(this.rowHeight_ValueChanged);
            // 
            // rowHeightLabel
            // 
            this.rowHeightLabel.AutoSize = true;
            this.rowHeightLabel.Location = new System.Drawing.Point(10, 131);
            this.rowHeightLabel.Margin = new System.Windows.Forms.Padding(4, 4, 1, 4);
            this.rowHeightLabel.Name = "rowHeightLabel";
            this.rowHeightLabel.Size = new System.Drawing.Size(64, 13);
            this.rowHeightLabel.TabIndex = 9;
            this.rowHeightLabel.Text = "Row height:";
            // 
            // ratingAsImage
            // 
            this.ratingAsImage.AutoSize = true;
            this.ratingAsImage.Location = new System.Drawing.Point(12, 55);
            this.ratingAsImage.Margin = new System.Windows.Forms.Padding(4);
            this.ratingAsImage.Name = "ratingAsImage";
            this.ratingAsImage.Size = new System.Drawing.Size(157, 17);
            this.ratingAsImage.TabIndex = 1;
            this.ratingAsImage.Text = "View work\'s rating as images";
            this.ratingAsImage.UseVisualStyleBackColor = true;
            this.ratingAsImage.CheckedChanged += new System.EventHandler(this.ratingAsImage_CheckedChanged);
            // 
            // agthTab
            // 
            this.agthTab.Controls.Add(this.launchWithChiiTrans);
            this.agthTab.Controls.Add(this.chiiTransBox);
            this.agthTab.Controls.Add(this.useHCodeForWolfGames);
            this.agthTab.Controls.Add(this.autoExitTranslator);
            this.agthTab.Controls.Add(this.translatorGroup);
            this.agthTab.Controls.Add(this.agthPathGroup);
            this.agthTab.Controls.Add(this.launchWithAgth);
            this.agthTab.Location = new System.Drawing.Point(4, 22);
            this.agthTab.Margin = new System.Windows.Forms.Padding(2);
            this.agthTab.Name = "agthTab";
            this.agthTab.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.agthTab.Size = new System.Drawing.Size(363, 376);
            this.agthTab.TabIndex = 4;
            this.agthTab.Text = "Translator";
            this.agthTab.UseVisualStyleBackColor = true;
            // 
            // launchWithChiiTrans
            // 
            this.launchWithChiiTrans.AutoSize = true;
            this.launchWithChiiTrans.Location = new System.Drawing.Point(8, 289);
            this.launchWithChiiTrans.Margin = new System.Windows.Forms.Padding(4);
            this.launchWithChiiTrans.Name = "launchWithChiiTrans";
            this.launchWithChiiTrans.Size = new System.Drawing.Size(214, 17);
            this.launchWithChiiTrans.TabIndex = 7;
            this.launchWithChiiTrans.Text = "Launch games with ChiiTrans as default";
            this.launchWithChiiTrans.UseVisualStyleBackColor = true;
            this.launchWithChiiTrans.CheckedChanged += new System.EventHandler(this.launchWithChiiTrans_CheckedChanged);
            // 
            // chiiTransBox
            // 
            this.chiiTransBox.Controls.Add(this.chiiTransPath);
            this.chiiTransBox.Controls.Add(this.chiiTransBrowseButton);
            this.chiiTransBox.Location = new System.Drawing.Point(9, 143);
            this.chiiTransBox.Margin = new System.Windows.Forms.Padding(9, 8, 13, 4);
            this.chiiTransBox.Name = "chiiTransBox";
            this.chiiTransBox.Padding = new System.Windows.Forms.Padding(4, 8, 4, 4);
            this.chiiTransBox.Size = new System.Drawing.Size(327, 55);
            this.chiiTransBox.TabIndex = 6;
            this.chiiTransBox.TabStop = false;
            this.chiiTransBox.Text = "ChiiTrans program path";
            // 
            // chiiTransPath
            // 
            this.chiiTransPath.Location = new System.Drawing.Point(6, 22);
            this.chiiTransPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 8);
            this.chiiTransPath.Name = "chiiTransPath";
            this.chiiTransPath.Size = new System.Drawing.Size(234, 20);
            this.chiiTransPath.TabIndex = 3;
            // 
            // chiiTransBrowseButton
            // 
            this.chiiTransBrowseButton.Location = new System.Drawing.Point(244, 22);
            this.chiiTransBrowseButton.Margin = new System.Windows.Forms.Padding(2);
            this.chiiTransBrowseButton.Name = "chiiTransBrowseButton";
            this.chiiTransBrowseButton.Size = new System.Drawing.Size(68, 22);
            this.chiiTransBrowseButton.TabIndex = 4;
            this.chiiTransBrowseButton.Text = "Browse";
            this.chiiTransBrowseButton.UseVisualStyleBackColor = true;
            this.chiiTransBrowseButton.Click += new System.EventHandler(this.chiiTransBrowseButton_Click);
            // 
            // useHCodeForWolfGames
            // 
            this.useHCodeForWolfGames.AutoSize = true;
            this.useHCodeForWolfGames.Location = new System.Drawing.Point(8, 334);
            this.useHCodeForWolfGames.Name = "useHCodeForWolfGames";
            this.useHCodeForWolfGames.Size = new System.Drawing.Size(235, 17);
            this.useHCodeForWolfGames.TabIndex = 5;
            this.useHCodeForWolfGames.Text = "Use special hook code for Wolf RPG games";
            this.toolTip.SetToolTip(this.useHCodeForWolfGames, resources.GetString("useHCodeForWolfGames.ToolTip"));
            this.useHCodeForWolfGames.UseVisualStyleBackColor = true;
            // 
            // autoExitTranslator
            // 
            this.autoExitTranslator.AutoSize = true;
            this.autoExitTranslator.Location = new System.Drawing.Point(8, 313);
            this.autoExitTranslator.Name = "autoExitTranslator";
            this.autoExitTranslator.Size = new System.Drawing.Size(307, 17);
            this.autoExitTranslator.TabIndex = 4;
            this.autoExitTranslator.Text = "Auto exit the translator program when AGTH/ChiiTrans exits";
            this.autoExitTranslator.UseVisualStyleBackColor = true;
            // 
            // translatorGroup
            // 
            this.translatorGroup.Controls.Add(this.translatorPath);
            this.translatorGroup.Controls.Add(this.translatorBrowseButton);
            this.translatorGroup.Location = new System.Drawing.Point(8, 203);
            this.translatorGroup.Margin = new System.Windows.Forms.Padding(9, 8, 13, 4);
            this.translatorGroup.Name = "translatorGroup";
            this.translatorGroup.Padding = new System.Windows.Forms.Padding(4, 8, 4, 4);
            this.translatorGroup.Size = new System.Drawing.Size(327, 55);
            this.translatorGroup.TabIndex = 2;
            this.translatorGroup.TabStop = false;
            this.translatorGroup.Text = "Translator program path";
            // 
            // translatorPath
            // 
            this.translatorPath.Location = new System.Drawing.Point(6, 22);
            this.translatorPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 8);
            this.translatorPath.Name = "translatorPath";
            this.translatorPath.Size = new System.Drawing.Size(234, 20);
            this.translatorPath.TabIndex = 3;
            // 
            // translatorBrowseButton
            // 
            this.translatorBrowseButton.Location = new System.Drawing.Point(244, 22);
            this.translatorBrowseButton.Margin = new System.Windows.Forms.Padding(2);
            this.translatorBrowseButton.Name = "translatorBrowseButton";
            this.translatorBrowseButton.Size = new System.Drawing.Size(68, 22);
            this.translatorBrowseButton.TabIndex = 4;
            this.translatorBrowseButton.Text = "Browse";
            this.translatorBrowseButton.UseVisualStyleBackColor = true;
            this.translatorBrowseButton.Click += new System.EventHandler(this.translatorBrowseButton_Click);
            // 
            // agthPathGroup
            // 
            this.agthPathGroup.Controls.Add(this.defaultParametersGroup);
            this.agthPathGroup.Controls.Add(this.agthPath);
            this.agthPathGroup.Controls.Add(this.agthBrowseButton);
            this.agthPathGroup.Location = new System.Drawing.Point(8, 8);
            this.agthPathGroup.Margin = new System.Windows.Forms.Padding(9, 8, 13, 4);
            this.agthPathGroup.Name = "agthPathGroup";
            this.agthPathGroup.Padding = new System.Windows.Forms.Padding(4, 8, 4, 4);
            this.agthPathGroup.Size = new System.Drawing.Size(327, 123);
            this.agthPathGroup.TabIndex = 0;
            this.agthPathGroup.TabStop = false;
            this.agthPathGroup.Text = "AGTH path";
            // 
            // defaultParametersGroup
            // 
            this.defaultParametersGroup.Controls.Add(this.agthHelpButton);
            this.defaultParametersGroup.Controls.Add(this.agthDefaultParameters);
            this.defaultParametersGroup.Location = new System.Drawing.Point(9, 56);
            this.defaultParametersGroup.Margin = new System.Windows.Forms.Padding(2);
            this.defaultParametersGroup.Name = "defaultParametersGroup";
            this.defaultParametersGroup.Padding = new System.Windows.Forms.Padding(2);
            this.defaultParametersGroup.Size = new System.Drawing.Size(310, 52);
            this.defaultParametersGroup.TabIndex = 5;
            this.defaultParametersGroup.TabStop = false;
            this.defaultParametersGroup.Text = "Default parameters";
            // 
            // agthHelpButton
            // 
            this.agthHelpButton.Location = new System.Drawing.Point(243, 18);
            this.agthHelpButton.Name = "agthHelpButton";
            this.agthHelpButton.Size = new System.Drawing.Size(54, 22);
            this.agthHelpButton.TabIndex = 24;
            this.agthHelpButton.Text = "Help";
            this.agthHelpButton.UseVisualStyleBackColor = true;
            this.agthHelpButton.Click += new System.EventHandler(this.agthHelpButton_Click);
            // 
            // agthDefaultParameters
            // 
            this.agthDefaultParameters.Location = new System.Drawing.Point(6, 18);
            this.agthDefaultParameters.Name = "agthDefaultParameters";
            this.agthDefaultParameters.Size = new System.Drawing.Size(230, 20);
            this.agthDefaultParameters.TabIndex = 0;
            // 
            // agthPath
            // 
            this.agthPath.Location = new System.Drawing.Point(6, 22);
            this.agthPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 8);
            this.agthPath.Name = "agthPath";
            this.agthPath.Size = new System.Drawing.Size(234, 20);
            this.agthPath.TabIndex = 3;
            // 
            // agthBrowseButton
            // 
            this.agthBrowseButton.Location = new System.Drawing.Point(244, 22);
            this.agthBrowseButton.Margin = new System.Windows.Forms.Padding(2);
            this.agthBrowseButton.Name = "agthBrowseButton";
            this.agthBrowseButton.Size = new System.Drawing.Size(68, 22);
            this.agthBrowseButton.TabIndex = 4;
            this.agthBrowseButton.Text = "Browse";
            this.agthBrowseButton.UseVisualStyleBackColor = true;
            this.agthBrowseButton.Click += new System.EventHandler(this.agthBrowseButton_Click);
            // 
            // launchWithAgth
            // 
            this.launchWithAgth.AutoSize = true;
            this.launchWithAgth.Location = new System.Drawing.Point(8, 266);
            this.launchWithAgth.Margin = new System.Windows.Forms.Padding(4);
            this.launchWithAgth.Name = "launchWithAgth";
            this.launchWithAgth.Size = new System.Drawing.Size(200, 17);
            this.launchWithAgth.TabIndex = 3;
            this.launchWithAgth.Text = "Launch games with AGTH as default";
            this.launchWithAgth.UseVisualStyleBackColor = true;
            this.launchWithAgth.CheckedChanged += new System.EventHandler(this.launchWithAgth_CheckedChanged);
            // 
            // dlSiteTab
            // 
            this.dlSiteTab.Controls.Add(this.rjCodeGroup);
            this.dlSiteTab.Controls.Add(this.downloadTags);
			this.dlSiteTab.Controls.Add(this.downloadReviewTags);
			this.dlSiteTab.Controls.Add(this.downloadHVDBInfo);
			this.dlSiteTab.Controls.Add(this.preferHVDBEnglishTitle);
			this.dlSiteTab.Controls.Add(this.filterCVs);
			this.dlSiteTab.Controls.Add(this.autoSetCategory);
            this.dlSiteTab.Controls.Add(this.downloadAverageRating);
            this.dlSiteTab.Controls.Add(this.gameTitleGroup);
            this.dlSiteTab.Controls.Add(this.downloadSampleImages);
            this.dlSiteTab.Controls.Add(this.downloadCoverImage);
            this.dlSiteTab.Location = new System.Drawing.Point(4, 22);
            this.dlSiteTab.Margin = new System.Windows.Forms.Padding(2);
            this.dlSiteTab.Name = "dlSiteTab";
            this.dlSiteTab.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.dlSiteTab.Size = new System.Drawing.Size(363, 376);
            this.dlSiteTab.TabIndex = 2;
            this.dlSiteTab.Text = "DLSite";
            this.dlSiteTab.UseVisualStyleBackColor = true;
            // 
            // rjCodeGroup
            // 
            this.rjCodeGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rjCodeGroup.Controls.Add(this.lookForRJCodeInPath);
			this.rjCodeGroup.Controls.Add(this.lookForRJCodeInNames);
            this.rjCodeGroup.Controls.Add(this.lookForRJCodeInFile);
            this.rjCodeGroup.Location = new System.Drawing.Point(8, 8);
            this.rjCodeGroup.Margin = new System.Windows.Forms.Padding(9, 8, 9, 4);
            this.rjCodeGroup.Name = "rjCodeGroup";
            this.rjCodeGroup.Padding = new System.Windows.Forms.Padding(4, 8, 4, 4);
            this.rjCodeGroup.Size = new System.Drawing.Size(347, 72);
            this.rjCodeGroup.TabIndex = 0;
            this.rjCodeGroup.TabStop = false;
            this.rjCodeGroup.Text = "RJCode";
            // 
            // lookForRJCodeInPath
            // 
            this.lookForRJCodeInPath.AutoSize = true;
            this.lookForRJCodeInPath.Location = new System.Drawing.Point(9, 15);
            this.lookForRJCodeInPath.Margin = new System.Windows.Forms.Padding(4);
            this.lookForRJCodeInPath.Name = "lookForRJCodeInPath";
            this.lookForRJCodeInPath.Size = new System.Drawing.Size(222, 17);
            this.lookForRJCodeInPath.TabIndex = 4;
            this.lookForRJCodeInPath.Text = "Look for RJCodes in folder paths";
            this.toolTip.SetToolTip(this.lookForRJCodeInPath, "Whenever a new work is added, its path is searched fo" +
                    "r valid RJCodes.\r\nRJ, RE, VJ or BJ followed by four or more digits is considered" +
                    " a valid RJCode.");
            this.lookForRJCodeInPath.UseVisualStyleBackColor = true;
            // 
            // lookForRJCodeInNames
            // 
            this.lookForRJCodeInNames.AutoSize = true;
            this.lookForRJCodeInNames.Location = new System.Drawing.Point(9, 33);
            this.lookForRJCodeInNames.Margin = new System.Windows.Forms.Padding(4);
            this.lookForRJCodeInNames.Name = "lookForRJCodeInNames";
            this.lookForRJCodeInNames.Size = new System.Drawing.Size(222, 17);
            this.lookForRJCodeInNames.TabIndex = 5;
            this.lookForRJCodeInNames.Text = "Look for RJCodes in file and folder names";
            this.toolTip.SetToolTip(this.lookForRJCodeInNames, "Whenever a new work is added, the path of every file in its folder is searched fo" +
                    "r valid RJCodes.\r\nRJ, RE, VJ or BJ followed by four or more digits is considered" +
                    " a valid RJCode.");
            this.lookForRJCodeInNames.UseVisualStyleBackColor = true;
            // 
            // lookForRJCodeInFile
            // 
            this.lookForRJCodeInFile.AutoSize = true;
            this.lookForRJCodeInFile.Location = new System.Drawing.Point(9, 51);
            this.lookForRJCodeInFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 8);
            this.lookForRJCodeInFile.Name = "lookForRJCodeInFile";
            this.lookForRJCodeInFile.Size = new System.Drawing.Size(179, 17);
            this.lookForRJCodeInFile.TabIndex = 6;
            this.lookForRJCodeInFile.Text = "Look for RJCodes inside .txt files";
            this.toolTip.SetToolTip(this.lookForRJCodeInFile, "Whenever a new work is added,  all .txt files in the game\'s directory are opened " +
                    "and searched for valid RJCodes.");
            this.lookForRJCodeInFile.UseVisualStyleBackColor = true;
            // 
            // downloadTags
            // 
            this.downloadTags.AutoSize = true;
            this.downloadTags.Location = new System.Drawing.Point(8, 247);
            this.downloadTags.Margin = new System.Windows.Forms.Padding(4, 4, 4, 8);
            this.downloadTags.Name = "downloadTags";
            this.downloadTags.Size = new System.Drawing.Size(97, 17);
            this.downloadTags.TabIndex = 4;
            this.downloadTags.Text = "Download tags";
            this.downloadTags.UseVisualStyleBackColor = true;
            // 
            // downloadReviewTags
            // 
            this.downloadReviewTags.AutoSize = true;
            this.downloadReviewTags.Location = new System.Drawing.Point(8, 268);
            this.downloadReviewTags.Margin = new System.Windows.Forms.Padding(4, 4, 4, 8);
            this.downloadReviewTags.Name = "downloadReviewTags";
            this.downloadReviewTags.Size = new System.Drawing.Size(97, 17);
            this.downloadReviewTags.TabIndex = 5;
            this.downloadReviewTags.Text = "Download review tags";
            this.downloadReviewTags.UseVisualStyleBackColor = true;
            // 
            // downloadAverageRating
            // 
            this.downloadAverageRating.AutoSize = true;
            this.downloadAverageRating.Location = new System.Drawing.Point(8, 289);
            this.downloadAverageRating.Margin = new System.Windows.Forms.Padding(4, 4, 4, 8);
            this.downloadAverageRating.Name = "downloadAverageRating";
            this.downloadAverageRating.Size = new System.Drawing.Size(145, 17);
            this.downloadAverageRating.TabIndex = 6;
            this.downloadAverageRating.Text = "Download average rating";
            this.toolTip.SetToolTip(this.downloadAverageRating, "The average user score of each game will be automatically received from DLSite.");
            this.downloadAverageRating.UseVisualStyleBackColor = true;
            // 
            // downloadHVDBInfo
            // 
            this.downloadHVDBInfo.AutoSize = true;
            this.downloadHVDBInfo.Location = new System.Drawing.Point(210, 268);
            this.downloadHVDBInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 8);
            this.downloadHVDBInfo.Name = "downloadHVDBInfo";
            this.downloadHVDBInfo.Size = new System.Drawing.Size(97, 17);
            this.downloadHVDBInfo.TabIndex = 8;
            this.downloadHVDBInfo.Text = "Download HVDB info";
            this.downloadHVDBInfo.UseVisualStyleBackColor = true;
            // 
            // preferHVDBEnglishTitle
            // 
            this.preferHVDBEnglishTitle.AutoSize = true;
            this.preferHVDBEnglishTitle.Location = new System.Drawing.Point(210, 310);
            this.preferHVDBEnglishTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 8);
            this.preferHVDBEnglishTitle.Name = "preferHVDBEnglishTitle";
            this.preferHVDBEnglishTitle.Size = new System.Drawing.Size(97, 17);
            this.preferHVDBEnglishTitle.TabIndex = 10;
            this.preferHVDBEnglishTitle.Text = "Prefer HVDB English title";
            this.preferHVDBEnglishTitle.UseVisualStyleBackColor = true;
            // 
            // filterCVs
            // 
            this.filterCVs.AutoSize = true;
            this.filterCVs.Location = new System.Drawing.Point(210, 289);
            this.filterCVs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 8);
            this.filterCVs.Name = "filterCVs";
            this.filterCVs.Size = new System.Drawing.Size(97, 17);
            this.filterCVs.TabIndex = 9;
            this.filterCVs.Text = "Filter CVs";
            this.filterCVs.UseVisualStyleBackColor = true;
            // 
            // autoSetCategory
            // 
            this.autoSetCategory.AutoSize = true;
            this.autoSetCategory.Location = new System.Drawing.Point(8, 310);
            this.autoSetCategory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 8);
            this.autoSetCategory.Name = "autoSetCategory";
            this.autoSetCategory.Size = new System.Drawing.Size(97, 17);
            this.autoSetCategory.TabIndex = 7;
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
            this.gameTitleGroup.Location = new System.Drawing.Point(8, 92);
            this.gameTitleGroup.Margin = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.gameTitleGroup.Name = "gameTitleGroup";
            this.gameTitleGroup.Padding = new System.Windows.Forms.Padding(2);
            this.gameTitleGroup.Size = new System.Drawing.Size(347, 100);
            this.gameTitleGroup.TabIndex = 1;
            this.gameTitleGroup.TabStop = false;
            this.gameTitleGroup.Text = "Download work\'s information from";
            // 
            // useGoogleTranslate
            // 
            this.useGoogleTranslate.AutoSize = true;
            this.useGoogleTranslate.Checked = true;
            this.useGoogleTranslate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useGoogleTranslate.Location = new System.Drawing.Point(4, 74);
            this.useGoogleTranslate.Margin = new System.Windows.Forms.Padding(2);
            this.useGoogleTranslate.Name = "useGoogleTranslate";
            this.useGoogleTranslate.Size = new System.Drawing.Size(301, 17);
            this.useGoogleTranslate.TabIndex = 8;
            this.useGoogleTranslate.Text = "Use Google Translate to translate Japanese titles";
            this.useGoogleTranslate.UseVisualStyleBackColor = true;
            // 
            // useAlternativeDLSiteLanguage
            // 
            this.useAlternativeDLSiteLanguage.AutoSize = true;
            this.useAlternativeDLSiteLanguage.Checked = true;
            this.useAlternativeDLSiteLanguage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useAlternativeDLSiteLanguage.Location = new System.Drawing.Point(4, 52);
            this.useAlternativeDLSiteLanguage.Margin = new System.Windows.Forms.Padding(2);
            this.useAlternativeDLSiteLanguage.Name = "useAlternativeDLSiteLanguage";
            this.useAlternativeDLSiteLanguage.Size = new System.Drawing.Size(312, 17);
            this.useAlternativeDLSiteLanguage.TabIndex = 6;
            this.useAlternativeDLSiteLanguage.Text = "Get title and tags in Japanese if English ones are unavailable";
            this.useAlternativeDLSiteLanguage.UseVisualStyleBackColor = true;
            this.useAlternativeDLSiteLanguage.CheckedChanged += new System.EventHandler(this.useAlternativeDLSiteLanguage_CheckedChanged);
            // 
            // useNeitherDLSite
            // 
            this.useNeitherDLSite.AutoSize = true;
            this.useNeitherDLSite.Location = new System.Drawing.Point(221, 26);
            this.useNeitherDLSite.Margin = new System.Windows.Forms.Padding(2);
            this.useNeitherDLSite.Name = "useNeitherDLSite";
            this.useNeitherDLSite.Size = new System.Drawing.Size(59, 17);
            this.useNeitherDLSite.TabIndex = 2;
            this.useNeitherDLSite.Text = "Neither";
            this.useNeitherDLSite.UseVisualStyleBackColor = true;
            this.useNeitherDLSite.CheckedChanged += new System.EventHandler(this.useNeitherDLSite_CheckedChanged);
            // 
            // useJapaneseDLSite
            // 
            this.useJapaneseDLSite.AutoSize = true;
            this.useJapaneseDLSite.Location = new System.Drawing.Point(106, 26);
            this.useJapaneseDLSite.Margin = new System.Windows.Forms.Padding(2);
            this.useJapaneseDLSite.Name = "useJapaneseDLSite";
            this.useJapaneseDLSite.Size = new System.Drawing.Size(106, 17);
            this.useJapaneseDLSite.TabIndex = 0;
            this.useJapaneseDLSite.Text = "Japanese DLSite";
            this.useJapaneseDLSite.UseVisualStyleBackColor = true;
            this.useJapaneseDLSite.CheckedChanged += new System.EventHandler(this.useJapaneseDLSite_CheckedChanged);
            // 
            // useEnglishDLSite
            // 
            this.useEnglishDLSite.AutoSize = true;
            this.useEnglishDLSite.Checked = true;
            this.useEnglishDLSite.Location = new System.Drawing.Point(4, 26);
            this.useEnglishDLSite.Margin = new System.Windows.Forms.Padding(2);
            this.useEnglishDLSite.Name = "useEnglishDLSite";
            this.useEnglishDLSite.Size = new System.Drawing.Size(94, 17);
            this.useEnglishDLSite.TabIndex = 1;
            this.useEnglishDLSite.TabStop = true;
            this.useEnglishDLSite.Text = "English DLSite";
            this.useEnglishDLSite.UseVisualStyleBackColor = true;
            this.useEnglishDLSite.CheckedChanged += new System.EventHandler(this.useEnglishDLSite_CheckedChanged);
            // 
            // downloadSampleImages
            // 
            this.downloadSampleImages.AutoSize = true;
            this.downloadSampleImages.Checked = true;
            this.downloadSampleImages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.downloadSampleImages.Location = new System.Drawing.Point(8, 226);
            this.downloadSampleImages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 8);
            this.downloadSampleImages.Name = "downloadSampleImages";
            this.downloadSampleImages.Size = new System.Drawing.Size(270, 17);
            this.downloadSampleImages.TabIndex = 3;
            this.downloadSampleImages.Text = "Download the DLSite sample images for each work";
            this.toolTip.SetToolTip(this.downloadSampleImages, "Automatically download and save every work\'s preview image collection.\r\nThis amou" +
                    "nts to ~800 KB per game.");
            this.downloadSampleImages.UseVisualStyleBackColor = true;
            // 
            // downloadCoverImage
            // 
            this.downloadCoverImage.AutoSize = true;
            this.downloadCoverImage.Checked = true;
            this.downloadCoverImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.downloadCoverImage.Location = new System.Drawing.Point(8, 204);
            this.downloadCoverImage.Margin = new System.Windows.Forms.Padding(4);
            this.downloadCoverImage.Name = "downloadCoverImage";
            this.downloadCoverImage.Size = new System.Drawing.Size(259, 17);
            this.downloadCoverImage.TabIndex = 2;
            this.downloadCoverImage.Text = "Download the DLSite cover image for each work";
            this.toolTip.SetToolTip(this.downloadCoverImage, "Automatically download and save every work\'s front page image from DLSite.\r\nThis " +
                    "amounts to ~200 KB per game.");
            this.downloadCoverImage.UseVisualStyleBackColor = true;
            // 
            // performanceTab
            // 
            this.performanceTab.Controls.Add(this.disableGameSizeCalculation);
            this.performanceTab.Controls.Add(this.disableRowHighlighting);
            this.performanceTab.Location = new System.Drawing.Point(4, 22);
            this.performanceTab.Margin = new System.Windows.Forms.Padding(2);
            this.performanceTab.Name = "performanceTab";
            this.performanceTab.Padding = new System.Windows.Forms.Padding(2);
            this.performanceTab.Size = new System.Drawing.Size(363, 376);
            this.performanceTab.TabIndex = 5;
            this.performanceTab.Text = "Performance";
            this.performanceTab.UseVisualStyleBackColor = true;
            // 
            // disableGameSizeCalculation
            // 
            this.disableGameSizeCalculation.AutoSize = true;
            this.disableGameSizeCalculation.Location = new System.Drawing.Point(12, 34);
            this.disableGameSizeCalculation.Margin = new System.Windows.Forms.Padding(4);
            this.disableGameSizeCalculation.Name = "disableGameSizeCalculation";
            this.disableGameSizeCalculation.Size = new System.Drawing.Size(231, 17);
            this.disableGameSizeCalculation.TabIndex = 17;
            this.disableGameSizeCalculation.Text = "Disable automatic calculation of work\'s sizes";
            this.toolTip.SetToolTip(this.disableGameSizeCalculation, "If checked, a work\'s size will not be calculated when it is added.\r\nThis will dec" +
                    "rease the time it takes to add new games.");
            this.disableGameSizeCalculation.UseVisualStyleBackColor = true;
            // 
            // disableRowHighlighting
            // 
            this.disableRowHighlighting.AutoSize = true;
            this.disableRowHighlighting.Location = new System.Drawing.Point(12, 12);
            this.disableRowHighlighting.Margin = new System.Windows.Forms.Padding(4);
            this.disableRowHighlighting.Name = "disableRowHighlighting";
            this.disableRowHighlighting.Size = new System.Drawing.Size(137, 17);
            this.disableRowHighlighting.TabIndex = 16;
            this.disableRowHighlighting.Text = "Disable row highlighting";
            this.toolTip.SetToolTip(this.disableRowHighlighting, "If checked, the list row under the cursor will not be highlighted.\r\nThis may redu" +
                    "ce lag for users with old CPUs.");
            this.disableRowHighlighting.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(217, 415);
            this.okButton.Margin = new System.Windows.Forms.Padding(2);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(79, 23);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(300, 415);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(79, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 20000;
            this.toolTip.InitialDelay = 600;
            this.toolTip.ReshowDelay = 100;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Select a folder containing games";
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Executable File (*.exe)|*.exe|All Files (*.*)|*.*";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(390, 447);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsForm_FormClosed);
            this.tabControl.ResumeLayout(false);
            this.generalTab.ResumeLayout(false);
            this.deleteArchiveGroup.ResumeLayout(false);
            this.deleteArchiveGroup.PerformLayout();
            this.resolutionGroup.ResumeLayout(false);
            this.gameFolderGroup.ResumeLayout(false);
            this.gameFolderGroup.PerformLayout();
			this.renameTemplateGroup.ResumeLayout(false);
			this.renameTemplateGroup.PerformLayout();			
            this.moveGamesGroup.ResumeLayout(false);
            this.moveGamesGroup.PerformLayout();
            this.appearanceTab.ResumeLayout(false);
            this.appearanceTab.PerformLayout();
            this.tileImageSizeGroup.ResumeLayout(false);
            this.tileImageSizeGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tileImageHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileImageWidth)).EndInit();
            this.listImageSizeGroup.ResumeLayout(false);
            this.listImageSizeGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listImageHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listImageWidth)).EndInit();
            this.thumbnailSizeGroup.ResumeLayout(false);
            this.thumbnailSizeGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnailHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnailWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowHeight)).EndInit();
            this.agthTab.ResumeLayout(false);
            this.agthTab.PerformLayout();
            this.chiiTransBox.ResumeLayout(false);
            this.chiiTransBox.PerformLayout();
            this.translatorGroup.ResumeLayout(false);
            this.translatorGroup.PerformLayout();
            this.agthPathGroup.ResumeLayout(false);
            this.agthPathGroup.PerformLayout();
            this.defaultParametersGroup.ResumeLayout(false);
            this.defaultParametersGroup.PerformLayout();
            this.dlSiteTab.ResumeLayout(false);
            this.dlSiteTab.PerformLayout();
            this.rjCodeGroup.ResumeLayout(false);
            this.rjCodeGroup.PerformLayout();
            this.gameTitleGroup.ResumeLayout(false);
            this.gameTitleGroup.PerformLayout();
            this.performanceTab.ResumeLayout(false);
            this.performanceTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TabPage dlSiteTab;
        private System.Windows.Forms.TabPage appearanceTab;
        private System.Windows.Forms.NumericUpDown rowHeight;
        private System.Windows.Forms.CheckBox ratingAsImage;
        private System.Windows.Forms.GroupBox thumbnailSizeGroup;
        private System.Windows.Forms.NumericUpDown thumbnailHeight;
        private System.Windows.Forms.NumericUpDown thumbnailWidth;
        private System.Windows.Forms.Label thumbnailHeightLabel;
        private System.Windows.Forms.Label thumbnailWidthLabel;
        private System.Windows.Forms.Label rowHeightLabel;
        private System.Windows.Forms.CheckBox applyListFontToTiles;
        private System.Windows.Forms.CheckBox wordWrapRowText;
        private System.Windows.Forms.GroupBox listImageSizeGroup;
        private System.Windows.Forms.NumericUpDown listImageHeight;
        private System.Windows.Forms.NumericUpDown listImageWidth;
        private System.Windows.Forms.Label listImageHeightLabel;
        private System.Windows.Forms.Label listImageWidthLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TabPage generalTab;
        private System.Windows.Forms.GroupBox gameFolderGroup;
		private System.Windows.Forms.GroupBox renameTemplateGroup;		
        private System.Windows.Forms.GroupBox moveGamesGroup;
        private System.Windows.Forms.RadioButton askIfMove;
        private System.Windows.Forms.RadioButton neverMove;
        private System.Windows.Forms.RadioButton alwaysMove;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.GroupBox tileImageSizeGroup;
        private System.Windows.Forms.NumericUpDown tileImageHeight;
        private System.Windows.Forms.NumericUpDown tileImageWidth;
        private System.Windows.Forms.Label tileImageHeightLabel;
        private System.Windows.Forms.Label tileImageWidthLabel;
        private System.Windows.Forms.TabPage agthTab;
        private System.Windows.Forms.GroupBox translatorGroup;
        private System.Windows.Forms.Button translatorBrowseButton;
        private System.Windows.Forms.GroupBox agthPathGroup;
        private System.Windows.Forms.GroupBox defaultParametersGroup;
        private System.Windows.Forms.Button agthBrowseButton;
        private System.Windows.Forms.CheckBox launchWithAgth;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.CheckBox autoExitTranslator;
        private System.Windows.Forms.CheckBox useHCodeForWolfGames;
        private System.Windows.Forms.Button agthHelpButton;
        private System.Windows.Forms.Button restoreAppearanceButton;
        private TweakedTextBox gameFolder;
		private TweakedTextBox renameTemplate;
		private System.Windows.Forms.CheckBox renameOrganize;
        private TweakedTextBox translatorPath;
        private TweakedTextBox agthDefaultParameters;
        private TweakedTextBox agthPath;
        private System.Windows.Forms.CheckBox downloadTags;
		private System.Windows.Forms.CheckBox downloadReviewTags;
		private System.Windows.Forms.CheckBox downloadHVDBInfo;
		private System.Windows.Forms.CheckBox preferHVDBEnglishTitle;
		private System.Windows.Forms.CheckBox filterCVs;
		private System.Windows.Forms.CheckBox autoSetCategory;
        private System.Windows.Forms.CheckBox downloadAverageRating;
        private System.Windows.Forms.GroupBox gameTitleGroup;
        private System.Windows.Forms.CheckBox useAlternativeDLSiteLanguage;
        private System.Windows.Forms.RadioButton useNeitherDLSite;
        private System.Windows.Forms.RadioButton useJapaneseDLSite;
        private System.Windows.Forms.RadioButton useEnglishDLSite;
        private System.Windows.Forms.CheckBox downloadSampleImages;
        private System.Windows.Forms.CheckBox downloadCoverImage;
        private System.Windows.Forms.GroupBox resolutionGroup;
        private System.Windows.Forms.ComboBox resolutionList;
        private System.Windows.Forms.GroupBox rjCodeGroup;
        private System.Windows.Forms.CheckBox lookForRJCodeInPath;
		private System.Windows.Forms.CheckBox lookForRJCodeInNames;
        private System.Windows.Forms.CheckBox lookForRJCodeInFile;
        private System.Windows.Forms.GroupBox deleteArchiveGroup;
        private System.Windows.Forms.RadioButton askIfDelete;
        private System.Windows.Forms.RadioButton neverDelete;
        private System.Windows.Forms.RadioButton alwaysDelete;
        private System.Windows.Forms.CheckBox doubleClickToRun;
        private System.Windows.Forms.TabPage performanceTab;
        private System.Windows.Forms.CheckBox disableRowHighlighting;
        private System.Windows.Forms.CheckBox disableGameSizeCalculation;
        private System.Windows.Forms.Label aspectRatioLabel;
        private System.Windows.Forms.Button openListFontDialogButton;
        private System.Windows.Forms.FontDialog listFontDialog;
        private System.Windows.Forms.CheckBox useGoogleTranslate;
        private System.Windows.Forms.CheckBox useCoverImageAsListImage;
        private System.Windows.Forms.RadioButton alwaysRename;
        private System.Windows.Forms.CheckBox launchWithChiiTrans;
        private System.Windows.Forms.GroupBox chiiTransBox;
        private TweakedTextBox chiiTransPath;
        private System.Windows.Forms.Button chiiTransBrowseButton;
    }
}
