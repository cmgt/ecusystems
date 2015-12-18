using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using Nini.Ini;

namespace map2xdf
{
    class Program
    {        
        private static int level = 1;
        private static readonly List<string> categories = new List<string>();
        private static string inFile;
        private static string outFile;
        private static int categoriesId;
        private static readonly Dictionary<string, List<string>> refer = new Dictionary<string, List<string>>();

        static void Main(string[] args)
        {
            Console.WriteLine("\r\n\r\ntuner pro xdf file constructor. cm_gt Inc.\r\n");
            
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: map2xdf.exe map_file [xdf_file]\r\n\tExample: map2xdf.exe j5v07g26.ini j5v07g26.xdf");
                return;
            }

            inFile = args[0];
            var appDir = Environment.CurrentDirectory;
            //Console.WriteLine(appDir);
            var inFilePath = String.Empty;

            inFilePath = Path.IsPathRooted(inFile) ? inFile : String.Format("{0}\\{1}", appDir, inFile);
            //Console.WriteLine(inFilePath);

            if (!File.Exists(inFilePath))
            {
                Console.WriteLine(String.Format("map file {0} not found", inFilePath));
                return;
            }

            outFile = args.Length > 1 ? args[1] : String.Format("{0}.xdf", Path.GetFileNameWithoutExtension(inFile));
            var outFilePath = String.Format("{0}\\{1}", appDir, outFile);
            var xmlSettings = new XmlWriterSettings { Encoding = Encoding.GetEncoding(1251), ConformanceLevel = ConformanceLevel.Fragment, Indent = true, };
            using (var xdfFile = XmlWriter.Create(outFilePath, xmlSettings))
            {
                BeginXdf(xdfFile);
                categories.Add("Оси");
                categoriesId = categories.Count - 1;
                WriteAxis(xdfFile);
                ParseIniMap(inFilePath, xdfFile);

                WriteHeader(xdfFile);
                EndXdf(xdfFile);

                xdfFile.Flush();
                xdfFile.Close();
                
                Console.WriteLine("\r\n\r\nxdf map file create successfully. Press any key to continue ...");
            }

            //Console.WriteLine("\r\n\r\n");
            //foreach (var keyValue in refer)
            //{
            //    Console.Write("\r\n{0}: ", keyValue.Key);
            //    foreach (var value in keyValue.Value)
            //    {
            //        Console.Write("{0}, ", value);
            //    }
            //}

            //Console.ReadKey(false);
        }

        private static void ParseIniMap(string inFilePath, XmlWriter xdfFile)
        {
            var mapData = new IniDocument(new StreamReader(inFilePath, Encoding.GetEncoding(1251)), IniFileType.WindowsStyle);
            
            foreach (DictionaryEntry entry in mapData.Sections)
            {
                var section = (IniSection) entry.Value;
                try
                {
                    WriteSection(xdfFile, section);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error parse section: {0}. {1}", section.Name, e.Message);
                }
                
                Console.CursorLeft = 0;
                Console.Write(String.Format("#{0}", section.Name));
            }            
        }

        private static void WriteSection(XmlWriter xdfFile, IniSection sectionData)
        {
            var sectionType = sectionData.GetValue("Type");
            var l = Convert.ToInt32(sectionData.GetValue("Level"));
            var name = sectionData.GetValue("Name");
            if (l == 1 && !categories.Contains(name))
            {
                categories.Add(name);
                categoriesId = categories.IndexOf(name);
            }

            switch (sectionType)
            {
                case "BIT":
                    WriteSectionBit(xdfFile, sectionData);
                    break;

                case "3D":
                    Write3DTable(xdfFile, sectionData);
                    break;

                case "2D":
                    Write2DTable(xdfFile, sectionData);
                    break;

                case "1D":
                    Write1DTable(xdfFile, sectionData);
                    break;
            }
            xdfFile.WriteString(Environment.NewLine);
        }

