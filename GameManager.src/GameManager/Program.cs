using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameManager {
    static class Program {
        [STAThread]
        static void Main() {
            //Log all unhandled exceptions to file
            AppDomain.CurrentDomain.UnhandledException += (sender, e) => {
                Logger.LogException(e.ExceptionObject as Exception);
            };

            //Prevent unobserved exceptions in tasks from terminating the program
            TaskScheduler.UnobservedTaskException += (sender, e) => {
                e.SetObserved();
                Logger.LogExceptionIfDebugging(e.Exception);
            };

            //Speed up web requests by allowing more HTTP requests to be open simultaneously
            ServicePointManager.DefaultConnectionLimit = 100;

            //Avoid making an extra roundtrip to the server per request
            ServicePointManager.Expect100Continue = false;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.AddMessageFilter(new MouseWheelRedirector());
            Application.Run(new MainForm());
        }
    }
}
