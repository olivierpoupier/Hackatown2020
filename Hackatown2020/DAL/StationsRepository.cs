using Hackatown2020.Context;
using Hackatown2020.Interface;
using Hackatown2020.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackatown2020.DAL
{
    public class StationsRepository : GenericRepository<CoordonneesStationsRsqa>, IStationRepository
    {
        public StationsRepository(Hackatown2020Context context) : base(context)
        {
        }
    }
}