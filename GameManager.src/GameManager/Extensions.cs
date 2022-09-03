using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GameManager {
    /// <summary>
    /// Collection of extension methods for various framework classes.
    /// </summary>
    public static class Extensions {
        /// <summary>
        /// Returns a high quality thumbnail for this image.
        /// </summary>
        public static Image GetHighQualityThumbnail(this Image image, int thumbWidth, int thumbHeight) {
            Image thumbnail = new Bitmap(thumbWidth, thumbHeight);

            using (Graphics graphics = Graphics.FromImage(thumbnail)) {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, thumbnail.Width, thumbnail.Height);
            }
            return thumbnail;
        }

        /// <summary>
        /// Retrieves the specified column as a nullable Int32.
        /// </summary>
        public static Int32? GetNullableInt32(this SQLiteDataReader reader, int columnIndex) {
            //SQLite stores all int32 values as int64, hence the cast
            return (Int32?)(reader.GetValue(columnIndex) as Int64?);
        }

        /// <summary>
        /// Retrieves the specified column as a nullable byte.
        /// </summary>
        public static byte? GetNullableByte(this SQLiteDataReader reader, int columnIndex) {
            return reader.GetValue(columnIndex) as byte?;
        }

        /// <summary>
        /// Retrieves the specified column as a nullable boolean.
        /// </summary>
        public static bool? GetNullableBoolean(this SQLiteDataReader reader, int columnIndex) {
            var number = reader.GetNullableByte(columnIndex);

            if (!number.HasValue) {
                return null;
            }
            else if (number == 0) {
                return false;
            }
            else {
                return true;
            }
        }

        /// <summary>
        /// Returns the specified column or null if it does not exist.
        /// </summary>
        public static object GetValueOrNull(this SQLiteDataReader reader, int columnIndex) {
            object value = reader.GetValue(columnIndex);
            return value == DBNull.Value ? null : value;
        }

        /// <summary>
        /// If the caller is not the UI-thread, the action is delegated to the UI-thread.
        /// </summary>
        public static void InvokeIfRequired(this Control control, Action action) {
            if (control.InvokeRequired) {
                control.Invoke(action);
            }
            else {
                action();
            }
        }

        private static Regex digitsOnly = new Regex(@"[^\d]", RegexOptions.Compiled);

        /// <summary>
        /// Removes all non-digit characters from the string.
        /// </summary>
        public static string RemoveNonDigits(this string str) {
            return digitsOnly.Replace(str, "");
        }

        /// <summary>
        /// Converts the specified character in the string to its uppercase equivalent.
        /// </summary>
        public static string CapitalizeLetter(this string str, int index) {
            if (index >= 0 && str.Length > index) {
                return str.Substring(0, index) + char.ToUpper(str[index]) + (str.Length > index + 1 ? str.Substring(index + 1) : "");
            }
            return str;
        }

        /// <summary>
        /// Decodes the HTML-encoded string.
        /// </summary>
        public static string HtmlDecode(this string str) {
            return WebUtility.HtmlDecode(str);
        }

        /// <summary>
        /// Returns true if this string contains the specified string.
        /// </summary>
        public static bool Contains(this string source, string str, StringComparison comp) {
            return source.IndexOf(str, comp) >= 0;
        }

        /// <summary>
        /// Returns the index of the first character in this string that makes the string different from str.
        /// If the strings are exactly equal, the length of the string is returned.
        /// The comparison is case insensitive.
        /// </summary>
        public static int FirstDifference(this string source, string str) {
            if (source == null || str == null) {
                return 0;
            }
            int minLength = Math.Min(source.Length, str.Length);
            int i;

            for (i = 0; i < minLength; i++) {
                if (Char.ToLower(source[i]) != Char.ToLower(str[i])) {
                    break;
                }
            }
            return i;
        }

        private static List<string> specialFolders;

        /// <summary>
        /// Returns true if this folder is an important system special folder.
        /// </summary>
        public static bool IsSpecialFolder(this DirectoryInfo folder) {
            if (specialFolders == null) {
                specialFolders = new List<string>();

                specialFolders.Add(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
                specialFolders.Add(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86));
                specialFolders.Add(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
                specialFolders.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory));
                specialFolders.Add(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
                specialFolders.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments));
                specialFolders.Add(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
                specialFolders.Add(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads"));
            }
            return folder != null && specialFolders.Contains(folder.FullName);
        }

        public static string ToFileExtension(this ImageFormat format) {
            if (format.Guid == ImageFormat.Jpeg.Guid) {
                return ".jpg";
            }
            else if (format.Guid == ImageFormat.Gif.Guid) {
                return ".gif";
            }
            else if (format.Guid == ImageFormat.Bmp.Guid) {
                return ".bmp";
            }
            else if (format.Guid == ImageFormat.Png.Guid) {
                return ".png";
            }
            else if (format.Guid == ImageFormat.Tiff.Guid) {
                return ".tiff";
            }
            else {
                return "";
            }
        }
    }
}
