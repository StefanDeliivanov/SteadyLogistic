namespace SteadyLogistic.Services.Company
{
    using System;
    using System.Collections.Generic;
    using SteadyLogistic.Services.User;

    public class CompanyDetailsServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string VatNumber { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public string ManagerFullName { get; set; }

        public string ManagerId { get; set; }

        public string CountryName { get; set; }

        public string CityName { get; set; }

        public DateTime RegisteredOn { get; set; }

        public List<UserMiniDetailsModel> Employees { get; set; }
    }
}