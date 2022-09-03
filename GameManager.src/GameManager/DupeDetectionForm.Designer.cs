namespace GameManager {
    partial class DupeDetectionForm {
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
            this.infoLabel = new System.Windows.Forms.Label();
            this.DuplicateGames = new BrightIdeasSoftware.FastObjectListView();
            this.hiddenColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.rjCodeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.titleColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.reasonColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.okButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DuplicateGames)).BeginInit();
            this.SuspendLayout();
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(18, 16);
            this.infoLabel.Margin = new System.Windows.Forms.Padding(5, 10, 5, 0);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(163, 17);
            this.infoLabel.TabIndex = 11;
            this.infoLabel.Text = "0 duplicate works found";
            // 
            // DuplicateGames
            // 
            this.DuplicateGames.AllColumns.Add(this.hiddenColumn);
            this.DuplicateGames.AllColumns.Add(this.rjCodeColumn);
            this.DuplicateGames.AllColumns.Add(this.titleColumn);
            this.DuplicateGames.AllColumns.Add(this.reasonColumn);
            this.DuplicateGames.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.DuplicateGames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DuplicateGames.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hiddenColumn,
            this.rjCodeColumn,
            this.titleColumn,
            this.reasonColumn});
            this.DuplicateGames.FullRowSelect = true;
            this.DuplicateGames.GridLines = true;
            this.DuplicateGames.Location = new System.Drawing.Point(21, 49);
            this.DuplicateGames.Margin = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.DuplicateGames.Name = "DuplicateGames";
            this.DuplicateGames.SelectColumnsOnRightClick = false;
            this.DuplicateGames.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.DuplicateGames.ShowGroups = false;
            this.DuplicateGames.Size = new System.Drawing.Size(647, 301);
            this.DuplicateGames.TabIndex = 10;
            this.DuplicateGames.UseAlternatingBackColors = true;
            this.DuplicateGames.UseCompatibleStateImageBehavior = false;
            this.DuplicateGames.UseOverlays = false;
            this.DuplicateGames.View = System.Windows.Forms.View.Details;
            this.DuplicateGames.VirtualMode = true;
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
            this.rjCodeColumn.Groupable = false;
            this.rjCodeColumn.Text = "RJCode";
            this.rjCodeColumn.Width = 81;
            // 
            // titleColumn
            // 
            this.titleColumn.AspectName = "Title";
            this.titleColumn.AutoCompleteEditor = false;
            this.titleColumn.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.titleColumn.CellPadding = null;
            this.titleColumn.DefaultSortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.titleColumn.Groupable = false;
            this.titleColumn.IsEditable = false;
            this.titleColumn.Text = "Title";
            this.titleColumn.Width = 184;
            // 
            // reasonColumn
            // 
            this.reasonColumn.AspectName = "Reason";
            this.reasonColumn.CellPadding = null;
            this.reasonColumn.DefaultSortOrder = System.Windows.Forms.SortOrder.None;
            this.reasonColumn.FillsFreeSpace = true;
            this.reasonColumn.Groupable = false;
            this.reasonColumn.IsEditable = false;
            this.reasonColumn.Text = "Reason";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(585, 362);
            this.okButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(83, 30);
            this.okButton.TabIndex = 31;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // DupeDetectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(686, 403);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.DuplicateGames);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DupeDetectionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Dupe Detection Tool";
            ((System.ComponentModel.ISupportInitialize)(this.DuplicateGames)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label infoLabel;
        private BrightIdeasSoftware.FastObjectListView DuplicateGames;
        private BrightIdeasSoftware.OLVColumn hiddenColumn;
        private BrightIdeasSoftware.OLVColumn rjCodeColumn;
        private BrightIdeasSoftware.OLVColumn titleColumn;
        private BrightIdeasSoftware.OLVColumn reasonColumn;
        private System.Windows.Forms.Button okButton;
    }
}
