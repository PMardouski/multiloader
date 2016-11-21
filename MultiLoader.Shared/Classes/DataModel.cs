using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MultiLoader.Shared
{
    [Serializable]
    [XmlRoot("value")]
    public class DataModel
    {
        [XmlAttribute("date")]
        public DateTime Date { get; set; }

        [XmlAttribute("open")]
        public decimal Open { get; set; }

        [XmlAttribute("high")]
        public decimal High { get; set; }

        [XmlAttribute("low")]
        public decimal Low { get; set; }

        [XmlAttribute("close")]
        public decimal Close { get; set; }

        [XmlAttribute("volume")]
        public decimal Volume { get; set; }
    }
}
