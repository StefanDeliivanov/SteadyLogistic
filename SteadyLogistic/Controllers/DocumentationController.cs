namespace SteadyLogistic.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class DocumentationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}