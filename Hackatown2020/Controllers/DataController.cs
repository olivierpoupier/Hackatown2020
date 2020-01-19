using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hackatown2020.BLL;
using Hackatown2020.Context;
using Hackatown2020.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hackatown2020.Controllers
{
    [ApiController]
    [Route("api/data")]
    public class DataController : ControllerBase
    {
        private readonly AirPollutionCalculationLogic _airPollutionCalculationLogic;

        public DataController(Hackatown2020Context ctx)
        {
            _airPollutionCalculationLogic = new AirPollutionCalculationLogic(ctx);
        }

        [HttpGet]
        public async Task<ActionResult<CurrentDataDTO>> getCurrentData()
        {
            CurrentDataDTO returnObject = await _airPollutionCalculationLogic.getCurrentData();

            return Ok(returnObject);
        }

    }
}
