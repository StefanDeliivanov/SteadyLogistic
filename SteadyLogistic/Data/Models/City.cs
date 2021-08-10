namespace SteadyLogistic.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.City;

    public class City
    {
        public City()
        {
            Companies = new List<Company>();
            LoadUnloadings = new List<LoadUnloadInfo>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(cityNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(cityPostCodeMaxLength)]
        public string PostCode { get; set; }

        [Required]
        public virtual Country Country { get; set; }

        public int CountryId { get; set; }

        public virtual ICollection<Company> Companies { get; set; }

        public virtual ICollection<LoadUnloadInfo> LoadUnloadings { get; set; }
    }
}