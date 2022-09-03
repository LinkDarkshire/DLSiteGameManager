using System;
using System.Collections.Generic;

namespace GameManager {
    public class Circle {
        private static List<Circle> circles;

        /// <summary>
        /// Retrieves a list containing all saved circles from the database and caches the result.
        /// If the list has been previously retrieved, the cached list is returned. 
        /// </summary>
        public static List<Circle> GetCircles() {
            if (circles == null) {
                circles = Database.GetCircles();
            }
            return circles;
        }

        //Properties initialised by the database call getCircles()
        public int? CircleID { set; get; }
        public string Name { set; get; }
        private string rgCode;

        public string RGCode {
            set {
                rgCode = value;
            }
            get {
                if (!String.IsNullOrEmpty(rgCode) && Char.IsNumber(rgCode[0])) {
                    return "RG" + rgCode;
                }
                else {
                    return rgCode;
                }
            }
        }

        /// <summary>
        /// This event is triggered after a circle has been saved to the database.
        /// </summary>
        public event EventHandler Saved;

        protected void OnSaved(EventArgs e) {
            var eventHandler = Saved;

            if (eventHandler != null) {
                eventHandler(this, e);
            }
        }

        public void Save() {
            CircleID = Database.SaveCircle(this);

            if (!circles.Contains(this)) {
                circles.Add(this);
            }
            OnSaved(EventArgs.Empty);
        }

        /// <summary>
        /// This event is triggered after a circle has been deleted from the database.
        /// </summary>
        public event EventHandler Deleted;

        protected void OnDeleted(EventArgs e) {
            var eventHandler = Deleted;

            if (eventHandler != null) {
                eventHandler(this, e);
            }
        }

        public void Delete() {
            Database.DeleteCircle(this);
            circles.Remove(this);
            OnDeleted(EventArgs.Empty);
        }
    }
}