        private static void Write3DTable(XmlWriter xdfFile, IniSection sectionData)
        {
            string elemFlag;
            string elemSize;
            GetElemParams(sectionData, out elemFlag, out elemSize);

            WriteTableBegin(sectionData, xdfFile);

            #region X axis
            WriteXAxis(sectionData, xdfFile);
            #endregion

            #region Y axis
            WriteYAxis(sectionData, xdfFile);
            #endregion

            #region Z axis
            WriteZAxis(sectionData, xdfFile, elemFlag, elemSize);
            #endregion

            WriteTableEnd(xdfFile);
        }

        static void Write2DTable(XmlWriter xdfFile, IniSection sectionData)
        {
            if (sectionData.GetValue("Name").Contains("Тарировка ДМРВ"))
            {
                WriteTarirovkaDMRV(sectionData, xdfFile);
                return;
            }
            
            string elemFlag;
            string elemSize;
            GetElemParams(sectionData, out elemFlag, out elemSize);            

            WriteTableBegin(sectionData, xdfFile);

            #region X axis
            WriteXAxis(sectionData, xdfFile);
            #endregion

            #region Y axis
            xdfFile.WriteStartElement("XDFAXIS");
            xdfFile.WriteAttributeString("id", "y");
            xdfFile.WriteElementString("units", sectionData.GetValue("NameT"));
            xdfFile.WriteElementString("indexcount", "1");
            xdfFile.WriteElementString("outputtype", "4");
            xdfFile.WriteElementString("datatype", "0");
            xdfFile.WriteElementString("unittype", "0");

            xdfFile.WriteStartElement("LABEL");
            xdfFile.WriteAttributeString("index", "0");
            xdfFile.WriteAttributeString("value", " ");
            xdfFile.WriteEndElement();
            xdfFile.WriteEndElement();
            #endregion

            #region Z axis
            WriteZAxis(sectionData, xdfFile, elemFlag, elemSize);
            #endregion

            WriteTableEnd(xdfFile);
        }

