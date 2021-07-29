namespace SteadyLogistic.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

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

        //[Required]
        //public virtual SLogisticsUser Manager { get; set; }

        //public string ManagerId { get; set; }

        [Required]
        public virtual Country Country { get; set; }

        public int CountryId { get; set; }

        [Required]
        public virtual City City { get; set; }

        public int CityId { get; set; }

        public int FleetCount { get; set; }

        public virtual ICollection<Truck> TruckFleet { get; set; }

        public virtual ICollection<Trailer> TrailerFleet { get; set; }

        public virtual ICollection<SLogisticsUser> Employees { get; set; }
    }
}
