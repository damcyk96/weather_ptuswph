using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using WebApplication12.Messages.Responses;

namespace WebApplication12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly DatabaseRepository _repository;
        
        public WeatherController(DatabaseRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<ICollection<WeatherResponse>> Get()
        {
            return _repository
                .GetWeatherData()
                .Select(x => new WeatherResponse(x.Description))
                .ToArray();
        }

        [HttpGet("{city}")]
        public ActionResult<WeatherResponse> Get(string description)
        {
            var weather = _repository
                .GetWeatherData()
                .FirstOrDefault(x => x.Description == description);

            if (weather == null)
                return NotFound();
            
            return new WeatherResponse(weather.Description);
        }
    }
}