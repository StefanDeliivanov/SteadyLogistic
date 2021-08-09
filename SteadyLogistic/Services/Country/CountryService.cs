namespace SteadyLogistic.Services.Country
{
    using System.Collections.Generic;
    using System.Linq;
    using SteadyLogistic.Data;
    using SteadyLogistic.Data.Models;

    public class CountryService : ICountryService
    {
        private readonly SteadyLogisticDbContext data;

        public CountryService(SteadyLogisticDbContext data)
        {
            this.data = data;
        }

        public ICollection<CountryServiceModel> AllCountries()
        {
            return this.data
                        .Countries
                        .Select(x => new CountryServiceModel
                        {
                            Id = x.Id,
                            Name = x.Name
                        })
                        .ToList();
        }

        public bool CountryExists(int countryId)
        {
            return this.data
                        .Countries
                        .Any(a => a.Id == countryId);
        }

        public Country GetCountryById (int countryId)
        {
            return this.data
                        .Countries
                        .Where(a => a.Id == countryId)
                        .FirstOrDefault();
        }
    }
}
