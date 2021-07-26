namespace SteadyLogistic.Data.Models
{
    using System.Collections.Generic;

    public class Country
    {
        public Country()
        {
            this.Cities = new List<City>();
            this.Companies = new List<Company>();
        }

        public int  Id { get; set; }

        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }

        public ICollection<Company> Companies { get; set; }
    }
}