        private static void WriteTarirovkaDMRV(IniSection sectionData, XmlWriter xdfFile)
        {
            //A358 младший байт тарировки
            //A458 старший байт тарировки

            #region Lo            
            WriteTableBegin(sectionData, xdfFile);

            xdfFile.WriteElementString("title", "Тарировка ДМРВ (lo)");

            xdfFile.WriteStartElement("XDFAXIS");
            xdfFile.WriteAttributeString("id", "x");
            xdfFile.WriteElementString("units", sectionData.GetValue("NameX"));
            xdfFile.WriteElementString("outputtype", "4");
            xdfFile.WriteElementString("datatype", "0");
            xdfFile.WriteElementString("unittype", "0");

            int count = Convert.ToInt32(sectionData.GetValue("PixelX"));
            xdfFile.WriteElementString("indexcount", count.ToString());
            
            double firstX = 0;            
            var delta = 1f;

            WriteAxisLabels(xdfFile, count, firstX, delta);

            xdfFile.WriteEndElement();

            #region Y axis
            xdfFile.WriteStartElement("XDFAXIS");
            xdfFile.WriteAttributeString("id", "y");
            xdfFile.WriteElementString("units", sectionData.GetValue("NameT"));
            xdfFile.WriteElementString("indexcount", "1");
            xdfFile.WriteElementString("outputtype", "4");
            xdfFile.WriteElementString("datatype", "0");
            xdfFile.WriteElementString("unittype", "0");

            xdfFile.WriteStartElement("LABEL");
            xdfFile.WriteAttributeString("index", "0");
            xdfFile.WriteAttributeString("value", " ");
            xdfFile.WriteEndElement();
            xdfFile.WriteEndElement();
            #endregion
            
            xdfFile.WriteStartElement("XDFAXIS");
            xdfFile.WriteAttributeString("id", "z");

            xdfFile.WriteStartElement("EMBEDDEDDATA");
            xdfFile.WriteAttributeString("mmedtypeflags", "0x00");
            xdfFile.WriteAttributeString("mmedelementsizebits", "8");
            xdfFile.WriteAttributeString("mmedaddress", "0xA358");
            xdfFile.WriteEndElement();

            xdfFile.WriteElementString("decimalpl", "2");
            xdfFile.WriteElementString("outputtype", "1");

            xdfFile.WriteStartElement("MATH");
            xdfFile.WriteAttributeString("equation", "x");
            xdfFile.WriteStartElement("VAR");
            xdfFile.WriteAttributeString("id", "x");
            xdfFile.WriteEndElement();
            xdfFile.WriteEndElement();

            xdfFile.WriteEndElement();

            WriteTableEnd(xdfFile);
            #endregion

            #region hi

            WriteTableBegin(sectionData, xdfFile);
            xdfFile.WriteElementString("title", "Тарировка ДМРВ (hi)");

            xdfFile.WriteStartElement("XDFAXIS");
            xdfFile.WriteAttributeString("id", "x");
            xdfFile.WriteElementString("units", sectionData.GetValue("NameX"));
            xdfFile.WriteElementString("outputtype", "4");
            xdfFile.WriteElementString("datatype", "0");
            xdfFile.WriteElementString("unittype", "0");

            count = Convert.ToInt32(sectionData.GetValue("PixelX"));
            xdfFile.WriteElementString("indexcount", count.ToString());

            firstX = 0;
            delta = 1f;

            WriteAxisLabels(xdfFile, count, firstX, delta);

            xdfFile.WriteEndElement();

            #region Y axis
            xdfFile.WriteStartElement("XDFAXIS");
            xdfFile.WriteAttributeString("id", "y");
            xdfFile.WriteElementString("units", sectionData.GetValue("NameT"));
            xdfFile.WriteElementString("indexcount", "1");
            xdfFile.WriteElementString("outputtype", "4");
            xdfFile.WriteElementString("datatype", "0");
            xdfFile.WriteElementString("unittype", "0");

            xdfFile.WriteStartElement("LABEL");
            xdfFile.WriteAttributeString("index", "0");
            xdfFile.WriteAttributeString("value", " ");
            xdfFile.WriteEndElement();
            xdfFile.WriteEndElement();
            #endregion

            xdfFile.WriteStartElement("XDFAXIS");
            xdfFile.WriteAttributeString("id", "z");

            xdfFile.WriteStartElement("EMBEDDEDDATA");
            xdfFile.WriteAttributeString("mmedtypeflags", "0x00");
            xdfFile.WriteAttributeString("mmedelementsizebits", "8");
            xdfFile.WriteAttributeString("mmedaddress", "0xA458");
            xdfFile.WriteEndElement();

            xdfFile.WriteElementString("decimalpl", "2");
            xdfFile.WriteElementString("outputtype", "1");

            xdfFile.WriteStartElement("MATH");
            xdfFile.WriteAttributeString("equation", "x");
            xdfFile.WriteStartElement("VAR");
            xdfFile.WriteAttributeString("id", "x");
            xdfFile.WriteEndElement();
            xdfFile.WriteEndElement();

            xdfFile.WriteEndElement();

            WriteTableEnd(xdfFile);
            #endregion
        }

        private static void WriteYAxis(IniSection sectionData, XmlWriter xdfFile)
        {
            xdfFile.WriteStartElement("XDFAXIS");
            xdfFile.WriteAttributeString("id", "y");
            xdfFile.WriteElementString("units", sectionData.GetValue("NameY"));
            xdfFile.WriteElementString("outputtype", "4");
            xdfFile.WriteElementString("datatype", "0");
            xdfFile.WriteElementString("unittype", "0");

            int count = Convert.ToInt32(sectionData.GetValue("PixelY"));
            xdfFile.WriteElementString("indexcount", count.ToString());

            if (sectionData.Contains("ReferY"))
            {
                WriteReferAxis(xdfFile, sectionData, count, ReadStr(sectionData, "ReferY", String.Empty));
            }
            else
            {
                double firstX = ReadDouble(sectionData, "FirstY", 0);
                double lastX = ReadDouble(sectionData, "LastY", 255);
                int delta = (int)Math.Ceiling((lastX - firstX) / count);

                WriteAxisLabels(xdfFile, count, firstX, delta);
            }

            xdfFile.WriteEndElement();
        }

