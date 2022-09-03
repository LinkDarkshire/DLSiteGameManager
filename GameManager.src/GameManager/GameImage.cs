using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;

namespace GameManager {
    public class GameImage  {
        private static List<GameImage> images;

        /// <summary>
        /// Retrieves a list containing all saved images from the database and caches the result.
        /// If the list has been previously retrieved, the cached list is returned. 
        /// </summary>
        public static List<GameImage> GetImages() {
            if (images == null) {
                images = Database.GetImages();
            }
            return images;
        }

        //Properties initialised by the database call getImages()
        public int? ImageID { set; get; }
        public int GameID { set; get; } //The owner of this image
        public bool IsCoverImage { set; get; }
        public bool IsListImage { set; get; }
        public string ImagePath { set; get; }

        public string ImageURL { set; get; }

        private FileStream fileStream;
        private Object imageLock = new Object();
        private bool invalidImagePath = false;

        private Image imageData;

        public Image ImageData {
            set {
                imageData = value;
            }
            get {
                if (imageData == null && !invalidImagePath) {
                    lock (imageLock) {
                        if (imageData == null) {
                            Load();
                        }
                    }
                }
                return imageData;
            }
        }

        public string ImageExtension { get { return ImageData.RawFormat.ToFileExtension(); } }

        private Size? imageSize = null;

        public Size ImageSize {
            get {
                if (!imageSize.HasValue) {
                    try {
                        imageSize = ImageData.Size;
                    }
                    catch (NullReferenceException) {
                        //An exception is thrown here if the image fails to load
                        imageSize = Size.Empty;
                    }
                }
                return imageSize.Value;
            }
        }

