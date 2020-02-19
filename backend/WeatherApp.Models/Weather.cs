using System;
using System.Collections.Generic;

namespace Weather.Models
{
    
    public class Response
    {
        public Guid Id { get; set; }
        public City City { get; set; }
        public Main Main { get; set; }
        public ICollection<Weather> Weather { get; set; }
    }

    public class City
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }

    public class Main
    {
        public decimal Temp { get; set; }   
    }

    public class Weather
    {
        public string Description { get; set; }
    }
}