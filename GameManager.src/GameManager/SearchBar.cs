using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameManager {
    public partial class SearchBar : UserControl {
        /// <summary>
        /// Triggered when the text in the search bar changes.
        /// </summary>
        public event EventHandler SearchTextChanged;

        /// <summary>
        /// Triggered when the arrow keys or the enter key is pressed.
        /// </summary>
        public event KeyEventHandler CommandKeyPressed;

        private Pen borderPen;

        public SearchBar() {
            InitializeComponent();

            foreach (Control c in Controls) {
                if (c != closeButton) {
                    c.Font = Settings.Instance.GlobalFont;
                }
            }

            borderPen = new Pen(BackColor, 5);
        }

        private void closeButton_Paint(object sender, PaintEventArgs e) {
            //Hide the default button border
            e.Graphics.DrawRectangle(borderPen, e.ClipRectangle);
        }

        private void closeButton_MouseEnter(object sender, EventArgs e) {
            closeButton.BackColor = Color.FromArgb(80, Color.Gray);
        }

        private void closeButton_MouseLeave(object sender, EventArgs e) {
            closeButton.BackColor = Color.Transparent;
        }

        private void closeButton_Click(object sender, EventArgs e) {
            Visible = false;
        }

        private void SearchBox_TextChanged(object sender, EventArgs e) {
            if (SearchTextChanged != null) {
                SearchTextChanged(sender, e);
            }
        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Enter:
                case Keys.Left:
                case Keys.Right:
                case Keys.Up:
                case Keys.Down:
                    if (CommandKeyPressed != null) {
                        CommandKeyPressed(sender, e);
                    }
                    break;
            }
        }
    }
}
