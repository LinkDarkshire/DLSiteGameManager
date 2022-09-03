using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GameManager {
    /// <summary>
    /// A dropdown list used to edit a game's rating.
    /// </summary>
    public partial class RatingEditor : ComboBox {
        /// <summary>
        /// Graphical representations of a game's rating.
        /// </summary>
        public static Image[] Images { private set; get; }

        /// <summary>
        /// Gets or sets the currently selected rating. Set to <code>null</code> to clear the rating.
        /// </summary>
        public byte? SelectedRating {
            set {
                if (value == null) {
                    SelectedIndex = 5;
                }
                else if (value >= 1 && value <= 5) {
                    //The rating is subtracted from the rating count becuase the list is reversed
                    SelectedIndex = Items.Count - value.Value - 1;
                }
            }
            get {
                if (SelectedIndex == 5) {
                    return null;
                }
                else {
                    return (byte)(Items.Count - SelectedIndex - 1);
                }
            }
        }

        static RatingEditor() {
            Images = new Image[] {Properties.Resources.Unrated, Properties.Resources.DLSRating1,
                                  Properties.Resources.DLSRating2, Properties.Resources.DLSRating3,
                                  Properties.Resources.DLSRating4, Properties.Resources.DLSRating5};
        }

        public RatingEditor(IContainer container = null) {
            if (container != null) {
                container.Add(this);
            }
            DrawMode = DrawMode.OwnerDrawFixed;
            DropDownStyle = ComboBoxStyle.DropDownList;
            ItemHeight = 22;
            Width = 48;
            Items.AddRange(new String[] { "", "", "", "", "", "" }); //Make the list of ratings expand to 6 items
            SelectedRating = 5;
        }

        protected override void OnDrawItem(DrawItemEventArgs e) {
            base.OnDrawItem(e);

            //Draws rating editor items as images or text according to the setting 
            if (Settings.Instance.ShowRatingsAsImage && !DesignMode) {
                //Draw the mouse-focused item with a light gray background color
                e.Graphics.FillRectangle(((e.State & DrawItemState.Focus) != 0) ? Brushes.LightGray : Brushes.White, e.Bounds);
                e.Graphics.DrawImage(Images[5 - e.Index], e.Bounds.X, e.Bounds.Y + 1);
            }
            else {
                //Draw null-ratings as a question mark
                string label = e.Index == 5 ? "?" : (Items.Count - e.Index - 1).ToString();

                e.Graphics.FillRectangle(((e.State & DrawItemState.Focus) != 0) ? Brushes.LightGray : Brushes.White, e.Bounds);
                e.Graphics.DrawString(label, Label.DefaultFont, Brushes.Black, new PointF(e.Bounds.X, e.Bounds.Y + 4));
            }
        }
    }
}
