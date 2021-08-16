namespace SteadyLogistic.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SteadyLogistic.Models.FreightExchange;
    using SteadyLogistic.Services.Company;
    using SteadyLogistic.Services.User;
    using SteadyLogistic.Models.Catalogue;

    using static Areas.AreaGlobalConstants.Roles;
    using static WebConstants;

    [Authorize]
    public class CatalogueController : Controller
    {
        private readonly ICompanyService companies;
        private readonly IUserService users;

        public CatalogueController( 
            ICompanyService companies, 
            IUserService users)
        {
            this.companies = companies;
            this.users = users;
        }

        [Authorize(Roles = NotAMemberRoleName)]
        public IActionResult AllCompanies([FromQuery] AllCompaniesQueryModel query)
        {
            var queryResult = this.companies.All(
                query.SearchTerm,
                query.SearchType,
                query.Sorting,
                query.CurrentPage,
                AllFreightsQueryModel.FreightsPerPage);


            query.TotalCompanies = queryResult.TotalCompanies;
            query.Companies = queryResult.AllCompanies;

            return View(query);
        }


        [Authorize(Roles = NotAMemberRoleName)]
        public IActionResult AllUsers([FromQuery] AllUsersQueryModel query)
        {
            var queryResult = this.users.All(
                 query.SearchTerm,
                 query.SearchType,
                 query.Sorting,
                 query.CurrentPage,
                 AllFreightsQueryModel.FreightsPerPage);


            query.TotalUsers = queryResult.TotalUsers;
            query.Users = queryResult.AllUsers;

            return View(query);
        }

        [Authorize(Roles = NotAMemberRoleName)]
        public IActionResult CompanyDetails(int id)
        {
            var company = this.companies.Details(id);

            if (company == null)
            {
                TempData[GlobalErrorKey] = "This company does not exist!";

                return RedirectToAction(nameof(AllCompanies));
            }

            return View(company);
        }
    }
}