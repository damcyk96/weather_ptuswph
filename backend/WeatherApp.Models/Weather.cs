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
        public static string Name { get; set; }
        public static string Country { get; set; }
    }

    public class Main
    {
        public static decimal Temp { get; set; }   
    }

    public class Weather
    {
        public string Description { get; set; }
    }
}