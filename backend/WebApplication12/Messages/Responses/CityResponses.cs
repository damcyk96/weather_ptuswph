namespace WebApplication12.Messages.Responses
{
    public class CityResponses
    {
        public string Name { get; set; }
        public string FindName { get; set; }
        public string Country { get; set; }
        


        public CityResponses(string name, string findname, string country)
        {
            Name = name;
            FindName = findname;
            Country = country;
        }
    }
}