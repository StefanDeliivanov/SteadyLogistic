namespace SteadyLogistic.Areas.Member.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}