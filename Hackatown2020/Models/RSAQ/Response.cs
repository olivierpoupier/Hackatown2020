using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Hackatown2020.Models.RSAQ
{
    [XmlRoot("iqa")]
    public class Response
    {
        [XmlElement("prevision_actuelle")]
        public PrevisionActuelle previsionActuelle { get; set; }

        [XmlElement("indice_secteur")]
        public IndiceSecteur indiceSecteur { get; set; }

        public Journee journee { get; set; }
    }
}
