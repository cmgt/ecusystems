using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Helper;
using OpenOltTypes;

namespace OpenOLT
{
    internal class PluginManager
    {
        public static void Load(string path, IApplicationHost applicationHost)
        {
            try
            {
                foreach (var file in Directory.GetFiles(path, "*.dll"))
                {
                    try
                    {
                        var assembly = Assembly.LoadFrom(file);
                        var isPlugin = assembly.GetCustomAttributes(typeof (PluginAttribute), false).Any();
                        if (!isPlugin) continue;
                        foreach (var type in assembly.GetExportedTypes())
                        {
                            Activator.CreateInstance(type, applicationHost);
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception e)
            {}
        }
    }
}