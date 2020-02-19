using System;

namespace WebApplication12.Messages.Responses
{
    public class WeatherResponse
    {
        public string Description { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public decimal Temperature { get; set; }

        public WeatherResponse()
        {
            
        }
        
        public WeatherResponse(string description, string city, string country, decimal temperature)
        {
            Description = description;
            City = city;
            Country = country;
            Temperature = temperature;
        }
    }
}