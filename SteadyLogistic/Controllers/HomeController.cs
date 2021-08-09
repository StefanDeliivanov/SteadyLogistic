namespace SteadyLogistic.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SteadyLogistic.Models;
    using SteadyLogistic.Infrastructure.Extensions;

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
                return RedirectToAction("Index", "Member", new { area = "Member" });
            }
            else
            {
                return RedirectToAction(nameof(News));
            }
        }

        public IActionResult News()
        {
            return View();
        }

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
