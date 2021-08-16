namespace SteadyLogistic.Services.City
{
    using SteadyLogistic.Data.Models;

    public interface ICityService
    {
        public bool CityExists(string postCode, string name, int countryId);

        public City Create(string postCode, string name, int countryId);

        public City GetCity(string postCode, string name, int countryId);  
    }
}