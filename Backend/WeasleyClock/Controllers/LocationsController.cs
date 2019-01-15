using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeasleyClock.Model.Data;
using WeasleyClock.Repositories.Interfaces;

namespace WeasleyClock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationsRepository _repo;

        public LocationsController(ILocationsRepository repo)
        {
            _repo = repo;
        }

        // GET api/values
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<Location>> GetCurrentLocation([FromQuery] string userName, [FromQuery] double latitude, [FromQuery] double longitude)
        {
            if (string.IsNullOrEmpty(userName) || latitude == 0 || longitude == 0 )
                return UnprocessableEntity();

            try
            {
                var location = await _repo.GetCurrentLocation(userName, latitude, longitude);
                return Ok(location);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpGet("all")]
        [Produces("application/json")]
        public async Task<ActionResult<List<Location>>> GetAll()
        {
            try
            {
                var location = await _repo.GetAll();
                return Ok(location);
            }
            catch(Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveLocation([FromQuery] Guid id)
        {
            try
            {
                await _repo.RemoveLocation(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateLocation([FromBody] Location location)
        {
            try
            {
                await _repo.AddLocation(location);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("test")]
        [Produces("application/json")]
        public Location Test()
        {
            return new Location
            {
                UserName = "Jonas",
                LocationName = "Arbeit",
                MaxDistance = 200,
                Latitude = 51.234677843,
                Longitude = 39.34789111
            };
        }
    }
}
