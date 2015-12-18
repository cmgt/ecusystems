using System.IO;
using System.Windows.Forms;
using SokolovSport.Dat;
using SokolovSport.EcuComm;
using SokolovSport.Logs;
using SokolovSport.Options;

namespace SokolovSport
{
    class Dispatcher
    {
        private readonly OpenFileDialog openFileDialog;
        public EcuCommunication Ecu { get; private set; }
        public DatFile DatFile { get; private set; }
        private CalibrLogger calibrLogger;

        public Dispatcher()
        {
            Ecu = new EcuCommunication(OptionsHelper.Options);
            openFileDialog = new OpenFileDialog();
        }

        public void OpenDatFileDialog(IWin32Window owner)
        {
            openFileDialog.InitialDirectory = Application.StartupPath;

            while (true)
            {
                if (openFileDialog.ShowDialog(owner) != DialogResult.OK || OpenDatFile(openFileDialog.FileName)) return;
                
                MessageBox.Show(owner, "Dat файл не существует или доступен только для чтения. Загрузка невозможна");
            }
        }

        public bool OpenDatFile(string path)
        {
            if (!DatHelper.TestFile(path)) 
                return false;


            DatFile = new DatFile(path);

            if (calibrLogger != null)
                calibrLogger.Close();

            calibrLogger = new CalibrLogger(DatFile, Ecu);

            return true;
        }
    }
}
