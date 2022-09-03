using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace GameManager {
    /// <summary>
    /// A static class providing an application programming interface to the underlying data store.
    /// </summary>
    static class Database {
        private static Object writeLock = new Object();
        private static readonly string connectionString;

        /// <summary>
        /// Ensures that the database is initialised with all the needed tables.
        /// Automatically run before the first database method is called.
        /// </summary>
        static Database() {
            connectionString = String.Format("Data Source={0};" + "Version=3;" +
                                             "Pooling=True;" + "Max Pool Size=5;" +
                                             "Page Size=4096;" + "Cache Size=4000;", //SQLite will use ~15 MB of RAM with these cache settings
                                              Path.Combine(Settings.ProgramDirectoryPath, Settings.RelativeDatabasePath));
            
            //Create the database if it doesn't exist
            using (SQLiteConnection conn = new SQLiteConnection(connectionString)) {
                conn.Open();

                using (SQLiteCommand query = conn.CreateCommand()) {
                    query.CommandText =
                        @"BEGIN;

                        CREATE TABLE IF NOT EXISTS circle (
                            CircleID integer PRIMARY KEY,
                            RGCode varchar(255) DEFAULT NULL,
                            Name varchar(255) UNIQUE
                        );
                    
                        CREATE TABLE IF NOT EXISTS game (
                            GameID integer PRIMARY KEY,
                            RJCode varchar(255) DEFAULT NULL,
                            Title varchar(255) DEFAULT NULL,
                            FolderPath varchar(255) DEFAULT NULL,
                            Rating tinyint DEFAULT NULL,
                            DLSRating tinyint DEFAULT NULL,
                            ReleaseDate datetime DEFAULT NULL,
                            AddedDate datetime DEFAULT NULL,
                            LastPlayedDate datetime DEFAULT NULL,
                            TimesPlayed integer NOT NULL,
                            SecondsPlayed integer NOT NULL,
                            CircleID integer DEFAULT NULL, --REFERENCES circle(CircleID), --Foreign keys are ignored by SQLite
                            Category varchar(255) DEFAULT NULL,
                            Tags text DEFAULT NULL,
                            Comments text DEFAULT NULL,
                            RunWithAgth tinyint DEFAULT NULL,
                            AgthParameters text DEFAULT NULL,
                            Size integer DEFAULT NULL,
                            DLSiteFlags smallint NOT NULL,
                            IsRpgMakerGame tinyint NOT NULL,
                            WolfRpgMakerVersion varchar(255) DEFAULT NULL,
                            UseCustomResolution tinyint NOT NULL,
                            ResolutionWidth smallint DEFAULT NULL,
                            ResolutionHeight smallint DEFAULT NULL
                        );

                        CREATE TABLE IF NOT EXISTS image (
                            ImageID integer PRIMARY KEY,
                            ImagePath varchar(255),
                            IsListImage tinyint NOT NULL,
                            IsCoverImage tinyint NOT NULL,
                            GameID integer NOT NULL
                                --REFERENCES game(GameID)
                        );
                        
                        PRAGMA user_version;

                        COMMIT;";
                    long version = (long)query.ExecuteScalar();

                    if (version < 1) {
                        query.CommandText = "PRAGMA user_version = 1;";
                        query.ExecuteNonQuery();
                    }

                    if (version < 2) {
                        //Add the language column to the game table and set its value to Japanese for all games with an RJCode
                        query.CommandText = @"BEGIN;
                                              PRAGMA user_version = 2;
                                              ALTER TABLE Game ADD Language varchar(255);
                                              UPDATE Game SET Language = 'Japanese' WHERE RJCode IS NOT NULL;
                                              COMMIT;";
                        query.ExecuteNonQuery();
                                              
                    }
                    if (version < 3) {
                        //Remove all new lines from game titles that begin with a new line
                        query.CommandText = @"BEGIN;
                                              PRAGMA user_version = 3;
                                              UPDATE Game SET Title = replace(Title, x'0a', '') WHERE Title LIKE x'0a' || '%';
                                              COMMIT;";
                        query.ExecuteNonQuery();
                    }
                    if (version < 4)
                    {
                        //Add the ChiiTrans line
                        query.CommandText = @"BEGIN;
                                              PRAGMA user_version = 4;
                                              ALTER TABLE game ADD RunWithChiiTrans tinyint DEFAULT NULL;
                                              COMMIT;";
                        query.ExecuteNonQuery();
                    }
                    if (version < 5)
                    {
                        //Add HVDBTags and CVs columns
                        query.CommandText = @"BEGIN;
                                              PRAGMA user_version = 5;
                                              ALTER TABLE game ADD HVDBTags text DEFAULT NULL;
											  ALTER TABLE game ADD CVs text DEFAULT NULL;
                                              COMMIT;";
                        query.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Returns all circles (game authors) stored in the database.
        /// </summary>
        public static List<Circle> GetCircles() {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString)) {
                conn.Open();

                using (SQLiteCommand query = new SQLiteCommand("Select * from Circle;", conn)) {
                    using (SQLiteDataReader reader = query.ExecuteReader()) {
                        var circles = new List<Circle>();
                        int idPos = reader.GetOrdinal("CircleID");
                        int rgPos = reader.GetOrdinal("RGCode");
                        int namePos = reader.GetOrdinal("Name");

                        while (reader.Read()) {
                            circles.Add(new Circle() {
                                CircleID = reader.GetInt32(idPos),
                                RGCode = (string)reader.GetValueOrNull(rgPos),
                                Name = (string)reader.GetValueOrNull(namePos)
                            });
                        }
                        return circles;
                    }
                }
            }
        }

        /// <summary>
        /// Returns all games stored in the database.
        /// </summary>
        public static List<Game> GetGames() {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString)) {
                conn.Open();

                using (SQLiteCommand query = new SQLiteCommand("Select * from Game;", conn)) {
                    using (SQLiteDataReader reader = query.ExecuteReader()) {
                        //Initialising a game requires data from these three tables
                        var games = new List<Game>();
                        var circles = Circle.GetCircles();
                        var images = GameImage.GetImages();

                        int idPos = reader.GetOrdinal("GameID");
                        int rjPos = reader.GetOrdinal("RJCode");
                        int titlePos = reader.GetOrdinal("Title");
                        int pathPos = reader.GetOrdinal("FolderPath");
                        int ratingPos = reader.GetOrdinal("Rating");
                        int dlsRatingPos = reader.GetOrdinal("DLSRating");
                        int releasePos = reader.GetOrdinal("ReleaseDate");
                        int addedPos = reader.GetOrdinal("AddedDate");
                        int playedDate = reader.GetOrdinal("LastPlayedDate");
                        int timesPlayedPos = reader.GetOrdinal("TimesPlayed");
                        int secondsPlayedPos = reader.GetOrdinal("SecondsPlayed");
                        int categoryPos = reader.GetOrdinal("Category");
                        int languagePos = reader.GetOrdinal("Language");
                        int tagsPos = reader.GetOrdinal("Tags");
						int hvdbtagsPos = reader.GetOrdinal("HVDBTags");
						int cvsPos = reader.GetOrdinal("CVs");
                        int commentsPos = reader.GetOrdinal("Comments");
                        int circleIdPos = reader.GetOrdinal("CircleID");
                        int runWithAgthPos = reader.GetOrdinal("RunWithAgth");
                        int runWithChiiTransPos = reader.GetOrdinal("RunWithChiiTrans");
                        int agthParamsPos = reader.GetOrdinal("AgthParameters");
                        int sizePos = reader.GetOrdinal("Size");
                        int dlSiteFlagsPos = reader.GetOrdinal("DLSiteFlags");
                        int isRpgMakerGamePos = reader.GetOrdinal("IsRpgMakerGame");
                        int wolfRpgMakerVersionPos = reader.GetOrdinal("WolfRpgMakerVersion");
                        int useCustomResolutionPos = reader.GetOrdinal("UseCustomResolution");
                        int resolutionWidthPos = reader.GetOrdinal("ResolutionWidth");
                        int resolutionHeightPos = reader.GetOrdinal("ResolutionHeight");

                        while (reader.Read()) {
                            int? circleID = reader.GetNullableInt32(circleIdPos);
                            int? x = reader.GetNullableInt32(resolutionWidthPos);
                            int? y = reader.GetNullableInt32(resolutionHeightPos);
                            int dlSiteFlags = reader.GetInt16(dlSiteFlagsPos);

                            Game game = new Game() {
                                GameID = reader.GetInt32(idPos),
                                RJCode = (string)reader.GetValueOrNull(rjPos),
                                Title = (string)reader.GetValueOrNull(titlePos),
                                Path = (string)reader.GetValueOrNull(pathPos),
                                Rating = reader.GetNullableByte(ratingPos),
                                DLSRating = reader.GetNullableByte(dlsRatingPos),
                                ReleaseDate = (DateTime?)reader.GetValueOrNull(releasePos),
                                AddedDate = (DateTime?)reader.GetValueOrNull(addedPos),
                                LastPlayedDate = (DateTime?)reader.GetValueOrNull(playedDate),
                                TimesPlayed = reader.GetInt32(timesPlayedPos),
                                TimePlayed = TimeSpan.FromSeconds(reader.GetInt32(secondsPlayedPos)),
                                Tags = (string)reader.GetValueOrNull(tagsPos),
								HVDBTags = (string)reader.GetValueOrNull(hvdbtagsPos),
								CVs = (string)reader.GetValueOrNull(cvsPos),
                                Category = (string)reader.GetValueOrNull(categoryPos),
                                Language = (string)reader.GetValueOrNull(languagePos),
                                Comments = (string)reader.GetValueOrNull(commentsPos),
                                RunWithAgth = reader.GetNullableBoolean(runWithAgthPos),
                                RunWithChiiTrans = (runWithChiiTransPos >= 0 ? reader.GetNullableBoolean(runWithChiiTransPos) : null),
                                AgthParameters = (string)reader.GetValueOrNull(agthParamsPos),
                                Size = reader.GetNullableInt32(sizePos),
                                IsOnJapaneseDLSite = (dlSiteFlags & 1) != 0,
                                IsReleasedOnJapaneseDLSite = (dlSiteFlags & 2) != 0,
                                IsOnEnglishDLSite = (dlSiteFlags & 4) != 0,
                                IsReleasedOnEnglishDLSite = (dlSiteFlags & 8) != 0,
								IsOnHVDB = (dlSiteFlags & 16) != 0,
                                IsRpgMakerGame = reader.GetBoolean(isRpgMakerGamePos),
                                WolfRpgMakerVersion = (string)reader.GetValueOrNull(wolfRpgMakerVersionPos),
                                UseCustomResolution = reader.GetBoolean(useCustomResolutionPos),
                                CustomResolution = x.HasValue && y.HasValue ? new ScreenResolution(x.Value, y.Value) : null,
                            };

                            /* Combine all three tables.
                             * Doing this outside of an SQL query is considered bad practise and slow.
                             * I might go back and change this if application startup time becomes an issue.
                             */
                            if (circleID.HasValue) {
                                foreach (Circle circle in circles) {
                                    if (circleID == circle.CircleID) {
                                        game.Author = circle;
                                        break;
                                    }
                                }
                            }

                            foreach (GameImage image in images) {
                                if (image.GameID == game.GameID) {
                                    if (image.IsListImage) {
                                        game.ListImage = image;
                                    }
                                    else {
                                        game.Images.Add(image);
                                    }
                                }
                            }
                            games.Add(game);
                        }
                        return games;
                    }
                }
            }
        }

        /// <summary>
        /// Returns all images stored in the database.
        /// </summary>
        public static List<GameImage> GetImages() {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString)) {
                conn.Open();

                using (SQLiteCommand query = new SQLiteCommand("Select ImageID, ImagePath, IsListImage, IsCoverImage, GameID from Image;", conn)) {
                    using (SQLiteDataReader reader = query.ExecuteReader()) {
                        var images = new List<GameImage>();
                        int idPos = reader.GetOrdinal("ImageID");
                        int pathPos = reader.GetOrdinal("ImagePath");
                        int isListPos = reader.GetOrdinal("IsListImage");
                        int isCoverPos = reader.GetOrdinal("IsCoverImage");
                        int gameIdPos = reader.GetOrdinal("GameID");

                        while (reader.Read()) {
                            images.Add(new GameImage() {
                                ImageID = reader.GetInt32(idPos),
                                ImagePath = (string)reader.GetValueOrNull(pathPos),
                                IsCoverImage = reader.GetBoolean(isCoverPos),
                                IsListImage = reader.GetBoolean(isListPos),
                                GameID = reader.GetInt32(gameIdPos)
                            });
                        }
                        return images;
                    }
                }
            }
        }

        /// <summary>
        /// Inserts a new circle or updates an existing one and returns the auto generated CircleID.
        /// </summary>
        public static int SaveCircle(Circle circle) {
            if (circle.Name == null) {
                throw new ArgumentException("Circle name cannot be null.");
            }

            lock (writeLock) {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString)) {
                    conn.Open();

                    using (SQLiteCommand query = new SQLiteCommand(conn)) {
                        //The COALESCE function returns the first non-null expression
                        //This causes all circles with identical names to also have identical IDs and RGCodes
                        query.CommandText = @"BEGIN;
                                          INSERT OR REPLACE INTO circle VALUES (COALESCE(@CircleID, (SELECT circleID FROM circle WHERE Name = @Name)), @RGCode, @Name);
                                          SELECT last_insert_rowid();
                                          COMMIT;";
                        query.Parameters.AddWithValue("@CircleID", circle.CircleID);
                        query.Parameters.AddWithValue("@RGCode", circle.RGCode);
                        query.Parameters.AddWithValue("@Name", circle.Name);

                        //row_id is an Int64
                        return (int)(Int64)query.ExecuteScalar();
                    }
                }
            }
        }

        /// <summary>
        /// Inserts a new game or updates an existing one and returns the auto generated GameID.
        /// </summary>
        public static int SaveGame(Game game) {
            int dlSiteFlags = (game.IsOnJapaneseDLSite ? 1 : 0) | (game.IsReleasedOnJapaneseDLSite ? 2 : 0) |
                              (game.IsOnEnglishDLSite ? 4 : 0) | (game.IsReleasedOnEnglishDLSite ? 8 : 0) | (game.IsOnHVDB ? 16 : 0);

            lock (writeLock) {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString)) {
                    conn.Open();

                    using (SQLiteCommand query = new SQLiteCommand(conn)) {
                        query.CommandText = @"BEGIN;
                                          INSERT OR REPLACE INTO game VALUES (  @GameID, @RJCode, @Title, @Path,
                                                                                @Rating, @DLSRating, @Released, @Added, @LastPlayed,
                                                                                @TimesPlayed, @SecondsPlayed, @CircleID, @Category,
                                                                                @Tags, @Comments, @RunWithAgth, @AgthParameters, @Size,
                                                                                @DLSiteFlags, @IsRpgMakerGame, @WolfRpgMakerVersion,
                                                                                @UseCustomResolution, @ResolutionWidth, @ResolutionHeight, @Language, @RunWithChiiTrans, @HVDBTags, @CVs); 
                                          SELECT last_insert_rowid();
                                          COMMIT;";
                        query.Parameters.AddWithValue("@GameID", game.GameID);
                        query.Parameters.AddWithValue("@RJCode", game.RJCode);
                        query.Parameters.AddWithValue("@Title", game.Title);
                        query.Parameters.AddWithValue("@Path", game.Path);
                        query.Parameters.AddWithValue("@Rating", game.Rating);
                        query.Parameters.AddWithValue("@DLSRating", game.DLSRating);
                        query.Parameters.AddWithValue("@Released", game.ReleaseDate);
                        query.Parameters.AddWithValue("@Added", game.AddedDate);
                        query.Parameters.AddWithValue("@LastPlayed", game.LastPlayedDate);
                        query.Parameters.AddWithValue("@TimesPlayed", game.TimesPlayed);
                        query.Parameters.AddWithValue("@SecondsPlayed", (int)game.TimePlayed.TotalSeconds);
                        query.Parameters.AddWithValue("@CircleID", game.Author == null ? null : game.Author.CircleID);
                        query.Parameters.AddWithValue("@Category", game.Category);
                        query.Parameters.AddWithValue("@Tags", game.Tags);
						query.Parameters.AddWithValue("@HVDBTags", game.HVDBTags);
						query.Parameters.AddWithValue("@CVs", game.CVs);
                        query.Parameters.AddWithValue("@Comments", game.Comments);
                        query.Parameters.AddWithValue("@RunWithAgth", game.RunWithAgth);
                        query.Parameters.AddWithValue("@RunWithChiiTrans", game.RunWithChiiTrans);
                        query.Parameters.AddWithValue("@AgthParameters", game.AgthParameters);
                        query.Parameters.AddWithValue("@Size", game.Size);
                        query.Parameters.AddWithValue("@DLSiteFlags", dlSiteFlags);
                        query.Parameters.AddWithValue("@IsRpgMakerGame", game.IsRpgMakerGame);
                        query.Parameters.AddWithValue("@WolfRpgMakerVersion", game.WolfRpgMakerVersion);
                        query.Parameters.AddWithValue("@UseCustomResolution", game.UseCustomResolution);
                        query.Parameters.AddWithValue("@ResolutionWidth", game.CustomResolution != null ? game.CustomResolution.Width : (int?)null);
                        query.Parameters.AddWithValue("@ResolutionHeight", game.CustomResolution != null ? game.CustomResolution.Height : (int?)null);
                        query.Parameters.AddWithValue("@Language", game.Language);

                        return (int)(Int64)query.ExecuteScalar();
                    }
                }
            }
        }

        /// <summary>
        /// Inserts a new game image or updates an existing one and returns the auto generated ImageID.
        /// </summary>
        public static int SaveImage(GameImage image) {
            lock (writeLock) {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString)) {
                    conn.Open();

                    using (SQLiteCommand query = new SQLiteCommand(conn)) {
                        query.CommandText = @"BEGIN;
                                          INSERT OR REPLACE INTO image VALUES (@ImageID, @ImagePath, @IsListImage, @IsCoverImage, @GameID);
                                          SELECT last_insert_rowid();
                                          COMMIT;";
                        query.Parameters.AddWithValue("@ImageID", image.ImageID);
                        query.Parameters.AddWithValue("@ImagePath", image.ImagePath);
                        query.Parameters.AddWithValue("@IsListImage", image.IsListImage);
                        query.Parameters.AddWithValue("@IsCoverImage", image.IsCoverImage);
                        query.Parameters.AddWithValue("@GameID", image.GameID);

                        return (int)(Int64)query.ExecuteScalar();
                    }
                }
            }
        }

        /// <summary>
        /// Deletes the game object from the database as well the images associated with it.
        /// </summary>
        public static void DeleteGame(Game game) {
            lock (writeLock) {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString)) {
                    conn.Open();

                    using (SQLiteCommand query = new SQLiteCommand(conn)) {
                        query.CommandText = @"BEGIN;
                                          DELETE FROM Image
                                          WHERE GameID = @GameID;

                                          DELETE FROM Game
                                          WHERE GameID = @GameID;
                                          COMMIT;";
                        query.Parameters.AddWithValue("@GameID", game.GameID);
                        query.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Deletes the circle object from the database as well the references to it.
        /// </summary>
        public static void DeleteCircle(Circle circle) {
            lock (writeLock) {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString)) {
                    conn.Open();

                    using (SQLiteCommand query = new SQLiteCommand(conn)) {
                        query.CommandText = @"BEGIN;
                                          UPDATE Game
                                          SET CircleID = NULL
                                          WHERE CircleID = @CircleID;

                                          DELETE FROM Circle
                                          WHERE CircleID = @CircleID;
                                          COMMIT;";
                        query.Parameters.AddWithValue("@CircleID", circle.CircleID);
                        query.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Deletes the image object from the databse.
        /// </summary>
        public static void DeleteImage(GameImage image) {
            lock (writeLock) {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString)) {
                    conn.Open();

                    using (SQLiteCommand query = new SQLiteCommand(@"DELETE FROM image 
                                                                 WHERE ImageID =" + image.ImageID + ";", conn)) {
                        query.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
