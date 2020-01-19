using Hackatown2020.Context;
using Hackatown2020.DAL;
using Hackatown2020.Models;
using Hackatown2020.Models.DTO;
using Hackatown2020.Models.RSAQ;
using Hackatown2020.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hackatown2020.BLL
{
    public class AirPollutionCalculationLogic
    {
        private readonly StationsRepository _stationRepository;
        private readonly RSAQService service;

        public AirPollutionCalculationLogic(Hackatown2020Context ctx)
        {
            _stationRepository = new StationsRepository(ctx);
            service = new RSAQService();
        }
        public async Task<CurrentDataDTO> getCurrentData()
        {
            List<StationDTO> stationDTOs = new List<StationDTO>();
            DateTime today = new DateTime();

            List<Station> stationsData = (await service.GetDataFromRSAQ(today)).journee.stations;
            List<CoordonneesStationsRsqa> coordonneeStationRsaqs = (await _stationRepository.Get()).ToList();

            foreach(Station station in stationsData)
            {
                CoordonneesStationsRsqa coordonnees = coordonneeStationRsaqs.Where(x => x.Id == station.id).FirstOrDefault();

                stationDTOs.Add(new StationDTO
                {
                    qualite = station.echantillons[station.echantillons.Count - 1].qualite.value,
                    longitude = double.Parse(coordonnees.Longitude),
                    latitude = double.Parse(coordonnees.Latitude)
                }) ;
            }

            return new CurrentDataDTO() { stations = stationDTOs };
        }
    }
}
