namespace SteadyLogistic.Services.Country
{
    using System.Collections.Generic;
    using SteadyLogistic.Data.Models;

    public interface ICountryService
    {
        public ICollection<CountryServiceModel> AllCountries();

        public ICollection<string> AllCountryCodes();

        public bool Exists(int countryId);

        public Country GetCountryById(int countryId); 
    }
}