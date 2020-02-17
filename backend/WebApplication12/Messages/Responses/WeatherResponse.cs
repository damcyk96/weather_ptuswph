using System;

namespace WebApplication12.Messages.Responses
{
    public class WeatherResponse
    {
        public string Name { get; }
        public float Temperature { get; }
        public string Description { get; }

        public WeatherResponse(string name, float temperature, string description)
        {
            Name = name;
            Temperature = temperature;
            Description = description;
        }
    }
}