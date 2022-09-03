using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameManager {
    public enum PostExtractionAction { Delete, Rename, Nothing, Ask };

    public partial class PostExtractionMessageBox : Form {
        public PostExtractionAction Result { private set; get; }
        public bool DontAskAgainChecked { private set; get; }
        
        public PostExtractionMessageBox() {
            InitializeComponent();

            foreach (Control c in Controls) {
                c.Font = Settings.Instance.GlobalFont;
            }

            message.MaximumSize = new Size(messagePanel.Width - message.Margin.Right, 0);
            Result = PostExtractionAction.Nothing;
            DontAskAgainChecked = dontAskAgainCheckbox.Checked;
        }

        public PostExtractionMessageBox(string message, string title) : this() {
            this.message.Text = message;
            this.Text = title;
        }

        private void neitherButton_Click(object sender, EventArgs e) {
            Result = PostExtractionAction.Nothing;
            Close();
        }

        private void deleteButton_Click(object sender, EventArgs e) {
            Result = PostExtractionAction.Delete;
            Close();
        }

        private void renameButton_Click(object sender, EventArgs e) {
            Result = PostExtractionAction.Rename;
            Close();
        }

        private void dontAskAgainCheckbox_CheckedChanged(object sender, EventArgs e) {
            DontAskAgainChecked = dontAskAgainCheckbox.Checked;
        }
    }
}