        private static void WriteXAxis(IniSection sectionData, XmlWriter xdfFile)
        {
            xdfFile.WriteStartElement("XDFAXIS");
            xdfFile.WriteAttributeString("id", "x");
            xdfFile.WriteElementString("units", sectionData.GetValue("NameX"));
            xdfFile.WriteElementString("outputtype", "4");
            xdfFile.WriteElementString("datatype", "0");
            xdfFile.WriteElementString("unittype", "0");

            int count = Convert.ToInt32(sectionData.GetValue("PixelX"));
            xdfFile.WriteElementString("indexcount", count.ToString());

            if (sectionData.Contains("ReferX"))
            {
                WriteReferAxis(xdfFile, sectionData, count, ReadStr(sectionData, "ReferX", String.Empty));
            }
            else
            {                                               
                double firstX = ReadDouble(sectionData, "FirstX", 0);
                double lastX = ReadDouble(sectionData, "LastX", 255);
                var delta = Math.Round((lastX - firstX) / count, 3, MidpointRounding.AwayFromZero);

                WriteAxisLabels(xdfFile, count, firstX, (float) delta);
            }
                        
            xdfFile.WriteEndElement();
        }

        private static void WriteReferAxis(XmlWriter xdfFile, IniSection sectionData, int count, string refX)
        {            
            if (!refer.ContainsKey(refX))
                refer.Add(refX, new List<string>());
            refer[refX].Add(sectionData.GetValue("Name"));

            short[] labels;
            switch (refX)
            {
                case "!006-7208":
                    labels = new short[] { 0, 2, 4, 6, 8, 10, 14, 18, 23, 29, 37, 46, 56, 66, 80, 100 };
                    WriteAxisLabels(xdfFile, labels);                        
                    break;

                case "!003-6064-6066":
                    xdfFile.WriteRaw("<embedinfo type=\"2\" linkobjid=\"0x6064\" />");
                    break;

                case "!004-6064-6066":
                    xdfFile.WriteRaw("<embedinfo type=\"2\" linkobjid=\"0x6164\" />");
                    break;

                case "!012-6064-6066":
                    xdfFile.WriteRaw("<embedinfo type=\"2\" linkobjid=\"0x6264\" />");
                    break;

                case "!005-5F84":
                    WriteAxisLabels(xdfFile, count, 0, 32);
                    break;

                case "!001-613C-30":
                    labels = new short[]
                                 {
                                     600, 660, 720, 780, 840, 930, 990, 1080, 1170, 1290, 1380, 1530, 1650, 1800,
                                     1950, 2130, 2310, 2520, 2730, 2970, 3210, 3540, 3840, 4200, 4530, 4950, 5370,
                                     5850, 6360, 6930, 7650, 0
                                 };
                    WriteAxisLabels(xdfFile, labels);
                    break;

                case "!002-613C-30":
                    labels = new short[]
                                 {
                                     600, 720, 840, 990, 1170, 1380, 1650, 1950, 2310, 2730, 3210, 3840, 4530, 5370, 6360,
                                     7650
                                 };
                    WriteAxisLabels(xdfFile, labels);
                    break;                

                default:
#if DEBUG
                    //throw new NotSupportedException();
#endif
                    break;
            }
        }

        private static void WriteTableEnd(XmlWriter xdfFile)
        {
            xdfFile.WriteEndElement();
        }

