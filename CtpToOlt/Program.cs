using System;
using System.Windows.Forms;
using CtpMaps;

namespace CtpToOlt
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("ctp map to online tuner file converter. ecusystems.ru");            

            using (var openFile = new OpenFileDialog())
            using (var saveFile = new SaveFileDialog())
            {
                openFile.InitialDirectory = saveFile.InitialDirectory = Application.StartupPath;
                openFile.Filter = saveFile.Filter = "Map files|*.j5;*.j7|All files|*.*";

                openFile.Title = "Укажите карту ChipTunerPro 3.21 для преобразования";
                saveFile.Title = "Укажите имя файла для сохранения карты OnlineTuner";

                if (openFile.ShowDialog() != DialogResult.OK) return;
                if (saveFile.ShowDialog() != DialogResult.OK) return;

                var ctpMap = new CtpMap();
                ctpMap.LoadFromFile(openFile.FileName);

                ctpMap.SaveToFile(saveFile.FileName, true);
            }
        }
    }
}
