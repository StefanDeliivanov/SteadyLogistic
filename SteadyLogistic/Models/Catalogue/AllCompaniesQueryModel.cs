namespace SteadyLogistic.Models.Catalogue
{
    using System.Collections.Generic;
    using SteadyLogistic.Services.Company;

    public class AllCompaniesQueryModel
    {
        public const int CompaniesPerPage = 10;

        public string SearchTerm { get; set; }

        public CompanySearchType SearchType { get; set; }

        public CompanySorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalCompanies { get; set; }

        public IEnumerable<CompanyServiceModel> Companies { get; set; }
    }
}