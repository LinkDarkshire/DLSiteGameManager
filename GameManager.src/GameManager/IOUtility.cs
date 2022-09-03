using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Ionic.Zip;
using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic.FileIO;

namespace GameManager {
    /// <summary>
    /// A collection of static helper methods related to reading game information from disk.
    /// </summary>
    public static class IOUtility {
        public static readonly string UnrarPath = Path.Combine(Path.GetTempPath(), "UnRAR_5.exe");
        public static bool UnrarCreated = false;

        /// <summary>
        /// Returns an enumerable collection of file names that match a search pattern in a specified path.
        /// If access to any directory is denied during the enumeration, the path of the failing directory is passed to the onAccessDenied function,
        /// and the enumeration continues.
        /// </summary>
        public static IEnumerable<string> EnumerateFilesSafely(string path, string searchPattern, System.IO.SearchOption searchOptions = System.IO.SearchOption.TopDirectoryOnly, Action<string> onAccessDenied = null) {
            try {
                var fileNames = Enumerable.Empty<string>();

                if (searchOptions == System.IO.SearchOption.AllDirectories) {
                    fileNames = Directory.EnumerateDirectories(path).SelectMany(x => EnumerateFilesSafely(x, searchPattern, searchOptions, onAccessDenied));
                }
                return fileNames.Concat(Directory.EnumerateFiles(path, searchPattern));
            }
            catch (UnauthorizedAccessException) {
                if (onAccessDenied != null) {
                    onAccessDenied(path);
                }
                return Enumerable.Empty<string>();
            }
        }