        private static void GetElemParams(IniSection sectionData, out string elemFlag, out string elemSize)
        {
            elemFlag = elemSize = String.Empty;
            var format = ReadStr(sectionData, "Format", String.Empty);
            if (format.Length == 10)
                format = format.Substring(8, 2);

            switch (format)
            {
                case "00":
                case "0":
                    elemSize = "8";
                    elemFlag = "0x00";
                    break;

                case "01":
                case "1":
                    elemSize = "8";
                    elemFlag = "0x01";
                    break;

                case "02":
                case "2":
                    elemSize = "16";
                    elemFlag = "0x02";
                    break;

                case "03":
                case "3":
                    elemSize = "16";
                    elemFlag = "0x03";
                    break;

                case "06":
                    //elemSize = "16";
                    //elemFlag = "0x02";
                    //break;
                    break;

                default:
#if DEBUG
                    throw new NotImplementedException();
#endif                    
                    break;
            }
        }

        private static void WriteTableBegin(IniSection sectionData, XmlWriter xdfFile)
        {
            xdfFile.WriteStartElement("XDFTABLE");
            var flags = 0 | (sectionData.Contains("Lim1") ? 0x10 : 0) | (sectionData.Contains("Lim2") ? 0x20 : 0);
            xdfFile.WriteAttributeString("flags", flags.ToString("X2"));
            xdfFile.WriteElementString("title", sectionData.GetValue("Name").Replace("\"", String.Empty));
            WriteCurrentCategory(xdfFile);
        }

        private static void WriteZAxis(IniSection sectionData, XmlWriter xdfFile, string elemFlag, string elemSize)
        {
            xdfFile.WriteStartElement("XDFAXIS");
            xdfFile.WriteAttributeString("id", "z");

            xdfFile.WriteStartElement("EMBEDDEDDATA");
            xdfFile.WriteAttributeString("mmedtypeflags", elemFlag);
            xdfFile.WriteAttributeString("mmedelementsizebits", elemSize);
            xdfFile.WriteAttributeString("mmedaddress", sectionData.GetValue("Addr"));
            xdfFile.WriteEndElement();
            
            if (sectionData.Contains("Lim1"))
                xdfFile.WriteElementString("min", sectionData.GetValue("Lim1").Replace("\"", ""));

            if (sectionData.Contains("Lim2"))
                xdfFile.WriteElementString("max", sectionData.GetValue("Lim2").Replace("\"", ""));

            xdfFile.WriteElementString("decimalpl", "2");
            xdfFile.WriteElementString("outputtype", "1");

            WriteValueEquation(sectionData, xdfFile);

            xdfFile.WriteEndElement();
        }

        static void WriteAxisLabels(XmlWriter xdfFile, int count, double firstX, float delta)
        {
            for (int i = 0; i < count; i++)
            {
                xdfFile.WriteStartElement("LABEL");
                xdfFile.WriteAttributeString("index", i.ToString());
                xdfFile.WriteAttributeString("value", (firstX + i * delta).ToString("0.###", CultureInfo.InvariantCulture));
                xdfFile.WriteEndElement();
            }
        }

        static void WriteAxisLabels(XmlWriter xdfFile, short[] labels)
        {
            for (int i = 0; i < labels.Length; i++)
            {
                xdfFile.WriteStartElement("LABEL");
                xdfFile.WriteAttributeString("index", i.ToString());
                xdfFile.WriteAttributeString("value", labels[i].ToString(CultureInfo.InvariantCulture));
                xdfFile.WriteEndElement();
            }
        }

