namespace SteadyLogistic.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Country;

    public class Country
    {
        public Country()
        {
            Cities = new List<City>();
            Companies = new List<Company>();
            LoadUnloadings = new List<LoadUnloadInfo>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(countryNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(countryCodeLength)]
        public string Code { get; set; }

        public virtual ICollection<City> Cities { get; set; }

        public virtual ICollection<Company> Companies { get; set; }

        public virtual ICollection<LoadUnloadInfo> LoadUnloadings { get; set; }
    }
}