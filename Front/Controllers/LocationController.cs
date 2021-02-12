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


        [HttpGet()]
        public IEnumerable<Location> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Location(index, "Clermont", "https://images.france.fr/zeaejvyq9bhj/5PPHLz3qykyyAOqK8W4ESq/92b73f3a28583f9919cfb451b9e58fb9/clermont-ferrand.jpg?w=1120&h=490&q=70&fl=progressive&fit=fill"));
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