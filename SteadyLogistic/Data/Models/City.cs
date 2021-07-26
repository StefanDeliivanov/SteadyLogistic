namespace SteadyLogistic.Data.Models
{
    using System.Collections.Generic;

    public class City
    {
        public City()
        {
            this.Companies = new List<Company>();
    
        }

        public int Id { get; init; }

        public string Name { get; set; }

        public Country Country { get; set; }

        public int CountryId { get; set; }

        public ICollection<Company> Companies { get; set; }

    }
}
