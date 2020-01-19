using Hackatown2020.Context;
using Hackatown2020.DAL;
using Hackatown2020.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackatown2020.BLL
{
    public class AirPollutionCalculationLogic
    {
        private readonly StationsRepository _stationRepository;

        public AirPollutionCalculationLogic(Hackatown2020Context ctx)
        {
            _stationRepository = new StationsRepository(ctx);
        }
        public async Task<CurrentDataDTO> getCurrentData()
        {
            // 

        }
    }
}
