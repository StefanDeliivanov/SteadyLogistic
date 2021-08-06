namespace SteadyLogistic.Areas.Member.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Area("Member")]
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UpgradeToPremium()
        {
            return View();
        }
    }
}