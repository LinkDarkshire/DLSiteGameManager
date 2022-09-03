using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GameManager {
    public partial class ImageViewControl : UserControl {
        /// <summary>
        /// Gets a collection containing the images currently displayed in the image view control.
        /// </summary>
        public ReadOnlyCollection<GameImage> DisplayedImages {
            get {
                return new ReadOnlyCollection<GameImage>(displayedImages);
            }
        }

        private int scrollPosition = 0;
        private Game game; //The owner of the displayed images
        private GameImage hoveredImage = null, rightClickedImage = null;
        private List<GameImage> displayedImages = new List<GameImage>();
        private Game previouslyDisplayedGame = null;

        public class ImageCollectionAlteredEventArgs : EventArgs {
            public bool ImagesAdded, ImageRemoved, ListImageChanged;
        }

        /// <summary>
        /// Triggered when the collection of images displayed in this image view control is altered by the user.
        /// </summary>
        public event EventHandler<ImageCollectionAlteredEventArgs> ImageCollectionAltered;

        private void OnImageCollectionAltered(ImageCollectionAlteredEventArgs e) {
            var handler = ImageCollectionAltered;

            if (handler != null) {
                handler(this, e);
            }
        }

        /// <summary>
        /// Contains the game image object being hovered.
        /// </summary>
        public class GameImageHoveredEventArgs : EventArgs {
            public GameImage HoveredImage { private set; get; }

            public GameImageHoveredEventArgs(GameImage hoveredImage) {
                HoveredImage = hoveredImage;
            }
        }

        /// <summary>
        /// Triggered when the mouse cursor is resting on a game image in this image view control.
        /// </summary>
        public event EventHandler<GameImageHoveredEventArgs> GameImageMouseHover;

        protected void OnGameImageMouseHover(GameImageHoveredEventArgs e) {
            var handler = GameImageMouseHover;

            if (handler != null) {
                handler(this, e);
            }
        }

        /// <summary>
        /// Triggered when the mouse cursor has left the bounds of a game image in this image view control.
        /// </summary>
        public event EventHandler GameImageMouseLeave;

        protected void OnGameImageMouseLeave(EventArgs e) {
            var handler = GameImageMouseLeave;

            if (handler != null) {
                handler(this, e);
            }
        }

        public ImageViewControl() {
            InitializeComponent();

            foreach (Control c in Controls) {
                c.Font = Settings.Instance.GlobalFont;
            }

            //Always keep the scroll buttons on the edges of the control
            SizeChanged += (sender, e) => {
                scrollRightButton.Bounds = new Rectangle(new Point(Width - scrollRightButton.Width, Height - scrollRightButton.Height), scrollRightButton.Size);
                scrollLeftButton.Bounds = new Rectangle(new Point(0, Height - scrollLeftButton.Height), scrollLeftButton.Size);
            };

            Settings.Instance.Saved += (settings, e) => {
                //Resize the previously displayed images to match the new settings
                var prevDisplayedImages = displayedImages.ToArray();
                ClearImages();
                AddImages(prevDisplayedImages);
            };
        }

        /// <summary>
        /// Displays the specified image collection in the image view control.
        /// </summary>
        private void AddImages(params GameImage[] images) {
            if (images != null) {
                lock (displayedImages) {
                    mainContainer.SuspendLayout();

                    for (int i = 0; i < images.Length; i++) {
                        var image = images[i];
                        var size = Settings.Instance.ImageSizeInPanel;

                        if (image != null && image.ImageSize.Width > 0 && image.ImageSize.Height > 0 && size.Width > 0 && size.Height > 0) {
                            displayedImages.Add(image);
                            var box = new PictureBox();

                            //Create a thumbnail if necessary
                            if (image.ImageSize.Width > size.Width || image.ImageSize.Height > size.Height) {
                                box.Image = image.GetThumbnail(size);
                                box.Size = image.GetThumbnail(size).Size;
                            }
                            else {
                                box.Image = image.ImageData;
                                box.Size = image.ImageSize;
                            }
                            box.Tag = image;
                            box.Cursor = Cursors.Hand;
                            box.ContextMenuStrip = pictureMenuStrip;
                            box.BorderStyle = BorderStyle.FixedSingle;
                            box.Margin = new Padding(4);

                            box.MouseEnter += box_MouseEnter;
                            box.MouseHover += box_MouseHover;
                            box.MouseLeave += box_MouseLeave;
                            box.MouseClick += box_MouseClick;
                            box.MouseWheel += box_MouseWheel;

                            mainContainer.Controls.Add(box);
                            mainContainer.ColumnCount++;
                            mainContainer.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                        }
                    }
                    mainContainer.ResumeLayout();
                }
            }
        }

        /// <summary>
        /// Removes all images currently displaying in the image view control.
        /// </summary>
        public void ClearImages() {
            lock (displayedImages) {
                foreach (var obj in mainContainer.Controls) {
                    ((PictureBox)obj).Image = null;
                    ((PictureBox)obj).Dispose();
                }
                scrollPosition = 0;
                mainContainer.Controls.Clear();
                mainContainer.ColumnCount = 0;
                mainContainer.ColumnStyles.Clear();
                displayedImages.Clear();
            }
        }

        /// <summary>
        /// Displays the specified game's image collection in the image view control.
        /// </summary>
        public void SetGame(Game game) {
            previouslyDisplayedGame = this.game;
            this.game = game;

            mainContainer.SuspendLayout();
            ClearImages();

            //Clean up the old image data
            if (previouslyDisplayedGame != null && previouslyDisplayedGame.Images != null) {
                foreach (var image in previouslyDisplayedGame.Images) {
                    image.UnloadImageData();
                }
            }

            //Add the new image data
            if (game != null) {
                var imagesToDisplay = new GameImage[game.Images.Count + 1];
                int i;

                for (i = 0; i < game.Images.Count; i++) {
                    imagesToDisplay[i] = game.Images[i];
                }
                imagesToDisplay[i] = game.ListImage;

                AddImages(imagesToDisplay);
            }
            mainContainer.ResumeLayout();
        }

        /// <summary>
        /// Scrolls the image list one image to the right
        /// </summary>
        private void ScrollRight() {
            if (scrollPosition < mainContainer.ColumnCount - 1) {
                //Hide the leftmost picture cell by setting its size to 0
                mainContainer.ColumnStyles[scrollPosition].Width = 0;
                mainContainer.ColumnStyles[scrollPosition].SizeType = SizeType.Absolute;
                scrollLeftButton.Visible = Settings.Instance.ShowImageScrollButtons;
                scrollPosition++;
            }
        }

        /// <summary>
        /// Scrolls the image list one image to the left
        /// </summary>
        private void ScrollLeft() {
            if (scrollPosition > 0) {
                mainContainer.ColumnStyles[scrollPosition - 1].SizeType = SizeType.AutoSize;
                scrollRightButton.Visible = Settings.Instance.ShowImageScrollButtons;
                scrollPosition--;
            }
        }

        /// <summary>
        /// Scrolls the image list back to the leftmost image
        /// </summary>
        private void ResetScroll() {
            if (scrollPosition != 0) {
                scrollPosition = 0;
                mainContainer.SuspendLayout();

                for (int i = 0; i < mainContainer.ColumnStyles.Count; i++) {
                    mainContainer.ColumnStyles[i].SizeType = SizeType.AutoSize;
                }

                mainContainer.ResumeLayout();
            }
        }

        /// <summary>
        /// Shows the scroll buttons when the mouse pointer enters the bounds of the control.
        /// Must be added to each child of the container.
        /// </summary>
        private void MouseEntered(object sender, EventArgs e) {
            if (Settings.Instance.ShowImageScrollButtons) {
                scrollRightButton.Visible = scrollPosition < mainContainer.ColumnCount - 1;
                scrollLeftButton.Visible = scrollPosition > 0;
            }
        }

        /// <summary>
        /// Hides the scroll buttons when the mouse pointer leaves the bounds of the control.
        /// Must be added to each child of the container.
        /// </summary>
        private void MouseLeft(object sender, EventArgs e) {
            //Check that the mouse pointer actually left
            if (!ClientRectangle.Contains(PointToClient(Control.MousePosition))) {
                scrollLeftButton.Visible = scrollRightButton.Visible = false;
                OnGameImageMouseLeave(EventArgs.Empty);
            }
        }

        private void box_MouseEnter(object sender, EventArgs e) {
            var box = (PictureBox)sender;

            hoveredImage = (GameImage)box.Tag;
            MouseEntered(sender, e);
        }

        private void box_MouseHover(object sender, EventArgs e) {
            var box = (PictureBox)sender;
            OnGameImageMouseHover(new GameImageHoveredEventArgs((GameImage)box.Tag));
        }

        private void box_MouseLeave(object sender, EventArgs e) {
            MouseLeft(sender, e);
        }

        private void box_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                if (scrollPosition < mainContainer.ColumnCount - 1) {
                    ScrollRight();
                }
                else {
                    ResetScroll();
                }
            }
        }

        private void box_MouseWheel(object sender, MouseEventArgs e) {
            if (e.Delta < 0) {
                ScrollRight();
            }
            else if (e.Delta > 0) {
                ScrollLeft();
            }
        }

        private void scrollRightButton_Click(object sender, EventArgs e) {
            ScrollRight();
        }

        private void scrollLeftButton_Click(object sender, EventArgs e) {
            ScrollLeft();
        }

        private void addNewImageMenuStrip_Opening(object sender, CancelEventArgs e) {
            e.Cancel = game == null;
        }

        private void pictureMenuStrip_Opening(object sender, CancelEventArgs e) {
            rightClickedImage = hoveredImage;
            setListImageToolStripMenuItem.Text = (rightClickedImage.IsListImage ? "Remove" : "Use as") + " list image";
            setCoverImageToolStripMenuItem.Text = (game.CoverImage == rightClickedImage ? "Remove" : "Use as") + " cover image";
        }

        private void addNewImageToolStripMenuItem_Click(object sender, EventArgs e) {
            var result = openImageDialog.ShowDialog(this);

            if (result == DialogResult.OK) {
                var images = new List<GameImage>(openImageDialog.FileNames.Length);

                foreach (var fileName in openImageDialog.FileNames) {
                    images.Add(new GameImage { ImagePath = fileName });
                }
                AddImages(images.ToArray());
            }
            OnImageCollectionAltered(new ImageCollectionAlteredEventArgs { ImagesAdded = true });
        }

        private void setListImageToolStripMenuItem_Click(object sender, EventArgs e) {
            if (rightClickedImage.IsListImage) {
                rightClickedImage.IsListImage = false;
            }
            else {
                foreach (var image in displayedImages) {
                    if (image.IsListImage) {
                        image.IsListImage = false;
                    }
                }
                rightClickedImage.IsListImage = true;
            }
            OnImageCollectionAltered(new ImageCollectionAlteredEventArgs { ListImageChanged = true });
        }

        private void setCoverImageToolStripMenuItem_Click(object sender, EventArgs e) {
            if (game.CoverImage == rightClickedImage) {
                rightClickedImage.IsCoverImage = false;
                game.CoverImage = null;
            }
            else {
                rightClickedImage.IsCoverImage = true;
                game.CoverImage = rightClickedImage;
            }
            OnImageCollectionAltered(new ImageCollectionAlteredEventArgs { ListImageChanged = true });
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            if (rightClickedImage != null) {
                displayedImages.Remove(rightClickedImage);
                var imagesToAdd = displayedImages.ToArray();

                mainContainer.SuspendLayout();
                ClearImages();
                AddImages(imagesToAdd);
                mainContainer.ResumeLayout();
                OnImageCollectionAltered(new ImageCollectionAlteredEventArgs { ImageRemoved = true });
            }
        }
    }
}
