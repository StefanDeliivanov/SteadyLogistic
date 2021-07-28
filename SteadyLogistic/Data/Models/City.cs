namespace SteadyLogistic.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.City;

    public class City
    {
        public City()
        {
            this.Companies = new List<Company>();  
        }
        [Required]
        [Key]
        public int Id { get; init; }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; }

        [Required]
        public Country Country { get; set; }

        public int CountryId { get; set; }

        public ICollection<Company> Companies { get; set; }

    }
}
