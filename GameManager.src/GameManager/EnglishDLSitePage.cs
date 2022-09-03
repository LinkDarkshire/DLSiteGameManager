using System;
using System.Diagnostics;

namespace GameManager {
    class EnglishDLSitePage : DLSitePage {
        /// <summary>
        /// The URL pointing to this DLSite page.
        /// </summary>
        public override string Url { 
            get { 
                string url = "http://www.dlsite.com/";

                switch (type) {
                    case Type.Maniax:
                        url += "ecchi-eng/work/=/product_id/RE" + rjCode + ".html"; break;
                    case Type.Pro:
                        url += "eng/work/=/product_id/VE" + rjCode + ".html"; break;
                    case Type.Book:
                        url += "eng/work/=/product_id/BE" + rjCode + ".html"; break;
                }

                return ReleasePageExists ? url : url.Replace("work", "announce");
            } 
        }

        /// <summary>
        /// Creates a new DLSite page.
        /// </summary>
        /// <param name="rjCode">The game's DLSite identifier. </param>
        public EnglishDLSitePage(string rjCode) : base(rjCode) {

        }

        /// <summary>
        /// Returns true if the methods in this class return the expected values for an example game.
        /// Verbose information is printed to the debug stream.
        /// </summary>
        public static bool RunTestCase() {
            var page = new EnglishDLSitePage("rj105442");
            bool noErrors = true;

            if (!page.DownloadPageData()) {
                Debug.WriteLine("ERROR: The English DLSite page for game 'rj105442' was not found");
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
            var expectedAuthor = new Circle { RGCode = "15237", Name = "CircleKAME" };

            if (author.Name != expectedAuthor.Name || author.RGCode != expectedAuthor.RGCode) {
                noErrors = false;
                Debug.WriteLine(String.Format("ERROR: DLSitePage.GetAuthor() returned {0} (RG{1}). Expected {2} (RG{3})",
                                              author.Name, author.RGCode, expectedAuthor.Name, expectedAuthor.RGCode));
            }

            var tags = page.GetTags();
            var expectedTags = "Clothed, Pregnancy/Impregnation, Violation";

            if (tags != expectedTags) {
                noErrors = false;
                Debug.WriteLine("ERROR: DLSitePage.GetTags() returned " + tags + ". Expected " + expectedTags);
            }

            var title = page.GetTitle();
            var expectedTitle = "Arms Devicer!";

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
