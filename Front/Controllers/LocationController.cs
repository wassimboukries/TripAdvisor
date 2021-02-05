using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TripAdvisor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly TripAdvisorContext _TripAdvisorContext;

        public LocationController(TripAdvisorContext TripAdvisorContext)
        {
            _TripAdvisorContext = TripAdvisorContext;

        }

        [HttpGet]
        public IEnumerable<Location> Get()
        {
            return null;
        }

        [HttpGet("(id)")]
        public IActionResult Get(int id)
        {
            var prod = _TripAdvisorContext.Locations.SingleOrDefault();
            if (prod != null)
            {
                return Ok(prod);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
