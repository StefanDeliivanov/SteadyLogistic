namespace SteadyLogistic.Services.Company
{
    using System;

    public class CompanyServiceModel
    {
        public int Id { get; set; }

        public string ManagerId { get; set; }

        public string CompanyName { get; set; }

        public string ManagerName { get; set; }

        public DateTime RegisteredOn { get; set; }
    }
}