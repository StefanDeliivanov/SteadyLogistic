namespace SteadyLogistic.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Country;

    public class Country
    {
        public Country()
        {
            this.Cities = new List<City>();
            this.Companies = new List<Company>();
            this.LoadUnloadings = new List<LoadUnloadInfo>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(countryNameMaxLenght)]
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }

        public virtual ICollection<Company> Companies { get; set; }

        public virtual ICollection<LoadUnloadInfo> LoadUnloadings { get; set; }
    }
}
