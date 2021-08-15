namespace SteadyLogistic.Services.Company
{
    using System.Collections.Generic;

    public class CompanyQueryServiceModel
    {
        public int CurrentPage { get; set; }

        public int CompaniesPerPage { get; set; }

        public int TotalCompanies { get; set; }

        public IEnumerable<CompanyServiceModel> AllCompanies { get; set; }
    }
}