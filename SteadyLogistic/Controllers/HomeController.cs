namespace SteadyLogistic.Controllers
{
    using System;
    using System.Diagnostics;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SteadyLogistic.Infrastructure.Extensions;
    using SteadyLogistic.Models;
    using SteadyLogistic.Models.Home;
    using SteadyLogistic.Services.Message;
    using SteadyLogistic.Services.Article;

    using static WebConstants;

    [Authorize]
    public class HomeController : Controller
    {
        private readonly IArticleService articles;
        private readonly IMessageService messages;   

        public HomeController(
            IArticleService articles,
            IMessageService messages)
        {
            this.articles = articles;
            this.messages = messages;          
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contacts(ContactFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            var userId = this.User.GetUserId();
            var userEmail = this.User.GetEmail();
            var date = DateTime.UtcNow;
            this.messages.Create(userId, userEmail, model.FirstName, model.LastName, model.Title, model.Body, date);

            TempData[GlobalMessageKey] = "Thank you for your feedback!";

            return RedirectToAction(nameof(News));
        }

        public IActionResult Details(int id)
        {
            var article = this.articles.Details(id);
            if (article == null)
            {
                TempData[GlobalErrorKey] = "This article does not exist!";
                return RedirectToAction(nameof(News));
            }

            return View(article);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            if (this.User.IsMember())
            {
                return RedirectToAction("Index", "Member", new { area = "Member" });
            }

            return RedirectToAction(nameof(News));
        }

        public IActionResult News([FromQuery] NewsViewModel query)
        {
            var queryResult = this.articles.All(
                query.CurrentPage,
                NewsViewModel.ArticlesPerPage);

            query.TotalNews = queryResult.TotalArticles;
            query.News = queryResult.AllArticles;

            return View(query);
        }   
    }
}