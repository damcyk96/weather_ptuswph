using System;

namespace WebApplication12.Messages.Responses
{
    public class WeatherResponse
    {
        public string Description { get; set; }

        public WeatherResponse(string description)
        {
            Description = description;
        }
    }
}