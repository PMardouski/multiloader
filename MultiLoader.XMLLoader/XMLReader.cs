using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;
using MultiLoader.Shared;

namespace MultiLoader.XMLLoader
{
    public class XMLReader
    {
        private static readonly XMLReader instance = new XMLReader();

        public string Name { get; private set; }

        private XMLReader()
        {
            Name = System.Guid.NewGuid().ToString();
        }

        public static XMLReader GetInstance()
        {
            return instance;
        }

        public IEnumerable<DataModel> LoadData(string loadFrom)
        {
            IList<DataModel> lines = new List<DataModel>();
            XDocument doc = XDocument.Load(loadFrom);
            XmlSerializer ser = new XmlSerializer(typeof(DataModel));
            foreach (XElement element in doc.Element("values").Elements("value"))
            {
                using (var reader = element.CreateReader())
                {
                    lines.Add((DataModel)ser.Deserialize(reader));
                }
            }

            return lines;
        }
    }
}
