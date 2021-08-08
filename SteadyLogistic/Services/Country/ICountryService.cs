namespace SteadyLogistic.Services.Country
{
    using System.Collections.Generic;

    public interface ICountryService
    {

        public ICollection<CountryServiceModel> AllCountries();

        public bool CountryExists(int countryId);
    }
}