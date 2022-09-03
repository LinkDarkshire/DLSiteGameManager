using System;
using System.Windows.Forms;

namespace GameManager {
    /// <summary>
    /// A TextBox that fixes ctrl + A not working on some .NET versions
    /// </summary>
    class TweakedTextBox : TextBox {
        protected override void OnKeyDown(KeyEventArgs e) {
            if (e.Control && (e.KeyCode == Keys.A)) {
                SelectAll();
                e.SuppressKeyPress = true;
            }
            else {
                base.OnKeyDown(e);
            }
        }
    }

    /// <summary>
    /// A ComboBox that fixes ctrl + A not working on some .NET versions
    /// </summary>
    class TweakedComboBox : ComboBox {
        private bool selectionCleared = false;

        protected override void OnKeyDown(KeyEventArgs e) {
            if (e.Control && (e.KeyCode == Keys.A)) {
                SelectAll();
                e.SuppressKeyPress = true;
            }
            else {
                base.OnKeyDown(e);
            }
        }

        private void deselectText() {
            Timer timer = new Timer();

            timer.Tick += (sender, e2) => {
                SelectionLength = 0;
                selectionCleared = true;
                timer.Enabled = false;
            };

            timer.Interval = 1;
            timer.Enabled = true;
        }

        //Deselects the text in the combo box the first time it is shown
        protected override void OnVisibleChanged(EventArgs e) {
            base.OnVisibleChanged(e);

            if (Visible && !selectionCleared) {
                deselectText();
            }
        }

        //Deselects the text in the combo box when it loses focus
        protected override void OnLeave(EventArgs e) {
            base.OnLeave(e);
            deselectText();
        }
    }
}
