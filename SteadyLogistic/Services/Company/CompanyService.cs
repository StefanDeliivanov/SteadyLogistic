namespace SteadyLogistic.Services.Company
{
    using System.Linq;
    using SteadyLogistic.Data;
    using SteadyLogistic.Data.Models;

    public class CompanyService : ICompanyService
    {
        private readonly SteadyLogisticDbContext data;

        public CompanyService(SteadyLogisticDbContext data)
        {
            this.data = data;
        }

        public bool CompanyExists(string vatNumber)
        {
            return data.Companies
                    .Any(a => a.VatNumber == vatNumber);
        }

        public Company GetCompanyByVatNumber(string vatNumber)
        {
            return data.Companies
                    .Where(a => a.VatNumber == vatNumber)
                    .FirstOrDefault();
        }

        public bool NameTaken(string name)
        {
            return this.data.Companies
                        .Any(a => a.Name == name);
        }

        public bool PhoneNumberTaken(string phoneNumber)
        {
            return this.data.Companies
                         .Any(a => a.PhoneNumber == phoneNumber);
        }

        public bool EmailTaken(string email)
        {
            return this.data.Companies
                        .Any(a => a.Email == email);
        }

        public bool VatNumberTaken(string vatNumber)
        {
            return this.data.Companies
                        .Any(a => a.VatNumber == vatNumber);
        }

        public Company Create(string name, string phoneNumber, string vatNumber, string email, string address, int cityId, Country country)
        {
            var company = new Company()
            {
                Name = name,
                PhoneNumber = phoneNumber,
                VatNumber = vatNumber,
                Email = email,
                Address = address,
                CityId = cityId,
                Country = country,
            };

            data.Companies.Add(company);

            data.SaveChanges();

            return company;
        }

        public void AddManager(string userId, int companyId)
        {
            var company = data.Companies
                            .Where(a => a.Id == companyId)
                            .FirstOrDefault();
            company.ManagerId = userId;

            data.SaveChanges();
        }
    }
}