        static void WriteValueEquation(IniSection sectionData, XmlWriter xdfFile)
        {
            var mul = ReadDouble(sectionData, "F_MulMul", 1);
            var div = ReadDouble(sectionData, "F_DivDiv", 1);
            var sub1 = ReadDouble(sectionData, "F_Sub1st", 0);
            var sub2 = ReadDouble(sectionData, "F_Sub2nd", 0);
            var mask = ReadStr(sectionData, "MaskX", "0xFFFF");
            var bc = new BitArray(new [] {Convert.ToInt32(mask, 16)});
            var shift = 0;
            for (int i = 0; i < bc.Count; i++)
            {
                if (bc[i]) break;
                shift++;
            }
                     
            xdfFile.WriteStartElement("MATH");
            xdfFile.WriteAttributeString("equation",
                                         String.Format("((x & {4}) >> {5} - {2}) * {0} / {1} - {3}",
                                                       mul.ToString(CultureInfo.InvariantCulture),
                                                       div.ToString(CultureInfo.InvariantCulture),
                                                       sub1.ToString(CultureInfo.InvariantCulture),
                                                       sub2.ToString(CultureInfo.InvariantCulture),
                                                       mask, shift));
            xdfFile.WriteStartElement("VAR");
            xdfFile.WriteAttributeString("id", "x");
            xdfFile.WriteEndElement();
            xdfFile.WriteEndElement();
        }

        static void Write1DTable(XmlWriter xdfFile, IniSection sectionData)
        {
            string elemFlag;
            string elemSize;
            GetElemParams(sectionData, out elemFlag, out elemSize);             

            xdfFile.WriteStartElement("XDFCONSTANT");            
            xdfFile.WriteAttributeString("flags", "0x30");
            xdfFile.WriteElementString("title", sectionData.GetValue("Name"));
            WriteCurrentCategory(xdfFile);            
                      
            xdfFile.WriteStartElement("EMBEDDEDDATA");
            xdfFile.WriteAttributeString("mmedtypeflags", elemFlag);
            xdfFile.WriteAttributeString("mmedelementsizebits", elemSize);
            xdfFile.WriteAttributeString("mmedaddress", sectionData.GetValue("Addr"));
            xdfFile.WriteEndElement();

            xdfFile.WriteElementString("units", sectionData.GetValue("Unit"));
            xdfFile.WriteElementString("outputtype", "1");
            xdfFile.WriteElementString("datatype", "0");
            xdfFile.WriteElementString("decimalpl", "2");

            WriteValueEquation(sectionData, xdfFile);

            xdfFile.WriteEndElement();
        }

        static void WriteSectionBit(XmlWriter xdfFile, IniSection sectionData)
        {            
            for (int i = 0; i < 8; i++)
            {
                var addrName = String.Format("Addr{0}", i);
                if (!sectionData.Contains(addrName)) continue;
                var addr = sectionData.GetValue(addrName);
                for (int j = 0; j < 8; j++)
                {
                    var bitName = String.Format("Bit{0}{1}", i, j);
                    if (!sectionData.Contains(bitName)) continue;
                    var bit = sectionData.GetValue(bitName);

                    xdfFile.WriteStartElement("XDFFLAG");
                    //xdfFile.WriteAttributeString("uniqueid", addr);
                    xdfFile.WriteElementString("title", bit);

                    WriteCurrentCategory(xdfFile);

                    xdfFile.WriteStartElement("EMBEDDEDDATA");
                    xdfFile.WriteAttributeString("mmedaddress", addr);
                    xdfFile.WriteAttributeString("mmedelementsizebits", "8");
                    xdfFile.WriteEndElement();

                    xdfFile.WriteElementString("mask", ((int)Math.Pow(2, j)).ToString("X2"));

                    xdfFile.WriteEndElement();
                }
            }            
        }

        static void WriteCurrentCategory(XmlWriter xdfFile)
        {
            xdfFile.WriteStartElement("CATEGORYMEM");
            xdfFile.WriteAttributeString("index", "0x0");
            xdfFile.WriteAttributeString("category", (categoriesId + 1).ToString());
            xdfFile.WriteEndElement();
        }

