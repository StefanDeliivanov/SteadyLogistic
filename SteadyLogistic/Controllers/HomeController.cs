namespace SteadyLogistic.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using SteadyLogistic.Data.Models;
    using SteadyLogistic.Models;
    

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Random()
        {
            var stoti = new SLogisticsUser();
            //stoti.

            return View();
        }


        public IActionResult Index()
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
