namespace GameManager {
    partial class MainForm {
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
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle1 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle2 = new BrightIdeasSoftware.HeaderStateStyle();
            BrightIdeasSoftware.HeaderStateStyle headerStateStyle3 = new BrightIdeasSoftware.HeaderStateStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInExplorerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openEngDLSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openJpDLSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openHVDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.filterOnCircleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.translateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updatePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameWorksFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.extractCgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addGamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.extractCgGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.findDuplicatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.viewSearchBar = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.extractionFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.addGameDialog = new System.Windows.Forms.OpenFileDialog();
            this.headerFormatStyle = new BrightIdeasSoftware.HeaderFormatStyle();
            this.splitContainer = new GameManager.TweakedSplitContainer();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonLibary = new System.Windows.Forms.Button();
            this.buttonNewGames = new System.Windows.Forms.Button();
            this.searchBar = new GameManager.SearchBar();
            this.gameList = new BrightIdeasSoftware.ObjectListView();
            this.imageColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.rjCodeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.titleColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.circleColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cvsColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.categoryColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.languageColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ratingColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.dlSiteRatingColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.sizeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.timesPlayedColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.timePlayedColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.lastPlayedColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.releasedColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.addedColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tagsColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.hvdbtagsColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.commentsColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.gameEditControl = new GameManager.GameEditControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.contextMenuStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameList)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.openInExplorerMenuItem,
            this.toolStripSeparator1,
            this.openEngDLSiteToolStripMenuItem,
            this.openJpDLSiteToolStripMenuItem,
            this.openHVDBToolStripMenuItem,
            this.toolStripSeparator2,
            this.filterOnCircleToolStripMenuItem,
            this.toolStripSeparator6,
            this.translateToolStripMenuItem,
            this.updatePathToolStripMenuItem,
            this.renameWorksFolderToolStripMenuItem,
            this.downloadInfoToolStripMenuItem,
            this.toolStripSeparator3,
            this.extractCgToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.toolStripSeparator4,
            this.propertiesToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(236, 320);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // openInExplorerMenuItem
            // 
            this.openInExplorerMenuItem.Name = "openInExplorerMenuItem";
            this.openInExplorerMenuItem.Size = new System.Drawing.Size(235, 22);
            this.openInExplorerMenuItem.Text = "Open Containing Folder";
            this.openInExplorerMenuItem.Click += new System.EventHandler(this.openInExplorerMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(232, 6);
            // 
            // openEngDLSiteToolStripMenuItem
            // 
            this.openEngDLSiteToolStripMenuItem.Name = "openEngDLSiteToolStripMenuItem";
            this.openEngDLSiteToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.openEngDLSiteToolStripMenuItem.Text = "Open English DLSite";
            this.openEngDLSiteToolStripMenuItem.Click += new System.EventHandler(this.openEngDLSiteToolStripMenuItem_Click);
            // 
            // openJpDLSiteToolStripMenuItem
            // 
            this.openJpDLSiteToolStripMenuItem.Name = "openJpDLSiteToolStripMenuItem";
            this.openJpDLSiteToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.openJpDLSiteToolStripMenuItem.Text = "Open Japanese DLSite";
            this.openJpDLSiteToolStripMenuItem.Click += new System.EventHandler(this.openJpDLSiteToolStripMenuItem_Click);
            // 
            // openHVDBToolStripMenuItem
            // 
            this.openHVDBToolStripMenuItem.Name = "openHVDBToolStripMenuItem";
            this.openHVDBToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.openHVDBToolStripMenuItem.Text = "Open HVDB Page";
            this.openHVDBToolStripMenuItem.Click += new System.EventHandler(this.openHVDBToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(232, 6);
            // 
            // filterOnCircleToolStripMenuItem
            // 
            this.filterOnCircleToolStripMenuItem.Name = "filterOnCircleToolStripMenuItem";
            this.filterOnCircleToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.filterOnCircleToolStripMenuItem.Text = "Filter on circle";
            this.filterOnCircleToolStripMenuItem.Click += new System.EventHandler(this.filterOnCircleToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(232, 6);
            // 
            // translateToolStripMenuItem
            // 
            this.translateToolStripMenuItem.Name = "translateToolStripMenuItem";
            this.translateToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.translateToolStripMenuItem.Text = "Translate title";
            this.translateToolStripMenuItem.Click += new System.EventHandler(this.translateToolStripMenuItem_Click);
            // 
            // updatePathToolStripMenuItem
            // 
            this.updatePathToolStripMenuItem.Name = "updatePathToolStripMenuItem";
            this.updatePathToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.updatePathToolStripMenuItem.Text = "Update path";
            this.updatePathToolStripMenuItem.Click += new System.EventHandler(this.updatePathToolStripMenuItem_Click);
            // 
            // renameWorksFolderToolStripMenuItem
            // 
            this.renameWorksFolderToolStripMenuItem.Name = "renameWorksFolderToolStripMenuItem";
            this.renameWorksFolderToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.renameWorksFolderToolStripMenuItem.Text = "Rename/Organize by template";
            this.renameWorksFolderToolStripMenuItem.Click += new System.EventHandler(this.renameWorksFolderToolStripMenuItem_Click);
            // 
            // downloadInfoToolStripMenuItem
            // 
            this.downloadInfoToolStripMenuItem.Name = "downloadInfoToolStripMenuItem";
            this.downloadInfoToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.downloadInfoToolStripMenuItem.Text = "Download info";
            this.downloadInfoToolStripMenuItem.Click += new System.EventHandler(this.downloadInfoToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(232, 6);
            // 
            // extractCgToolStripMenuItem
            // 
            this.extractCgToolStripMenuItem.Name = "extractCgToolStripMenuItem";
            this.extractCgToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.extractCgToolStripMenuItem.Text = "Extract CG";
            this.extractCgToolStripMenuItem.Click += new System.EventHandler(this.extractCgToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeFromListToolStripMenuItem,
            this.removeFromDiskToolStripMenuItem});
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            // 
            // removeFromListToolStripMenuItem
            // 
            this.removeFromListToolStripMenuItem.Name = "removeFromListToolStripMenuItem";
            this.removeFromListToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.removeFromListToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.removeFromListToolStripMenuItem.Text = "From List";
            this.removeFromListToolStripMenuItem.Click += new System.EventHandler(this.removeFromListToolStripMenuItem_Click);
            // 
            // removeFromDiskToolStripMenuItem
            // 
            this.removeFromDiskToolStripMenuItem.Name = "removeFromDiskToolStripMenuItem";
            this.removeFromDiskToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Delete)));
            this.removeFromDiskToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.removeFromDiskToolStripMenuItem.Text = "From Disk";
            this.removeFromDiskToolStripMenuItem.Click += new System.EventHandler(this.removeFromDiskToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(232, 6);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 710);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(1233, 24);
            this.menuStrip.TabIndex = 2;
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addGameToolStripMenuItem,
            this.addGamesToolStripMenuItem,
            this.toolStripSeparator7,
            this.extractCgGameToolStripMenuItem,
            this.toolStripSeparator8,
            this.findDuplicatesToolStripMenuItem,
            this.toolStripSeparator9,
            this.exitToolStripMenuItem});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.actionToolStripMenuItem.Text = "Action";
            // 
            // addGameToolStripMenuItem
            // 
            this.addGameToolStripMenuItem.Name = "addGameToolStripMenuItem";
            this.addGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.addGameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addGameToolStripMenuItem.Text = "Add work";
            this.addGameToolStripMenuItem.Click += new System.EventHandler(this.addGameToolStripMenuItem_Click);
            // 
            // addGamesToolStripMenuItem
            // 
            this.addGamesToolStripMenuItem.Name = "addGamesToolStripMenuItem";
            this.addGamesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addGamesToolStripMenuItem.Text = "Add works";
            this.addGamesToolStripMenuItem.Click += new System.EventHandler(this.addGamesToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(177, 6);
            // 
            // extractCgGameToolStripMenuItem
            // 
            this.extractCgGameToolStripMenuItem.Name = "extractCgGameToolStripMenuItem";
            this.extractCgGameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.extractCgGameToolStripMenuItem.Text = "Extract CG";
            this.extractCgGameToolStripMenuItem.Click += new System.EventHandler(this.extractCgGameToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(177, 6);
            // 
            // findDuplicatesToolStripMenuItem
            // 
            this.findDuplicatesToolStripMenuItem.Name = "findDuplicatesToolStripMenuItem";
            this.findDuplicatesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.findDuplicatesToolStripMenuItem.Text = "Find Duplicates";
            this.findDuplicatesToolStripMenuItem.Click += new System.EventHandler(this.findDuplicatesToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewDetails,
            this.viewTiles,
            this.toolStripSeparator5,
            this.viewSearchBar});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // viewDetails
            // 
            this.viewDetails.Checked = true;
            this.viewDetails.CheckState = System.Windows.Forms.CheckState.Checked;
            this.viewDetails.Name = "viewDetails";
            this.viewDetails.Size = new System.Drawing.Size(139, 22);
            this.viewDetails.Text = "Details";
            this.viewDetails.Click += new System.EventHandler(this.viewDetails_Click);
            // 
            // viewTiles
            // 
            this.viewTiles.Name = "viewTiles";
            this.viewTiles.Size = new System.Drawing.Size(139, 22);
            this.viewTiles.Text = "Tiles";
            this.viewTiles.Click += new System.EventHandler(this.viewTiles_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(136, 6);
            // 
            // viewSearchBar
            // 
            this.viewSearchBar.Name = "viewSearchBar";
            this.viewSearchBar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.viewSearchBar.Size = new System.Drawing.Size(139, 22);
            this.viewSearchBar.Text = "Find";
            this.viewSearchBar.Click += new System.EventHandler(this.viewSearchBar_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statisticsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // statisticsToolStripMenuItem
            // 
            this.statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
            this.statisticsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.statisticsToolStripMenuItem.Text = "Statistics...";
            this.statisticsToolStripMenuItem.Click += new System.EventHandler(this.statisticsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 688);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip.Size = new System.Drawing.Size(1233, 22);
            this.statusStrip.TabIndex = 3;
            // 
            // statusStripLabel
            // 
            this.statusStripLabel.Name = "statusStripLabel";
            this.statusStripLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // extractionFileDialog
            // 
            this.extractionFileDialog.Filter = "Game archive (*.wolf, *.rgssad, *.rgss2a, *.rgss3a)|*.wolf;*.rgssad;*.rgss2a;*.rg" +
    "ss3a|All Files (*.*)|*.*";
            // 
            // addGameDialog
            // 
            this.addGameDialog.Filter = "Executable or Archive (*.exe; *.swf; *.zip; *.rar)|*.exe; *.swf; *.zip; *.rar|All" +
    " Files (*.*)|*.*";
            // 
            // headerFormatStyle
            // 
            headerStateStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(75)))), ((int)(((byte)(73)))));
            headerStateStyle1.ForeColor = System.Drawing.Color.White;
            headerStateStyle1.FrameColor = System.Drawing.Color.White;
            this.headerFormatStyle.Hot = headerStateStyle1;
            headerStateStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(75)))), ((int)(((byte)(73)))));
            headerStateStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(167)))), ((int)(((byte)(167)))));
            headerStateStyle2.FrameColor = System.Drawing.Color.Black;
            headerStateStyle2.FrameWidth = 1F;
            this.headerFormatStyle.Normal = headerStateStyle2;
            headerStateStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(75)))), ((int)(((byte)(73)))));
            headerStateStyle3.ForeColor = System.Drawing.Color.White;
            headerStateStyle3.FrameColor = System.Drawing.Color.White;
            this.headerFormatStyle.Pressed = headerStateStyle3;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Location = new System.Drawing.Point(349, 103);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.searchBar);
            this.splitContainer.Panel1.Controls.Add(this.gameList);
            this.splitContainer.Panel1MinSize = 30;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Panel2.Controls.Add(this.gameEditControl);
            this.splitContainer.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer_Panel2_Paint);
            this.splitContainer.Panel2MinSize = 0;
            this.splitContainer.Size = new System.Drawing.Size(1233, 688);
            this.splitContainer.SnapToNotches = true;
            this.splitContainer.SpaceBetweenNotches = 40;
            this.splitContainer.SplitterDistance = 818;
            this.splitContainer.SplitterIncrement = 30;
            this.splitContainer.SplitterWidth = 12;
            this.splitContainer.TabIndex = 4;
            this.splitContainer.TabStop = false;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(97)))), ((int)(((byte)(139)))));
            this.panelMenu.Controls.Add(this.panel2);
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Controls.Add(this.buttonHelp);
            this.panelMenu.Controls.Add(this.buttonSettings);
            this.panelMenu.Controls.Add(this.buttonLibary);
            this.panelMenu.Controls.Add(this.buttonNewGames);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(305, 688);
            this.panelMenu.TabIndex = 2;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMenu_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(305, 172);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.WaitOnLoad = true;
            // 
            // buttonHelp
            // 
            this.buttonHelp.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonHelp.FlatAppearance.BorderSize = 0;
            this.buttonHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHelp.ForeColor = System.Drawing.Color.White;
            this.buttonHelp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHelp.Location = new System.Drawing.Point(0, 180);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.buttonHelp.Size = new System.Drawing.Size(305, 60);
            this.buttonHelp.TabIndex = 3;
            this.buttonHelp.Text = "Help";
            this.buttonHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonSettings.FlatAppearance.BorderSize = 0;
            this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings.ForeColor = System.Drawing.Color.White;
            this.buttonSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSettings.Location = new System.Drawing.Point(0, 120);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.buttonSettings.Size = new System.Drawing.Size(305, 60);
            this.buttonSettings.TabIndex = 2;
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // buttonLibary
            // 
            this.buttonLibary.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonLibary.FlatAppearance.BorderSize = 0;
            this.buttonLibary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLibary.ForeColor = System.Drawing.Color.White;
            this.buttonLibary.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLibary.Location = new System.Drawing.Point(0, 60);
            this.buttonLibary.Name = "buttonLibary";
            this.buttonLibary.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.buttonLibary.Size = new System.Drawing.Size(305, 60);
            this.buttonLibary.TabIndex = 1;
            this.buttonLibary.Text = "Libary";
            this.buttonLibary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLibary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonLibary.UseVisualStyleBackColor = true;
            this.buttonLibary.Click += new System.EventHandler(this.buttonLibary_Click);
            // 
            // buttonNewGames
            // 
            this.buttonNewGames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(97)))), ((int)(((byte)(139)))));
            this.buttonNewGames.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonNewGames.FlatAppearance.BorderSize = 0;
            this.buttonNewGames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewGames.ForeColor = System.Drawing.Color.White;
            this.buttonNewGames.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNewGames.Location = new System.Drawing.Point(0, 0);
            this.buttonNewGames.Name = "buttonNewGames";
            this.buttonNewGames.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.buttonNewGames.Size = new System.Drawing.Size(305, 60);
            this.buttonNewGames.TabIndex = 0;
            this.buttonNewGames.Text = "New Games";
            this.buttonNewGames.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNewGames.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonNewGames.UseVisualStyleBackColor = false;
            this.buttonNewGames.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // searchBar
            // 
            this.searchBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(97)))), ((int)(((byte)(139)))));
            this.searchBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.searchBar.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.searchBar.Location = new System.Drawing.Point(0, 651);
            this.searchBar.Margin = new System.Windows.Forms.Padding(4);
            this.searchBar.Name = "searchBar";
            this.searchBar.Size = new System.Drawing.Size(442, 37);
            this.searchBar.TabIndex = 1;
            this.searchBar.SearchTextChanged += new System.EventHandler(this.searchBar_SearchTextChanged);
            this.searchBar.CommandKeyPressed += new System.Windows.Forms.KeyEventHandler(this.searchBar_CommandKeyPressed);
            this.searchBar.VisibleChanged += new System.EventHandler(this.searchBar_VisibleChanged);
            // 
            // gameList
            // 
            this.gameList.AllColumns.Add(this.imageColumn);
            this.gameList.AllColumns.Add(this.rjCodeColumn);
            this.gameList.AllColumns.Add(this.titleColumn);
            this.gameList.AllColumns.Add(this.circleColumn);
            this.gameList.AllColumns.Add(this.cvsColumn);
            this.gameList.AllColumns.Add(this.categoryColumn);
            this.gameList.AllColumns.Add(this.languageColumn);
            this.gameList.AllColumns.Add(this.ratingColumn);
            this.gameList.AllColumns.Add(this.dlSiteRatingColumn);
            this.gameList.AllColumns.Add(this.sizeColumn);
            this.gameList.AllColumns.Add(this.timesPlayedColumn);
            this.gameList.AllColumns.Add(this.timePlayedColumn);
            this.gameList.AllColumns.Add(this.lastPlayedColumn);
            this.gameList.AllColumns.Add(this.releasedColumn);
            this.gameList.AllColumns.Add(this.addedColumn);
            this.gameList.AllColumns.Add(this.tagsColumn);
            this.gameList.AllColumns.Add(this.hvdbtagsColumn);
            this.gameList.AllColumns.Add(this.commentsColumn);
            this.gameList.AllowColumnReorder = true;
            this.gameList.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.SingleClick;
            this.gameList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.imageColumn,
            this.rjCodeColumn,
            this.titleColumn,
            this.circleColumn,
            this.cvsColumn,
            this.categoryColumn,
            this.languageColumn,
            this.ratingColumn,
            this.dlSiteRatingColumn,
            this.sizeColumn,
            this.timesPlayedColumn,
            this.timePlayedColumn,
            this.lastPlayedColumn,
            this.releasedColumn,
            this.addedColumn,
            this.tagsColumn,
            this.hvdbtagsColumn,
            this.commentsColumn});
            this.gameList.ContextMenuStrip = this.contextMenuStrip;
            this.gameList.Dock = System.Windows.Forms.DockStyle.Right;
            this.gameList.FullRowSelect = true;
            this.gameList.HeaderFormatStyle = this.headerFormatStyle;
            this.gameList.HideSelection = false;
            this.gameList.IsSearchOnSortColumn = false;
            this.gameList.Location = new System.Drawing.Point(442, 0);
            this.gameList.Margin = new System.Windows.Forms.Padding(0);
            this.gameList.Name = "gameList";
            this.gameList.OwnerDraw = true;
            this.gameList.RowHeight = 50;
            this.gameList.ShowCommandMenuOnRightClick = true;
            this.gameList.Size = new System.Drawing.Size(376, 688);
            this.gameList.SortGroupItemsByPrimaryColumn = false;
            this.gameList.TabIndex = 0;
            this.gameList.UseCompatibleStateImageBehavior = false;
            this.gameList.UseFiltering = true;
            this.gameList.UseOverlays = false;
            this.gameList.View = System.Windows.Forms.View.Details;
            this.gameList.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.gameList_CellEditFinishing);
            this.gameList.CellEditStarting += new BrightIdeasSoftware.CellEditEventHandler(this.gameList_CellEditStarting);
            this.gameList.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.gameList_CellClick);
            this.gameList.SelectionChanged += new System.EventHandler(this.gameList_SelectionChanged);
            this.gameList.SizeChanged += new System.EventHandler(this.gameList_SizeChanged);
            this.gameList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gameList_KeyDown);
            // 
            // imageColumn
            // 
            this.imageColumn.CellPadding = null;
            this.imageColumn.CellVerticalAlignment = System.Drawing.StringAlignment.Center;
            this.imageColumn.DefaultSortOrder = System.Windows.Forms.SortOrder.None;
            this.imageColumn.Groupable = false;
            this.imageColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.imageColumn.ImageAspectName = "";
            this.imageColumn.IsEditable = false;
            this.imageColumn.Searchable = false;
            this.imageColumn.Sortable = false;
            this.imageColumn.Text = "";
            this.imageColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.imageColumn.UseFiltering = false;
            this.imageColumn.Width = 28;
            // 
            // rjCodeColumn
            // 
            this.rjCodeColumn.AspectName = "RJCode";
            this.rjCodeColumn.CellPadding = null;
            this.rjCodeColumn.DefaultSortOrder = System.Windows.Forms.SortOrder.Descending;
            this.rjCodeColumn.Groupable = false;
            this.rjCodeColumn.IsEditable = false;
            this.rjCodeColumn.Text = "RJCode";
            this.rjCodeColumn.UseFiltering = false;
            this.rjCodeColumn.Width = 75;
            // 
            // titleColumn
            // 
            this.titleColumn.AspectName = "Title";
            this.titleColumn.CellPadding = new System.Drawing.Rectangle(0, 4, 0, 4);
            this.titleColumn.DefaultSortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.titleColumn.IsEditable = false;
            this.titleColumn.Text = "Title";
            this.titleColumn.UseFiltering = false;
            this.titleColumn.UseInitialLetterForGroup = true;
            this.titleColumn.Width = 132;
            this.titleColumn.WordWrap = true;
            // 
            // circleColumn
            // 
            this.circleColumn.AspectName = "Author.Name";
            this.circleColumn.CellPadding = null;
            this.circleColumn.DefaultSortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.circleColumn.IsEditable = false;
            this.circleColumn.Text = "Circle";
            this.circleColumn.UseFiltering = false;
            this.circleColumn.Width = 116;
            // 
            // cvsColumn
            // 
            this.cvsColumn.AspectName = "CVs";
            this.cvsColumn.CellPadding = new System.Drawing.Rectangle(0, 4, 0, 4);
            this.cvsColumn.DefaultSortOrder = System.Windows.Forms.SortOrder.None;
            this.cvsColumn.IsEditable = false;
            this.cvsColumn.Text = "CVs";
            this.cvsColumn.UseFiltering = false;
            this.cvsColumn.Width = 150;
            this.cvsColumn.WordWrap = true;
            // 
            // categoryColumn
            // 
            this.categoryColumn.AspectName = "Category";
            this.categoryColumn.CellPadding = null;
            this.categoryColumn.DefaultSortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.categoryColumn.IsEditable = false;
            this.categoryColumn.Text = "Category";
            this.categoryColumn.UseFiltering = false;
            this.categoryColumn.Width = 92;
            // 
            // languageColumn
            // 
            this.languageColumn.AspectName = "Language";
            this.languageColumn.CellPadding = null;
            this.languageColumn.DefaultSortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.languageColumn.IsEditable = false;
            this.languageColumn.Text = "Language";
            this.languageColumn.UseFiltering = false;
            this.languageColumn.Width = 92;
            // 
            // ratingColumn
            // 
            this.ratingColumn.AspectName = "Rating";
            this.ratingColumn.CellPadding = null;
            this.ratingColumn.DefaultSortOrder = System.Windows.Forms.SortOrder.Descending;
            this.ratingColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ratingColumn.Searchable = false;
            this.ratingColumn.Text = "Rating";
            this.ratingColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ratingColumn.UseFiltering = false;
            this.ratingColumn.Width = 64;
            // 
            // dlSiteRatingColumn
            // 
            this.dlSiteRatingColumn.AspectName = "DLSRating";
            this.dlSiteRatingColumn.CellPadding = null;
            this.dlSiteRatingColumn.DefaultSortOrder = System.Windows.Forms.SortOrder.Descending;
            this.dlSiteRatingColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dlSiteRatingColumn.IsEditable = false;
            this.dlSiteRatingColumn.Searchable = false;
            this.dlSiteRatingColumn.Text = "DLSite Rating";
            this.dlSiteRatingColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dlSiteRatingColumn.UseFiltering = false;
            this.dlSiteRatingColumn.Width = 82;
            // 
            // sizeColumn
            // 
            this.sizeColumn.AspectName = "Size";
            this.sizeColumn.AspectToStringFormat = "{0} MB";
            this.sizeColumn.CellPadding = null;
            this.sizeColumn.DefaultSortOrder = System.Windows.Forms.SortOrder.Descending;
            this.sizeColumn.Groupable = false;
            this.sizeColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sizeColumn.IsEditable = false;
            this.sizeColumn.Searchable = false;
            this.sizeColumn.Text = "Size";
            this.sizeColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sizeColumn.UseFiltering = false;
            this.sizeColumn.Width = 65;
            // 
            // timesPlayedColumn
            // 
            this.timesPlayedColumn.AspectName = "TimesPlayed";
            this.timesPlayedColumn.CellPadding = null;
            this.timesPlayedColumn.DefaultSortOrder = System.Windows.Forms.SortOrder.Descending;
            this.timesPlayedColumn.IsEditable = false;
            this.timesPlayedColumn.Searchable = false;
            this.timesPlayedColumn.Text = "Times Played";
            this.timesPlayedColumn.UseFiltering = false;
            this.timesPlayedColumn.Width = 78;
            // 
            // timePlayedColumn
            // 
            this.timePlayedColumn.AspectName = "TimePlayed";
            this.timePlayedColumn.CellPadding = null;
            this.timePlayedColumn.DefaultSortOrder = System.Windows.Forms.SortOrder.Descending;
            this.timePlayedColumn.Groupable = false;
            this.timePlayedColumn.IsEditable = false;
            this.timePlayedColumn.Searchable = false;
            this.timePlayedColumn.Text = "Time Played";
            this.timePlayedColumn.UseFiltering = false;
            this.timePlayedColumn.Width = 96;
            // 
            // lastPlayedColumn
            // 
            this.lastPlayedColumn.AspectName = "LastPlayedDate";
            this.lastPlayedColumn.CellPadding = null;
            this.lastPlayedColumn.DefaultSortOrder = System.Windows.Forms.SortOrder.Descending;
            this.lastPlayedColumn.IsEditable = false;
            this.lastPlayedColumn.Searchable = false;
            this.lastPlayedColumn.Text = "Last Played";
            this.lastPlayedColumn.UseFiltering = false;
            this.lastPlayedColumn.Width = 145;
            // 
            // releasedColumn
            // 
            this.releasedColumn.AspectName = "ReleaseDate";
            this.releasedColumn.CellPadding = null;
            this.releasedColumn.DefaultSortOrder = System.Windows.Forms.SortOrder.Descending;
            this.releasedColumn.IsEditable = false;
            this.releasedColumn.Searchable = false;
            this.releasedColumn.Text = "Released";
            this.releasedColumn.UseFiltering = false;
            this.releasedColumn.Width = 83;
            // 
            // addedColumn
            // 
            this.addedColumn.AspectName = "AddedDate";
            this.addedColumn.CellPadding = null;
            this.addedColumn.DefaultSortOrder = System.Windows.Forms.SortOrder.Descending;
            this.addedColumn.IsEditable = false;
            this.addedColumn.Searchable = false;
            this.addedColumn.Text = "Added";
            this.addedColumn.UseFiltering = false;
            this.addedColumn.Width = 90;
            // 
            // tagsColumn
            // 
            this.tagsColumn.AspectName = "Tags";
            this.tagsColumn.CellPadding = new System.Drawing.Rectangle(0, 4, 0, 4);
            this.tagsColumn.DefaultSortOrder = System.Windows.Forms.SortOrder.None;
            this.tagsColumn.FillsFreeSpace = true;
            this.tagsColumn.Groupable = false;
            this.tagsColumn.IsEditable = false;
            this.tagsColumn.Sortable = false;
            this.tagsColumn.Text = "Tags";
            this.tagsColumn.UseFiltering = false;
            this.tagsColumn.WordWrap = true;
            // 
            // hvdbtagsColumn
            // 
            this.hvdbtagsColumn.AspectName = "HVDBTags";
            this.hvdbtagsColumn.CellPadding = new System.Drawing.Rectangle(0, 4, 0, 4);
            this.hvdbtagsColumn.DefaultSortOrder = System.Windows.Forms.SortOrder.None;
            this.hvdbtagsColumn.FillsFreeSpace = true;
            this.hvdbtagsColumn.Groupable = false;
            this.hvdbtagsColumn.IsEditable = false;
            this.hvdbtagsColumn.Sortable = false;
            this.hvdbtagsColumn.Text = "HVDB Tags";
            this.hvdbtagsColumn.UseFiltering = false;
            this.hvdbtagsColumn.WordWrap = true;
            // 
            // commentsColumn
            // 
            this.commentsColumn.AspectName = "Comments";
            this.commentsColumn.CellPadding = new System.Drawing.Rectangle(0, 4, 0, 4);
            this.commentsColumn.DefaultSortOrder = System.Windows.Forms.SortOrder.None;
            this.commentsColumn.FillsFreeSpace = true;
            this.commentsColumn.Groupable = false;
            this.commentsColumn.IsEditable = false;
            this.commentsColumn.Sortable = false;
            this.commentsColumn.Text = "Comments";
            this.commentsColumn.UseFiltering = false;
            // 
            // gameEditControl
            // 
            this.gameEditControl.BackColor = System.Drawing.Color.Transparent;
            this.gameEditControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.gameEditControl.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.gameEditControl.Location = new System.Drawing.Point(58, 0);
            this.gameEditControl.Margin = new System.Windows.Forms.Padding(2);
            this.gameEditControl.Name = "gameEditControl";
            this.gameEditControl.ReportDownloadProgress = null;
            this.gameEditControl.Size = new System.Drawing.Size(345, 688);
            this.gameEditControl.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 516);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 172);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(311, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(910, 100);
            this.panel2.TabIndex = 5;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(97)))), ((int)(((byte)(139)))));
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(305, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(928, 69);
            this.panelTitleBar.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1233, 734);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStrip);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Game Manager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.contextMenuStrip.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private BrightIdeasSoftware.HeaderFormatStyle headerFormatStyle;
        private BrightIdeasSoftware.ObjectListView gameList;
        private TweakedSplitContainer splitContainer;
        private GameEditControl gameEditControl;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractCgGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog extractionFileDialog;
        private System.Windows.Forms.OpenFileDialog addGameDialog;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel statusStripLabel;
        private System.Windows.Forms.ToolStripMenuItem addGamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewDetails;
        private System.Windows.Forms.ToolStripMenuItem viewTiles;
        private System.Windows.Forms.ToolStripMenuItem extractCgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private SearchBar searchBar;
        private System.Windows.Forms.ToolStripMenuItem openInExplorerMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem openEngDLSiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openJpDLSiteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openHVDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem filterOnCircleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem viewSearchBar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private BrightIdeasSoftware.OLVColumn imageColumn;
        private BrightIdeasSoftware.OLVColumn rjCodeColumn;
        private BrightIdeasSoftware.OLVColumn titleColumn;
        private BrightIdeasSoftware.OLVColumn ratingColumn;
        private BrightIdeasSoftware.OLVColumn dlSiteRatingColumn;
        private BrightIdeasSoftware.OLVColumn circleColumn;
        private BrightIdeasSoftware.OLVColumn releasedColumn;
        private BrightIdeasSoftware.OLVColumn lastPlayedColumn;
        private BrightIdeasSoftware.OLVColumn timePlayedColumn;
        private BrightIdeasSoftware.OLVColumn tagsColumn;
		private BrightIdeasSoftware.OLVColumn hvdbtagsColumn;
		private BrightIdeasSoftware.OLVColumn cvsColumn;
        private BrightIdeasSoftware.OLVColumn timesPlayedColumn;
        private BrightIdeasSoftware.OLVColumn commentsColumn;
        private BrightIdeasSoftware.OLVColumn addedColumn;
        private BrightIdeasSoftware.OLVColumn sizeColumn;
        private BrightIdeasSoftware.OLVColumn categoryColumn;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFromListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFromDiskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisticsToolStripMenuItem;
        private BrightIdeasSoftware.OLVColumn languageColumn;
        private System.Windows.Forms.ToolStripMenuItem findDuplicatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem translateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem updatePathToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem renameWorksFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem downloadInfoToolStripMenuItem;		
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button buttonNewGames;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonLibary;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelTitleBar;
    }
}

