using System;
using System.Collections.Generic;

namespace Hackatown2020.Models
{
    public partial class CoordonneesStationsRsqa : BaseModel
    {
        public string NumeroStation { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string ArrondissementVille { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
