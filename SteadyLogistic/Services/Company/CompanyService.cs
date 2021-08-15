namespace SteadyLogistic.Services.Company
{
    using System.Collections.Generic;
    using System.Linq;
    using SteadyLogistic.Data;
    using SteadyLogistic.Data.Models;
    using SteadyLogistic.Models.Catalogue;
    using SteadyLogistic.Services.User;

    public class CompanyService : ICompanyService
    {
        private readonly SteadyLogisticDbContext data;
        private readonly IUserService users;

        public CompanyService(
            SteadyLogisticDbContext data,
            IUserService users)
        {
            this.data = data;
            this.users = users;
        }

        public CompanyQueryServiceModel All(
            string searchTerm = null,
            CompanySearchType searchType = CompanySearchType.Name,
            CompanySorting sorting = CompanySorting.CompanyNameAscending,
            int currentPage = 1,
            int companiesPerPage = int.MaxValue)
        {
            var companiesQuery = this.data.Companies.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                companiesQuery = searchType switch
                {
                    CompanySearchType.VatNumber => companiesQuery.Where(a => a.VatNumber.Contains(searchTerm)),
                    CompanySearchType.Address => companiesQuery.Where(a => a.Address.Contains(searchTerm)),
                    CompanySearchType.PhoneNumber => companiesQuery.Where(a => a.PhoneNumber.Contains(searchTerm)),
                    CompanySearchType.Email => companiesQuery.Where(a => a.Email.Contains(searchTerm)),
                    CompanySearchType.CountryName => companiesQuery.Where(a => a.Country.Name.Contains(searchTerm)),
                    CompanySearchType.CityName => companiesQuery.Where(a => a.City.Name.Contains(searchTerm)),
                    CompanySearchType.Name or _ => companiesQuery.Where(a => a.Name.Contains(searchTerm))
                };
            }  

            companiesQuery = sorting switch
            {
                CompanySorting.RegisteredOnDescending => companiesQuery.OrderByDescending(a => a.RegisteredOn),
                CompanySorting.RegisteredOnAscending => companiesQuery.OrderBy(a => a.RegisteredOn),
                CompanySorting.ManagerNameDescending => companiesQuery.OrderByDescending(a => a.ManagerFullName),
                CompanySorting.ManagerNameAscending => companiesQuery.OrderBy(a => a.ManagerFullName),
                CompanySorting.CompanyNameDescending => companiesQuery.OrderByDescending(a => a.Name),
                CompanySorting.CompanyNameAscending or _ => companiesQuery.OrderBy(a => a.Name)
            };

            var totalCompanies = companiesQuery.Count();

            var companies = GetCompanies(companiesQuery
                .Skip((currentPage - 1) * companiesPerPage)
                .Take(companiesPerPage)).ToList();

            return new CompanyQueryServiceModel
            {
                TotalCompanies = totalCompanies,
                CurrentPage = currentPage,
                CompaniesPerPage = companiesPerPage,
                AllCompanies = companies
            };
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

        public Company Create(
            string name, 
            string phoneNumber, 
            string vatNumber, 
            string email, 
            string address, 
            string firstName,
            string lastName,
            int cityId, 
            Country country)
        {
            var company = new Company()
            {
                Name = name,
                PhoneNumber = phoneNumber,
                VatNumber = vatNumber,
                Email = email,
                Address = address,
                ManagerFullName = firstName + " " + lastName,
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

        private static IEnumerable<CompanyServiceModel> GetCompanies(IQueryable<Company> query)
        {
            var companies = query
                .Select(a => new CompanyServiceModel
                {
                    Id = a.Id,
                    ManagerId = a.ManagerId,
                    CompanyName = a.Name,
                    ManagerName = a.ManagerFullName,
                    RegisteredOn = a.RegisteredOn
                })
                .ToList();

            return companies;
        }
    }
}