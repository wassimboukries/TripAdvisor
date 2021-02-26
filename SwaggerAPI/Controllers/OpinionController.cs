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
    public class OpinionController : ControllerBase
    {
        private readonly TripAdvisorContext _TripAdvisorContext;

        public OpinionController(TripAdvisorContext TripAdvisorContext)
        {
            _TripAdvisorContext = TripAdvisorContext;

        }

        [HttpGet]
        public IEnumerable<Opinion> Get()
        {
            return _TripAdvisorContext.Opinions;
        }

        [HttpGet("(id)")]
        public Opinion Get(int id)
        {
            var opinion = _TripAdvisorContext.Opinions.SingleOrDefault(opi => opi.id == id);
            if (opinion != null)
            {
                return opinion;
            }
            else
            {
                return null;
            }
        }

        [HttpPut("(id)")]
        public void Put(int id, String content)
        {
            var opinion = _TripAdvisorContext.Opinions.SingleOrDefault(opi => opi.id == id);
            if (opinion != null)
            {
                opinion.Content = content;
                _TripAdvisorContext.SaveChanges();
            }
        }

        [HttpPost]
        public void Post(Opinion opinion)
        {
            _TripAdvisorContext.Opinions.Add(opinion);
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