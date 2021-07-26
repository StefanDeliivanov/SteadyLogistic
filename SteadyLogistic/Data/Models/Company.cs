namespace SteadyLogistic.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using SteadyLogistic.Data.Models.Interfaces;

    public class Company
    {
        public Company()
        {
            this.Fleet = new List<IVehicle>();
            this.Employees = new List<SLogisticsUser>();
        }

        public int Id { get; set; }

        public string Logo { get; set; }

        public string Name { get; set; }

        public string VatNumber { get; set; }

        public string HeadquartersAdress { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public SLogisticsUser Manager { get; set; }

        [ForeignKey("Manager")]
        public string ManagerId { get; set; }

        public Country Country { get; set; }

        public int CountryId { get; set; }

        public City City { get; set; }

        public int CityId { get; set; }

        public int FleetCount { get; set; }

        public ICollection<IVehicle> Fleet { get; set; }

        public ICollection<SLogisticsUser> Employees { get; set; }
    }
}
