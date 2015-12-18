using System;
using System.Threading;
using System.Windows;
using EcuCommunication;
using Application = System.Windows.Forms.Application;

namespace OpenOLT
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

#if !DEBUG
            var splashScreen = new SplashScreen("Resources/Intro.png");
            splashScreen.Show(false);         
            //var intro = new IntroWindow();
            ////ElementHost.EnableModelessKeyboardInterop(intro);
            //intro.Show();
            Thread.Sleep(500);
#endif

            var startupPath = Application.StartupPath;
            var errorsPath = startupPath + "\\errors.txt";
            var errorStatus = startupPath + "\\error_status.txt";
            ECUErrorFactory.Init(errorsPath, errorStatus);
            var appHost = new MainForm();
            PluginManager.Load(startupPath, appHost);

#if !DEBUG
            splashScreen.Close(TimeSpan.FromSeconds(1));
#endif
            
            Application.Run(appHost);
        }
    }
}
