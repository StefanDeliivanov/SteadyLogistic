namespace SteadyLogistic.Services.Company
{
    using SteadyLogistic.Data.Models;
    using SteadyLogistic.Models.Catalogue;

    public interface ICompanyService
    {
        public void AddManager(string userId, int companyId);

        public CompanyQueryServiceModel All(
         string searchTerm = null,
         CompanySearchType searchType = CompanySearchType.Name,
         CompanySorting sorting = CompanySorting.CompanyNameAscending,
         int currentPage = 1,
         int companiesPerPage = int.MaxValue);

        public bool CompanyExists(string vatNumber);

        public Company Create(
          string name,
          string phoneNumber,
          string vatNumber,
          string email,
          string address,
          string description,
          string firstName,
          string lastName,
          int cityId,
          Country country);

        public CompanyDetailsServiceModel Details(int id);

        public bool EmailTaken(string email);

        public Company GetCompanyByVatNumber(string vatNumber);

        public bool NameTaken(string name);

        public bool PhoneNumberTaken(string phoneNumber);

        public bool VatNumberTaken(string vatNumber);
    }
}