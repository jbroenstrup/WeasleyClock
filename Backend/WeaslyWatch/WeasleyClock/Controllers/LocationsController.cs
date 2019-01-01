using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeasleyClock.Model.Data;

namespace WeasleyClock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        public LocationsController()
        {

        }

        // GET api/values
        [HttpGet]
        [Produces("application/json")]
        public async Task<Location> GetCurrentLocation([FromQuery] string userName, [FromQuery] double latitude, [FromQuery] double longitude)
        {
            return await Task.FromResult(new Location());
        }
    }
}
