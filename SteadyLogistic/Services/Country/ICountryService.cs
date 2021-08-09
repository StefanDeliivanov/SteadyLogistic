namespace SteadyLogistic.Services.Country
{
    using SteadyLogistic.Data.Models;
    using System.Collections.Generic;

    public interface ICountryService
    {

        public ICollection<CountryServiceModel> AllCountries();

        public bool CountryExists(int countryId);

        public Country GetCountryById(int countryId);
    }
}