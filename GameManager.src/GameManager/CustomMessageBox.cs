using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameManager {
    public partial class CustomMessageBox : Form {
        public enum MessageBoxResult { Yes, No }
        public MessageBoxResult Result { private set; get; }
        public bool DontAskAgainChecked { private set; get; }
        
        public CustomMessageBox() {
            InitializeComponent();

            foreach (Control c in Controls) {
                c.Font = Settings.Instance.GlobalFont;
            }

            message.MaximumSize = new Size(messagePanel.Width - message.Margin.Right, 0);
            Result = MessageBoxResult.No;
            DontAskAgainChecked = dontAskAgainCheckbox.Checked;
        }

        public CustomMessageBox(string message, string title) : this() {
            this.message.Text = message;
            this.Text = title;
        }

        private void noButton_Click(object sender, EventArgs e) {
            Result = MessageBoxResult.No;
            Close();
        }

        private void yesButton_Click(object sender, EventArgs e) {
            Result = MessageBoxResult.Yes;
            Close();
        }

        private void dontAskAgainCheckbox_CheckedChanged(object sender, EventArgs e) {
            DontAskAgainChecked = dontAskAgainCheckbox.Checked;
        }
    }
}
