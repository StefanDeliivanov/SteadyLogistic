namespace SteadyLogistic.Areas.Member.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SteadyLogistic.Areas.Member.Models;
    using SteadyLogistic.Services.Country;
    using SteadyLogistic.Services.City;
    using SteadyLogistic.Services.Company;
    using SteadyLogistic.Services.User;
    using SteadyLogistic.Infrastructure.Extensions;

    using static AreaGlobalConstants.Roles;
    using static Data.DataConstants.ErrorMessages;

    [Area("Member")]
    [Authorize(Roles = MemberRoleName)]
    public class MemberController : Controller
    {
        private readonly ICountryService countries;
        private readonly ICityService cities;
        private readonly ICompanyService companies;
        private readonly IUserService users;

        public MemberController(
            ICountryService countries,
            ICityService cities,
            ICompanyService companies,
            IUserService users)
        {
            this.countries = countries;
            this.cities = cities;
            this.companies = companies;
            this.users = users;
        }

        [HttpGet]
        [Authorize(Roles = MemberRoleName)]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = MemberRoleName)]
        public IActionResult UpgradeToPremium()
        {
            return View(new UpgradeToPremiumFormModel { Countries = countries.AllCountries() });
        }

        [HttpPost]
        [Authorize(Roles = MemberRoleName)]
        public IActionResult UpgradeToPremium(UpgradeToPremiumFormModel model)
        {
            var country = countries.GetCountryById(model.CountryId);

            if (!this.countries.CountryExists(model.CountryId))
            {
                this.ModelState.AddModelError(nameof(model.CountryId), "Country does not exist.");
            }

            if (users.PhoneNumberTaken(model.PhoneNumber))
            {
                this.ModelState.AddModelError(nameof(model.PhoneNumber), propertyExistsErrorMessage);
            }

            if (companies.PhoneNumberTaken(model.CompanyPhoneNumber))
            {
                this.ModelState.AddModelError(nameof(model.CompanyPhoneNumber), propertyExistsErrorMessage);
            }

            if (companies.EmailTaken(model.CompanyEmail))
            {
                this.ModelState.AddModelError(nameof(model.CompanyEmail), propertyExistsErrorMessage);
            }

            if (companies.NameTaken(model.CompanyName))
            {
                this.ModelState.AddModelError(nameof(model.CompanyName), propertyExistsErrorMessage);
            }

            if (companies.VatNumberTaken(model.VatNumber))
            {
                this.ModelState.AddModelError(nameof(model.VatNumber), propertyExistsErrorMessage);
            }

            if (!ModelState.IsValid)
            {
                model.Countries = this.countries.AllCountries();

                return View(model);
            }

            var city = cities.GetCity(model.PostCode, model.CityName, model.CountryId);

            if (city == null)
            {
                city = cities.Create(model.CityName, model.PostCode, model.CountryId);
            }

            var company = companies.Create(model.CompanyName, model.CompanyPhoneNumber, model.VatNumber, model.CompanyEmail, model.Address, city.Id, country);

            var memberId = this.User.GetUserId();
            var memberEmail = this.User.GetEmail();

            var premiumUser = users.CreatePremium(memberId, model.FirstName, model.LastName, memberEmail, model.PhoneNumber, company.Id);

            users.AddAsManager(premiumUser);
            companies.AddManager(premiumUser.Id, company.Id);

            return RedirectToAction("News", "Home", new { area = "" });
        }
    }
}