using System.Collections.Generic;
using System.Xml.Serialization;

namespace Hackatown2020.Models.RSAQ
{
    public class IndiceSecteur
    {
        [XmlElement("secteur")]
        public List<Secteur> secteurs { get; set; }
    }
}