using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameManager {
    /// <summary>
    /// A SplitContainer control that
    ///     -Makes the splitter more visible by drawing three dots in the middle
    ///     -Does not steal focus when the splitter is clicked
    ///     -Updates the content in the left and right panels continuously when the splitter is dragged
    /// </summary>
    class TweakedSplitContainer : SplitContainer {
        private Control focused;

        /// <summary>
        /// If true, the splitter will snap to the closest 'notch' when resized.
        /// </summary>
        public bool SnapToNotches { set; get; }

        /// <summary>
        /// The number of pixels between each notch.
        /// </summary>
        public int SpaceBetweenNotches { set; get; }

        public TweakedSplitContainer() : base() {
            SnapToNotches = true;
            SpaceBetweenNotches = 40;
        }

        protected override void OnMouseDown(MouseEventArgs e) {
            //Get the focused control before the splitter is focused
            focused = getFocused(Parent.Controls);

            //Disable normal move behavior
            IsSplitterFixed = true;

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e) {
            //Enable normal move behavior
            IsSplitterFixed = false;

            //Return focus to the previous control
            if (focused != null) {
                focused.Focus();
                focused = null;
            }

            base.OnMouseUp(e);
        }
        
        protected override void OnMouseMove(MouseEventArgs e) {
            base.OnMouseMove(e);

            //Check to make sure the splitter won't be updated by the normal move behavior also
            if (IsSplitterFixed) {
                //Make sure that the button used to move the splitter is the left mouse button
                if (e.Button.Equals(MouseButtons.Left)) {
                    //Make the splitter snap to notches
                    if (Orientation.Equals(Orientation.Vertical)) {
                        if (e.X <= Panel1MinSize) {
                            SplitterDistance = Panel1MinSize;
                        }
                        else if (e.X >= Width - Panel2MinSize - 1) {
                            var newDistance = Width - Panel2MinSize;
                            SplitterDistance = newDistance > Width - SplitterWidth ? newDistance - SplitterWidth : newDistance;
                        }
                        else if (!SnapToNotches || Math.Abs(SplitterDistance - e.X) > SpaceBetweenNotches) {
                            //Only move the splitter if the mouse is within the appropriate bounds
                            if (e.X > 0 && e.X < Width) {
                                //Snap the splitter to the closest notch
                                SplitterDistance = e.X;
                            }
                        }
                    }
                    else {
                        if (e.Y <= Panel1MinSize) {
                            SplitterDistance = Panel1MinSize;
                        }
                        else if (e.Y >= Height - Panel2MinSize - 1) {
                            var newDistance = Height - Panel2MinSize;
                            SplitterDistance = newDistance > Height - SplitterWidth ? newDistance - SplitterWidth : newDistance;
                        }
                        else if (!SnapToNotches || Math.Abs(SplitterDistance - e.Y) > SpaceBetweenNotches) {
                            if (e.Y > 0 && e.Y < Height) {
                                SplitterDistance = e.Y;
                            }
                        }
                    }
                }
                else {
                    // This allows the splitter to be moved normally again
                    IsSplitterFixed = false;
                }
            }
        }
        
        private Control getFocused(Control.ControlCollection controls) {
            foreach (Control c in controls) {
                if (c.Focused) {
                    //Return the focused control
                    return c;
                }
                else if (c.ContainsFocus) {
                    //If the focus is contained inside a control's children return the child
                    return getFocused(c.Controls);
                }
            }
            //No control on the form has focus
            return null;
        }

        //Paints the three dots
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            Point[] points = new Point[3];

            //Calculate the position of the dots
            if (Orientation == Orientation.Horizontal) {
                points[0] = new Point((Width / 2), SplitterDistance + (SplitterWidth / 2));
                points[1] = new Point(points[0].X - 10, points[0].Y);
                points[2] = new Point(points[0].X + 10, points[0].Y);
            }
            else {
                points[0] = new Point(SplitterDistance + (SplitterWidth / 2), (Height / 2));
                points[1] = new Point(points[0].X, points[0].Y - 10);
                points[2] = new Point(points[0].X, points[0].Y + 10);
            }

            //Draw the dots
            foreach (Point p in points) {
                p.Offset(-2, -2);
                e.Graphics.FillEllipse(SystemBrushes.ControlDark,
                    new Rectangle(p, new Size(3, 3)));

                p.Offset(1, 1);
                e.Graphics.FillEllipse(SystemBrushes.ControlLight,
                    new Rectangle(p, new Size(3, 3)));
            }
        }
    }
}
