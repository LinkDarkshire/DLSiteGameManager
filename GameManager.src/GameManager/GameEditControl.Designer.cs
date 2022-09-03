namespace GameManager {
    partial class GameEditControl {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.tableOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showRjCode = new System.Windows.Forms.ToolStripMenuItem();
            this.showTitle = new System.Windows.Forms.ToolStripMenuItem();
            this.showCircle = new System.Windows.Forms.ToolStripMenuItem();
            this.showCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.showLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.showPath = new System.Windows.Forms.ToolStripMenuItem();
            this.showSize = new System.Windows.Forms.ToolStripMenuItem();
            this.showRating = new System.Windows.Forms.ToolStripMenuItem();
            this.showDlSiteRating = new System.Windows.Forms.ToolStripMenuItem();
            this.showTimesPlayed = new System.Windows.Forms.ToolStripMenuItem();
            this.showTimePlayed = new System.Windows.Forms.ToolStripMenuItem();
            this.showLastPlayed = new System.Windows.Forms.ToolStripMenuItem();
            this.showReleased = new System.Windows.Forms.ToolStripMenuItem();
            this.showTags = new System.Windows.Forms.ToolStripMenuItem();
			this.showHVDBTags = new System.Windows.Forms.ToolStripMenuItem();
			this.showCVs = new System.Windows.Forms.ToolStripMenuItem();
            this.showComments = new System.Windows.Forms.ToolStripMenuItem();
            this.addGameDialog = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer = new GameManager.TweakedSplitContainer();
            this.buttonContainer = new System.Windows.Forms.TableLayoutPanel();
            this.editButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.downloadButton = new System.Windows.Forms.Button();
            this.bottomContainer = new System.Windows.Forms.TableLayoutPanel();
            this.languageBox = new GameManager.TweakedComboBox();
            this.languageLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.categoryBox = new GameManager.TweakedComboBox();
            this.commentsBox = new GameManager.TweakedTextBox();
            this.commentsLabel = new System.Windows.Forms.Label();
            this.sizeContainer = new System.Windows.Forms.TableLayoutPanel();
            this.sizeBox = new GameManager.TweakedTextBox();
            this.updateSize = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.titleBox = new GameManager.TweakedTextBox();
            this.rjCodeBox = new GameManager.TweakedTextBox();
            this.circleHeader = new System.Windows.Forms.Label();
            this.dlsRatingHeader = new System.Windows.Forms.Label();
            this.ratingHeader = new System.Windows.Forms.Label();
            this.rjCodeHeader = new System.Windows.Forms.Label();
            this.titleHeader = new System.Windows.Forms.Label();
            this.circleContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.circleLabel = new System.Windows.Forms.Label();
            this.editCircleButton = new System.Windows.Forms.Button();
            this.rjCodeLabel = new System.Windows.Forms.Label();
            this.dlsRatingImage = new System.Windows.Forms.PictureBox();
            this.ratingImage = new System.Windows.Forms.PictureBox();
            this.commentsHeader = new System.Windows.Forms.Label();
			
            this.tagsHeader = new System.Windows.Forms.Label();
            this.tagsBox = new GameManager.TweakedTextBox();
            this.tagsLabel = new System.Windows.Forms.Label();
			
            this.hvdbtagsHeader = new System.Windows.Forms.Label();
            this.hvdbtagsBox = new GameManager.TweakedTextBox();
            this.hvdbtagsLabel = new System.Windows.Forms.Label();
			
            this.cvsHeader = new System.Windows.Forms.Label();
            this.cvsBox = new GameManager.TweakedTextBox();
            this.cvsLabel = new System.Windows.Forms.Label();
			
            this.timesPlayedHeader = new System.Windows.Forms.Label();
            this.timePlayedHeader = new System.Windows.Forms.Label();
            this.lastPlayedHeader = new System.Windows.Forms.Label();
            this.releasedHeader = new System.Windows.Forms.Label();
            this.pathHeader = new System.Windows.Forms.Label();
            this.pathContainer = new System.Windows.Forms.TableLayoutPanel();
            this.pathBox = new GameManager.TweakedTextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.pathLabel = new System.Windows.Forms.Label();
            this.timesPlayedLabel = new System.Windows.Forms.Label();
            this.timePlayedLabel = new System.Windows.Forms.Label();
            this.lastPlayedLabel = new System.Windows.Forms.Label();
            this.releasedLabel = new System.Windows.Forms.Label();
            this.timesPlayedBox = new System.Windows.Forms.NumericUpDown();
            this.timePlayedBox = new GameManager.TweakedTextBox();
            this.lastPlayedBox = new GameManager.TweakedTextBox();
            this.releasedBox = new GameManager.TweakedTextBox();
            this.sizeHeader = new System.Windows.Forms.Label();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.categoryHeader = new System.Windows.Forms.Label();
            this.languageHeader = new System.Windows.Forms.Label();
            this.imageViewControl = new GameManager.ImageViewControl();
            this.tableOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.buttonContainer.SuspendLayout();
            this.bottomContainer.SuspendLayout();
            this.sizeContainer.SuspendLayout();
            this.circleContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dlsRatingImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratingImage)).BeginInit();
            this.pathContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timesPlayedBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableOptions
            // 
            this.tableOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showRjCode,
            this.showTitle,
            this.showCircle,
            this.showCategory,
            this.showLanguage,
            this.showPath,
            this.showSize,
            this.showRating,
            this.showDlSiteRating,
            this.showTimesPlayed,
            this.showTimePlayed,
            this.showLastPlayed,
            this.showReleased,
            this.showTags,
			this.showHVDBTags,
			this.showCVs,
            this.showComments});
            this.tableOptions.Name = "tableOptions";
            this.tableOptions.ShowCheckMargin = true;
            this.tableOptions.ShowImageMargin = false;
            this.tableOptions.Size = new System.Drawing.Size(169, 386);
            this.tableOptions.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.tableOptions_Closing);
            this.tableOptions.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tableOptions_ItemClicked);
            // 
            // showRjCode
            // 
            this.showRjCode.Name = "showRjCode";
            this.showRjCode.Size = new System.Drawing.Size(168, 24);
            this.showRjCode.Text = "RJCode";
            // 
            // showTitle
            // 
            this.showTitle.Name = "showTitle";
            this.showTitle.Size = new System.Drawing.Size(168, 24);
            this.showTitle.Text = "Title";
            // 
            // showCircle
            // 
            this.showCircle.Name = "showCircle";
            this.showCircle.Size = new System.Drawing.Size(168, 24);
            this.showCircle.Text = "Circle";
            // 
            // showCategory
            // 
            this.showCategory.Name = "showCategory";
            this.showCategory.Size = new System.Drawing.Size(168, 24);
            this.showCategory.Text = "Category";
            // 
            // showLanguage
            // 
            this.showLanguage.Name = "showLanguage";
            this.showLanguage.Size = new System.Drawing.Size(168, 24);
            this.showLanguage.Text = "Language";
            // 
            // showPath
            // 
            this.showPath.Name = "showPath";
            this.showPath.Size = new System.Drawing.Size(168, 24);
            this.showPath.Text = "Path";
            // 
            // showSize
            // 
            this.showSize.Name = "showSize";
            this.showSize.Size = new System.Drawing.Size(168, 24);
            this.showSize.Text = "Size";
            // 
            // showRating
            // 
            this.showRating.Name = "showRating";
            this.showRating.Size = new System.Drawing.Size(168, 24);
            this.showRating.Text = "Rating";
            // 
            // showDlSiteRating
            // 
            this.showDlSiteRating.Name = "showDlSiteRating";
            this.showDlSiteRating.Size = new System.Drawing.Size(168, 24);
            this.showDlSiteRating.Text = "DLSite Rating";
            // 
            // showTimesPlayed
            // 
            this.showTimesPlayed.Name = "showTimesPlayed";
            this.showTimesPlayed.Size = new System.Drawing.Size(168, 24);
            this.showTimesPlayed.Text = "Times Played";
            // 
            // showTimePlayed
            // 
            this.showTimePlayed.Name = "showTimePlayed";
            this.showTimePlayed.Size = new System.Drawing.Size(168, 24);
            this.showTimePlayed.Text = "Time Played";
            // 
            // showLastPlayed
            // 
            this.showLastPlayed.Name = "showLastPlayed";
            this.showLastPlayed.Size = new System.Drawing.Size(168, 24);
            this.showLastPlayed.Text = "Last Played";
            // 
            // showReleased
            // 
            this.showReleased.Name = "showReleased";
            this.showReleased.Size = new System.Drawing.Size(168, 24);
            this.showReleased.Text = "Released";
            // 
            // showTags
            // 
            this.showTags.Name = "showTags";
            this.showTags.Size = new System.Drawing.Size(168, 24);
            this.showTags.Text = "Tags";
            // 
            // showHVDBTags
            // 
            this.showHVDBTags.Name = "showHVDBTags";
            this.showHVDBTags.Size = new System.Drawing.Size(168, 24);
            this.showHVDBTags.Text = "HVDB Tags";
            // 
            // showCVs
            // 
            this.showCVs.Name = "showCVs";
            this.showCVs.Size = new System.Drawing.Size(168, 24);
            this.showCVs.Text = "CVs";
            // 
            // showComments
            // 
            this.showComments.Name = "showComments";
            this.showComments.Size = new System.Drawing.Size(168, 24);
            this.showComments.Text = "Comments";
            // 
            // addGameDialog
            // 
            this.addGameDialog.Filter = "Executable File (*.exe)|*.exe|All Files (*.*)|*.*";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer.Panel1MinSize = 0;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.buttonContainer);
            this.splitContainer.Panel2.Controls.Add(this.bottomContainer);
            this.splitContainer.Panel2.Controls.Add(this.imageViewControl);
            this.splitContainer.Panel2MinSize = 0;
            this.splitContainer.Size = new System.Drawing.Size(455, 985);
            this.splitContainer.SnapToNotches = true;
            this.splitContainer.SpaceBetweenNotches = 4;
            this.splitContainer.SplitterDistance = 25;
            this.splitContainer.SplitterIncrement = 4;
            this.splitContainer.SplitterWidth = 9;
            this.splitContainer.TabIndex = 7;
            this.splitContainer.TabStop = false;
            // 
            // buttonContainer
            // 
            this.buttonContainer.ColumnCount = 3;
            this.buttonContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.buttonContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.buttonContainer.Controls.Add(this.editButton, 2, 0);
            this.buttonContainer.Controls.Add(this.applyButton, 1, 0);
            this.buttonContainer.Controls.Add(this.downloadButton, 0, 0);
            this.buttonContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonContainer.Location = new System.Drawing.Point(0, 555);
            this.buttonContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonContainer.Name = "buttonContainer";
            this.buttonContainer.RowCount = 1;
            this.buttonContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.buttonContainer.Size = new System.Drawing.Size(455, 82);
            this.buttonContainer.TabIndex = 3;
            // 
            // editButton
            // 
            this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editButton.Location = new System.Drawing.Point(381, 2);
            this.editButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(71, 30);
            this.editButton.TabIndex = 3;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.Location = new System.Drawing.Point(304, 2);
            this.applyButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(71, 30);
            this.applyButton.TabIndex = 2;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Visible = false;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(3, 2);
            this.downloadButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(122, 30);
            this.downloadButton.TabIndex = 1;
            this.downloadButton.Text = "Download info";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // bottomContainer
            // 
            this.bottomContainer.AutoSize = true;
            this.bottomContainer.BackColor = System.Drawing.Color.Transparent;
            this.bottomContainer.ColumnCount = 3;
            this.bottomContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97F));
            this.bottomContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.bottomContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.bottomContainer.Controls.Add(this.languageBox, 2, 4);
            this.bottomContainer.Controls.Add(this.languageLabel, 1, 4);
            this.bottomContainer.Controls.Add(this.categoryLabel, 1, 3);
            this.bottomContainer.Controls.Add(this.categoryBox, 2, 3);
            this.bottomContainer.Controls.Add(this.commentsBox, 2, 16);
            this.bottomContainer.Controls.Add(this.commentsLabel, 1, 16);
            this.bottomContainer.Controls.Add(this.sizeContainer, 2, 6);
            this.bottomContainer.Controls.Add(this.titleLabel, 1, 1);
            this.bottomContainer.Controls.Add(this.titleBox, 2, 1);
            this.bottomContainer.Controls.Add(this.rjCodeBox, 2, 0);
            this.bottomContainer.Controls.Add(this.circleHeader, 0, 2);
            this.bottomContainer.Controls.Add(this.dlsRatingHeader, 0, 8);
            this.bottomContainer.Controls.Add(this.ratingHeader, 0, 7);
            this.bottomContainer.Controls.Add(this.rjCodeHeader, 0, 0);
            this.bottomContainer.Controls.Add(this.titleHeader, 0, 1);
            this.bottomContainer.Controls.Add(this.circleContainer, 2, 2);
            this.bottomContainer.Controls.Add(this.rjCodeLabel, 1, 0);
            this.bottomContainer.Controls.Add(this.dlsRatingImage, 1, 8);
            this.bottomContainer.Controls.Add(this.ratingImage, 1, 7);
            this.bottomContainer.Controls.Add(this.commentsHeader, 0, 16);
			
            this.bottomContainer.Controls.Add(this.tagsHeader, 0, 13);
            this.bottomContainer.Controls.Add(this.tagsBox, 2, 13);
            this.bottomContainer.Controls.Add(this.tagsLabel, 1, 13);
			
            this.bottomContainer.Controls.Add(this.hvdbtagsHeader, 0, 14);
            this.bottomContainer.Controls.Add(this.hvdbtagsBox, 2, 14);
            this.bottomContainer.Controls.Add(this.hvdbtagsLabel, 1, 14);
			
            this.bottomContainer.Controls.Add(this.cvsHeader, 0, 15);
            this.bottomContainer.Controls.Add(this.cvsBox, 2, 15);
            this.bottomContainer.Controls.Add(this.cvsLabel, 1, 15);
			
            this.bottomContainer.Controls.Add(this.timesPlayedHeader, 0, 9);
            this.bottomContainer.Controls.Add(this.timePlayedHeader, 0, 10);
            this.bottomContainer.Controls.Add(this.lastPlayedHeader, 0, 11);
            this.bottomContainer.Controls.Add(this.releasedHeader, 0, 12);
            this.bottomContainer.Controls.Add(this.pathHeader, 0, 5);
            this.bottomContainer.Controls.Add(this.pathContainer, 2, 5);
            this.bottomContainer.Controls.Add(this.pathLabel, 1, 5);
            this.bottomContainer.Controls.Add(this.timesPlayedLabel, 1, 9);
            this.bottomContainer.Controls.Add(this.timePlayedLabel, 1, 10);
            this.bottomContainer.Controls.Add(this.lastPlayedLabel, 1, 11);
            this.bottomContainer.Controls.Add(this.releasedLabel, 1, 12);
            this.bottomContainer.Controls.Add(this.timesPlayedBox, 2, 9);
            this.bottomContainer.Controls.Add(this.timePlayedBox, 2, 10);
            this.bottomContainer.Controls.Add(this.lastPlayedBox, 2, 11);
            this.bottomContainer.Controls.Add(this.releasedBox, 2, 12);
            this.bottomContainer.Controls.Add(this.sizeHeader, 0, 6);
            this.bottomContainer.Controls.Add(this.sizeLabel, 1, 6);
            this.bottomContainer.Controls.Add(this.categoryHeader, 0, 3);
            this.bottomContainer.Controls.Add(this.languageHeader, 0, 4);
            this.bottomContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.bottomContainer.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.bottomContainer.Location = new System.Drawing.Point(0, 105);
            this.bottomContainer.Margin = new System.Windows.Forms.Padding(5, 2, 3, 2);
            this.bottomContainer.Name = "bottomContainer";
            this.bottomContainer.RowCount = 17;
            this.bottomContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.bottomContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.bottomContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.bottomContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.bottomContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.bottomContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.bottomContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.bottomContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.bottomContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.bottomContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.bottomContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.bottomContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.bottomContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.bottomContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.bottomContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.bottomContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.bottomContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.bottomContainer.Size = new System.Drawing.Size(455, 450);
            this.bottomContainer.TabIndex = 1;
            // 
            // languageBox
            // 
            this.languageBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.languageBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.languageBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.languageBox.Name = "languageBox";
            this.languageBox.Size = new System.Drawing.Size(173, 24);
            this.languageBox.TabIndex = 5;
            // 
            // languageLabel
            // 
            this.languageLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.languageLabel.AutoEllipsis = true;
            this.languageLabel.Location = new System.Drawing.Point(100, 125);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(0, 20);
            this.languageLabel.TabIndex = 53;
            // 
            // categoryLabel
            // 
            this.categoryLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.categoryLabel.AutoEllipsis = true;
            this.categoryLabel.Location = new System.Drawing.Point(100, 95);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(0, 20);
            this.categoryLabel.TabIndex = 51;
            // 
            // categoryBox
            // 
            this.categoryBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.categoryBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.categoryBox.Location = new System.Drawing.Point(279, 92);
            this.categoryBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.categoryBox.Name = "categoryBox";
            this.categoryBox.Size = new System.Drawing.Size(173, 24);
            this.categoryBox.TabIndex = 4;
            // 
            // commentsBox
            // 
            this.commentsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commentsBox.Location = new System.Drawing.Point(279, 422);
            this.commentsBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.commentsBox.Multiline = true;
            this.commentsBox.Name = "commentsBox";
            this.commentsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.commentsBox.Size = new System.Drawing.Size(173, 26);
            this.commentsBox.TabIndex = 16;
            this.commentsBox.Enter += new System.EventHandler(this.commentsBox_Enter);
            // 
            // commentsLabel
            // 
            this.commentsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.commentsLabel.AutoEllipsis = true;
            this.commentsLabel.Location = new System.Drawing.Point(100, 425);
            this.commentsLabel.Name = "commentsLabel";
            this.commentsLabel.Size = new System.Drawing.Size(0, 20);
            this.commentsLabel.TabIndex = 47;
            // 
            // sizeContainer
            // 
            this.sizeContainer.ColumnCount = 2;
            this.sizeContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.sizeContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.sizeContainer.Controls.Add(this.sizeBox, 0, 0);
            this.sizeContainer.Controls.Add(this.updateSize, 1, 0);
            this.sizeContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sizeContainer.Location = new System.Drawing.Point(276, 180);
            this.sizeContainer.Margin = new System.Windows.Forms.Padding(0);
            this.sizeContainer.Name = "sizeContainer";
            this.sizeContainer.RowCount = 1;
            this.sizeContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.sizeContainer.Size = new System.Drawing.Size(179, 30);
            this.sizeContainer.TabIndex = 6;
            // 
            // sizeBox
            // 
            this.sizeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sizeBox.Location = new System.Drawing.Point(3, 2);
            this.sizeBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sizeBox.Name = "sizeBox";
            this.sizeBox.Size = new System.Drawing.Size(65, 22);
            this.sizeBox.TabIndex = 7;
            // 
            // updateSize
            // 
            this.updateSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.updateSize.AutoSize = true;
            this.updateSize.Location = new System.Drawing.Point(74, 2);
            this.updateSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.updateSize.Name = "updateSize";
            this.updateSize.Size = new System.Drawing.Size(85, 26);
            this.updateSize.TabIndex = 8;
            this.updateSize.Text = "Update";
            this.updateSize.UseVisualStyleBackColor = true;
            this.updateSize.Click += new System.EventHandler(this.updateSize_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            //this.titleLabel.AutoEllipsis = true;
            this.titleLabel.Location = new System.Drawing.Point(100, 35);
			this.titleLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(0, 20);
			this.titleLabel.MaximumSize = new System.Drawing.Size(0, 0);
			this.titleLabel.AutoSize = true;
            this.titleLabel.TabIndex = 13;
            // 
            // titleBox
            // 
            this.titleBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleBox.Location = new System.Drawing.Point(279, 32);
            this.titleBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(173, 22);
            this.titleBox.TabIndex = 2;
            // 
            // rjCodeBox
            // 
            this.rjCodeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rjCodeBox.Location = new System.Drawing.Point(279, 2);
            this.rjCodeBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rjCodeBox.Name = "rjCodeBox";
            this.rjCodeBox.Size = new System.Drawing.Size(173, 22);
            this.rjCodeBox.TabIndex = 1;
            // 
            // circleHeader
            // 
            this.circleHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.circleHeader.AutoSize = true;
            this.circleHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.circleHeader.Location = new System.Drawing.Point(0, 66);
            this.circleHeader.Margin = new System.Windows.Forms.Padding(0);
            this.circleHeader.Name = "circleHeader";
            this.circleHeader.Size = new System.Drawing.Size(43, 17);
            this.circleHeader.TabIndex = 5;
            this.circleHeader.Text = "Circle";
            // 
            // dlsRatingHeader
            // 
            this.dlsRatingHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dlsRatingHeader.AutoSize = true;
            this.dlsRatingHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.dlsRatingHeader.Location = new System.Drawing.Point(0, 246);
            this.dlsRatingHeader.Margin = new System.Windows.Forms.Padding(0);
            this.dlsRatingHeader.Name = "dlsRatingHeader";
            this.dlsRatingHeader.Size = new System.Drawing.Size(80, 17);
            this.dlsRatingHeader.TabIndex = 7;
            this.dlsRatingHeader.Text = "DLS Rating";
            // 
            // ratingHeader
            // 
            this.ratingHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ratingHeader.AutoSize = true;
            this.ratingHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.ratingHeader.Location = new System.Drawing.Point(0, 216);
            this.ratingHeader.Margin = new System.Windows.Forms.Padding(0);
            this.ratingHeader.Name = "ratingHeader";
            this.ratingHeader.Size = new System.Drawing.Size(49, 17);
            this.ratingHeader.TabIndex = 4;
            this.ratingHeader.Text = "Rating";
            // 
            // rjCodeHeader
            // 
            this.rjCodeHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rjCodeHeader.AutoSize = true;
            this.rjCodeHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.rjCodeHeader.Location = new System.Drawing.Point(0, 6);
            this.rjCodeHeader.Margin = new System.Windows.Forms.Padding(0);
            this.rjCodeHeader.Name = "rjCodeHeader";
            this.rjCodeHeader.Size = new System.Drawing.Size(58, 17);
            this.rjCodeHeader.TabIndex = 2;
            this.rjCodeHeader.Text = "RJCode";
            // 
            // titleHeader
            // 
            this.titleHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.titleHeader.AutoSize = true;
            this.titleHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.titleHeader.Location = new System.Drawing.Point(0, 36);
            this.titleHeader.Margin = new System.Windows.Forms.Padding(0);
            this.titleHeader.Name = "titleHeader";
            this.titleHeader.Size = new System.Drawing.Size(35, 17);
            this.titleHeader.TabIndex = 3;
            this.titleHeader.Text = "Title";
            // 
            // circleContainer
            // 
            this.circleContainer.Controls.Add(this.circleLabel);
            this.circleContainer.Controls.Add(this.editCircleButton);
            this.circleContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.circleContainer.Location = new System.Drawing.Point(276, 60);
            this.circleContainer.Margin = new System.Windows.Forms.Padding(0);
            this.circleContainer.Name = "circleContainer";
            this.circleContainer.Size = new System.Drawing.Size(179, 30);
            this.circleContainer.TabIndex = 3;
            this.circleContainer.WrapContents = false;
            // 
            // circleLabel
            // 
            this.circleLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.circleLabel.AutoEllipsis = true;
            this.circleLabel.Location = new System.Drawing.Point(3, 4);
            this.circleLabel.Name = "circleLabel";
            this.circleLabel.Size = new System.Drawing.Size(0, 20);
            this.circleLabel.TabIndex = 0;
            // 
            // editCircleButton
            // 
            this.editCircleButton.Location = new System.Drawing.Point(9, 2);
            this.editCircleButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editCircleButton.Name = "editCircleButton";
            this.editCircleButton.Size = new System.Drawing.Size(53, 25);
            this.editCircleButton.TabIndex = 3;
            this.editCircleButton.Text = "Edit";
            this.editCircleButton.UseVisualStyleBackColor = true;
            this.editCircleButton.Click += new System.EventHandler(this.editCircleButton_Click);
            // 
            // rjCodeLabel
            // 
            this.rjCodeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.rjCodeLabel.AutoEllipsis = true;
            this.rjCodeLabel.Location = new System.Drawing.Point(100, 5);
            this.rjCodeLabel.Name = "rjCodeLabel";
            this.rjCodeLabel.Size = new System.Drawing.Size(0, 20);
            this.rjCodeLabel.TabIndex = 12;
            // 
            // dlsRatingImage
            // 
            this.dlsRatingImage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dlsRatingImage.Location = new System.Drawing.Point(97, 244);
            this.dlsRatingImage.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.dlsRatingImage.Name = "dlsRatingImage";
            this.dlsRatingImage.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.dlsRatingImage.Size = new System.Drawing.Size(127, 24);
            this.dlsRatingImage.TabIndex = 19;
            this.dlsRatingImage.TabStop = false;
            // 
            // ratingImage
            // 
            this.ratingImage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ratingImage.Location = new System.Drawing.Point(97, 214);
            this.ratingImage.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.ratingImage.Name = "ratingImage";
            this.ratingImage.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.ratingImage.Size = new System.Drawing.Size(127, 24);
            this.ratingImage.TabIndex = 18;
            this.ratingImage.TabStop = false;
            // 
            // commentsHeader
            // 
            this.commentsHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.commentsHeader.AutoSize = true;
            this.commentsHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.commentsHeader.Location = new System.Drawing.Point(0, 426);
            this.commentsHeader.Margin = new System.Windows.Forms.Padding(0);
            this.commentsHeader.Name = "commentsHeader";
            this.commentsHeader.Size = new System.Drawing.Size(74, 17);
            this.commentsHeader.TabIndex = 25;
            this.commentsHeader.Text = "Comments";
            // 
            // tagsHeader
            // 
            this.tagsHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tagsHeader.AutoSize = true;
            this.tagsHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.tagsHeader.Location = new System.Drawing.Point(0, 396);
            this.tagsHeader.Margin = new System.Windows.Forms.Padding(0);
            this.tagsHeader.Name = "tagsHeader";
            this.tagsHeader.Size = new System.Drawing.Size(40, 17);
            this.tagsHeader.TabIndex = 6;
            this.tagsHeader.Text = "Tags";
            // 
            // tagsBox
            // 
            this.tagsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagsBox.Location = new System.Drawing.Point(279, 392);
            this.tagsBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tagsBox.Multiline = true;
            this.tagsBox.Name = "tagsBox";
            this.tagsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tagsBox.Size = new System.Drawing.Size(173, 26);
            this.tagsBox.TabIndex = 15;
            this.tagsBox.Enter += new System.EventHandler(this.tagsBox_Enter);
            // 
            // tagsLabel
            // 
            this.tagsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            //this.tagsLabel.AutoEllipsis = true;
            this.tagsLabel.Location = new System.Drawing.Point(100, 395);
			this.tagsLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tagsLabel.Name = "tagsLabel";
            this.tagsLabel.Size = new System.Drawing.Size(0, 20);
			this.tagsLabel.MaximumSize = new System.Drawing.Size(0, 0);
			this.tagsLabel.AutoSize = true;
            this.tagsLabel.TabIndex = 17;
            // 
            // hvdbtagsHeader
            // 
            this.hvdbtagsHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hvdbtagsHeader.AutoSize = true;
            this.hvdbtagsHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.hvdbtagsHeader.Location = new System.Drawing.Point(0, 396);
            this.hvdbtagsHeader.Margin = new System.Windows.Forms.Padding(0);
            this.hvdbtagsHeader.Name = "hvdbtagsHeader";
            this.hvdbtagsHeader.Size = new System.Drawing.Size(40, 17);
            this.hvdbtagsHeader.TabIndex = 6;
            this.hvdbtagsHeader.Text = "HVDB Tags";
            // 
            // hvdbtagsBox
            // 
            this.hvdbtagsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hvdbtagsBox.Location = new System.Drawing.Point(279, 392);
            this.hvdbtagsBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hvdbtagsBox.Multiline = true;
            this.hvdbtagsBox.Name = "hvdbtagsBox";
            this.hvdbtagsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.hvdbtagsBox.Size = new System.Drawing.Size(173, 26);
            this.hvdbtagsBox.TabIndex = 15;
            this.hvdbtagsBox.Enter += new System.EventHandler(this.hvdbtagsBox_Enter);
            // 
            // hvdbtagsLabel
            // 
            this.hvdbtagsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            //this.hvdbtagsLabel.AutoEllipsis = true;
            this.hvdbtagsLabel.Location = new System.Drawing.Point(100, 395);
			this.hvdbtagsLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hvdbtagsLabel.Name = "hvdbtagsLabel";
            this.hvdbtagsLabel.Size = new System.Drawing.Size(0, 20);
			this.hvdbtagsLabel.MaximumSize = new System.Drawing.Size(0, 0);
			this.hvdbtagsLabel.AutoSize = true;
            this.hvdbtagsLabel.TabIndex = 17;
            // 
            // cvsHeader
            // 
            this.cvsHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cvsHeader.AutoSize = true;
            this.cvsHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.cvsHeader.Location = new System.Drawing.Point(0, 396);
            this.cvsHeader.Margin = new System.Windows.Forms.Padding(0);
            this.cvsHeader.Name = "cvsHeader";
            this.cvsHeader.Size = new System.Drawing.Size(40, 17);
            this.cvsHeader.TabIndex = 6;
            this.cvsHeader.Text = "CVs";
            // 
            // cvsBox
            // 
            this.cvsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cvsBox.Location = new System.Drawing.Point(279, 392);
            this.cvsBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cvsBox.Multiline = true;
            this.cvsBox.Name = "cvsBox";
            this.cvsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.cvsBox.Size = new System.Drawing.Size(173, 26);
            this.cvsBox.TabIndex = 15;
            this.cvsBox.Enter += new System.EventHandler(this.cvsBox_Enter);
            // 
            // cvsLabel
            // 
            this.cvsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            //this.cvsLabel.AutoEllipsis = true;
            this.cvsLabel.Location = new System.Drawing.Point(100, 395);
			this.cvsLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cvsLabel.Name = "cvsLabel";
            this.cvsLabel.Size = new System.Drawing.Size(0, 20);
			this.cvsLabel.MaximumSize = new System.Drawing.Size(0, 0);
			this.cvsLabel.AutoSize = true;
            this.cvsLabel.TabIndex = 17;
            // 
            // timesPlayedHeader
            // 
            this.timesPlayedHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.timesPlayedHeader.AutoSize = true;
            this.timesPlayedHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.timesPlayedHeader.Location = new System.Drawing.Point(0, 276);
            this.timesPlayedHeader.Margin = new System.Windows.Forms.Padding(0);
            this.timesPlayedHeader.Name = "timesPlayedHeader";
            this.timesPlayedHeader.Size = new System.Drawing.Size(93, 17);
            this.timesPlayedHeader.TabIndex = 22;
            this.timesPlayedHeader.Text = "Times Played";
            // 
            // timePlayedHeader
            // 
            this.timePlayedHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.timePlayedHeader.AutoSize = true;
            this.timePlayedHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.timePlayedHeader.Location = new System.Drawing.Point(0, 306);
            this.timePlayedHeader.Margin = new System.Windows.Forms.Padding(0);
            this.timePlayedHeader.Name = "timePlayedHeader";
            this.timePlayedHeader.Size = new System.Drawing.Size(86, 17);
            this.timePlayedHeader.TabIndex = 23;
            this.timePlayedHeader.Text = "Time Played";
            // 
            // lastPlayedHeader
            // 
            this.lastPlayedHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lastPlayedHeader.AutoSize = true;
            this.lastPlayedHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lastPlayedHeader.Location = new System.Drawing.Point(0, 336);
            this.lastPlayedHeader.Margin = new System.Windows.Forms.Padding(0);
            this.lastPlayedHeader.Name = "lastPlayedHeader";
            this.lastPlayedHeader.Size = new System.Drawing.Size(82, 17);
            this.lastPlayedHeader.TabIndex = 24;
            this.lastPlayedHeader.Text = "Last Played";
            // 
            // releasedHeader
            // 
            this.releasedHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.releasedHeader.AutoSize = true;
            this.releasedHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.releasedHeader.Location = new System.Drawing.Point(0, 366);
            this.releasedHeader.Margin = new System.Windows.Forms.Padding(0);
            this.releasedHeader.Name = "releasedHeader";
            this.releasedHeader.Size = new System.Drawing.Size(68, 17);
            this.releasedHeader.TabIndex = 26;
            this.releasedHeader.Text = "Released";
            // 
            // pathHeader
            // 
            this.pathHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pathHeader.AutoSize = true;
            this.pathHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.pathHeader.Location = new System.Drawing.Point(0, 156);
            this.pathHeader.Margin = new System.Windows.Forms.Padding(0);
            this.pathHeader.Name = "pathHeader";
            this.pathHeader.Size = new System.Drawing.Size(37, 17);
            this.pathHeader.TabIndex = 27;
            this.pathHeader.Text = "Path";
            // 
            // pathContainer
            // 
            this.pathContainer.ColumnCount = 2;
            this.pathContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.pathContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.pathContainer.Controls.Add(this.pathBox, 0, 0);
            this.pathContainer.Controls.Add(this.browseButton, 1, 0);
            this.pathContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathContainer.Location = new System.Drawing.Point(276, 150);
            this.pathContainer.Margin = new System.Windows.Forms.Padding(0);
            this.pathContainer.Name = "pathContainer";
            this.pathContainer.RowCount = 1;
            this.pathContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pathContainer.Size = new System.Drawing.Size(179, 30);
            this.pathContainer.TabIndex = 5;
            // 
            // pathBox
            // 
            this.pathBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathBox.Location = new System.Drawing.Point(3, 2);
            this.pathBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(119, 22);
            this.pathBox.TabIndex = 5;
            // 
            // browseButton
            // 
            this.browseButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.browseButton.AutoSize = true;
            this.browseButton.Location = new System.Drawing.Point(128, 2);
            this.browseButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(48, 26);
            this.browseButton.TabIndex = 6;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // pathLabel
            // 
            this.pathLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            //this.pathLabel.AutoEllipsis = true;
            this.pathLabel.Location = new System.Drawing.Point(100, 155);
			this.pathLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(0, 20);
			this.pathLabel.MaximumSize = new System.Drawing.Size(0, 0);
			this.pathLabel.AutoSize = true;
            this.pathLabel.TabIndex = 29;
            // 
            // timesPlayedLabel
            // 
            this.timesPlayedLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.timesPlayedLabel.AutoEllipsis = true;
            this.timesPlayedLabel.Location = new System.Drawing.Point(100, 275);
            this.timesPlayedLabel.Name = "timesPlayedLabel";
            this.timesPlayedLabel.Size = new System.Drawing.Size(0, 20);
            this.timesPlayedLabel.TabIndex = 30;
            // 
            // timePlayedLabel
            // 
            this.timePlayedLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.timePlayedLabel.AutoEllipsis = true;
            this.timePlayedLabel.Location = new System.Drawing.Point(100, 305);
            this.timePlayedLabel.Name = "timePlayedLabel";
            this.timePlayedLabel.Size = new System.Drawing.Size(0, 20);
            this.timePlayedLabel.TabIndex = 31;
            // 
            // lastPlayedLabel
            // 
            this.lastPlayedLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lastPlayedLabel.AutoEllipsis = true;
            this.lastPlayedLabel.Location = new System.Drawing.Point(100, 335);
            this.lastPlayedLabel.Name = "lastPlayedLabel";
            this.lastPlayedLabel.Size = new System.Drawing.Size(0, 20);
            this.lastPlayedLabel.TabIndex = 32;
            // 
            // releasedLabel
            // 
            this.releasedLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.releasedLabel.AutoEllipsis = true;
            this.releasedLabel.Location = new System.Drawing.Point(100, 365);
            this.releasedLabel.Name = "releasedLabel";
            this.releasedLabel.Size = new System.Drawing.Size(0, 20);
            this.releasedLabel.TabIndex = 33;
            // 
            // timesPlayedBox
            // 
            this.timesPlayedBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.timesPlayedBox.Location = new System.Drawing.Point(279, 276);
            this.timesPlayedBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.timesPlayedBox.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.timesPlayedBox.Name = "timesPlayedBox";
            this.timesPlayedBox.Size = new System.Drawing.Size(64, 22);
            this.timesPlayedBox.TabIndex = 11;
            // 
            // timePlayedBox
            // 
            this.timePlayedBox.Location = new System.Drawing.Point(279, 302);
            this.timePlayedBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.timePlayedBox.Name = "timePlayedBox";
            this.timePlayedBox.Size = new System.Drawing.Size(87, 22);
            this.timePlayedBox.TabIndex = 12;
            // 
            // lastPlayedBox
            // 
            this.lastPlayedBox.Location = new System.Drawing.Point(279, 332);
            this.lastPlayedBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lastPlayedBox.Name = "lastPlayedBox";
            this.lastPlayedBox.Size = new System.Drawing.Size(152, 22);
            this.lastPlayedBox.TabIndex = 13;
            // 
            // releasedBox
            // 
            this.releasedBox.Location = new System.Drawing.Point(279, 362);
            this.releasedBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.releasedBox.Name = "releasedBox";
            this.releasedBox.Size = new System.Drawing.Size(152, 22);
            this.releasedBox.TabIndex = 14;
            // 
            // sizeHeader
            // 
            this.sizeHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.sizeHeader.AutoSize = true;
            this.sizeHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.sizeHeader.Location = new System.Drawing.Point(0, 186);
            this.sizeHeader.Margin = new System.Windows.Forms.Padding(0);
            this.sizeHeader.Name = "sizeHeader";
            this.sizeHeader.Size = new System.Drawing.Size(35, 17);
            this.sizeHeader.TabIndex = 44;
            this.sizeHeader.Text = "Size";
            // 
            // sizeLabel
            // 
            this.sizeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.sizeLabel.AutoEllipsis = true;
            this.sizeLabel.Location = new System.Drawing.Point(100, 185);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(0, 20);
            this.sizeLabel.TabIndex = 45;
            // 
            // categoryHeader
            // 
            this.categoryHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.categoryHeader.AutoSize = true;
            this.categoryHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.categoryHeader.Location = new System.Drawing.Point(0, 96);
            this.categoryHeader.Margin = new System.Windows.Forms.Padding(0);
            this.categoryHeader.Name = "categoryHeader";
            this.categoryHeader.Size = new System.Drawing.Size(65, 17);
            this.categoryHeader.TabIndex = 49;
            this.categoryHeader.Text = "Category";
            // 
            // languageHeader
            // 
            this.languageHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.languageHeader.AutoSize = true;
            this.languageHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.languageHeader.Location = new System.Drawing.Point(0, 126);
            this.languageHeader.Margin = new System.Windows.Forms.Padding(0);
            this.languageHeader.Name = "languageHeader";
            this.languageHeader.Size = new System.Drawing.Size(72, 17);
            this.languageHeader.TabIndex = 52;
            this.languageHeader.Text = "Language";
            // 
            // imageViewControl
            // 
            this.imageViewControl.BackColor = System.Drawing.Color.Transparent;
            this.imageViewControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.imageViewControl.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.imageViewControl.Location = new System.Drawing.Point(0, 0);
            this.imageViewControl.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.imageViewControl.Name = "imageViewControl";
            this.imageViewControl.Size = new System.Drawing.Size(455, 105);
            this.imageViewControl.TabIndex = 0;
            this.imageViewControl.TabStop = false;
            this.imageViewControl.ImageCollectionAltered += new System.EventHandler<GameManager.ImageViewControl.ImageCollectionAlteredEventArgs>(this.imageViewControl_ImageCollectionAltered);
            // 
            // GameEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ContextMenuStrip = this.tableOptions;
            this.Controls.Add(this.splitContainer);
            this.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.Name = "GameEditControl";
            this.Size = new System.Drawing.Size(455, 985);
            this.Load += new System.EventHandler(this.GameEditControl_Load);
            this.SizeChanged += new System.EventHandler(this.GameEditControl_SizeChanged);
            this.tableOptions.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.buttonContainer.ResumeLayout(false);
            this.bottomContainer.ResumeLayout(false);
            this.bottomContainer.PerformLayout();
            this.sizeContainer.ResumeLayout(false);
            this.sizeContainer.PerformLayout();
            this.circleContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dlsRatingImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratingImage)).EndInit();
            this.pathContainer.ResumeLayout(false);
            this.pathContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timesPlayedBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel bottomContainer;
        private System.Windows.Forms.Label rjCodeHeader;
        private System.Windows.Forms.Label titleHeader;
        private System.Windows.Forms.Label ratingHeader;
        private System.Windows.Forms.Label circleHeader;
        private System.Windows.Forms.Label dlsRatingHeader;
        private System.Windows.Forms.Label tagsHeader;
		private System.Windows.Forms.Label hvdbtagsHeader;
		private System.Windows.Forms.Label cvsHeader;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label rjCodeLabel;
        private System.Windows.Forms.Label tagsLabel;
		private System.Windows.Forms.Label hvdbtagsLabel;
		private System.Windows.Forms.Label cvsLabel;
        private System.Windows.Forms.PictureBox ratingImage;
        private System.Windows.Forms.PictureBox dlsRatingImage;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.TableLayoutPanel buttonContainer;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button editCircleButton;
        private System.Windows.Forms.FlowLayoutPanel circleContainer;
        private System.Windows.Forms.Label circleLabel;
        private System.Windows.Forms.Button downloadButton;
        private ImageViewControl imageViewControl;
        private TweakedSplitContainer splitContainer;
        private System.Windows.Forms.ContextMenuStrip tableOptions;
        private System.Windows.Forms.ToolStripMenuItem showRjCode;
        private System.Windows.Forms.ToolStripMenuItem showTitle;
        private System.Windows.Forms.ToolStripMenuItem showCircle;
        private System.Windows.Forms.ToolStripMenuItem showRating;
        private System.Windows.Forms.ToolStripMenuItem showTimesPlayed;
        private System.Windows.Forms.ToolStripMenuItem showTimePlayed;
        private System.Windows.Forms.ToolStripMenuItem showDlSiteRating;
        private System.Windows.Forms.ToolStripMenuItem showLastPlayed;
        private System.Windows.Forms.ToolStripMenuItem showReleased;
        private System.Windows.Forms.ToolStripMenuItem showTags;
		private System.Windows.Forms.ToolStripMenuItem showHVDBTags;
		private System.Windows.Forms.ToolStripMenuItem showCVs;
        private System.Windows.Forms.ToolStripMenuItem showComments;
        private System.Windows.Forms.Label commentsHeader;
        private System.Windows.Forms.Label timesPlayedHeader;
        private System.Windows.Forms.Label timePlayedHeader;
        private System.Windows.Forms.Label lastPlayedHeader;
        private System.Windows.Forms.Label releasedHeader;
        private System.Windows.Forms.Label pathHeader;
        private System.Windows.Forms.ToolStripMenuItem showPath;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TableLayoutPanel pathContainer;
        private System.Windows.Forms.OpenFileDialog addGameDialog;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Label timesPlayedLabel;
        private System.Windows.Forms.Label timePlayedLabel;
        private System.Windows.Forms.Label lastPlayedLabel;
        private System.Windows.Forms.Label releasedLabel;
        private System.Windows.Forms.NumericUpDown timesPlayedBox;
        private System.Windows.Forms.TableLayoutPanel sizeContainer;
        private System.Windows.Forms.Button updateSize;
        private System.Windows.Forms.Label sizeHeader;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.ToolStripMenuItem showSize;
        private System.Windows.Forms.Label commentsLabel;
        private TweakedTextBox titleBox;
        private TweakedTextBox rjCodeBox;
        private TweakedTextBox tagsBox;
		private TweakedTextBox hvdbtagsBox;
		private TweakedTextBox cvsBox;
        private TweakedTextBox pathBox;
        private TweakedTextBox timePlayedBox;
        private TweakedTextBox lastPlayedBox;
        private TweakedTextBox releasedBox;
        private TweakedTextBox sizeBox;
        private TweakedTextBox commentsBox;
        private System.Windows.Forms.ToolStripMenuItem showCategory;
        private System.Windows.Forms.Label categoryLabel;
        private TweakedComboBox categoryBox;
        private System.Windows.Forms.Label categoryHeader;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.Label languageHeader;
        private TweakedComboBox languageBox;
        private System.Windows.Forms.ToolStripMenuItem showLanguage;

    }
}
