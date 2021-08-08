namespace SteadyLogistic.Areas.Member.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SteadyLogistic.Areas.Member.Models;
    using SteadyLogistic.Data;

    [Area("Member")]
    public class MemberController : Controller
    {
        private readonly SteadyLogisticDbContext data;

        public MemberController(SteadyLogisticDbContext data)
        {
            this.data = data;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UpgradeToPremium()
        {
            data.SaveChanges();
            return View();
        }

        [HttpPost]
        public IActionResult UpgradeToPremium(UpgradeToPremiumFormModel premiumModel)
        {
            return View();
        }
    }
}