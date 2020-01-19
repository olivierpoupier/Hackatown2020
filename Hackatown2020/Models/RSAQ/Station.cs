using System.Collections.Generic;
using System.Xml.Serialization;

namespace Hackatown2020.Models.RSAQ
{
    public class Station
    {
        public int id { get; set; }
        public string donnees { get; set; }
        [XmlElement("iqa-val")]
        public IQAVal iqaVal { get; set; }
        [XmlElement("echantillon")]
        public List<Echantillon> echantillons { get; set; }
    }
}