using System;

namespace WebApplication12.Messages.Responses
{
    public class WeatherResponse
    {
        public string Name { get; }
        public decimal Temperature { get; }
        public string Description { get; }

        public WeatherResponse(string name, decimal temperature, string description)
        {
            Name = name;
            Temperature = temperature;
            Description = description;
        }
    }
}