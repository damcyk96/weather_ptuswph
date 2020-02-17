using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Infrastructure;
using Weather.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using WebApplication12.Messages.Requests;
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
                .Select(x => new WeatherResponse(x.Name, x.Description,x.Temperature))
                .ToArray();
        }

        [HttpGet("{city}")]
        public ActionResult<WeatherResponse> Get(Guid id)
        {
            var weather = _repository
                .GetWeatherData()
                .FirstOrDefault(x => x.Id == id);

            if (weather == null)
                return NotFound();
            
            return new WeatherResponse(weather.Name, weather.Temperature, weather.Description);
        }
    }
}