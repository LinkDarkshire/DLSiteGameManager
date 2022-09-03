using System;
using System.Windows.Forms;

namespace GameManager {
    public partial class AboutDialog : Form {
        public AboutDialog() {
            InitializeComponent();

            foreach (Control c in Controls) {
                c.Font = Settings.Instance.GlobalFont;
            }

            aboutText.Text = aboutText.Text.Replace("_VERSION", Settings.ProgramVersion);
        }

        private void okButton_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
