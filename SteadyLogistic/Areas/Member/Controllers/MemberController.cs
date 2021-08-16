namespace SteadyLogistic.Areas.Member.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SteadyLogistic.Areas.Member.Models;
    using SteadyLogistic.Infrastructure.Extensions;
    using SteadyLogistic.Services.City;
    using SteadyLogistic.Services.Company;
    using SteadyLogistic.Services.Country;
    using SteadyLogistic.Services.User;
    
    using static AreaGlobalConstants.Roles;
    using static Data.DataConstants.ErrorMessages;
    using static WebConstants;

    [Authorize]
    [Area("Member")]
    public class MemberController : Controller
    {
        private readonly ICityService cities;
        private readonly ICompanyService companies;
        private readonly ICountryService countries;       
        private readonly IUserService users;

        public MemberController(
            ICityService cities,
            ICompanyService companies,
            ICountryService countries,        
            IUserService users)
        {
            this.cities = cities;
            this.companies = companies;
            this.countries = countries;           
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
            var country = this.countries.GetCountryById(model.CountryId);

            if (!this.countries.Exists(model.CountryId))
            {
                this.ModelState.AddModelError(nameof(model.CountryId), countryNotExistErrorMessage);
            }

            if (this.users.PhoneNumberTaken(model.PhoneNumber))
            {
                this.ModelState.AddModelError(nameof(model.PhoneNumber), propertyExistsErrorMessage);
            }

            if (this.companies.PhoneNumberTaken(model.CompanyPhoneNumber))
            {
                this.ModelState.AddModelError(nameof(model.CompanyPhoneNumber), propertyExistsErrorMessage);
            }

            if (this.companies.EmailTaken(model.CompanyEmail))
            {
                this.ModelState.AddModelError(nameof(model.CompanyEmail), propertyExistsErrorMessage);
            }
            
            if (this.companies.NameTaken(model.CompanyName))
            {
                this.ModelState.AddModelError(nameof(model.CompanyName), propertyExistsErrorMessage);
            }

            if (this.companies.VatNumberTaken(model.VatNumber))
            {
                this.ModelState.AddModelError(nameof(model.VatNumber), propertyExistsErrorMessage);
            }

            if (!this.ModelState.IsValid)
            {
                model.Countries = this.countries.AllCountries();
                return View(model);
            }

            var city = this.cities.GetCity(model.PostCode, model.CityName, model.CountryId);
            var company = this.companies.Create(
                model.CompanyName, 
                model.CompanyPhoneNumber, 
                model.VatNumber, 
                model.CompanyEmail, 
                model.Address,
                model.Description,
                model.FirstName, 
                model.LastName, 
                city.Id, 
                country);

            var memberId = this.User.GetUserId();
            var memberEmail = this.User.GetEmail();
            var user = this.users.GetUserByEmail(memberEmail);
            var registeredOn = user.RegisteredOn;

            var premiumUser = this.users.CreatePremium(
                memberId, 
                model.FirstName, 
                model.LastName, 
                memberEmail, 
                model.PhoneNumber, 
                company.Id, 
                registeredOn);

            this.users.AddAsManager(premiumUser);
            this.companies.AddManager(premiumUser.Id, company.Id);

            TempData[GlobalMessageKey] = "Your company was added and your account was upgraded successfully! " +
                                         "Please logout in order to refresh your account status! Enjoy SteadyLogistics!";

            return RedirectToAction("News", "Home", new { area = "" });
        }
    }
}