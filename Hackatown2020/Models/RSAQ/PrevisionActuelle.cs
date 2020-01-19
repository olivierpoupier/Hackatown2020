using System.Xml.Serialization;

namespace Hackatown2020.Models.RSAQ
{
    public class PrevisionActuelle
    {
        [XmlElement("qualite")]
        public QualiteGenerale qualite { get; set; }
        [XmlElement("texte_info")]
        public string texteInfo { get; set; }
    }
}