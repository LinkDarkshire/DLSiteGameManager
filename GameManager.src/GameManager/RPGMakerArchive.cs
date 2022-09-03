using System;
using System.IO;
using System.Text;
using System.Threading;

namespace GameManager {
    /// <summary>
    /// An RPG maker archive that can be decrypted and extracted to a folder.
    /// </summary>
    public class RPGMakerArchive {
        /// <param name="fileName">The name of the file currently being extracted.</param>
        /// <param name="progress">The number of bytes that have been extracted so far.</param>
        public delegate void ProgressReporter(string fileName, long progress);

        private string path;
        private int version;
        private CancellationToken cancellationToken;
        private ProgressReporter reportProgress;

        /// <summary>
        /// Gets the size of the archive in bytes.
        /// </summary>
        public long Size { get { return new FileInfo(path).Length; } }

        /// <param name="archivePath">The path to the RPG maker archive. </param>
        /// <exception cref="ArgumentException">Thrown if the file path is not a valid archive, or the archive version is unsupported.</exception>
        public RPGMakerArchive(string archivePath) {
            path = archivePath;
            version = GetVersion();

            if (version != 1 && version != 3) {
                throw new ArgumentException("Cannot decrypt version " + version + " RGSSAD files.");
            }
        }

        /// <summary>
        /// Returns the version of an RPG maker archive file stream.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if the file path is not a valid archive, or the archive version is unsupported.</exception>
        private int GetVersion() {
            using (var archive = new FileStream(path, FileMode.Open)) {
                byte[] header = new byte[8];

                //Extract the header
                int bytesRead = archive.Read(header, 0, header.Length);

                if (bytesRead == 8 && Encoding.ASCII.GetString(header, 0, 6) == "RGSSAD") {
                    return header[7];
                }
                else {
                    throw new ArgumentException(archive.Name + " is not a valid RPG Maker archive.");
                }
            }
        }

        /// <summary>
        /// Decrypts and extracts the archive to the destination folder.
        /// Returns the number of successfully extracted files.
        /// </summary>
        /// <param name="destPath">The folder the archive will be extracted to.</param>
        /// <param name="token">Signal this token to cancel the extraction. </param>
        /// <param name="reportProgress">The function to be invoked when a new file is being decrypted. </param>
        /// <exception cref="ArgumentException">Thrown if the archive is invalid. </exception>
        public int Extract(string destPath, CancellationToken token, ProgressReporter reportProgress = null) {
            this.reportProgress = reportProgress;
            this.cancellationToken = token;

            if (version == 1) {
                return DecryptVersion1Archive(destPath); 
            }
            else if (version == 3) {
                return DecryptVersion3Archive(destPath);
            }
            return 0;
        }

        #region Version 1 and 2 decrypter
        /// <summary>
        /// Extracts the version 1 archive file stream to the specified destination path.
        /// </summary>
        private int DecryptVersion1Archive(string destination) {
            using (var reader = new BinaryReader(new FileStream(path, FileMode.Open))) {
                int filesExtracted = 0;
                long bytesExtracted = 0;
                long archiveLength = reader.BaseStream.Length;
                bool invalidArchive = false;
                uint key = 0xDEADCAFE;

                //Seek past the header
                reader.BaseStream.Seek(8, SeekOrigin.Begin);

                try {
                    //Decrypt all the files in the archive individually
                    while (reader.BaseStream.Position < archiveLength && !cancellationToken.IsCancellationRequested) {
                        int fileNameLength = DecryptVersion1Int(reader.ReadInt32(), ref key);
                        byte[] encryptedFileName = reader.ReadBytes(fileNameLength);

                        if (encryptedFileName.Length != fileNameLength) {
                            //Inconsistent archive. Probably corrupt 
                            invalidArchive = true;
                            break;
                        }

                        string fileName = DecryptVersion1Name(encryptedFileName, ref key);
                        string filePath = Path.Combine(destination, fileName);
                        int fileSize = DecryptVersion1Int(reader.ReadInt32(), ref key);
                        string directoryName = Path.GetDirectoryName(filePath);

                        if (reportProgress != null) {
                            reportProgress(fileName, bytesExtracted);
                        }

                        //Create a new folder for the file if needed
                        if (!Directory.Exists(directoryName)) {
                            Directory.CreateDirectory(directoryName);
                        }

                        //Extract the encrypted file data
                        byte[] encryptedFileData = reader.ReadBytes(fileSize);

                        if (encryptedFileData.Length != fileSize) {
                            //Inconsistent archive. Probably corrupt 
                            invalidArchive = true;
                            break;
                        }

                        //Decode and write the file to disc
                        using (FileStream file = new FileStream(filePath, FileMode.Create)) {
                            file.Write(DecryptVersion1File(encryptedFileData, key), 0, fileSize);
                            bytesExtracted += fileSize;
                            filesExtracted++;
                        }
                    }
                }
                catch (EndOfStreamException) {
                    //End of stream reached prematurely 
                    invalidArchive = true;
                }

                if (invalidArchive) {
                    throw new ArgumentException(path + " is not a valid RPG Maker archive.");
                }
                return filesExtracted;
            }
        }

        private static int DecryptVersion1Int(int value, ref uint key) {
            int result = (int)(value ^ key);

            key *= 7;
            key += 3;
            return result;
        }

