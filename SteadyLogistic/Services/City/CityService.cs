namespace SteadyLogistic.Services.City
{
    using System.Linq;
    using SteadyLogistic.Data;
    using SteadyLogistic.Data.Models;

    public class CityService : ICityService
    {
        private readonly SteadyLogisticDbContext data;

        public CityService(SteadyLogisticDbContext data)
        {
            this.data = data;
        }

        public bool CityExists(string postCode, string name, int countryId)
        {
            var city = data.Cities
                    .Where(a => a.PostCode == postCode)
                    .Where(b => b.Name == name)
                    .Where(c => c.CountryId == countryId)
                    .FirstOrDefault();

            if(city == null)
            {
                return true;
            }            
            
            else return false;
        }

        public City Create(string postCode, string name, int countryId)
        {
            var city = new City()
            {
                PostCode = postCode,
                Name = name,             
                CountryId = countryId
            };

            data.Cities.Add(city);

            data.SaveChanges();

            return city;
        }

        public City GetCity(string postCode, string name, int countryId)
        {
            var city = this.data.Cities
                    .Where(a => a.PostCode == postCode)
                    .Where(b => b.Name == name)
                    .Where(c => c.CountryId == countryId)
                    .FirstOrDefault();

            if (city == null)
            {
                city = Create(postCode, name, countryId);
            }
            return city;
        }
    }
}