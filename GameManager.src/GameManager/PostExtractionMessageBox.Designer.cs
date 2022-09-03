namespace GameManager {
    partial class PostExtractionMessageBox {
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
            this.messagePanel = new System.Windows.Forms.Panel();
            this.message = new System.Windows.Forms.Label();
            this.neitherButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.dontAskAgainCheckbox = new System.Windows.Forms.CheckBox();
            this.renameButton = new System.Windows.Forms.Button();
            this.messagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // messagePanel
            // 
            this.messagePanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.messagePanel.Controls.Add(this.message);
            this.messagePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.messagePanel.Location = new System.Drawing.Point(0, 0);
            this.messagePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.messagePanel.Name = "messagePanel";
            this.messagePanel.Size = new System.Drawing.Size(496, 123);
            this.messagePanel.TabIndex = 0;
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Location = new System.Drawing.Point(9, 33);
            this.message.MaximumSize = new System.Drawing.Size(500, 0);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(81, 17);
            this.message.TabIndex = 0;
            this.message.Text = "<message>";
            // 
            // neitherButton
            // 
            this.neitherButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.neitherButton.Location = new System.Drawing.Point(385, 136);
            this.neitherButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.neitherButton.Name = "neitherButton";
            this.neitherButton.Size = new System.Drawing.Size(99, 32);
            this.neitherButton.TabIndex = 3;
            this.neitherButton.Text = "Neither";
            this.neitherButton.UseVisualStyleBackColor = true;
            this.neitherButton.Click += new System.EventHandler(this.neitherButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(172, 136);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 5, 2);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(99, 32);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // dontAskAgainCheckbox
            // 
            this.dontAskAgainCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dontAskAgainCheckbox.AutoSize = true;
            this.dontAskAgainCheckbox.Location = new System.Drawing.Point(12, 143);
            this.dontAskAgainCheckbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dontAskAgainCheckbox.Name = "dontAskAgainCheckbox";
            this.dontAskAgainCheckbox.Size = new System.Drawing.Size(128, 21);
            this.dontAskAgainCheckbox.TabIndex = 0;
            this.dontAskAgainCheckbox.Text = "Don\'t ask again";
            this.dontAskAgainCheckbox.UseVisualStyleBackColor = true;
            this.dontAskAgainCheckbox.CheckedChanged += new System.EventHandler(this.dontAskAgainCheckbox_CheckedChanged);
            // 
            // renameButton
            // 
            this.renameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.renameButton.Location = new System.Drawing.Point(279, 136);
            this.renameButton.Margin = new System.Windows.Forms.Padding(3, 2, 5, 2);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(99, 32);
            this.renameButton.TabIndex = 4;
            this.renameButton.Text = "Rename";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // PostExtractionMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(496, 180);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.dontAskAgainCheckbox);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.neitherButton);
            this.Controls.Add(this.messagePanel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PostExtractionMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "<title>";
            this.TopMost = true;
            this.messagePanel.ResumeLayout(false);
            this.messagePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel messagePanel;
        private System.Windows.Forms.Button neitherButton;
        private System.Windows.Forms.Label message;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.CheckBox dontAskAgainCheckbox;
        private System.Windows.Forms.Button renameButton;
    }
}
