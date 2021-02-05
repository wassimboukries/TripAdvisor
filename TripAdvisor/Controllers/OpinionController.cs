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
       

        private readonly ILogger<OpinionController> _logger;

        public OpinionController(ILogger<OpinionController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Opinion> Get()
        {
            return null;
        }
    }
}
