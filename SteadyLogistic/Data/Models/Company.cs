namespace SteadyLogistic.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static DataConstants.Company;

    public class Company
    {
        public Company()
        {
            this.TruckFleet = new List<Truck>();
            this.TrailerFleet = new List<Trailer>();
            this.Employees = new List<SLogisticsUser>();
        }

        public int Id { get; set; }

        [Required]
        public string Logo { get; set; }

        [Required]
        [MaxLength(companyNameMaxLenght)]
        public string Name { get; set; }

        [Required]
        [MaxLength(vatNumberMaxLenght)]
        public string VatNumber { get; set; }

        [Required]
        [MaxLength(headquatersMaxLenght)]
        public string HeadquartersAdress { get; set; }

        [Required]
        [MaxLength(phoneMaxLenght)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(emailMaxLenght)]
        public string Email { get; set; }

        [Required]
        public SLogisticsUser Manager { get; set; }

        [ForeignKey("Manager")]
        public string ManagerId { get; set; }

        [Required]
        public Country Country { get; set; }

        public int CountryId { get; set; }

        [Required]
        public City City { get; set; }

        public int CityId { get; set; }

        public int FleetCount { get; set; }

        public ICollection<Truck> TruckFleet { get; set; }

        public ICollection<Trailer> TrailerFleet { get; set; }

        public ICollection<SLogisticsUser> Employees { get; set; }
    }
}