        /// <summary>
        /// Downloads the image data to memory.
        /// </summary>
        /// <exception cref="UriFormatException">Thrown if the image URL is invalid. </exception>
        /// <exception cref="BadImageFormatException">Thrown if the image URL points to an invalid image type. </exception>
        private void LoadFromUrl() {
            if (ImageURL != null) {
                try {
                    using (var downloader = new WebClient()) {
                        downloader.Proxy = null;

                        imageData = Image.FromStream(new MemoryStream(downloader.DownloadData(ImageURL)));
                    }
                }
                catch (Exception e) {
                    if (e is WebException && e.Message != null && e.Message.Contains("404")) {
						if (ImageURL.Contains("/RE")) {												//fix for when there are RE cover but RJ list image
							ImageURL = ImageURL.Replace("/RE", "/RJ");
							LoadFromUrl();
						}
						else {
							throw new UriFormatException("The image " + ImageURL + " does not exist.", e);
						}
                    }
                    else if (e is ArgumentException || (e is WebException && e.Message != null && e.Message.Contains("500"))) {
                        throw new BadImageFormatException(ImageURL + " points to an invalid image type.", e);
                    }
                    else {
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Loads the image data from the disk.
        /// </summary>
        /// <exception cref="FileNotFoundException">Thrown if the image path is invalid. </exception>
        /// <exception cref="BadImageFormatException">Thrown if the image path points to an invalid image type. </exception>
        private void LoadFromDisk() {
            if (ImagePath != null) {
                string absoluteImagePath = ImagePath;

                if (!Path.IsPathRooted(ImagePath)) {
                    absoluteImagePath = Path.Combine(Settings.ProgramDirectoryPath, ImagePath);
                }

                if (!File.Exists(absoluteImagePath)) {
                    throw new FileNotFoundException("The image " + ImagePath + " does not exist.");
                }

                try {
                    var fileStream = new FileStream(absoluteImagePath, FileMode.Open, FileAccess.Read);
                    imageData = Image.FromStream(fileStream);

                    //If a file containing a gif image is closed, the program will crash when trying to animate the gif 
                    if (ImageExtension != ".gif") {
                        fileStream.Dispose();
                    }
                    else {
                        this.fileStream = fileStream;
                    }
                }
                catch (OutOfMemoryException e) {
                    throw new BadImageFormatException(absoluteImagePath + " is not a valid image type.", e);
                }
            }
        }

        /// <summary>
        /// Loads and caches the image data.
        /// </summary>
        /// <exception cref="FileNotFoundException">Thrown if the image path or URL is invalid. </exception>
        /// <exception cref="BadImageFormatException">Thrown if the image path or URL points to an invalid image type. </exception>
        public void Load() {
            lock (imageLock) {
                try {
                    if (ImagePath != null) {
                        LoadFromDisk();
                    }
                    else if (ImageURL != null) {
                        LoadFromUrl();
                    }
                    else {
                        Debug.Assert(false, "Game image has no URL");
                        invalidImagePath = true;
                    }
                }
                catch (Exception e) {
                    invalidImagePath = true;
                    Logger.LogExceptionIfDebugging(e);
                }
            }
        }

        /// <summary>
        /// Returns true if the file containing the image data exists.
        /// </summary>
        public bool Exists() {
            return imageData != null || (!invalidImagePath && ImagePath != null && File.Exists(Path.Combine(Settings.ProgramDirectoryPath, ImagePath)));
        }

        /// <summary>
        /// Saves the image data to the specified file and updates the database object.
        /// If the image already exists, it is overwritten.
        /// </summary>
        public void Save(string path) {
            //If the image data has already been saved to disk, don't save it again
            if (ImageData != null && path != null && (ImagePath == null || !Exists())) {
                string absoluteImagePath = path;
                ImagePath = path;

                if (String.IsNullOrEmpty(Path.GetExtension(ImagePath))) {
                    ImagePath += ImageExtension;
                }

                if (!Path.IsPathRooted(ImagePath)) {
                    absoluteImagePath = Path.Combine(Settings.ProgramDirectoryPath, ImagePath);
                }

                string imageDirectory = Path.GetDirectoryName(absoluteImagePath);

                if (!Directory.Exists(imageDirectory)) {
                    Directory.CreateDirectory(imageDirectory);
                }

                try {
                    File.Delete(absoluteImagePath);
                }
                catch (Exception) {
                    //The already existing image file cannot be deleted, so replace the file name with a random name
                    ImagePath = Path.GetRandomFileName() + Path.GetExtension(ImagePath);
                    Path.Combine(Settings.ProgramDirectoryPath, ImagePath);
                }

                try {
                    ImageData.Save(absoluteImagePath);
                }
                catch (ExternalException e) {
                    //This exception is thrown if GDI+ fails to save the image
                    Logger.LogExceptionIfDebugging(e);
                    Dispose();
                    invalidImagePath = true;
                    imageSize = null;
                }
            }

            //Save the image object to the database
            ImageID = Database.SaveImage(this);

            if (!images.Contains(this)) {
                images.Add(this);
            }
        }

        private Dictionary<Size, Image> cachedThumbnails = new Dictionary<Size, Image>(4);

        /// <summary>
        /// Creates a thumbnail image of the specified size.
        /// </summary>
        public Image GetThumbnail(Size size) {
            lock (imageLock) {
                if (cachedThumbnails.ContainsKey(size)) {
                    return cachedThumbnails[size];
                }
                else {
                    if (cachedThumbnails.Count >= 3) {
                        var keys = new List<Size>(cachedThumbnails.Keys);

                        //Dispose images that won't be accessed again
                        foreach (var key in keys) {
                            if (key != Settings.Instance.ImageSizeInList &&
                                    key != Settings.Instance.ImageSizeInPanel &&
                                    key != Settings.Instance.ImageSizeInTile) {
                                cachedThumbnails[key].Dispose();
                                cachedThumbnails.Remove(key);
                            }
                        }
                    }
                    Debug.Assert(cachedThumbnails.Count < 3, "The number of cached thumbs should be less than 3 at this point.");
                    
                    Image thumb = ImageData.GetHighQualityThumbnail(size.Width, size.Height);
                    cachedThumbnails[size] = thumb;

                    //Unload the image that was used to create the thumbnail unless the image is a list image that is smaller than
                    //the width and height of a panel image, because such an image might currently be displayed in the panel
                    if (!IsListImage || ImageSize.Width > Settings.Instance.ImageSizeInPanel.Width || ImageSize.Height > Settings.Instance.ImageSizeInPanel.Height) {
                        UnloadImageData();
                    }

                    return thumb;
                }
            }
        }

        /// <summary>
        /// Unloads the full sized image from memory.
        /// </summary>
        /// <param name="unloadUnsavedImages">If true, full sized images not yet saved to the disk will also be unloaded.</param>
        public void UnloadImageData(bool unloadUnsavedImages = false) {
            if (unloadUnsavedImages || ImageID.HasValue) {
                lock (imageLock) {
                    if (imageData != null) {
                        imageData.Dispose();
                    }
                    imageData = null;
                }
            }
        }

        /// <summary>
        /// Frees up all resources allocated by this object.
        /// If the image data is accessed after this call, it will be reloaded.
        /// </summary>
        public void Dispose() {
            lock (imageLock) {
                UnloadImageData(true);

                foreach (var thumbnail in cachedThumbnails.Values) {
                    thumbnail.Dispose();
                }
                cachedThumbnails.Clear();
            }
        }

        /// <summary>
        /// Deletes this image object from the database and the image file from the disk if one exists.
        /// </summary>
        public void Delete() {
            lock (imageLock) {
                Database.DeleteImage(this);
                images.Remove(this);
                Dispose();

                //The file stream is kept open for GIF images to make animation work. It must be closed before deleting the image
                if (fileStream != null) {
                    fileStream.Dispose();
                    fileStream = null;
                }

                if (ImagePath != null) {
                    try {
                        var absolutePath = Path.Combine(Settings.ProgramDirectoryPath, ImagePath);
                        var imageDirectory = Path.GetDirectoryName(absolutePath);

                        File.Delete(absolutePath);

                        if (IOUtility.IsDirectoryEmpty(imageDirectory)) {
                            Directory.Delete(imageDirectory);
                        }
                    }
                    catch (Exception e) {
                        if (e is DirectoryNotFoundException) {
                            //The file has already been deleted
                        }
                        else if (e is IOException || e is UnauthorizedAccessException) {
                            Logger.LogException(e);
                        }
                        else {
                            Logger.LogException(e);
                            throw;
                        }
                    }
                }
            }
        }
    }
}
