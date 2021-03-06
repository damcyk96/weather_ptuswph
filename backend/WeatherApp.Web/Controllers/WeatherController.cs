﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Weather.Models;
using WeatherApp.Messages.Responses;

namespace WeatherApp.Controllers
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
                .Select(x => new WeatherResponse(string.Join(',',
                        x.Description.Select(y => y.Weather.Description)),
                    City.Name,
                    City.Country,
                    Main.Temp))
                .ToArray();
        }

        [HttpGet("{city}")]
        public ActionResult<WeatherResponse> Get(string city)
        {
            var weather = _repository
                .GetWeatherData()
                .FirstOrDefault(x => City.Name.ToLower().Contains(city.ToLower()));
            
            if (weather == null)
                return NotFound();

            return new WeatherResponse(string.Join(',',
                    Weather.Select(y => y.Description)),
                City.Name,
                City.Country,
                Main.Temp);
        }
    }
}