using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GameManager {
    public class Game {
        private static List<Game> games;

        /// <summary>
        /// Retrieves a list containing all saved games from the database and caches the result.
        /// If the list has been previously retrieved, the cached list is returned. 
        /// </summary>
        public static List<Game> GetGames() {
            if (games == null) {
                games = Database.GetGames();
            }
            return games;
        }

        /// <summary>
        /// The path of this game's image directory relative to the program directory path.
        /// </summary>
        public string RelativeImageFolderPath { get { return System.IO.Path.Combine(Settings.RelativeImageFolderPath, RJCode != null ? RJCode : "Untitled"); } }

        //Properties initialised by the database call getGames()
        public int? GameID { set; get; }
        public string Title { set; get; }
        public string Path { set; get; }
        public byte? Rating { set; get; }
        public byte? DLSRating { set; get; }
        public DateTime? ReleaseDate { set; get; }
        public DateTime? AddedDate { set; get; }
        public DateTime? LastPlayedDate { set; get; }
        public int TimesPlayed { set; get; }
        public TimeSpan TimePlayed { set; get; }
        public string Category { get; set; }
        public string Language { get; set; }
        public string Tags { get; set; }
		public string HVDBTags { get; set; }
		public string CVs { get; set; }
		public string HVDBTitle { get; set; }
        public string Comments { get; set; }
        public GameImage ListImage { set; get; }
        public List<GameImage> Images { set; get; }
        public bool? RunWithAgth { set; get; }
        public bool? RunWithChiiTrans { set; get; }
        public string AgthParameters { set; get; }
        public int? Size { get; set; }
        public bool IsOnEnglishDLSite { get; set; }
        public bool IsOnJapaneseDLSite { get; set; }
        public bool IsReleasedOnJapaneseDLSite { get; set; }
        public bool IsReleasedOnEnglishDLSite { get; set; }
		public bool IsOnHVDB { get; set; }
        public bool IsRpgMakerGame { get; set; }
        public string WolfRpgMakerVersion { get; set; }
        public bool UseCustomResolution { get; set; }
        public ScreenResolution CustomResolution { set; get; }
        private string rjCode;

        public string RJCode {
            set {
                rjCode = value;
            }
            get {
                if (!String.IsNullOrEmpty(rjCode) && Char.IsNumber(rjCode[0])) {
                    return "RJ" + rjCode;
                }
                else {
                    return rjCode;
                }
            }
        }

        private Circle author;

        public Circle Author {
            set {
                if (author != null) {
                    author.Deleted -= Author_Deleted;
                }

                if (value != null) {
                    value.Deleted += Author_Deleted;
                }
                author = value;
            }
            get {
                return author;
            }
        }

        private GameImage coverImage = null;

        public GameImage CoverImage {
            get {
                if (coverImage == null) {
                    coverImage = Images.FirstOrDefault(image => image.IsCoverImage);
                }
                return coverImage;
            }
            set {
                coverImage = value;

                foreach (var image in Images) {
                    if (image == value) {
                        image.IsCoverImage = true;
                    }
                    else {
                        image.IsCoverImage = false;
                    }
                }
            }
        }

        /// <summary>
        /// This event is triggered after a game has been saved to the database.
        /// </summary>
        public event EventHandler Saved;

        private bool deleted = false;

        public Game() {
            Images = new List<GameImage>();
            IsReleasedOnJapaneseDLSite = true;
            IsReleasedOnEnglishDLSite = true;
        }

        protected void OnSaved(EventArgs e) {
            var eventHandler = Saved;

            if (eventHandler != null) {
                eventHandler(this, e);
            }
        }

        public void Save(bool notifyListeners = true) {
            Task sizeGetter = null;

            if (deleted) {
                return;
            }

            //Check if this is the first time this game is saved
            if (!GameID.HasValue) {
                AddedDate = DateTime.Now;

                if (File.Exists(Path) || Directory.Exists(Path)) {
					string path = Path;
					if (File.Exists(path)) {
						path = System.IO.Path.GetDirectoryName(path);
					}
                    IsRpgMakerGame = IOUtility.IsRpgMakerGame(Path);
                    WolfRpgMakerVersion = IOUtility.GetWolfRpgVersion(Path);
					
                    if (Title == null && Settings.Instance.GetTitleFromPath) {
                        Title = new DirectoryInfo(path).Name;
                    }

                    if (path != null && !Size.HasValue && Settings.Instance.AutoUpdateGameSize) {
                        sizeGetter = new Task(() => {
                            Size = IOUtility.GetDirectorySize(path) / 1024;
                            Save(false);
                        });
                    }
                }
            }

            GameID = Database.SaveGame(this);

            if (sizeGetter != null) {
                sizeGetter.Start();
            }

            if (!games.Contains(this)) {
                games.Add(this);
            }

            if (notifyListeners) {
                OnSaved(EventArgs.Empty);
            }
        }

        public void Delete() {
            deleted = true;
            Database.DeleteGame(this);
            games.Remove(this);
        }

        /// <summary>
        /// Returns a shallow copy of this game.
        /// </summary>
        /// <returns></returns>
        public Game Copy() {
            return (Game)MemberwiseClone();
        }

        /// <summary>
        /// Downloads and extracts information about this game from DLSite.
        /// If this game does not have an associated RJCode, nothing is done. 
        /// </summary>
        /// <param name="downloadImagesInParallel">If true, each game image will be downloaded in its own thread.</param>
        /// <param name="ReportDownloadProgress">This delegate is called when there is download progress to report. </param>
        /// <param name="downloadCanceller">If the specified token is signalled, the download will end. </param>
        /// <exception cref="UriFormatException">Thrown if some extracted image URL is invalid. </exception>
        /// <exception cref="PageNotFoundException">Thrown if no DLSite page matches the game's RJCode. </exception>
        /// <exception cref="WebException">Thrown if a connection to DLSite cannot be established. </exception>
        public void DownloadInfo(bool downloadImagesInParallel, Action<string> ReportDownloadProgress = null, CancellationToken? downloadCanceller = null) {
            if (RJCode == null) {
                return;
            }

            DLSitePage page;
            var engDLSite = new EnglishDLSitePage(RJCode);
            var jpDLSite = new JapaneseDLSitePage(RJCode);
            var preferredLanguageAvailable = true;
            var imagesDownloaded = 0;

            Task<byte?> ratingDownloader = null;
            Task<int> sizeGetter = null;
            Task translatorTask = null;
            Task<bool> engPageDownloader = Task.Factory.StartNew(() => engDLSite.DownloadPageData());
            Task<bool> jpPageDownloader = Task.Factory.StartNew(() => jpDLSite.DownloadPageData()); ;
            
            if (Settings.Instance.DownloadRating) {
                ratingDownloader = Task.Factory.StartNew(() => jpDLSite.DownloadRating());
            }

            if (Settings.Instance.AutoUpdateGameSize) {
				if (File.Exists(Path) || Directory.Exists(Path)) {
					string path = Path;
					if (File.Exists(path)) {
						path = System.IO.Path.GetDirectoryName(path);
					}
					sizeGetter = Task.Factory.StartNew(() => {
						return IOUtility.GetDirectorySize(path) / 1024;
					});					
				}
            }

			IsRpgMakerGame = IOUtility.IsRpgMakerGame(Path);
            WolfRpgMakerVersion = IOUtility.GetWolfRpgVersion(Path);
			
            if (ReportDownloadProgress != null) {
                ReportDownloadProgress("Downloading page " + jpDLSite.Url + "...");
            }

            //Getting the result of a page download throws an exception if a connection to the internet could not be established
            try {
                IsOnEnglishDLSite = engPageDownloader.Result;
                IsOnJapaneseDLSite = jpPageDownloader.Result;
            }
            catch (AggregateException e) {
                throw e.InnerException;
            }
			


            IsReleasedOnEnglishDLSite = engDLSite.ReleasePageExists;
            IsReleasedOnJapaneseDLSite = jpDLSite.ReleasePageExists;
			if (IsOnJapaneseDLSite) {
				IsOnHVDB = jpDLSite.IsOnHVDB;
			}
			else if (IsOnEnglishDLSite) {
				IsOnHVDB = engDLSite.IsOnHVDB;
			}
			else {
				IsOnHVDB = false;
			}
			

            if (!IsOnEnglishDLSite && !IsOnJapaneseDLSite) {
                throw new PageNotFoundException("No game with the code " + RJCode + " found.");
            }
            else if (Settings.Instance.DLSiteLanguage == DLSitePage.Language.Japanese) {
                if (IsOnJapaneseDLSite) {
                    page = jpDLSite;
                }
                else {
                    page = engDLSite;
                    preferredLanguageAvailable = false;
                }
            }
            else {
                if (IsOnEnglishDLSite) {
                    page = engDLSite;
                }
                else {
                    page = jpDLSite;
                    preferredLanguageAvailable = false;
                }
            }

            if (preferredLanguageAvailable || Settings.Instance.UseAlternativeDLSiteLanguages) {
				if (Settings.Instance.AutoSetCategory) {
					Category = page.GetCategory();
				}				
                Title = page.GetTitle();


                if (Settings.Instance.DownloadTags) {
                    Tags = page.GetTags();
					if (Settings.Instance.DownloadReviewTags) {
						if (IsOnJapaneseDLSite) {
							Tags = jpDLSite.GetAggrReviewTags(Tags);						
							Tags = jpDLSite.GetReviewTags(Tags);													
						}
						if (IsOnEnglishDLSite) {
							Tags = engDLSite.GetAggrReviewTags(Tags);
							Tags = engDLSite.GetReviewTags(Tags);
						}
					}
					Tags = Tags.Replace("R*pe", "Rape").Replace("Woman R*pes Man", "Woman Rapes Man").Replace("B*stiality", "Bestiality");	//remove censorship
					if (IsOnJapaneseDLSite && !IsReleasedOnJapaneseDLSite) {
						if (Settings.Instance.DLSiteLanguage == DLSitePage.Language.English) {
							Tags = "/Announce/, " + Tags;
						}
						else {
							Tags = "/予告中/, " + Tags;
						}
					}
				}
				if (Settings.Instance.DownloadHVDBInfo) {
					if (IsOnHVDB) {
						HVDBTags = page.GetHVDBTags();
						CVs = page.GetHVDB_CVs();
						HVDBTitle = page.GetHVDBTitle();
						if (Settings.Instance.DLSiteLanguage == DLSitePage.Language.English && HVDBTitle != "") {
							if (!IsOnEnglishDLSite || (IsOnEnglishDLSite && Settings.Instance.PreferHVDBEnglishTitle)) {
								Title = HVDBTitle;
							}
						}
					}
				}
            }

            //Use Google Translate to translate the title if the English page was not available
            if (!preferredLanguageAvailable && Settings.Instance.DLSiteLanguage == DLSitePage.Language.English && Settings.Instance.UseAlternativeDLSiteLanguages && Settings.Instance.UseGoogleTranslateOnTitleAndTags) {
                translatorTask = TranslateTitleAndTags();
            }

            ReleaseDate = page.GetReleaseDate();
            ListImage = page.GetListImage();
            Author = page.GetAuthor();
            Language = "Japanese";

            if (Author != null) {
                //Check if the database already contains an author with this RGCode before saving it
                Author = Circle.GetCircles().FirstOrDefault(circle => circle.RGCode == Author.RGCode) ?? Author;

                if (!Author.CircleID.HasValue) {
                    Author.Save();
                }
            }

            GameImage coverImage = null;
            List<GameImage> sampleImages = null;

            if (Settings.Instance.DownloadCoverImage) {
                coverImage = page.GetCoverImage();
            }

            if (Settings.Instance.DownloadSampleImages) {
                //Sample images are sometimes missing from the English DLSite, so always download them from the Japanese one if available
                if (IsOnJapaneseDLSite) {
                    sampleImages = jpDLSite.GetSampleImages();
                }
                else {
                    sampleImages = page.GetSampleImages();
                }
            }

            if (downloadCanceller.HasValue && downloadCanceller.Value.IsCancellationRequested) {
                return;
            }

            if (ListImage != null) {
                Images.Add(ListImage);
            }

            if (coverImage != null) {
                Images.Add(coverImage);
            }

            if (sampleImages != null) {
                Images.AddRange(sampleImages);
            }

            if (ReportDownloadProgress != null) {
                ReportDownloadProgress("0/" + Images.Count + " images downloaded.");
            }

            Action<GameImage> downloadImage = image => {
                try {
                    image.Load();
                }
                catch (Exception e) {
                    if (e is BadImageFormatException || e is UriFormatException) {
                        Images.Remove(image);
                    }
                    else {
                        throw;
                    }
                }

                if (downloadCanceller.HasValue && downloadCanceller.Value.IsCancellationRequested) {
                    return;
                }

                if (ReportDownloadProgress != null) {
                    ReportDownloadProgress(++imagesDownloaded + "/" + Images.Count + " images downloaded.");
                }
            };

            var imageListCopy = Images.ToArray();

            if (downloadImagesInParallel) {
                Parallel.ForEach(imageListCopy, downloadImage);
            }
            else {
                foreach (var image in imageListCopy) {
                    downloadImage(image);
                }
            }

            Images.Remove(ListImage);

            if (sizeGetter != null) {
                Size = sizeGetter.Result;
            }

            if (ratingDownloader != null) {
                try {
                    DLSRating = ratingDownloader.Result;
                }
                catch (Exception e) {
                    Logger.LogExceptionIfDebugging(e);
                }
            }

            if (translatorTask != null) {
                translatorTask.Wait();
            }
        }

        private static Object saveImageLock = new Object();

        /// <summary>
        /// Saves all images associated with this game to this game's image folder.
        /// </summary>
        public void SaveImages() {
            int counter = 1;

            Func<string, string> GetUnusedFileName = extension => {
                string imagePath;
                
                do {
                    imagePath = System.IO.Path.Combine(RelativeImageFolderPath, counter.ToString()) + extension;
                    counter++;
                } while (File.Exists(System.IO.Path.Combine(Settings.ProgramDirectoryPath, imagePath)));

                return imagePath;
            };

            //Lock before saving the images to ensure that no two threads are competing for the same file name
            lock (saveImageLock) {
                if (ListImage != null) {
                    ListImage.GameID = GameID.Value;
                    ListImage.Save(GetUnusedFileName(ListImage.ImageExtension));
                }

                if (Images != null) {
                    Images.ForEach(image => {
                        image.GameID = GameID.Value;
                        image.Save(GetUnusedFileName(image.ImageExtension));
                    });
                }
            }
        }

        /// <summary>
        /// Deletes all images associated with this game.
        /// </summary>
        public void DeleteImages() {
            if (ListImage != null) {
                ListImage.Delete();
                ListImage = null;
            }

            if (Images != null && Images.Count != 0) {
                Images.ForEach(image => image.Delete());
                Images.Clear();
            }
        }

        /// <summary>
        /// Uses Google Translate to translate this game's title and tags.
        /// </summary>
        public Task TranslateTitleAndTags() {
            Task task = null;
            var translator = new GoogleTranslate("ja", "en");
            var input = new List<string>();

            if (Title != null) {
                input.Add(Title);
            }

            if (input.Count > 0) {
                var translatorTask = Task.Factory.StartNew(() => translator.TranslateStrings(input.ToArray()));

                task = translatorTask.ContinueWith(_ => {
                    try {
                        var translatedStrings = translatorTask.Result;

                        if (translatedStrings != null) {
                            if (translatedStrings.Length > 0) {
                                Title = translatedStrings[0];
                            }

                        }
                    }
                    catch (Exception e) {
                        Logger.LogExceptionIfDebugging(e);
                    }
                }, TaskContinuationOptions.OnlyOnRanToCompletion);
            }

            return task;
        }

        public override string ToString() {
            if (String.IsNullOrWhiteSpace(Title)) {
                if (String.IsNullOrWhiteSpace(RJCode)) {
                    return "<Untitled game>";
                }
                else {
                    return RJCode;
                }
            }
            else {
                return Title;
            }
        }

        private void Author_Deleted(object sender, EventArgs e) {
            Author = null;
        }
    }
}
