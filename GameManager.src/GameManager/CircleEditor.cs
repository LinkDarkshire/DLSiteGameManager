using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace GameManager {
    public partial class CircleEditor : Form {
        /// <summary>
        /// Whether or not the cancel button was pressed to close the form.
        /// </summary>
        public Boolean Cancelled = true;

        /// <summary>
        /// The circles that will be saved when the 'ok' button is pressed.
        /// </summary>
        private List<Circle> editedCircles = new List<Circle>();

        /// <summary>
        /// The original copies of edited circles.
        /// </summary>
        private List<Circle> preservedCircles = new List<Circle>();

        /// <summary>
        /// The circles that will be removed when the 'ok' button is pressed.
        /// </summary>
        private List<Circle> circlesToDelete = new List<Circle>();

        public Circle SelectedCircle {
            set {
                circleList.SelectedObject = value;

                if (circleList.SelectedIndex >= 0) {
                    circleList.EnsureVisible(circleList.SelectedIndex);
                }
            }
            get {
                return (Circle)circleList.SelectedObject;
            }
        }

        public static bool IsValidRgCode(string rgCode) {
            int tmp;

            if (rgCode.Length < 3) {
                return false;
            }

            if (Regex.IsMatch(rgCode.Substring(0, 2), "vg|bg|rg", RegexOptions.IgnoreCase)) {
                if (Int32.TryParse(rgCode.Substring(2), out tmp)) {
                    return true;
                }
            }
            else if (Int32.TryParse(rgCode, out tmp)) {
                return true;
            }
            return false;
        }

        public CircleEditor() {
            InitializeComponent();

            foreach (Control c in Controls) {
                c.Font = Settings.Instance.GlobalFont;
            }

            //Prefixes non-empty RGCodes with 'RG'            
            rgCodeColumn.AspectToStringConverter = rgCode => String.IsNullOrWhiteSpace((string)rgCode) ? "" : "" + rgCode;
            
            circleList.SetObjects(Circle.GetCircles());
        }

        private void CircleEditor_FormClosing(object sender, FormClosingEventArgs e) {
            if (circleList.IsCellEditing) {
                circleList.FinishCellEdit();
            }

            if (Cancelled) {
                for (int i = 0; i < editedCircles.Count; i++) {
                    editedCircles[i].Name = preservedCircles[i].Name;
                    editedCircles[i].RGCode = preservedCircles[i].RGCode;
                }
            }
        }

        private void circleList_CellEditFinishing(object sender, BrightIdeasSoftware.CellEditEventArgs e) {
            var editedCircle = (Circle)e.RowObject;

            if (e.Column == rgCodeColumn) {
                if (String.IsNullOrWhiteSpace((string)e.NewValue)) {
                    e.NewValue = null;
                }
            }

            if (!editedCircles.Contains(editedCircle)) {
                preservedCircles.Add(new Circle { Name = editedCircle.Name, RGCode = editedCircle.RGCode });
                editedCircles.Add(editedCircle);
            }
        }

        private void okButton_Click(object sender, EventArgs e) {
            if (circleList.IsCellEditing) {
                circleList.FinishCellEdit();
            }

            //Validate
            foreach (Circle circle in circleList.Objects) {
                if (String.IsNullOrWhiteSpace(circle.RGCode)) {
                    circle.RGCode = null;
                }

                if (circle.Name.Trim() == "") {
                    MessageBox.Show("Circle name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (circle.RGCode != null && !IsValidRgCode(circle.RGCode)) {
                    MessageBox.Show("Circle " + circle.Name + " has an invalid RGCode.");
                    return;
                }
            }

            //Save
            foreach (Circle c in editedCircles) {
                c.Save();
            }

            foreach (Circle c in circlesToDelete) {
                c.Delete();
            }
            Cancelled = false;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            Cancelled = true;
            Close();
        }

        private void newButton_Click(object sender, EventArgs e) {
            circleList.AddObject(new Circle());

            //Find the item just inserted and begin a cell edit
            for (int i = 0; i < circleList.GetItemCount(); i++) {
                if (((Circle)circleList.GetItem(i).RowObject).Name == null) {
                    var newItem = circleList.GetItem(i);
                    newItem.EnsureVisible();
                    newItem.Selected = true;
                    newItem.Focused = true;
                    circleList.StartCellEdit(newItem, 1);
                    break;
                }
            }
        }

        private void circleList_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete) {
                foreach (var circle in circleList.SelectedObjects) {
                    editedCircles.Remove((Circle)circle);
                    circlesToDelete.Add((Circle)circle);
                }
                circleList.RemoveObjects(circleList.SelectedObjects);
            }
        }
    }
}
