using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DoenaSoft.DVDProfiler.CastDemoClient_V2
{
    public class Settings
    {
        public String UserName;

        private static XmlSerializer s_Serializer = new XmlSerializer(typeof(Settings));

        internal static Settings Deserialize(String fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                Settings instance = (Settings)(s_Serializer.Deserialize(fs));

                return (instance);
            }
        }

        internal void Serialize(String fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                using (XmlTextWriter xtw = new XmlTextWriter(fs, Encoding.UTF8))
                {
                    xtw.Formatting = Formatting.Indented;

                    s_Serializer.Serialize(xtw, this);
                }
            }
        }
    }
}