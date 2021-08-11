namespace SteadyLogistic.Areas.Admin.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using SteadyLogistic.Areas.Admin.Models;
    using SteadyLogistic.Services.Article;

    using static AreaGlobalConstants.Roles;
    using static WebConstants;

    [Authorize]
    [Area("Admin")]    
    public class AdminController : Controller
    {
        private readonly IArticleService articles;

        public AdminController(IArticleService articles)
        {
            this.articles = articles;
        }

        [HttpGet]
        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult AddNews()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult AddNews(AddNewsFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var date = DateTime.UtcNow;

            articles.Create(model.Author, model.Category, model.Title, model.Body, model.ImageUrl, date);

            TempData[GlobalMessageKey] = "Article added successfully to news";

            return RedirectToAction("News", "Home", new { area = "" });
        }

        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult Delete(int id)
        {
            if (!this.articles.ArticleExists(id))
            {
                TempData[GlobalMessageKey] = "The requested article does not exist!";

                return RedirectToAction("News", "Home", new { area = "" });
            }

            if (this.articles.Delete(id))
            {
                TempData[GlobalMessageKey] = "Article was deleted successfully!";

                return RedirectToAction("News", "Home", new { area = "" });
            }

            TempData[GlobalErrorKey] = "Something went wrong! Please try again";

            return RedirectToAction("News", "Details", id);
        }

        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult Messages()
        {
            return View();
        }
    }
}