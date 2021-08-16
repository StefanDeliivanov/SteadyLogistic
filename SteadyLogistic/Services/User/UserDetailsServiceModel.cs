namespace SteadyLogistic.Services.User
{
    using System;
    using SteadyLogistic.Services.Company;

    public class UserDetailsServiceModel
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        public CompanyDetailsServiceModel Company { get; set; }
    }
}