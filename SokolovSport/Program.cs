using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using SokolovSport.Options;

namespace SokolovSport
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SMSIntro.Launcer.Show();
            var mainForm = new MainForm();
            if (args.Length > 0)
            {
                var source = args[0];
                var path = Path.IsPathRooted(source)
                               ? args[0]
                               : String.Format("{0}\\{1}", Application.StartupPath, Path.GetFileName(source));
                mainForm.OpenDatFile(path);
            }
            else if (OptionsHelper.Options.LoadLastDatFile && OptionsHelper.Options.OpenedDatFile.Count > 0)
            {
                mainForm.OpenDatFile(OptionsHelper.Options.OpenedDatFile[0]);
            }
            Thread.Sleep(1000);
            SMSIntro.Launcer.Close();

            Application.Run(mainForm);
        }
    }
}