        private static string DecryptVersion1Name(byte[] name, ref uint key) {
	        byte[] decryptedName = new byte[name.Length];

	        for (int i = 0; i < name.Length; i++) {
		        decryptedName[i] = (byte)(name[i] ^ (key & 0xff));

		        key *= 7;
		        key += 3;
	        }
	        return Encoding.UTF8.GetString(decryptedName);
        }

        private static byte[] DecryptVersion1File(byte[] fileData, uint key) {
            byte[] decryptedFileData = new byte[fileData.Length];
            byte[] keyBytes = BitConverter.GetBytes(key);

            for (int i = 0, j = 0; i < fileData.Length; i++, j++) {
                if (j == 4) {
                    j = 0;
                    key *= 7;
                    key += 3;
                    //keyBytes = BitConverter.GetBytes(key);

                    //Does the above operation a lot faster
                    if (BitConverter.IsLittleEndian) {
                        keyBytes[3] = (byte)(key >> 24);
                        keyBytes[2] = (byte)(key >> 16);
                        keyBytes[1] = (byte)(key >> 8);
                        keyBytes[0] = (byte)key;
                    }
                    else {
                        keyBytes[0] = (byte)(key >> 24);
                        keyBytes[1] = (byte)(key >> 16);
                        keyBytes[2] = (byte)(key >> 8);
                        keyBytes[3] = (byte)key;
                    }
                }
                decryptedFileData[i] = (byte)(fileData[i] ^ keyBytes[j]);
            }
            return decryptedFileData;
        }
        #endregion

        #region Version 3 decrypter
        /// <summary>
        /// Extracts the version 3 archive file stream to the specified destination folder.
        /// </summary>
        private int DecryptVersion3Archive(string destination) {
            using (var reader = new BinaryReader(new FileStream(path, FileMode.Open))) {
                int filesExtracted = 0;
                long bytesExtracted = 0;
                long archiveLength = reader.BaseStream.Length;
                bool invalidArchive = false;
                uint key;

                //Seek past the header
                reader.BaseStream.Seek(8, SeekOrigin.Begin);

                try {
                    //Read the key
                    key = reader.ReadUInt32() * 9 + 3;

                    //Decrypt the archive
                    while (reader.BaseStream.Position < archiveLength && !cancellationToken.IsCancellationRequested) {
                        int fileOffset = DecryptVersion3Int(reader.ReadInt32(), ref key);
                        int fileSize = DecryptVersion3Int(reader.ReadInt32(), ref key);
                        int fileKey = DecryptVersion3Int(reader.ReadInt32(), ref key);
                        int fileNameLength = DecryptVersion3Int(reader.ReadInt32(), ref key);

                        //A file offset of 0 marks the end of the file
                        if (fileOffset == 0) {
                            break;
                        }
                        byte[] encryptedFileName = reader.ReadBytes(fileNameLength);

                        if (encryptedFileName.Length != fileNameLength) {
                            //Inconsistent archive. Probably corrupt 
                            invalidArchive = true;
                            break;
                        }

                        string fileName = DecryptVersion3Name(encryptedFileName, ref key);
                        string filePath = Path.Combine(destination, fileName);
                        string directoryName = Path.GetDirectoryName(filePath);

                        if (reportProgress != null) {
                            reportProgress(fileName, bytesExtracted);
                        }

                        //Create a new folder for the file if needed
                        if (!Directory.Exists(directoryName)) {
                            Directory.CreateDirectory(directoryName);
                        }

                        //Seek to the encrypted file data and read it
                        long currentOffset = reader.BaseStream.Position;
                        reader.BaseStream.Position = fileOffset;
                        byte[] encryptedFileData = reader.ReadBytes(fileSize);

                        if (encryptedFileData.Length != fileSize) {
                            //Inconsistent archive. Probably corrupt 
                            invalidArchive = true;
                            break;
                        }

                        //Seek back to the file index
                        reader.BaseStream.Seek(currentOffset, SeekOrigin.Begin);

                        //Write the decrypted file data to disc
                        using (FileStream file = new FileStream(filePath, FileMode.Create)) {
                            file.Write(DecryptVersion3File(encryptedFileData, (uint)fileKey), 0, fileSize);
                            bytesExtracted += fileSize;
                            filesExtracted++;
                        }
                    }
                }
                catch (EndOfStreamException) {
                    invalidArchive = true;
                }

                if (invalidArchive) {
                    throw new ArgumentException(path + " is not a valid RPG Maker archive.");
                }
                return filesExtracted;
            }
        }

        private static int DecryptVersion3Int(int value, ref uint key) {
            return (int)(value ^ key);
        }

        private static string DecryptVersion3Name(byte[] name, ref uint key) {
            byte[] decryptedName = new byte[name.Length];
            byte[] keyBytes = BitConverter.GetBytes(key);

            for (int i = 0; i < name.Length; i++) {
                decryptedName[i] = (byte)(name[i] ^ keyBytes[i % 4]);
            }
            return Encoding.UTF8.GetString(decryptedName);
        }

        private static byte[] DecryptVersion3File(byte[] file, uint key) {
            return DecryptVersion1File(file, key);
        }
        #endregion
    }
}
