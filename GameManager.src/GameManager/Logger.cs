using System;
using System.Diagnostics;
using System.IO;

namespace GameManager {
    public static class Logger {
        public static bool LoggingEnabled { set; get; }
        private static string logPath;

        static Logger() {
            logPath = Path.Combine(Settings.ProgramDirectoryPath, Settings.RelativeLogPath);
            LoggingEnabled = true;
        }

        public static void LogException(Exception e) {
            if (LoggingEnabled && e != null) {
                string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string exceptionText = e.ToString();

                File.AppendAllText(logPath, String.Format("[{0}] GameManager {1}, .NET {2}, Windows {3} {5}{4}{5}{5}", 
                                                          timeStamp, Settings.ProgramVersion,
                                                          Environment.Version.ToString(), Environment.OSVersion.Version.ToString(),
                                                          exceptionText, Environment.NewLine));

                Debug.WriteLine("An exception of type '" + e.GetType().ToString() + "' logged to file");
            }
        }

        [Conditional("DEBUG")]
        public static void LogExceptionIfDebugging(Exception e) {
            LogException(e);
        }
    }
}
