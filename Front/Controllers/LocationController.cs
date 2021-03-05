using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Model;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Front.Controllers
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
        public IEnumerable<LocationDto> Get()
        {
            return _TripAdvisorContext.Locations.Include(element => element.opinionList).Select(element => element.ToDto());
        }

        [HttpGet("{id}")]
        public LocationDto Get(int id)
        {
            LocationDto location = null;
            location = _TripAdvisorContext.Locations.SingleOrDefault(loc => loc.id == id).ToDto();
            return location;
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
            var location = _TripAdvisorContext.Locations.Include(element => element.opinionList).SingleOrDefault(loc => loc.id == id);
            if (location != null)
            {
                _TripAdvisorContext.Locations.Remove(location);
                _TripAdvisorContext.SaveChanges();
            }
        }
    }
}
