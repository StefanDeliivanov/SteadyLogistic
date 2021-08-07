namespace SteadyLogistic.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SteadyLogistic.Models;
    using SteadyLogistic.Infrastructure.Extensions;

    using static Areas.AreaGlobalConstants.Roles;

    [Authorize]
    public class HomeController : Controller
    {  
        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            if (User.IsMember())
            {
                return Redirect("/Member/Member/Index");
            }
            return View();
        }

        [Authorize(Roles = "NotAMemberRoleName")]
        public IActionResult News()
        {
            return View();
        }

        [Authorize(Roles = "NotAMemberRoleName")]
        public IActionResult Contacts()
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
