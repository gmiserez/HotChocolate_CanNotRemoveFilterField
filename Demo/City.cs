namespace Demo
{
    public class City
    {
        public City(string name, string countryCode)
        {
            Name = name;
            CountryCode = countryCode;
        }

        public string Name { get; }

        public string CountryCode { get; }
    }
}
