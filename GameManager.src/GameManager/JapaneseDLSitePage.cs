using System;
using System.Diagnostics;
using System.Net;

namespace GameManager {
    class JapaneseDLSitePage : DLSitePage {
        /// <summary>
        /// The URL pointing to this DLSite page.
        /// </summary>
        public override string Url {
            get {
                string url = "http://www.dlsite.com/";

                switch (type) {
                    case Type.Maniax:
                        url += "maniax/work/=/product_id/RJ" + rjCode + ".html"; break;
                    case Type.Pro:
                        url += "pro/work/=/product_id/VJ" + rjCode + ".html"; break;
                    case Type.Book:
                        url += "books/work/=/product_id/BJ" + rjCode + ".html"; break;
                }

                return ReleasePageExists ? url : url.Replace("work", "announce");
            }
        }

        /// <summary>
        /// Creates a new DLSite page.
        /// </summary>
        /// <param name="rjCode">The game's DLSite identifier. </param>
        public JapaneseDLSitePage(string rjCode) : base(rjCode) {

        }

        /// <summary>
        /// Returns the average rating from DLSite's JSON server.
        /// Returns null if the game does not have an average rating.
        /// </summary>
        /// <exception cref="WebException">Thrown if a connection to DLSite's JSON server cannot be established.</exception>
        public byte? DownloadRating() {
            string response = null;
            byte? rating = null;

            //The rating is not included in the raw html code and must be gotten by JSON
            using (WebClient client = new WebClient()) {
                client.Proxy = null;
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
                client.Headers.Add("X-Requested-With", "XMLHttpRequest");

                string url = "https://www.dlsite.com/";

                switch (type) {
                    case Type.Maniax:
                        response = client.UploadString(url + "maniax/product/info/ajax", "product_id=" + "RJ" + rjCode); break;
                    case Type.Pro:
                        response = client.UploadString(url + "pro/product/info/ajax", "product_id=" + "VJ" + rjCode); break;
                    case Type.Book:
                        response = client.UploadString(url + "books/product/info/ajax", "product_id=" + "BJ" + rjCode); break;
                }
            }

            //Parse the response
            int ratingIndex = response.IndexOf("rate_average\"");

            if (ratingIndex != -1) {
                ratingIndex += 12;

                //Look for the rating
                while (ratingIndex < response.Length) {
                    if (char.IsDigit(response[ratingIndex])) {
                        //Convert char to byte
                        rating = (byte)(response[ratingIndex] - '0');

                        //DLSite stores titles not yet rated with a rating of 0
                        if (rating == 0) {
                            rating = null;
                        }
                        break;
                    }
                    ratingIndex++;
                }
            }
            return rating;
        }

        /// <summary>
        /// Returns true if the methods in this class return the expected values for an example game.
        /// Verbose information is printed to the debug stream.
        /// </summary>
        public static bool RunTestCase() {
            var page = new JapaneseDLSitePage("rj105442");
            bool noErrors = true;

            if (!page.DownloadPageData()) {
                Debug.WriteLine("ERROR: The Japanese DLSite page for game 'rj105442' was not found");
                return false;
            }

            var blogUrl = page.GetBlogUrl();
            var expectedBlogUrl = "http://b.dlsite.net/RG15237/";

            if (blogUrl != expectedBlogUrl) {
                noErrors = false;
                Debug.WriteLine("ERROR: DLSitePage.GetBlogUrl() returned " + blogUrl + ". Expected " + expectedBlogUrl);
            }

            var coverImageUrl = page.GetCoverImage().ImageURL;
            var expectedCoverImageUrl = "http://img.dlsite.jp/modpub/images2/work/doujin/RJ106000/RJ105442_img_main.jpg";

            if (coverImageUrl != expectedCoverImageUrl) {
                noErrors = false;
                Debug.WriteLine("ERROR: DLSitePage.GetCoverImage() returned " + coverImageUrl + ". Expected " + expectedCoverImageUrl);
            }

            var author = page.GetAuthor();
            var expectedAuthor = new Circle { RGCode = "15237", Name = "さーくる亀" };

            if (author.Name != expectedAuthor.Name || author.RGCode != expectedAuthor.RGCode) {
                noErrors = false;
                Debug.WriteLine(String.Format("ERROR: DLSitePage.GetAuthor() returned {0} (RG{1}). Expected {2} (RG{3})",
                                              author.Name, author.RGCode, expectedAuthor.Name, expectedAuthor.RGCode));
            }

            var tags = page.GetTags();
            var expectedTags = "着衣, 妊娠/孕ませ, 陵辱";

            if (tags != expectedTags) {
                noErrors = false;
                Debug.WriteLine("ERROR: DLSitePage.GetTags() returned " + tags + ". Expected " + expectedTags);
            }

            var title = page.GetTitle();
            var expectedTitle = "アームズ・デバイサー!+";

            if (title != expectedTitle) {
                noErrors = false;
                Debug.WriteLine("ERROR: DLSitePage.GetTitle() returned " + title + ". Expected " + expectedTitle);
            }

            var listImageUrl = page.GetListImage().ImageURL;
            var expectedListImageUrl = "http://img.dlsite.jp/modpub/images2/work/doujin/RJ106000/RJ105442_img_sam.jpg";

            if (listImageUrl != expectedListImageUrl) {
                noErrors = false;
                Debug.WriteLine("ERROR: DLSitePage.GetListImage() returned " + listImageUrl + ". Expected " + expectedListImageUrl);
            }

            var rating = page.DownloadRating();
            var expectedRating = 5;

            if (rating != expectedRating) {
                noErrors = false;
                Debug.WriteLine("ERROR: DLSitePage.GetRating() returned " + rating + ". Expected " + expectedRating);
            }

            var releaseDate = page.GetReleaseDate();
            var expectedReleaseDate = new DateTime(2012, 12, 2);

            if (releaseDate != expectedReleaseDate) {
                noErrors = false;
                Debug.WriteLine("ERROR: DLSitePage.GetReleaseDate() returned " + releaseDate + ". Expected " + expectedReleaseDate);
            }

            var sampleImages = page.GetSampleImages();
            var sampleImageUrls = "";
            sampleImages.ForEach(image => sampleImageUrls += image.ImageURL + "\n");
            var expectedSampleImageUrls = "http://img.dlsite.jp/modpub/images2/work/doujin/RJ106000/RJ105442_img_smp1.jpg\n" +
                                          "http://img.dlsite.jp/modpub/images2/work/doujin/RJ106000/RJ105442_img_smp2.jpg\n" +
                                          "http://img.dlsite.jp/modpub/images2/work/doujin/RJ106000/RJ105442_img_smp3.jpg\n";

            if (sampleImageUrls != expectedSampleImageUrls) {
                noErrors = false;
                Debug.WriteLine("ERROR: DLSitePage.GetSampleImages() returned " + sampleImages + ". Expected " + expectedSampleImageUrls);
            }

            if (noErrors) {
                Debug.WriteLine("DLSitePage.RunTestCase() completed with no errors!");
            }

            return noErrors;
        }
    }
}
