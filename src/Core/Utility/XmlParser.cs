using System.IO;
using System.Xml.Serialization;

namespace FM.ParcelDist.Core.Utility
{
    public class XmlParser 
    {
        public static T LoadXml<T>(string xmlFilePath)
        {
            var serializer = new XmlSerializer(typeof(T));
            var t = default(T);

            using (var streamReader = File.OpenText(xmlFilePath))
            {
                t = (T)serializer.Deserialize(streamReader);
            }

            return t;
        }
    }
}
