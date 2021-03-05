using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Model;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace SwaggerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OpinionController : ControllerBase
    {
        private readonly TripAdvisorContext _TripAdvisorContext;

        public OpinionController(TripAdvisorContext TripAdvisorContext)
        {
            _TripAdvisorContext = TripAdvisorContext;

        }

        [HttpGet]
        public IEnumerable<OpinionDto> Get()
        {
            return _TripAdvisorContext.Opinions.Select(element => element.ToDto());
        }

        [HttpGet("(id)")]
        public OpinionDto Get(int id)
        {
            OpinionDto opinion = null;
            opinion = _TripAdvisorContext.Opinions.SingleOrDefault(opi => opi.id == id).ToDto();
            return opinion;
            
        }

        [HttpPut("(id, content)")]
        public void Put(int id, String content)
        {
            var opinion = _TripAdvisorContext.Opinions.SingleOrDefault(opi => opi.id == id);
            if (opinion != null)
            {
                opinion.Content = content;
                _TripAdvisorContext.SaveChanges();
            }
        }

        [HttpPost("(locationid)")]
        public void Post(int locationid, Opinion opinion)
        {
            var location = _TripAdvisorContext.Locations.SingleOrDefault(loc => loc.id == locationid);
            location.addOpinion(opinion);
            _TripAdvisorContext.SaveChanges();
        }

        [HttpDelete("(id)")]
        public void Delete(int id)
        {
            var opinion = _TripAdvisorContext.Opinions.SingleOrDefault(opi => opi.id == id);
            if (opinion != null)
            {
                _TripAdvisorContext.Opinions.Remove(opinion);
                _TripAdvisorContext.SaveChanges();
            }
        }


    }
}