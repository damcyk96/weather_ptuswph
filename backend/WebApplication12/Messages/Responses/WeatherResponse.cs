using System;

namespace WebApplication12.Messages.Responses
{
    public class WeatherResponse
    {
        public string Name { get; }
        
        public string Country { get; }
        public decimal Temperature { get; }
        public string Description { get; }

        public WeatherResponse(string name, string country, decimal temperature, string description)
        {
            Name = name;
            Country = country;
            Temperature = temperature;
            Description = description;
        }
    }
}