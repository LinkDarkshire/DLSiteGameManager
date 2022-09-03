namespace GameManager {
    partial class CircleEditor {
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
            this.nameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.rgCodeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.circleList = new BrightIdeasSoftware.ObjectListView();
            this.hiddenColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.newButton = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.circleList)).BeginInit();
            this.SuspendLayout();
            // 
            // nameColumn
            // 
            this.nameColumn.AspectName = "Name";
            this.nameColumn.AutoCompleteEditor = false;
            this.nameColumn.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.nameColumn.CellPadding = null;
            this.nameColumn.DefaultSortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.nameColumn.FillsFreeSpace = true;
            this.nameColumn.Text = "Name";
            this.nameColumn.Width = 148;
            // 
            // rgCodeColumn
            // 
            this.rgCodeColumn.AspectName = "RGCode";
            this.rgCodeColumn.AutoCompleteEditor = false;
            this.rgCodeColumn.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.rgCodeColumn.CellPadding = null;
            this.rgCodeColumn.DefaultSortOrder = System.Windows.Forms.SortOrder.Descending;
            this.rgCodeColumn.Text = "RGCode";
            this.rgCodeColumn.Width = 81;
            // 
            // circleList
            // 
            this.circleList.AllColumns.Add(this.hiddenColumn);
            this.circleList.AllColumns.Add(this.nameColumn);
            this.circleList.AllColumns.Add(this.rgCodeColumn);
            this.circleList.AlternateRowBackColor = System.Drawing.SystemColors.ButtonFace;
            this.circleList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.circleList.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.circleList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hiddenColumn,
            this.nameColumn,
            this.rgCodeColumn});
            this.circleList.FullRowSelect = true;
            this.circleList.GridLines = true;
            this.circleList.Location = new System.Drawing.Point(12, 55);
            this.circleList.Name = "circleList";
            this.circleList.SelectColumnsOnRightClick = false;
            this.circleList.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.circleList.ShowGroups = false;
            this.circleList.Size = new System.Drawing.Size(340, 308);
            this.circleList.TabIndex = 0;
            this.circleList.UseAlternatingBackColors = true;
            this.circleList.UseCompatibleStateImageBehavior = false;
            this.circleList.UseOverlays = false;
            this.circleList.View = System.Windows.Forms.View.Details;
            this.circleList.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.circleList_CellEditFinishing);
            this.circleList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.circleList_KeyDown);
            // 
            // hiddenColumn
            // 
            this.hiddenColumn.CellPadding = null;
            this.hiddenColumn.DefaultSortOrder = System.Windows.Forms.SortOrder.None;
            this.hiddenColumn.IsVisible = false;
            this.hiddenColumn.Width = 0;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(142, 369);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(66, 28);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(214, 369);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(66, 28);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // newButton
            // 
            this.newButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newButton.Location = new System.Drawing.Point(286, 369);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(66, 28);
            this.newButton.TabIndex = 5;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(12, 9);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(268, 34);
            this.infoLabel.TabIndex = 6;
            this.infoLabel.Text = "Double click a row to edit\r\nSelect a row and press \'delete\' to remove";
            // 
            // CircleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(364, 409);
            this.ControlBox = false;
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.circleList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CircleEditor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Circle Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CircleEditor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.circleList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.OLVColumn nameColumn;
        private BrightIdeasSoftware.OLVColumn rgCodeColumn;
        private BrightIdeasSoftware.ObjectListView circleList;
        private BrightIdeasSoftware.OLVColumn hiddenColumn;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Label infoLabel;


    }
}
