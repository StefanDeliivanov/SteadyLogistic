namespace SteadyLogistic.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SteadyLogistic.Models;

    using static Areas.AreaGlobalConstants.Roles;

    public class HomeController : Controller
    {
        
        
        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "AdministratorRoleName, PremiumRoleName, ManagerRoleName")]
        public IActionResult News()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
