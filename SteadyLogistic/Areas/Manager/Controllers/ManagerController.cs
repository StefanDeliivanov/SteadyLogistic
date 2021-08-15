namespace SteadyLogistic.Areas.Manager.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SteadyLogistic.Areas.Manager.Models;
    using SteadyLogistic.Services.User;
    using SteadyLogistic.Infrastructure.Extensions;

    using static AreaGlobalConstants.Roles;
    using static SteadyLogistic.Data.DataConstants.ErrorMessages;
    using static WebConstants;

    [Authorize]
    [Area("Manager")]
    public class ManagerController : Controller
    {
        private readonly IUserService users;

        public ManagerController(IUserService users)
        {
            this.users = users;
        }

        [HttpGet]
        [Authorize(Roles = ManagerRoleName)]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = ManagerRoleName)]
        public IActionResult AddEmployee(AddEmployeeFormModel model)
        {
            if (users.PhoneNumberTaken(model.PhoneNumber))
            {
                this.ModelState.AddModelError(nameof(model.PhoneNumber), propertyExistsErrorMessage);
            }

            if (users.EmailTaken(model.Email))
            {
                this.ModelState.AddModelError(nameof(model.Email), propertyExistsErrorMessage);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!users.CreateUser(model.Email, model.Password))
            {
                this.ModelState.AddModelError("User", userRegisterFailedErrorMessage);
                return View(model);
            }

            var managerId = this.User.GetUserId();
            var user = users.GetUserByEmail(model.Email);
            var companyId = users.GetCompanyIdByPremiumUserId(managerId);
            var registeredOn = user.RegisteredOn;

            var premiumUser = users.CreatePremium(user.Id, model.FirstName, model.LastName, model.Email, model.PhoneNumber, companyId, registeredOn);
            users.AddAsEmployee(premiumUser);

            TempData[GlobalMessageKey] = "Employee was added successfully to your company";

            return RedirectToAction("News", "Home", new { area = "" });
        }
    }
}