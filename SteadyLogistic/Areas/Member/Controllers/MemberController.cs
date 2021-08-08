namespace SteadyLogistic.Areas.Member.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SteadyLogistic.Areas.Member.Models;
    using SteadyLogistic.Data;
    using SteadyLogistic.Data.Models;
    using SteadyLogistic.Services.Country;
    using SteadyLogistic.Infrastructure.Extensions;

    using static AreaGlobalConstants.Roles;
    using System;

    [Area("Member")]
    [Authorize(Roles = MemberRoleName)]
    public class MemberController : Controller
    {
        private readonly SteadyLogisticDbContext data;
        private readonly ICountryService countries;

        public MemberController(
            SteadyLogisticDbContext data, 
            ICountryService countries)
        {
            this.data = data;
            this.countries = countries;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpgradeToPremium()
        {
            return View(new UpgradeToPremiumFormModel { Countries = countries.AllCountries() });
        }

        [HttpPost]
        public IActionResult UpgradeToPremium(UpgradeToPremiumFormModel premiumModel)
        {
            var memberId = this.User.GetUserId();
            var memberEmail = this.User.GetEmail();

            if (!this.countries.CountryExists(premiumModel.CountryId))
            {
                this.ModelState.AddModelError(nameof(premiumModel.CountryId), "Country does not exist.");
            }

            if (!ModelState.IsValid)
            {
                premiumModel.Countries = this.countries.AllCountries();

                return View(premiumModel);
            }

            var premiumUser = new PremiumUser
            {
                Id = new Guid().ToString(),
                UserId = memberId,
                FirstName = premiumModel.FirstName,
                LastName = premiumModel.LastName,
                Email = memberEmail,
                PhoneNumber = premiumModel.PhoneNumber,
                Company = new Company
                {
                    Name = premiumModel.CompanyName,
                    Address = premiumModel.Address,
                    VatNumber = premiumModel.VatNumber,
                    PhoneNumber = premiumModel.CompanyPhoneNumber,
                    Email = premiumModel.CompanyEmail,
                    CountryId = premiumModel.CountryId,
                    City = new City
                    {
                        Name = premiumModel.CityName,
                        PostCode = premiumModel.PostCode,
                    },
                    Manager = new Manager
                    {
                        UserId = memberId,
                    },
                }
            };

            data.PremiumUsers.Add(premiumUser);

            data.SaveChanges();

            return RedirectToAction("News", "Home");
        }
    }
}