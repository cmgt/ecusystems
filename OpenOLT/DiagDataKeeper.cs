using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EcuCommunication.Protocols;
using Helper;
using OpenOLT.DataValueInfo;
using OpenOLT.GUI;

namespace OpenOLT
{
    class DiagDataKeeper
    {
        internal readonly BindingList<DiagData> diagDataList;
        internal ValueInfo[] valueInfos;
        internal readonly List<ChartSet> chartSets = new List<ChartSet>(); 

        public DiagDataKeeper()
        {        
            diagDataList = new BindingList<DiagData>();

            InitValueInfos();
        }

        private void InitValueInfos()
        {
            var propInfos =
                typeof (DiagData).GetProperties().Where(
                    info => Attribute.GetCustomAttribute(info, typeof (BrowsableAttribute)) == null
                            ||
                            ((BrowsableAttribute) Attribute.GetCustomAttribute(info, typeof (BrowsableAttribute))).Browsable);   
      
            valueInfos = new ValueInfo[propInfos.Count()];
            var index = 0;
            foreach (var info in propInfos)
            {
                valueInfos[index] = new ValueInfo(info);
                index++;
            }
        }

        public ValueInfo[] OpenCharts()
        {
            var charts = new ValueInfo[0];

            try
            {
                using (var openChartsForm = new OpenCharts())
                {
                    openChartsForm.Init(this);
                    if (openChartsForm.ShowDialog() != DialogResult.OK) return charts;
                    charts = openChartsForm.GetSelectedCharts();
                    return charts;
                }
            }
            finally
            {
                SaveSettings(Settings.settingsKeeper);
            }
        }
       
        public void LoadFromFile(string fileName)
        {
            if (!File.Exists(fileName)) return;
            diagDataList.RaiseListChangedEvents = false;

            try
            {
                Clear();

                using (var logReader = new StreamReader(fileName))
                {
                    var header = logReader.ReadLine();                    
                    var protocolHeader = DiagProtocolHelper.GetLogHeader();
                    
                    if (String.IsNullOrWhiteSpace(header) || header != protocolHeader)
                    {
                        MessageBox.Show("Неизвестный формат лог файла");
                        return;
                    }                                       

                    while (!logReader.EndOfStream)
                    {
                        var line = logReader.ReadLine();
                        if (String.IsNullOrWhiteSpace(line)) continue;

                        try
                        {                            
                            var dataItem = new DiagData();
                            dataItem.Load(line);

                            diagDataList.Add(dataItem);
                        }
                        catch {}
                    }
                }
            }
            finally
            {
                diagDataList.RaiseListChangedEvents = true;
                diagDataList.ResetBindings();
            }
        }

        private void Clear()
        {
            diagDataList.Clear();
        }

        public void SaveSettings(LocalSettingsKeeper settingsKeeper)
        {
            var chartSetsCount = chartSets.Count;
            settingsKeeper.SetValue("ChartSetsCount", chartSetsCount);

            for (int i = 0; i < chartSetsCount; i++)
            {
                var name = chartSets[i].Name;
                settingsKeeper.SetValue("ChartSet" + i, name);
                var value = String.Join(";", chartSets[i].Items.Select(item => item.Name));
                settingsKeeper.SetValue("ChartSetValue" + i, value);
            }

            settingsKeeper.SaveSettings();
        }

        public void LoadSettings(LocalSettingsKeeper settingsKeeper)
        {
            var chartSetsCount = settingsKeeper.GetValue("ChartSetsCount", 0);
            
            for (int i = 0; i < chartSetsCount; i++)
            {
                var name = settingsKeeper.GetValue("ChartSet" + i, String.Empty);
                var value = settingsKeeper.GetValue("ChartSetValue" + i, String.Empty);

                var chartSet = new ChartSet {Name = name};
                chartSet.Items.AddRange(
                    value.Split(';').Select(item => valueInfos.FirstOrDefault(info => info.Name == item)).Where(
                        v => v != null));

                chartSets.Add(chartSet);
            }
        }
    }
}
