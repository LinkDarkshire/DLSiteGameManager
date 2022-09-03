namespace GameManager {
    partial class ImageViewControl {
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
            this.mainContainer = new System.Windows.Forms.TableLayoutPanel();
            this.dummyLabel1 = new System.Windows.Forms.Label();
            this.scrollRightButton = new System.Windows.Forms.Button();
            this.scrollLeftButton = new System.Windows.Forms.Button();
            this.pictureMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewImageToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.setListImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewImageMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewImageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.setCoverImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureMenuStrip.SuspendLayout();
            this.addNewImageMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.mainContainer.Location = new System.Drawing.Point(0, 0);
            this.mainContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.RowCount = 1;
            this.mainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainContainer.Size = new System.Drawing.Size(511, 156);
            this.mainContainer.TabIndex = 4;
            this.mainContainer.MouseEnter += new System.EventHandler(this.MouseEntered);
            this.mainContainer.MouseLeave += new System.EventHandler(this.MouseLeft);
            // 
            // dummyLabel1
            // 
            this.dummyLabel1.AutoSize = true;
            this.dummyLabel1.Location = new System.Drawing.Point(3, 0);
            this.dummyLabel1.Name = "dummyLabel1";
            this.dummyLabel1.Size = new System.Drawing.Size(96, 17);
            this.dummyLabel1.TabIndex = 0;
            this.dummyLabel1.Text = "dummyLabel1";
            this.dummyLabel1.Visible = false;
            // 
            // scrollRightButton
            // 
            this.scrollRightButton.Location = new System.Drawing.Point(488, 112);
            this.scrollRightButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.scrollRightButton.Name = "scrollRightButton";
            this.scrollRightButton.Size = new System.Drawing.Size(20, 27);
            this.scrollRightButton.TabIndex = 6;
            this.scrollRightButton.Text = ">";
            this.scrollRightButton.UseVisualStyleBackColor = true;
            this.scrollRightButton.Visible = false;
            this.scrollRightButton.Click += new System.EventHandler(this.scrollRightButton_Click);
            this.scrollRightButton.MouseLeave += new System.EventHandler(this.MouseLeft);
            // 
            // scrollLeftButton
            // 
            this.scrollLeftButton.Location = new System.Drawing.Point(3, 112);
            this.scrollLeftButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.scrollLeftButton.Name = "scrollLeftButton";
            this.scrollLeftButton.Size = new System.Drawing.Size(20, 27);
            this.scrollLeftButton.TabIndex = 7;
            this.scrollLeftButton.Text = "<";
            this.scrollLeftButton.UseVisualStyleBackColor = true;
            this.scrollLeftButton.Visible = false;
            this.scrollLeftButton.Click += new System.EventHandler(this.scrollLeftButton_Click);
            this.scrollLeftButton.MouseLeave += new System.EventHandler(this.MouseLeft);
            // 
            // pictureMenuStrip
            // 
            this.pictureMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewImageToolStripMenuItem2,
            this.setListImageToolStripMenuItem,
            this.setCoverImageToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.pictureMenuStrip.Name = "contextMenuStrip1";
            this.pictureMenuStrip.Size = new System.Drawing.Size(207, 122);
            this.pictureMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.pictureMenuStrip_Opening);
            this.pictureMenuStrip.MouseLeave += new System.EventHandler(this.MouseLeft);
            // 
            // addNewImageToolStripMenuItem2
            // 
            this.addNewImageToolStripMenuItem2.Name = "addNewImageToolStripMenuItem2";
            this.addNewImageToolStripMenuItem2.Size = new System.Drawing.Size(206, 24);
            this.addNewImageToolStripMenuItem2.Text = "Add new image";
            this.addNewImageToolStripMenuItem2.Click += new System.EventHandler(this.addNewImageToolStripMenuItem_Click);
            // 
            // setListImageToolStripMenuItem
            // 
            this.setListImageToolStripMenuItem.Name = "setListImageToolStripMenuItem";
            this.setListImageToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.setListImageToolStripMenuItem.Text = "Use as list image";
            this.setListImageToolStripMenuItem.Click += new System.EventHandler(this.setListImageToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // addNewImageMenuStrip
            // 
            this.addNewImageMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewImageToolStripMenuItem1});
            this.addNewImageMenuStrip.Name = "addNewImageMenuStrip";
            this.addNewImageMenuStrip.Size = new System.Drawing.Size(184, 28);
            this.addNewImageMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.addNewImageMenuStrip_Opening);
            // 
            // addNewImageToolStripMenuItem1
            // 
            this.addNewImageToolStripMenuItem1.Name = "addNewImageToolStripMenuItem1";
            this.addNewImageToolStripMenuItem1.Size = new System.Drawing.Size(183, 24);
            this.addNewImageToolStripMenuItem1.Text = "Add new image";
            this.addNewImageToolStripMenuItem1.Click += new System.EventHandler(this.addNewImageToolStripMenuItem_Click);
            // 
            // openImageDialog
            // 
            this.openImageDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.b" +
    "mp|All Files (*.*)|*.*";
            this.openImageDialog.Multiselect = true;
            this.openImageDialog.Title = "Select one or more image files or enter an URL";
            // 
            // setCoverImageToolStripMenuItem
            // 
            this.setCoverImageToolStripMenuItem.Name = "setCoverImageToolStripMenuItem";
            this.setCoverImageToolStripMenuItem.Size = new System.Drawing.Size(206, 24);
            this.setCoverImageToolStripMenuItem.Text = "Use as cover image";
            this.setCoverImageToolStripMenuItem.Click += new System.EventHandler(this.setCoverImageToolStripMenuItem_Click);
            // 
            // ImageViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ContextMenuStrip = this.addNewImageMenuStrip;
            this.Controls.Add(this.scrollRightButton);
            this.Controls.Add(this.scrollLeftButton);
            this.Controls.Add(this.mainContainer);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ImageViewControl";
            this.Size = new System.Drawing.Size(511, 156);
            this.pictureMenuStrip.ResumeLayout(false);
            this.addNewImageMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainContainer;
        private System.Windows.Forms.Button scrollRightButton;
        private System.Windows.Forms.Button scrollLeftButton;
        private System.Windows.Forms.Label dummyLabel1;
        private System.Windows.Forms.ContextMenuStrip pictureMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setListImageToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip addNewImageMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addNewImageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addNewImageToolStripMenuItem2;
        private System.Windows.Forms.OpenFileDialog openImageDialog;
        private System.Windows.Forms.ToolStripMenuItem setCoverImageToolStripMenuItem;




    }
}