        static void BeginXdf(XmlWriter xdfFile)
        {
            xdfFile.WriteComment(String.Format("Written {0} {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString()));
            xdfFile.WriteStartElement("XDFFORMAT");
            xdfFile.WriteAttributeString("version", "1.50");
        }

        static void EndXdf(XmlWriter xdfFile)
        {
            xdfFile.WriteEndElement();
        }

        static void WriteHeader(XmlWriter xdfFile)
        {
            xdfFile.WriteStartElement("XDFHEADER");
            xdfFile.WriteElementString("flags", "0x1");
            xdfFile.WriteElementString("fileversion", "02.01h");
            xdfFile.WriteElementString("deftitle", inFile);
            xdfFile.WriteElementString("author", "cm_gt");
            xdfFile.WriteElementString("baseoffset", "0");

            xdfFile.WriteStartElement("DEFAULTS");
            xdfFile.WriteAttributeString("datasizeinbits", "8");
            xdfFile.WriteAttributeString("sigdigits", "2");
            xdfFile.WriteAttributeString("outputtype", "1");
            xdfFile.WriteAttributeString("signed", "0");
            xdfFile.WriteAttributeString("lsbfirst", "0");
            xdfFile.WriteAttributeString("float", "0");
            xdfFile.WriteEndElement();

            xdfFile.WriteStartElement("REGION");
            xdfFile.WriteAttributeString("type", "0xFFFFFFFF");
            xdfFile.WriteAttributeString("startaddress", "0");
            xdfFile.WriteAttributeString("size", "0xFFFF");
            xdfFile.WriteAttributeString("regionflags", "0x0");
            xdfFile.WriteAttributeString("name", "Binary File");
            xdfFile.WriteAttributeString("desc", "This region describes the bin file edited by this XDF");
            xdfFile.WriteEndElement();
            xdfFile.WriteString(Environment.NewLine);

            for (int i = 0; i < categories.Count; i++)
            {
                xdfFile.WriteStartElement("CATEGORY");
                xdfFile.WriteAttributeString("index", String.Format("0x{0}",i.ToString("X2")));
                xdfFile.WriteAttributeString("name", categories[i].Replace("\"", String.Empty));
                xdfFile.WriteEndElement();
                xdfFile.WriteString(Environment.NewLine);
            }

            xdfFile.WriteEndElement();
        }

        static void WriteAxis(XmlWriter xdfFile)
        {
            xdfFile.WriteRaw(
                "<XDFFUNCTION uniqueid=\"0x6064\" flags=\"0x0\"><title>sc!003-6064-6066</title><CATEGORYMEM index=\"0\" category=\"1\" /><XDFAXIS id=\"x\" uniqueid=\"0x0\">" +
                "<EMBEDDEDDATA mmedelementsizebits=\"8\" mmedcolcount=\"32\" mmedmajorstridebits=\"-32\" /><indexcount>32</indexcount><decimalpl>1</decimalpl><outputtype>2</outputtype>" +
                "<embedinfo type=\"1\" /><datatype>0</datatype><unittype>0</unittype><DALINK index=\"0\" /><MATH equation=\"ROUND(X / 6 + INDEX() * 256 / INDEXES()  *  341.13 / Y; 0)\">" + 
                "<VAR id=\"X\" type=\"address\" address=\"0x6064\" sizeinbits=\"16\" flags=\"0x2\" /><VAR id=\"Y\" type=\"address\" address=\"0x6066\" /></MATH></XDFAXIS>" +
                "<XDFAXIS id=\"y\" uniqueid=\"0x0\"><EMBEDDEDDATA mmedelementsizebits=\"8\" mmedcolcount=\"32\" mmedmajorstridebits=\"-32\" /><indexcount>32</indexcount><decimalpl>1</decimalpl><outputtype>2</outputtype><embedinfo type=\"1\" />" +
                "<datatype>0</datatype><unittype>0</unittype><DALINK index=\"0\" /><MATH equation=\"INDEX()\" /></XDFAXIS></XDFFUNCTION>");

            xdfFile.WriteRaw(
                "<XDFFUNCTION uniqueid=\"0x6164\" flags=\"0x0\"><title>sc!004-6064-6066</title><CATEGORYMEM index=\"0\" category=\"1\" /><XDFAXIS id=\"x\" uniqueid=\"0x0\">" +
                "<EMBEDDEDDATA mmedelementsizebits=\"8\" mmedcolcount=\"16\" mmedmajorstridebits=\"-32\" /><indexcount>16</indexcount><decimalpl>1</decimalpl><outputtype>2</outputtype>" +
                "<embedinfo type=\"1\" /><datatype>0</datatype><unittype>0</unittype><DALINK index=\"0\" /><MATH equation=\"ROUND(X / 6 + INDEX() * 256 / INDEXES()  *  341.13 / Y; 0)\">" +
                "<VAR id=\"X\" type=\"address\" address=\"0x6064\" sizeinbits=\"16\" flags=\"0x2\" /><VAR id=\"Y\" type=\"address\" address=\"0x6066\" /></MATH></XDFAXIS>" +
                "<XDFAXIS id=\"y\" uniqueid=\"0x0\"><EMBEDDEDDATA mmedelementsizebits=\"8\" mmedcolcount=\"16\" mmedmajorstridebits=\"-32\" /><indexcount>16</indexcount><decimalpl>1</decimalpl><outputtype>2</outputtype><embedinfo type=\"1\" />" +
                "<datatype>0</datatype><unittype>0</unittype><DALINK index=\"0\" /><MATH equation=\"INDEX()\" /></XDFAXIS></XDFFUNCTION>");

            xdfFile.WriteRaw(
                "<XDFFUNCTION uniqueid=\"0x6264\" flags=\"0x0\"><title>sc!012-6064-6066</title><CATEGORYMEM index=\"0\" category=\"1\" /><XDFAXIS id=\"x\" uniqueid=\"0x0\">" +
                "<EMBEDDEDDATA mmedelementsizebits=\"8\" mmedcolcount=\"128\" mmedmajorstridebits=\"-32\" /><indexcount>128</indexcount><decimalpl>1</decimalpl><outputtype>2</outputtype>" +
                "<embedinfo type=\"1\" /><datatype>0</datatype><unittype>0</unittype><DALINK index=\"0\" /><MATH equation=\"ROUND(X / 6 + INDEX() * 4; 0)\">" +
                "<VAR id=\"X\" type=\"address\" address=\"0x6064\" sizeinbits=\"16\" flags=\"0x2\" /><VAR id=\"Y\" type=\"address\" address=\"0x6066\" /></MATH></XDFAXIS>" +
                "<XDFAXIS id=\"y\" uniqueid=\"0x0\"><EMBEDDEDDATA mmedelementsizebits=\"8\" mmedcolcount=\"128\" mmedmajorstridebits=\"-32\" /><indexcount>128</indexcount><decimalpl>1</decimalpl><outputtype>2</outputtype><embedinfo type=\"1\" />" +
                "<datatype>0</datatype><unittype>0</unittype><DALINK index=\"0\" /><MATH equation=\"INDEX()\" /></XDFAXIS></XDFFUNCTION>");
        }
        
        static double ReadDouble(IniSection section, string name, double def)
        {
            return section.Contains(name)
                       ? Convert.ToDouble(section.GetValue(name).Replace("\"", ""), CultureInfo.InvariantCulture)
                       : def;
        }

        static int ReadInt(IniSection section, string name, int def)
        {
            return section.Contains(name)
                       ? Convert.ToInt32(section.GetValue(name).Replace("\"", ""), CultureInfo.InvariantCulture)
                       : def;
        }

        static string ReadStr(IniSection section, string name, string def)
        {
            return section.Contains(name) ? section.GetValue(name).Replace("\"", "") : def;
        }
    }
}
