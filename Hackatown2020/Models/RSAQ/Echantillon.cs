using System.Collections.Generic;
using System.Xml.Serialization;

namespace Hackatown2020.Models.RSAQ
{
    public class Echantillon
    {
        public string heure { get; set; }
        [XmlElement("qualite")]
        public QualiteEchantillon qualite { get; set; }
        [XmlElement("polluants")]
        public List<Polluant> polluants { get; set; }
    }
}