        private static Regex RJCodePattern = new Regex(@"(rj|re|vj|bj)\d\d\d\d+", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        /// <summary>
        /// Returns the first occurence of a valid RJCode in the specified string.
        /// Returns null if the string does not contain a valid RJCode.
        /// </summary>
        public static string ExtractRJCode(string str) {
            var matchInfo = RJCodePattern.Match(str);

            return matchInfo.Success ? matchInfo.Value : null;
        }

        /// <summary>
        /// Returns the list of a valid RJCodes in the specified string.
        /// Returns null if the string does not contain a valid RJCode.
        /// </summary>
        public static List<string> ExtractAllRJCodes(string str) {
            //var matchInfo = RJCodePattern.Matches(str);
			MatchCollection matchList = RJCodePattern.Matches(str);
			var list = matchList.Cast<Match>().Select(match => match.Value).ToList();

            return list;//.Count() > 0 ? list : null;
        }

        /// <summary>
        /// Looks for the specified game's RJCode. How and where to look is specified in the program settings.
        /// If no RJCode is found, null is returned.
        /// </summary>
        /// <param name="path">The path to the specified game. </param>
        /// <returns>The RJCode without the 'RJ' or 'RE' prefix, or null if no code was found. </returns>
        public static string FindRJCode(string path) {
            if ((!File.Exists(path) && !Directory.Exists(path)) || (!Settings.Instance.LookForRJCodeInPath && !Settings.Instance.LookForRJCodeInNames && !Settings.Instance.LookForRJCodeInTextFiles)) {
                return null;
            }
			DirectoryInfo dir;
			string fullName;
			if (File.Exists(path)) {					//Added support for directories
				var fileInfo = new FileInfo(path);
				fullName = fileInfo.FullName;
				dir = fileInfo.Directory;
				//fullName = dir.FullName;
			}
			else {
				dir = new DirectoryInfo(path);
				fullName = dir.FullName;
			}

            
            string rjCode = null;

            if (Settings.Instance.LookForRJCodeInPath) {
                //See if the game's full path contains the RJCode
                rjCode = ExtractRJCode(fullName);

                if (rjCode != null) {
                    return rjCode;
                }

            }
			
			//See if any folder names inside the game's directory contains the RJCode
			if (Settings.Instance.LookForRJCodeInNames) {
				foreach (var directory in dir.EnumerateDirectories()) {
					rjCode = ExtractRJCode(directory.Name);

					if (rjCode != null) {
						return rjCode;
					}
				}
			}

            //See if any file names inside the game's directory contains the RJCode
            foreach (var file in dir.EnumerateFiles()) {
                if (Settings.Instance.LookForRJCodeInNames) {
                    rjCode = ExtractRJCode(file.Name);

                    if (rjCode != null) {
                        return rjCode;
                    }
                }

                //Search inside .txt files for the RJCode
                if (Settings.Instance.LookForRJCodeInTextFiles && file.Extension.Equals(".txt", StringComparison.OrdinalIgnoreCase)) {
                    rjCode = ExtractRJCode(File.ReadAllText(file.FullName, Encoding.UTF8));

                    if (rjCode != null) {
                        return rjCode;
                    }
                }
            }
            return rjCode;
        }

        /// <summary>
        /// Scans the specified directories for executable files.
        /// </summary>
        /// <param name="directories">The list of directory paths to scan</param>
        /// <param name="onGameFound">The action to be performed when a new game is found</param>
        /// <param name="onAccessDenied">The action to be performed if access is denied to a subfolder</param>
		
		//original - not used - left for reference
        public static IEnumerable<Game> FindGamesOriginal(IEnumerable<string> directories, CancellationToken scanCanceller, Action<Game> onGameFound = null, Action<string> onAccessDenied = null) {
            var gamesFound = new List<Game>();        
            
            foreach (string path in directories) {
                foreach (var fileName in IOUtility.EnumerateFilesSafely(path, "*.exe", System.IO.SearchOption.AllDirectories, onAccessDenied)) {
                    var onlyName = Path.GetFileNameWithoutExtension(fileName);

                    scanCanceller.ThrowIfCancellationRequested();

                    //Ignore config files and uninstallers
                    if (!onlyName.Contains("config", StringComparison.OrdinalIgnoreCase) && !onlyName.Contains("unins", StringComparison.OrdinalIgnoreCase)) {
                        var game = new Game { Path = fileName };
                        gamesFound.Add(game);

                        if (onGameFound != null) {
                            onGameFound(game);
                        }
                    }
                }
            }
            return gamesFound;
        }

		// new
		public static IEnumerable<Game> FindGames(IEnumerable<string> directories, CancellationToken scanCanceller, Action<Game> onGameFound = null, Action<string> onAccessDenied = null) {
            var gamesFound = new List<Game>();        
            var rjCodes = new List<string>();
            foreach (string path in directories) {
				
				IEnumerable<string> fullFileList = IOUtility.EnumerateFilesSafely(path, "*.*", System.IO.SearchOption.AllDirectories, onAccessDenied);
				string[] extensions = Settings.Instance.Extensions.Split(new [] {"|"},StringSplitOptions.None);
				var files = new List<string>();
				foreach (var fileName in fullFileList.Where(s => extensions.Any(ext => ext == Path.GetExtension(s).ToLower()))) {		// make list of files with specified extensions
					files.Add(fileName);
				}
				
				foreach (var fileName in files) {																			//add all files with specified extensions as works
					string rjCode = FindRJCode(fileName);
					if (rjCode != null && !rjCodes.Contains(rjCode)) {
						rjCodes.Add(rjCode);
					}

					var onlyName = Path.GetFileNameWithoutExtension(fileName);

                    scanCanceller.ThrowIfCancellationRequested();

                    //Ignore config files and uninstallers
                    if (!Settings.Instance.FilesToIgnore.Split(new [] {"|"},StringSplitOptions.None).Any(s=>onlyName.Contains(s, StringComparison.OrdinalIgnoreCase))) {
					//if (!onlyName.Contains("config", StringComparison.OrdinalIgnoreCase) && !onlyName.Contains("unins", StringComparison.OrdinalIgnoreCase)) {
                        var game = new Game { Path = fileName };
                        gamesFound.Add(game);

                        if (onGameFound != null) {
                            onGameFound(game);
                        }
                    }

				}
				
				
				IEnumerable<string> fullDirList = new[]{path}.Concat(Directory.EnumerateDirectories(path, "*.*", System.IO.SearchOption.AllDirectories));
                foreach (var fileName in fullDirList) {																	//add directories containing RJ Code in name
					string rjCode = ExtractRJCode(fileName);
					if (rjCode != null) {
						if (!rjCodes.Contains(rjCode)) {
							rjCodes.Add(rjCode);
							string rjDirPath = fileName;
							string rjDirPathTemp = fileName;
							while (rjDirPathTemp.Contains(rjCode)) {
								rjDirPathTemp = Path.GetDirectoryName(rjDirPathTemp);
								if (rjDirPathTemp.Contains(rjCode)) {
									rjDirPath = rjDirPathTemp;
								}
							}
							var game = new Game { Path = rjDirPath };
							gamesFound.Add(game);

							if (onGameFound != null) {
								onGameFound(game);
							}
						}
					}
                }
            }
            return gamesFound;
        }

		
		// update path
		public static void UpdatePath(Game game) {
			if (!File.Exists(game.Path) && !String.IsNullOrEmpty(game.RJCode)) {
				string path = "";
				int index = 0;
				int lastindex = 10000;
				var dirsToScan = new List<string>();
				if (!Directory.Exists(game.Path)) {
					if (!String.IsNullOrEmpty(Settings.Instance.GameFolder)) {
						dirsToScan.Add(Settings.Instance.GameFolder);
					} 
					if(game.Path.IndexOf(game.RJCode) != -1) {
						if (String.IsNullOrEmpty(Settings.Instance.GameFolder)) {
							dirsToScan.Add(System.IO.Path.GetDirectoryName(game.Path.Substring(0, game.Path.IndexOf(game.RJCode))));
						}
						else if (!game.Path.Contains(Settings.Instance.GameFolder)) {
							dirsToScan.Add(System.IO.Path.GetDirectoryName(game.Path.Substring(0, game.Path.IndexOf(game.RJCode))));
						}
					}					
				}
				else if(game.Path.IndexOf(game.RJCode) != -1) {
					dirsToScan.Add(System.IO.Path.GetDirectoryName(game.Path.Substring(0, game.Path.IndexOf(game.RJCode))));
				}
				foreach (var parentDirPath in dirsToScan) {
					if (parentDirPath != "" && Directory.Exists(parentDirPath)) {
						IEnumerable<string> fullFileList = Directory.EnumerateDirectories(parentDirPath).Concat(Directory.EnumerateFiles(parentDirPath, "*.*", System.IO.SearchOption.AllDirectories));
						foreach (var fileName in fullFileList) {
							if (fileName.Contains(game.RJCode)) {
								index = fileName.IndexOf(game.RJCode);
								if (index < lastindex) {
									lastindex = index;
									int length = fileName.IndexOf(Path.DirectorySeparatorChar.ToString(), index);
									if (length == -1) {
										path = fileName;
									}
									else {
										path = fileName.Substring(0, length);
									}
									
								}							
							}
						}
						if (path != "") {
							
							fullFileList = Directory.EnumerateFiles(path, "*.*", System.IO.SearchOption.AllDirectories);
							string[] extensions = Settings.Instance.Extensions.Split(new [] {"|"},StringSplitOptions.None);
							var files = new List<string>();
							foreach (var fileName in fullFileList.Where(s => extensions.Any(ext => ext == Path.GetExtension(s).ToLower()))) {		// make list of files with specified extensions
								if (!Path.GetFileNameWithoutExtension(fileName).Contains("config", StringComparison.OrdinalIgnoreCase) && !Path.GetFileNameWithoutExtension(fileName).Contains("unins", StringComparison.OrdinalIgnoreCase)) {
									files.Add(fileName);
								}
								
							}
							if (files.Count > 0) {
								path = files[0];	//for now get first eligible file until figure out how to handle multiple files for one work
							}
							if (game.Path != path) {
								game.Path = path;
								game.Save();
							}						
						}
					}
				}
			}
        }
		
		// Get top folder with RJ code in name from path or last folder if no RJ code
		public static string GetWorksFolderFromPath(string path, string rjcode) {

			if (String.IsNullOrEmpty(rjcode) || !path.Contains(rjcode)) {
				if (Path.HasExtension(path)) {
					return Path.GetDirectoryName(path);
				}
				else {
					return path;
				}
			}
			else {
				if (Path.HasExtension(path)) {
					path = Path.GetDirectoryName(path);
				}
				if (!path.Contains(rjcode)) {	//means RJ Code is in filename
					return path;
				}
				else {							//RJ Code is in folder name
					if (path.IndexOf(Path.DirectorySeparatorChar.ToString(), path.IndexOf(rjcode)) == -1) {	//folder with RJ Code is the last
						return path;
					}
					else {						//folder with RJ Code is not the last
						return path.Substring(0, path.IndexOf(Path.DirectorySeparatorChar.ToString(), path.IndexOf(rjcode)));
					}
				}
			}
		}

		
		
		// rename/organize work's folder
		public static void RenameWorksFolder(Game game) {
			string template = Settings.Instance.RenameTemplate;
			if ((File.Exists(game.Path) || Directory.Exists(game.Path)) && !String.IsNullOrWhiteSpace(game.RJCode) && !String.IsNullOrWhiteSpace(template) 
					&& ((template.Split('\\').Last().Contains("{rjcode}") && ( template.Length - template.Replace("{rjcode}", "").Length ) / 8 == 1) || template.Split('\\').Last().Contains("{foldername}"))
					) {
				string path = game.Path;
				string filename = "";
				string path_after = "";
				if (File.Exists(path)) {
					filename = Path.GetFileName(path);
					path = Path.GetDirectoryName(path);

                    if(!IsFreeSpaceAvailable(game.Size))
                    {
                        System.Windows.Forms.MessageBox.Show("No Free Space Available");
                        return;
                    }

					int index = path.IndexOf(game.RJCode);
					if (index != -1) {
						int length = path.IndexOf(Path.DirectorySeparatorChar.ToString(), index);
						if (length != -1) {
							path_after = path.Substring(length + 1, path.Length - length - 1);
							path = path.Substring(0, length);
						}
					}
                    else if(!String.IsNullOrWhiteSpace(game.RJCode)){
                        // just to avoid the interruption when RJCode is available
                    }
                    else{
                        return;
                    }
				}
				string path_before = Path.GetDirectoryName(path);
				string foldername = Path.GetFileName(path);

				if (Settings.Instance.RenameOrganize && !String.IsNullOrWhiteSpace(Settings.Instance.GameFolder) && Directory.Exists(Settings.Instance.GameFolder) && !foldername.Equals(Settings.Instance.GameFolder)) {
					template = template.Replace("\\", "{dir_separator}");
					path_before = Settings.Instance.GameFolder;						
				}
				else {
					template = template.Split('\\').Last();
				}

				char[] charsToTrim = {'.', ' '};
				string newname = template.Replace("{rjcode}", game.RJCode).Replace("{title}", game.Title);
				newname = newname.Replace("{category}", String.IsNullOrWhiteSpace(game.Category) ? Settings.Instance.NoCategory : game.Category);
				newname = newname.Replace("{circle}", String.IsNullOrWhiteSpace(game.Author.Name) ? Settings.Instance.NoCircle : game.Author.Name);
				newname = newname.Replace("{cvs}", String.IsNullOrWhiteSpace(game.CVs) ? Settings.Instance.NoCVs : game.CVs);
				newname = newname.Replace("D*ck", "Dick").Replace("C*ck", "Cock").Replace("R*p", "Rap").Replace("F*ck", "Fuck").Replace("C*nt", "Cunt").Replace("P*ss", "Puss").Replace("S**t", "Shit");
				newname = newname.Replace("d*ck", "dick").Replace("c*ck", "cock").Replace("r*p", "rap").Replace("f*ck", "fuck").Replace("c*nt", "cunt").Replace("p*ss", "puss").Replace("s**t", "shit");
				newname = newname.Replace("D*CK", "DICK").Replace("C*CK", "COCK").Replace("R*P", "RAP").Replace("F*CK", "FUCK").Replace("C*NT", "CUNT").Replace("P*SS", "PUSS").Replace("S**T", "SHIT");
				newname = newname.Replace("?", "？").Replace("\"", "'").Replace("*", "_").Replace("/", "／").Replace("<", "＜").Replace(">", "＞").Replace("\\", "＼").Replace("|", "｜").Replace(":", "ː").Trim(charsToTrim);
				newname = Path.GetInvalidFileNameChars().Aggregate(newname, (current, c) => current.Replace(c.ToString(), "_"));
				newname = newname.Replace("{dir_separator}", Path.DirectorySeparatorChar.ToString()).Trim('\\');
				newname = Regex.Replace(newname, "\\{2,}", "\\");
				newname = newname.Replace("{foldername}", foldername);
				newname = Path.Combine(path_before, newname);
				string newpath = Path.Combine(path_before, newname, path_after);
				if (filename != "") {
					newpath = Path.Combine(newpath, filename);
				}
				if(newpath != game.Path && !Directory.Exists(newpath) && newname.Contains(game.RJCode)) {
					try {

						new Computer().FileSystem.MoveDirectory(path, newname);
						game.Path = newpath;
						game.Save();
						//delete empty folders
						if (Settings.Instance.RenameOrganize && !String.IsNullOrWhiteSpace(Settings.Instance.GameFolder) && Directory.Exists(Settings.Instance.GameFolder) && !path.Contains(Settings.Instance.GameFolder)) {
							path = Path.GetDirectoryName(path);
							while (path != Settings.Instance.GameFolder && Directory.GetFiles(path).Length == 0 && Directory.GetDirectories(path).Length == 0) {
								Directory.Delete(path);
								path = Path.GetDirectoryName(path);
							}
						}
					}
					catch (Exception e) {
						System.Windows.Forms.MessageBox.Show(e.Message);
						return;
					}
				
				}
			}
		}

        /// <summary>
        /// Checks for the free Space on the Main Folder
        /// </summary>
        /// <param name="gamesize">The Size of the Game</param>
        /// <returns></returns>
        public static bool IsFreeSpaceAvailable(int? gamesize)
        {
            string drive = Settings.Instance.GameFolder.Substring(0, 1);
            DriveInfo driveInfo = new DriveInfo(drive);
            return ((driveInfo.AvailableFreeSpace/1024f) > gamesize) ? true : false;
        }
        /// <summary>
        /// Returns true if the specified path points to a game made with RPG Maker.
        /// </summary>
        /// <param name="path">The path to a game's exe file.</param>
        /// <returns></returns>
        public static bool IsRpgMakerGame(string path) {
            if (path == null || !File.Exists(path)) {
                return false;
            }

            var gameDir = Path.GetDirectoryName(path);

            if (IOUtility.EnumerateFilesSafely(gameDir, "*.rgss??").FirstOrDefault() != null) {
                return true;
            }

            var gameIni = IOUtility.EnumerateFilesSafely(gameDir, "game.ini").FirstOrDefault();

            if (gameIni == null) {
                return false;
            }
            else {
                try {
                    return Regex.IsMatch(File.ReadAllText(gameIni), "RTP|r.data");
                }
                catch (Exception e) {
                    Logger.LogExceptionIfDebugging(e);
                    return false;
                }
            }
        }

        /// <summary>
        /// Returns true if the specified path points to a game made with Wolf RPG maker.
        /// </summary>
        /// <param name="path">The path to a game's exe file. </param>
        public static bool IsWolfRpgGame(string path) {
            if (path == null || !File.Exists(path)) {
                return false;
            }

            var gameDir = Path.GetDirectoryName(path);

            //Search the game directory for .wolf files
            if (IOUtility.EnumerateFilesSafely(gameDir, "*.wolf").FirstOrDefault() != null) {
                return true;
            }

            var dataDir = new DirectoryInfo(gameDir).GetDirectories("Data").FirstOrDefault();

            return dataDir != null && IOUtility.EnumerateFilesSafely(dataDir.FullName, "*.wolf").FirstOrDefault() != null;
        }

        /// <summary>
        /// Returns the version of Wolf RPG maker that was used to build the the game in the specified path.
        /// Returns null if the path does not point to a game made with Wolf RPG maker.
        /// </summary>
        public static string GetWolfRpgVersion(string path) {
            if (IsWolfRpgGame(path)) {
                var gameFile = new FileInfo(path);

                if (gameFile.Length / 1024 >= 3700) {
                    return "Unknown";
                }
                else if (gameFile.Length / 1024 >= 3400) {
                    return "2.10";
                }
                else if (gameFile.Length / 1024 >= 3020) {
                    //Games made with 2.02 and 2.02a are the same size
                    //Hence we assume that games made before the below date are 2.02
                    //However, this is not always the case
                    if (gameFile.LastWriteTime < new DateTime(2012, 6, 10)) {
                        return "2.02";
                    }
                    else {
                        return "2.02a";
                    }
                }
                else if (gameFile.Length / 1024 >= 2700) {
                    return "2.01";
                }
                else {
                    return "1.31";
                }
            }
            return null;
        }

        /// <summary>
        /// Returns the correct AGTH parameters for a game made with the specified version of Wolf RPG maker.
        /// Returns null if the AGTH parameters for the specified version are unknown.
        /// </summary>
        public static string GetWolfRpgAgthParams(string version) {
            switch (version) {
                case "Unknown":
                case "2.10":
                    return "/hbn*0@493F83 /w1 /kf64:16";
                case "2.02a":
                    return "/hbn*0@470D5A /w1 /kf64:16";
                case "2.02":
                    return "/hbn*0@470CEA /w1 /kf64:16";
                case "2.01":
                    return "/hbn*0@46BA03 /w1 /kf64:16";
                case "1.31":
                    return "/hbn*0@454C6C /w1 /kf64:16";
                default:
                    return null;
            }
        }

        /// <summary>
        /// Removes the read only flag from all files in the specified directory and its subdirectories.
        /// </summary>
        public static void RemoveReadOnly(string directory) {
            foreach (var path in EnumerateFilesSafely(directory, "*", System.IO.SearchOption.AllDirectories)) {
                var attributes = File.GetAttributes(path);

                if ((attributes & FileAttributes.ReadOnly) != 0) {
                    File.SetAttributes(path, attributes & ~FileAttributes.ReadOnly);
                }
            }
        }

        /// <summary>
        /// If the source and destination paths have the same root, the source will be moved to the destination.
        /// If not, the source will be copied to the destination and then removed.
        /// Returns the new path to the destination folder.
        /// </summary>
        public static string MoveOrCopy(string sourcePath, string destPath) {
            var comp = new Computer();
            destPath += Path.DirectorySeparatorChar + new DirectoryInfo(sourcePath).Name;

            RemoveReadOnly(sourcePath);

            if (Path.GetPathRoot(sourcePath).ToUpper() == Path.GetPathRoot(destPath).ToUpper()) {
                comp.FileSystem.MoveDirectory(sourcePath, destPath, UIOption.AllDialogs, UICancelOption.DoNothing);
            }
            else {
                try {
                    comp.FileSystem.CopyDirectory(sourcePath, destPath, UIOption.AllDialogs, UICancelOption.ThrowException);
                    comp.FileSystem.DeleteDirectory(sourcePath, UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently, UICancelOption.DoNothing);
                }
                catch (OperationCanceledException) {
                    comp.FileSystem.DeleteDirectory(destPath, DeleteDirectoryOption.DeleteAllContents);
                    return sourcePath;
                }
            }
            return destPath;
        }

        /// <summary>
        /// If the specified folder exists, a standard Windows confirmation dialog is created that asks the user if the folder should be deleted.
        /// If 'yes' is clicked, the folder is moved to the recycle bin and true is returned.
        /// If 'no' is clicked or the folder cannot be removed, false is returned.
        /// </summary>
        public static bool DeleteFolder(string folderPath) {
            if (Directory.Exists(folderPath)) {
                try {
                    new Computer().FileSystem.DeleteDirectory(folderPath,
                                                              UIOption.AllDialogs,
                                                              RecycleOption.SendToRecycleBin,
                                                              UICancelOption.ThrowException);
                }
                catch (Exception) {
                    return false;
                }
            }
            return true;
        }

        public static bool IsZipArchive(string path) {
            return ZipFile.IsZipFile(path);
        }

        public static bool IsRarArchive(string path) {
            if (File.Exists(path)) {
                if (!File.Exists(UnrarPath) || !UnrarCreated) {
                    File.WriteAllBytes(UnrarPath, Properties.Resources.UnRAR);
                    UnrarCreated = true;
                }

                var startInfo = new ProcessStartInfo {
                    FileName = UnrarPath,
                    Arguments = "lb -p- -ierr \"" + path + "\"",
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                };

                var unrar = Process.Start(startInfo);

                //If the file is a valid .rar archive, at least one line is printed to stdout.
                if (!unrar.StandardError.EndOfStream) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns true if the specified path points to an archive that can be extracted.
        /// </summary>
        public static bool IsArchive(string path) {
            try {
                return IsZipArchive(path) || IsRarArchive(path);
            }
            catch (Exception e) {
                Logger.LogException(e);
                return false;
            }
        }

        public static bool ExtractRarArchive(string source, string destination, out string gamePath, Action<String> reportProgress = null) {
            gamePath = null;
            string line = "";
            int rootEntries = 0;
            var progressRegex = new Regex(@"\d+%");

            if (reportProgress == null) {
                reportProgress = s => { };
            }

            if (File.Exists(source) && !String.IsNullOrWhiteSpace(destination)) {
                if (!File.Exists(UnrarPath) || !UnrarCreated) {
                    File.WriteAllBytes(UnrarPath, Properties.Resources.UnRAR);
                    UnrarCreated = true;
                }

                var startInfo = new ProcessStartInfo {
                    FileName = UnrarPath,
                    Arguments = "lb -p- -ierr \"" + source + "\"",
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                };

                var unrar = Process.Start(startInfo);
                reportProgress("Reading archive data...");

                while (!unrar.StandardError.EndOfStream) {
                    line = unrar.StandardError.ReadLine();
                    var lowLine = line.ToLower();

                    //File names with no slashes are root entries
                    if (line.Count(c => c == '/' || c == '\\') == 0) {
                        rootEntries++;
                    }

                    if (lowLine.EndsWith(".exe") && !lowLine.Contains("config") && !lowLine.Contains("unins")) {
                        gamePath = line;
                    }
                }

                //If more than one entry exists at root level, create a new folder to contain the extracted archive
                if (rootEntries > 0) {
                    destination = Path.Combine(destination, Path.GetFileNameWithoutExtension(source));
                }

                if (gamePath == null) {
					gamePath = destination;
                    //var result = MessageBox.Show("The archive does not contain an executable file, so nothing will be added to the game list. Should the archive still be extracted?",
                    //                             "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                    //if (result != DialogResult.Yes) {
                    //    reportProgress("");
                    //    return false;
                    //}
                }
                else {
                    gamePath = Path.Combine(destination, gamePath);
                }

                startInfo = new ProcessStartInfo {
                    FileName = UnrarPath,
                    Arguments = "x -p- -o- -ierr \"" + source + "\" \"" + destination + "\\\"",
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                };

                unrar = Process.Start(startInfo);

                while (!unrar.StandardError.EndOfStream) {
                    line = unrar.StandardError.ReadLine();

                    if (line.Contains("- checksum error")) {
                        reportProgress("ERROR: CRC failed. Archive is corrupt.");
                        return false;
                    }
                    else if (line.Contains("header is corrupt")) {
                        reportProgress("ERROR: File header invalid. The archive is currupt.");
                        return false;
                    }
                    else if (line.Contains("Corrupt file or wrong password")) {
                        reportProgress("ERROR: The archive is password protected.");
                        return false;
                    }
                    else if (line.Contains("Cannot find volume") || line.Contains("start extraction from a previous volume")) {
                        reportProgress("ERROR: Volume missing, the archive is incomplete.");
                        return false;
                    }
                    else if (line.StartsWith("Extracting")) {
                        var match = progressRegex.Match(line);
                        var spaceIndex = line.IndexOf(' ');

                        if (match.Success && spaceIndex > -1) {
                            try {
                                var fileName = Path.GetFileName(line.Substring(spaceIndex, match.Index - spaceIndex).Trim(' ', '\b'));
                                reportProgress(String.Format("({0}) {1}...", match.Value, fileName));
                            }
                            catch (ArgumentException) { }
                        }
                    }
                }

                //Hack: If a rar file containing an exe with a Japanese name is extracted on a computer without a Japanese locale,
                //the game path will contain question marks. Try to fix this by searching for the actual name of the extracted folders and exe file in the destination folder.
                if (gamePath != null && gamePath.Contains('?')) {
                    try {
                        var folderPath = destination;
                        var relativePath = gamePath.Substring(folderPath.Trim('/', '\\').Length + 1).Replace('/', '\\').Trim('\\');

                        //If the relative path contains the path to a directory
                        if (relativePath.Contains('\\')) {
                            var relativeFolderPath = Path.GetDirectoryName(relativePath);
                            folderPath = new DirectoryInfo(folderPath).GetDirectories(relativeFolderPath)[0].FullName;
                            relativePath = Path.GetFileName(relativePath);
                        }

                        gamePath = new DirectoryInfo(folderPath).GetFiles(relativePath)[0].FullName;
                    }
                    catch (Exception) { }
                }

                if (line == "All OK") {
                    reportProgress(Path.GetFileName(source) + " successfully extracted to " + destination);
                    return true;
                }
                else if (line == "No files to extract") {
                    reportProgress(line + ".");
                }
                else {
                    reportProgress("An unknown error occurred while unpacking " + Path.GetFileName(source));
                }
            }
            return false;
        }

        public static bool ExtractZipArchive(string source, string destination, out string gamePath, Action<string> reportProgress = null) {
            gamePath = null;

            if (ZipFile.IsZipFile(source) && !String.IsNullOrWhiteSpace(destination)) {
                //Always assume archives are encoded in shift-JIS (932)
                using (var zip = new ZipFile(source, Encoding.GetEncoding(932))) {
                    if (reportProgress != null) {
                        zip.ExtractProgress += (sender, e) => {
                            if (e.EventType == ZipProgressEventType.Extracting_BeforeExtractEntry) {
                                reportProgress(String.Format("({0}%) {1}...", (int)(((float)e.EntriesExtracted / e.EntriesTotal) * 100), e.CurrentEntry.FileName));
                            }
                        };
                    }

                    int rootEntries = 0;
                    int rootDirectories = 0;

                    foreach (var entry in zip.Entries) {
                        //File names with no slashes are root entries
                        //The last character is ignored because directories have a trailing slash
                        if (entry.FileName.Take(entry.FileName.Length - 1).Count(c => c == '/' || c == '\\') == 0) {
                            rootEntries++;

                            if (entry.IsDirectory) {
                                rootDirectories++;
                            }
                        }
                    }

                    //If more than one directory exists at root level, create a new folder to contain the extracted archive
                    if (rootEntries > 0 || rootDirectories > 1) {
                        destination = Path.Combine(destination, Path.GetFileNameWithoutExtension(zip.Name));
                    }

                    var gameExecutable = zip.FirstOrDefault(entry => entry.FileName.ToLower().EndsWith(".exe") &&
                                         !entry.FileName.Contains("config", StringComparison.OrdinalIgnoreCase) &&
                                         !entry.FileName.Contains("unins", StringComparison.OrdinalIgnoreCase));

                    if (gameExecutable == null) {gamePath = destination;
                        //var result = MessageBox.Show("The archive does not contain an executable file, so nothing will be added to the game list. Should the archive still be extracted?",
                        //                             "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                        //if (result != DialogResult.Yes) {
                        //    return false;
                        //}
                    }
                    else {
                        gamePath = Path.Combine(destination, gameExecutable.FileName);
                    }

                    zip.ExtractAll(destination, ExtractExistingFileAction.DoNotOverwrite);

                    if (reportProgress != null) {
                        reportProgress(Path.GetFileName(source) + " successfully extracted to " + destination);
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Extracts a zip or rar archive to the specified destination folder. 
        /// Returns true if the archive is successfully extracted.
        /// </summary>
        /// <param name="source">Path to the archive file.</param>
        /// <param name="destination">Path to the destination folder.</param>
        /// <param name="gamePath">Will contain the path to the extracted game executable, or null if one does not exist.</param>
        /// <param name="reportProgress">This function is called to report progress as a string. Set as null to disable progress reporting. </param>
        public static bool ExtractArchive(string source, string destination, out string gamePath, Action<string> reportProgress = null) {
            gamePath = null;

            if (IsZipArchive(source)) {
                return ExtractZipArchive(source, destination, out gamePath, reportProgress);
            }
            else if (IsRarArchive(source)) {
                return ExtractRarArchive(source, destination, out gamePath, reportProgress);
            }
            else {
                return false;
            }
        }

        /// <summary>
        /// Returns the size of a directory in kilobytes.
        /// Returns 0 if the specified path does not point to a valid directory.
        /// </summary>
        public static int GetDirectorySize(string path) {
            long bytes = 0;

            if (Directory.Exists(path)) {
                foreach (string file in EnumerateFilesSafely(path, "*", System.IO.SearchOption.AllDirectories)) {
                    bytes += new FileInfo(file).Length;
                }
            }
            return (int)(bytes / 1024);
        }

        /// <summary>
        /// Returns true if the specified path is a valid directory that contains no files or subdirectories
        /// </summary>
        public static bool IsDirectoryEmpty(string path) {
            if (Directory.Exists(path)) {
                return !Directory.EnumerateFileSystemEntries(path).Any();
            }
            return false;
        }
    }
}
