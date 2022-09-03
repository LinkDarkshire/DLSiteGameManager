using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace GameManager {
    /// <summary>
    /// Contains DLSite-specific information for a specific game. 
    /// </summary>
    public abstract class DLSitePage {
        public enum Language {
            English, Japanese
        }

        public enum Type {
            Maniax, Book, Pro
        }

        /// <summary>
        /// Returns true if the specified string is a valid DLSite code.
        /// RJCodes are valid 32 bit numbers prefixed with 'rj', 're', 'vj' or 'bj'.
        /// </summary>
        public static bool IsValidRjCode(string rjCode) {
            int tmp;

            if (rjCode.Length < 3) {
                return false;
            }

            //If the first two characters are vj, bj, rj or re, check if the rest of the string is a number
            if (Regex.IsMatch(rjCode.Substring(0, 2), "vj|bj|rj|re", RegexOptions.IgnoreCase)) {
                if (Int32.TryParse(rjCode.Substring(2), out tmp)) {
                    return true;
                }
            }
            else if (Int32.TryParse(rjCode, out tmp)) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// The URL pointing to this DLSite page.
        /// </summary>
        public abstract string Url { get; }

        /// <summary>
        /// Determines if the release page or the announce page should be downloaded.
        /// </summary>
        public bool ReleasePageExists { get; set; }

        /// <summary>
        /// The game's DLSite identifier with the prefix removed.
        /// </summary>
        protected string rjCode;

        /// <summary>
        /// The raw html code.
        /// </summary>
        protected string html;

        /// <summary>
        /// The raw html code of english Advanced Search page.
        /// </summary>		
	    public static string htmlfs;

        /// <summary>
        /// The raw html code of HVDB page.
        /// </summary>		
	    protected string html_hvdb;
		
        /// <summary>
        /// Determines if the work type is Voice.
        /// </summary>
        public bool IsVoice { get; set; }

		/// <summary>
        /// Determines if the work is on HVDB.
        /// </summary>
        public bool IsOnHVDB { get; set; }
		
        /// <summary>
        /// The DLSite product type.
        /// </summary>
        protected Type type = Type.Maniax;

        /// <summary>
        /// Creates a new DLSite page.
        /// </summary>
        /// <param name="rjCode">The game's DLSite identifier. </param>
        public DLSitePage(string rjCode) {
            if (!IsValidRjCode(rjCode)) {
                throw new ArgumentException(rjCode + " is an invalid DLSite code.");
            }

            switch (rjCode.Substring(0, 2).ToLower()) {
                case "rj":
                    type = Type.Maniax; break;
                case "re":
                    type = Type.Maniax; break;
                case "vj":
                    type = Type.Pro; break;
                case "bj":
                    type = Type.Book; break;
            }

            this.rjCode = rjCode.RemoveNonDigits();
            ReleasePageExists = true;
        }

        /// <summary>
        /// Downloads the DLSite page data. This function blocks the caller until the page is successfully downloaded.
        /// Returns true if the page is successfully downloaded, false if the page does not exist.
        /// </summary>
        /// <exception cref="WebException">Thrown if a connection to DLSite cannot be established.</exception>
        public virtual bool DownloadPageData() {
            using (WebClient client = new WebClient()) {
                try {
                    client.Proxy = null;
                    client.Encoding = Encoding.UTF8;
                    html = client.DownloadString(Url);
					if (String.IsNullOrEmpty(htmlfs)) {
						if (Settings.Instance.DLSiteLanguage == DLSitePage.Language.English) {
							htmlfs = client.DownloadString("http://www.dlsite.com/ecchi-eng/fs");
						}
						else {
							htmlfs = client.DownloadString("http://www.dlsite.com/maniax/fs");
						}
					}					
					
                }
                catch (WebException e) {
                    if (e.Status == WebExceptionStatus.ProtocolError) {
                        //If the 'work' version of this page is not responding, try getting the 'announce' version instead
                        if (ReleasePageExists) {
                            ReleasePageExists = false;
                            return DownloadPageData();
                        }
                        else {
                            return false;
                        }
                    }
                    else {
                        throw;
                    }
                }
				
				try {
					if (html.IndexOf("icon_SOU") == -1 && html.IndexOf("icon_SND") == -1) {		//detecting if work type is Voice
						IsVoice = false;
					}
					else {
						IsVoice = true;
					}
					
					if (IsVoice == true && Settings.Instance.DownloadHVDBInfo) {						//downloading HVDB page
						html_hvdb = client.DownloadString("http://hvdb.me/Dashboard/Details/" + rjCode.RemoveNonDigits());
						if (html_hvdb.IndexOf(rjCode) == -1) {
							html_hvdb = "";					//if HVDB page not exists, set to empty string
							IsOnHVDB = false;
						}
						else {
							IsOnHVDB = true;
						}
					}
				}
				catch (WebException e) {
                    if (e.Status == WebExceptionStatus.ProtocolError) {//System.Windows.Forms.MessageBox.Show(e.Message);
                        IsOnHVDB = false;
                    }
                    else {
                        throw;
                    }
				}
            }
            return true;
        }

        /// <summary>
        /// Returns the title of the game.
        /// </summary>
        public virtual string GetTitle() {
            if (html != null) {
                //Parse the HTML to find the title
                string searchString_start = "<meta property=\"og:title\" content=\"";
                string searchString_end = "| DLsite";
                int titleStartIndex = html.IndexOf(searchString_start);

                //Get the index of the ending search string, detect first [ character from there
                //Really bad, change later to something more configurable, or an element unlikely to be changed like navegation on top of title
                int titleEndIndex = html.IndexOf(searchString_end, titleStartIndex);
                searchString_end = html.Substring(html.LastIndexOf(" [", titleEndIndex), titleEndIndex - html.LastIndexOf(" [", titleEndIndex));

                if (titleStartIndex != -1 && titleEndIndex != -1) {
                    titleStartIndex += searchString_start.Length;

                    int titleLength = html.IndexOf(searchString_end, titleStartIndex) - titleStartIndex;

                    if (titleLength > 0) {
                        return html.Substring(titleStartIndex, titleLength).HtmlDecode().Replace("\n", "").Trim();
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Returns the circle that made this game or null if no circle is found.
        /// </summary>
        public virtual Circle GetAuthor() {
            if (html != null) {
                //Find the the circle information
                int index = html.IndexOf("class=\"maker_name\"");
                Circle circle = new Circle();

                if (index != -1) {
                    string prefix = type == Type.Book ? "BG" : (type == Type.Pro ? "VG" : "RG");

                    //Find the RGCode
                    index = html.IndexOf(prefix, index, StringComparison.InvariantCultureIgnoreCase);

                    if (index != -1) {
                        int rgCodeLength = html.IndexOf(".htm", index) - index;
                        circle.RGCode = html.Substring(index, rgCodeLength);

                        //Find the circle name
                        index = html.IndexOf("\">", index);

                        //The name is sometimes enclosed in 'span' tags. If so, skip it
                        if (index != -1 && html[index + 2] == '<') {
                            index = html.IndexOf("\">", index + 2);
                        }

                        if (index != -1) {
                            index += 2;

                            int nameLength = html.IndexOf("</a>", index) - index;
                            circle.Name = html.Substring(index, nameLength).HtmlDecode();

                            if (circle.Name.EndsWith("</span>")) {
                                circle.Name = circle.Name.Substring(0, circle.Name.Length - 7);
                            }
                            return circle;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Returns the date this game was released, if one is found.
        /// </summary>
        public virtual DateTime? GetReleaseDate() {
            if (html != null) {
                //Find the location of the date
                int index = html.IndexOf("id=\"work_outline\"");
                string year, month, day;

                if (index != -1) {
                    index = html.IndexOf("year", index);

                    if (index != -1) {
                        index += 5;

                        year = html.Substring(index, 4);
                        index = html.IndexOf("mon", index);

                        if (index != -1) {
                            index += 4;

                            //Months can either be 1 digit or 2
                            if (char.IsDigit(html[index + 1])) {
                                month = html.Substring(index, 2);
                            }
                            else {
                                month = html.Substring(index, 1);
                            }
                            index = html.IndexOf("day", index);

                            if (index != -1) {
                                index += 4;

                                if (char.IsDigit(html[index + 1])) {
                                    day = html.Substring(index, 2);
                                }
                                else {
                                    day = html.Substring(index, 1);
                                }

                                try {
                                    return new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
                                }
                                catch (Exception) {
                                    //Ignore and return null if the resulting datetime is invalid
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Returns the cover image for this game, or null if one does not exist.
        /// </summary>
        public virtual GameImage GetCoverImage() {
            if (html != null) {
                //Get the general area of where the image is located
                int index = html.IndexOf("ref=\"product_slider_data\"");

                if (index != -1) {
                    index = html.IndexOf("data-src=\"", index);

                    if (index != -1) {
                        index += 10;
                       
                        //The image URL is sometimes prepended with control characters. Get rid of them
                        while (!Char.IsLetterOrDigit(html[index])) {
                            index++;
                        }

                        int urlLength = html.IndexOf("\"", index) - index;
                        string url = html.Substring(index, urlLength);

                        if (url.StartsWith("images")) {
                            url = url.Insert(0, "www.dlsite.com/");
                        }
                        if (!url.StartsWith("http")) {
                            url = url.Insert(0, "http://");
                        }

                        return new GameImage { ImageURL = url, IsCoverImage = true };
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Returns the 100x100 list image for this game, or null if one does not exist.
        /// </summary>
        public virtual GameImage GetListImage() {
            var coverImage = GetCoverImage();

            if (coverImage != null) {
                coverImage.ImageURL = coverImage.ImageURL.Replace("_main", "_sam");
                coverImage.IsCoverImage = false;
                coverImage.IsListImage = true;
            }
            return coverImage;
        }

        /// <summary>
        /// Returns a list containing all sample images on the DLSite of this game.
        /// </summary>
        public virtual List<GameImage> GetSampleImages() {
            var images = new List<GameImage>();

            if (html != null) {
                int index = html.IndexOf("ref=\"product_slider_data\"");
                index = html.IndexOf("\" data-width=\"", index);

                while (index != -1) {
                    index = html.IndexOf("data-src=\"", index);

                    if (index != -1) {
                        index += 10;

                        //The image URL is sometimes prepended with control characters. Get rid of them
                        while (!Char.IsLetterOrDigit(html[index])) {
                            index++;
                        }

                        int urlLength = html.IndexOf("\"", index) - index;
                        string url = html.Substring(index, urlLength);

                        if (url.StartsWith("images")) {
                            url = url.Insert(0, "www.dlsite.com/");
                        }
                        if (!url.StartsWith("http")) {
                            url = url.Insert(0, "http://");
                        }
                        images.Add(new GameImage {
                            ImageURL = url
                        });
                    }

                    if (index != -1) {
						index = html.IndexOf("<div data-src", index);
					}
                }
            }
            return images;
        }

        /// <summary>
        /// Returns the URL of this game's blog if one exists.
        /// </summary>
        public virtual string GetBlogUrl() {
            if (html != null) {
                int index = html.IndexOf("id=\"work_maker\"");

                if (index != -1) {
                    index = html.IndexOf("href=\"http://b.dlsite", index);

                    if (index != -1) {
                        index += 6;

                        int urlLength = html.IndexOf("\"", index) - index;

                        //The url length will be 0 if the game does not have a blog listed
                        if (urlLength > 0) {
                            return html.Substring(index, urlLength);
                        }
                    }
                }
            }
            return null;
        }

		/// <summary>
        /// Returns the game's category, or null if no tags exist.
        /// </summary>
        public virtual string GetCategory() {
            if (html != null) {
                string tagPrefix = "work_type/";
				string tagSuffix = "/from/icon";
				int tagIndex = html.IndexOf("class=\"maker_name");				//to skip english dlsite top bar
                tagIndex = html.IndexOf(tagPrefix, tagIndex) + tagPrefix.Length;
				int tagLength = html.IndexOf(tagSuffix, tagIndex) - tagIndex;
                if (tagIndex > 0 && tagLength > 0) {
                    // <span class="icon_RPG" title="ロールプレイング">ロールプレイング</span>
                    tagPrefix = "<span class=\"icon_" + html.Substring(tagIndex, tagLength) + "\" title=\"";
					tagSuffix = "\">";
                    tagIndex = html.IndexOf(tagPrefix) + tagPrefix.Length;
					tagLength = html.IndexOf(tagSuffix, tagIndex) - tagIndex;
					if (tagIndex > 0 && tagLength > 0) {
						return html.Substring(tagIndex, tagLength).HtmlDecode();
					}
					else {
						return null;
					}
                }
                else {
                    return null;
                }
            }
            return null;
        }

        /// <summary>
        /// Returns the game's tags separated by comma, or null if no tags exist.
        /// </summary>
        public virtual string GetTags() {
            if (html != null) {
                var tags = new List<string>();
                string tagPrefix = "work.genre\">";
                int tagIndex = html.IndexOf(tagPrefix);

                if (tagIndex == -1) {
                    //Tags for unreleased titles are prefixed by work_ana instead of work
                    tagPrefix = "work_ana.genre\">";
                    tagIndex = html.IndexOf(tagPrefix);
                }

                while (tagIndex != -1) {

                    // Find first close html tag
                    var genreEndStringIndex = html.IndexOf("</", tagIndex);
                    var genreStartStringIndex = tagIndex + tagPrefix.Length;
                    var genreStringLength = genreEndStringIndex - genreStartStringIndex;

                    var genreString = html.Substring(genreStartStringIndex, genreStringLength);
                    if (!string.IsNullOrEmpty(genreString))
                        tags.Add(genreString.HtmlDecode());

                    tagIndex += genreStringLength;

                    //string tagNum = html.Substring(tagIndex - 9, 3);
					//string tagPrefixfs = "genre_" + tagNum + "\">";
					//int tagNumIndex = htmlfs.IndexOf(tagPrefixfs);
					//tagIndex += tagPrefix.Length;
					//if (tagNumIndex != -1) {
					//	tagNumIndex += tagPrefixfs.Length;
					//	int tagLength = htmlfs.IndexOf("</label", tagNumIndex) - tagNumIndex;
					//	if (tagLength > 0) {
					//		tags.Add(htmlfs.Substring(tagNumIndex, tagLength).HtmlDecode());
					//	}						
					//}

                    //Find next tag
                    tagIndex = html.IndexOf(tagPrefix, tagIndex);
                }
				
				if (html.IndexOf("icon_GRO") != -1) {
					if (Settings.Instance.DLSiteLanguage == DLSitePage.Language.English) {
						tags.Add("Grotesque");
					}
					else {
						tags.Add("グロテスク");
					}
				}
				if (html.IndexOf("icon_MEN") != -1) {
					if (Settings.Instance.DLSiteLanguage == DLSitePage.Language.English) {
						tags.Add("Gay");
					}
					else {
						tags.Add("ゲイ");
					}
				}

                if (tags.Count == 0) {
                    return "";
                }
                else {
                    return String.Join(", ", tags.ToArray());
                }
            }
            return null;
        }

        /// <summary>
        /// Returns the game's aggregated review tags separated by comma, or null if no tags exist.
        /// </summary>
        public virtual string GetAggrReviewTags(string tags0) {
            if (html != null) {
                var tags = new List<string>();
                string tagPrefix = "work.review_genre\">";
                int tagIndex = html.IndexOf(tagPrefix);

                while (tagIndex != -1) {

                    // Find first close html tag
                    var genreEndStringIndex = html.IndexOf("</", tagIndex);
                    var genreStartStringIndex = tagIndex + tagPrefix.Length;
                    var genreStringLength = genreEndStringIndex - genreStartStringIndex;

                    var genreString = html.Substring(genreStartStringIndex, genreStringLength);
                    if (!string.IsNullOrEmpty(genreString))
                        tags.Add(genreString.HtmlDecode());

                    tagIndex += genreStringLength;

     //               string tagNum = html.Substring(tagIndex - 9, 3);
					//string tagPrefixfs = "genre_" + tagNum + "\">";
					//int tagNumIndex = htmlfs.IndexOf(tagPrefixfs);
     //               tagIndex += tagPrefix.Length;
					//if (tagNumIndex != -1) {
					//	tagNumIndex += tagPrefixfs.Length;
					//	int tagLength = htmlfs.IndexOf("</label", tagNumIndex) - tagNumIndex;
					//	if (tagLength > 0) {
					//		string tag = htmlfs.Substring(tagNumIndex, tagLength).HtmlDecode();
					//		if (tags0.IndexOf(tag) == -1) {
					//			tags.Add(tag);
					//		}
					//	}						
					//}

                    //Find next tag
                    tagIndex = html.IndexOf(tagPrefix, tagIndex);
                }

                if (tags.Count == 0) {
                    return tags0;
                }
                else {
					if (tags0 == "") {
						return String.Join(", ", tags.ToArray());
					}
					else {
						return tags0 + ", " + String.Join(", ", tags.ToArray());
					}
                }
            }
            return null;
        }

        /// <summary>
        /// Returns the game's review tags separated by comma, or null if no tags exist.
        /// </summary>
        public virtual string GetReviewTags(string tags0) {
            if (html != null) {
                var tags = new List<string>();
                string tagPrefix = "review.genre\">";
                int tagIndex = html.IndexOf(tagPrefix);

                while (tagIndex != -1) {

                    // Find first close html tag
                    var genreEndStringIndex = html.IndexOf("</", tagIndex);
                    var genreStartStringIndex = tagIndex + tagPrefix.Length;
                    var genreStringLength = genreEndStringIndex - genreStartStringIndex;

                    var genreString = html.Substring(genreStartStringIndex, genreStringLength);
                    if (!string.IsNullOrEmpty(genreString))
                        tags.Add(genreString.HtmlDecode());

                    tagIndex += genreStringLength;

     //               string tagNum = html.Substring(tagIndex - 9, 3);
					//string tagPrefixfs = "genre_" + tagNum + "\">";
					//int tagNumIndex = htmlfs.IndexOf(tagPrefixfs);
     //               tagIndex += tagPrefix.Length;
					//if (tagNumIndex != -1) {
					//	tagNumIndex += tagPrefixfs.Length;
					//	int tagLength = htmlfs.IndexOf("</label", tagNumIndex) - tagNumIndex;
					//	if (tagLength > 0) {
					//		string tag = htmlfs.Substring(tagNumIndex, tagLength).HtmlDecode();
					//		if (tags0.IndexOf(tag) == -1) {
					//			tags.Add(tag);
					//		}
					//	}						
					//}

                    //Find next tag
                    tagIndex = html.IndexOf(tagPrefix, tagIndex);
                }

                if (tags.Count == 0) {
                    return tags0;
                }
                else {
					if (tags0 == "") {
						return String.Join(", ", tags.ToArray());
					}
					else {
						return tags0 + ", " + String.Join(", ", tags.ToArray());
					}
                }
            }
            return null;
        }

        /// <summary>
        /// Returns the HVDB tags separated by comma, or null if no tags exist.
        /// </summary>
        public virtual string GetHVDBTags() {
            if (html != null) {
				if (html_hvdb != ""){
					var tags = new List<string>();
					string tagPrefix = "TagWorks";
					int tagIndex = html_hvdb.IndexOf(tagPrefix);

					while (tagIndex != -1) {
						
						tagIndex = html_hvdb.IndexOf(">", tagIndex) + 1;
						
						int tagLength = html_hvdb.IndexOf("</a>", tagIndex) - tagIndex;

						if (tagLength > 0) {
							string tag = html_hvdb.Substring(tagIndex, tagLength).HtmlDecode();
							if (tag != "n/a" && tag != "N/A") {
								tags.Add(tag);
							}
						}

						//Find next tag
						tagIndex = html_hvdb.IndexOf(tagPrefix, tagIndex);
					}

					if (tags.Count == 0) {
						return null;
					}
					else {
						return String.Join(", ", tags.ToArray());
					}
				}
            }
            return null;
        }

        /// <summary>
        /// Returns the HVDB CVs separated by comma, or null if no CVs exist.
        /// </summary>
        public virtual string GetHVDB_CVs() {
            if (html != null) {
				if (html_hvdb != ""){
					var tags = new List<string>();
					var CVsEn = new List<string>();
					var CVsJp = new List<string>();
					string tagPrefix = "CVWorks";
					int tagIndex = html_hvdb.IndexOf(tagPrefix);
					int tagIndex0 = tagIndex;
					while (tagIndex != -1) {
						tagIndex0 = tagIndex;
						tagIndex = html_hvdb.IndexOf(">", tagIndex) + 1;
						
						int tagLength = html_hvdb.IndexOf("</a>", tagIndex) - tagIndex;

						if (tagLength > 0) {
							string tag = html_hvdb.Substring(tagIndex, tagLength).HtmlDecode();
							if (tag.Contains("__cf_email__")) {											//workarounf for CVs with @ symbol in name
								tagIndex0 = tagIndex0 + 8;
								tagLength = html_hvdb.IndexOf("\">", tagIndex0) - tagIndex0;
								if (tagLength > 0) {
									tag = html_hvdb.Substring(tagIndex0, tagLength).HtmlDecode().Replace("%40", "@");
								}
							}
							if (tag != "n/a" && tag != "N/A") {//  Regex.IsMatch(tag, "^[ -~]+$")
								tags.Add(tag);
								if (Regex.IsMatch(tag, "^[ -~]+$")) {
									CVsEn.Add(tag);
								}
								else {
									CVsJp.Add(tag);
								}
							}
						}

						//Find next tag
						tagIndex = html_hvdb.IndexOf(tagPrefix, tagIndex);
					}

					if (tags.Count == 0) {
						return null;
					}
					else {
						if (CVsEn.Count == CVsJp.Count && Settings.Instance.FilterCVs) {
							return String.Join(", ", CVsEn.ToArray());
						}
						else {
							return String.Join(", ", tags.ToArray());
						}
						
					}
				}
            }
            return null;
        }

        /// <summary>
        /// Returns the HVDB English title, or empty string if no such exists.
        /// </summary>
        public virtual string GetHVDBTitle() {
            if (html != null) {
				if (html_hvdb != ""){
					
					string tagPrefix = "name=\"EngName";
					int tagIndex = html_hvdb.IndexOf(tagPrefix);

					if (tagIndex != -1) {
						
						tagIndex = html_hvdb.IndexOf("value=", tagIndex) + 7;
						
						int tagLength = html_hvdb.IndexOf("\" />", tagIndex) - tagIndex;

						if (tagLength > 0) {
							string tag = html_hvdb.Substring(tagIndex, tagLength).HtmlDecode();
							if (tag.Length > 0) {
								return tag;
							}
							else {
								return "";
							}
						}
						else {
							return "";
						}

					}
				}
            }
            return null;
        }
	}

	
    public class PageNotFoundException : Exception {
        public PageNotFoundException() : base() { }
        public PageNotFoundException(string message) : base(message) { }
        public PageNotFoundException(string format, params object[] args) : base(string.Format(format, args)) { }
        public PageNotFoundException(string message, Exception innerException) : base(message, innerException) { }
        public PageNotFoundException(string format, Exception innerException, params object[] args) : base(string.Format(format, args), innerException) { }
    }
}
