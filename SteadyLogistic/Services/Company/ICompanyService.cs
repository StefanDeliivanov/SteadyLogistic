namespace SteadyLogistic.Services.Company
{
    using SteadyLogistic.Data.Models;

    public interface ICompanyService
    {

        public bool CompanyExists(string vatNumber);

        public Company GetCompanyByVatNumber(string vatNumber);

        public Company Create(string name, string phoneNumber, string vatNumber, string email, string address, int cityId, Country country);

        public bool NameTaken(string name);

        public bool VatNumberTaken(string vatNumber);

        public bool PhoneNumberTaken(string phoneNumber);

        public bool EmailTaken(string email);

        public void AddManager(string userId, int companyId);
    }
}
