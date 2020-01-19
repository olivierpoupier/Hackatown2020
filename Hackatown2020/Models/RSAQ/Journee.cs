using System.Collections.Generic;
using System.Xml.Serialization;

namespace Hackatown2020.Models.RSAQ
{
    public class Journee
    {
        public int jour { get; set; }
        public int mois { get; set; }
        public int annee { get; set; }

        [XmlElement("station")]
        public List<Station> stations { get; set; }

    }
}