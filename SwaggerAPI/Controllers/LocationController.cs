using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Fro.Controllers
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
            return _TripAdvisorContext.Locations;
        }

        [HttpGet("(id)")]
        public Location Get(int id)
        {
            var location = _TripAdvisorContext.Locations.SingleOrDefault();
            if (location != null)
            {
                return location;
            }
            else
            {
                return null;
            }
        }

        [HttpPut("(id)")]
        public void Put(int id, String str)
        {
            var location = _TripAdvisorContext.Locations.SingleOrDefault(loc => loc.id == id);
            if (location != null)
            {
                location.name = str;
                _TripAdvisorContext.SaveChanges();
            }
        }

        [HttpPost]
        public void Post(Location location)
        {
            _TripAdvisorContext.Locations.Add(location);
            _TripAdvisorContext.SaveChanges();
        }

        [HttpDelete("(id)")]
        public void Delete(int id)
        {
            var location = _TripAdvisorContext.Locations.SingleOrDefault(loc => loc.id == id);
            if (location != null)
            {
                _TripAdvisorContext.Locations.Remove(location);
            }
        }
    }
}
