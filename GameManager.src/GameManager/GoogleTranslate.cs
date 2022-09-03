using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace GameManager {
    public class GoogleTranslate {
        private string url;

        public GoogleTranslate(string fromLanguage, string toLanguage) {
            url = "http://translate.google.com/translate_a/single?client=gtx&sl=" + fromLanguage + "&tl=" + toLanguage + "&dt=t&q=";
        }

        /// <summary>
        /// Capitalizes the first letter after each comma and forward slash and removes spaces before and after forward slashes 
        /// </summary>
        private string DoSpecialStringProcessing(string str) {
            for (int i = 1; i < str.Length - 2; i++) {
                if (str[i] == ',' && str[i + 1] == ' ') {
                    str = str.CapitalizeLetter(i + 2);
                }
                else if (str[i] == '/') {
                    if (str[i - 1] == ' ') {
                        str = str.Remove(i - 1, 1);
                        i--;
                    }

                    if (str[i + 1] == ' ') {
                        str = str.Remove(i + 1, 1);
                    }

                    str = str.CapitalizeLetter(i + 1);
                }
            }

            return str.CapitalizeLetter(0);
        }

        /// <summary>
        /// Sends the specified string to Google Translate and returns the translated result.
        /// </summary>
        public string TranslateString(string str) {
            string html;
            str = Uri.EscapeDataString(str);

            using (WebClient client = new WebClient()) {
                client.Proxy = null;
                client.Encoding = Encoding.UTF8;

                try {
                    //Add user agent header to fool Google into thinking we're a browser
                    client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:47.0) Gecko/20100101 Firefox/47.0");
                    html = client.DownloadString(url + str);
                }
                catch (Exception e) {
                    Logger.LogExceptionIfDebugging(e);
                    return str;
                }
            }

            int index = html.IndexOf("[[[\"");

            if (index != -1) {
				index = index + 4;
                int endIndex = html.IndexOf("\",", index);

                if (endIndex != -1) {
                    string translatedText = html.Substring(index, endIndex - index);

                    //Un-escape special Google escape codes
                    translatedText = translatedText.Replace("\\x26amp;", "&").Replace("\\x3cbr\\x3e", "\n").Replace("\\x26#39;", "'").Replace("\\x26quot;", "\"").Replace("\\x26lt;", "<").Replace("\\x26gt;", ">");

                    return DoSpecialStringProcessing(translatedText);
                }
            }

            return null;
        }
        
        /// <summary>
        /// Translates a list of sentences in one web request. 
        /// </summary>
        public string[] TranslateStrings(params string[] strings) {
            string translatedString = TranslateString(String.Join("\n", strings));

            if (translatedString != null) {
                return translatedString.Split('\n'); 
            }
            else {
                return null;
            }
        }

        /// <summary>
        /// Returns true if the methods in this class return the expected values for an example string.
        /// Verbose information is printed to the debug stream.
        /// </summary>
        public static bool RunTestCase() {
            var japaneseTranslator = new GoogleTranslate("ja", "en");
            string[] stringsToTranslate = {"ありがとう", "ごめん　なさい", "東/西"};
            string[] expectedTranslations = {"Thank you", "I'm sorry", "East/West"};

            var translations = japaneseTranslator.TranslateStrings(stringsToTranslate);

            for (int i = 0; i < stringsToTranslate.Length; i++) {
                if (translations[i] != expectedTranslations[i]) {
                    Debug.WriteLine(String.Format("ERROR: GoogleTranslate.TranslateString({0}) returned {1}. Expected {2}", stringsToTranslate[i], translations[i], expectedTranslations[i]));
                    return false;
                }
            }
            Debug.WriteLine(String.Format("GoogleTranslate.RunTestCase() completed with no errors!"));
            return true;
        }
    }
}
