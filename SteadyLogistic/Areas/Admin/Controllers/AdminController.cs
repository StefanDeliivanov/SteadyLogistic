namespace SteadyLogistic.Areas.Admin.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using SteadyLogistic.Areas.Admin.Models;
    using SteadyLogistic.Services.Article;
    using SteadyLogistic.Services.Message;

    using static AreaGlobalConstants.Roles;
    using static WebConstants;

    [Authorize]
    [Area("Admin")]    
    public class AdminController : Controller
    {
        private readonly IArticleService articles;
        private readonly IMessageService messages;

        public AdminController(
            IArticleService articles,
            IMessageService messages)
        {
            this.articles = articles;
            this.messages = messages;
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
        public IActionResult Messages([FromQuery] MessagesViewModel query)
        {
            var queryResult = this.messages.All(
                query.CurrentPage,
                MessagesViewModel.MessagesPerPage);


            query.TotalMessages = queryResult.TotalMessages;
            query.Messages = queryResult.AllMessages;

            return View(query);
        }

        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult MessageDetails(int id)
        {
            var message = this.messages.Details(id);

            if (message == null)
            {
                TempData[GlobalErrorKey] = "This message does not exist!";

                return RedirectToAction(nameof(Messages));
            }

            return View(message);
        }

        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult MessageDelete (int id)
        {
            if (!this.messages.MessageExists(id))
            {
                TempData[GlobalMessageKey] = "The requested message does not exist!";

                return RedirectToAction(nameof(Messages));
            }

            if (this.messages.Delete(id))
            {
                TempData[GlobalMessageKey] = "Message was deleted successfully!";

                return RedirectToAction(nameof(Messages));
            }

            TempData[GlobalErrorKey] = "Something went wrong! Please try again";

            return RedirectToAction(nameof(MessageDetails), id);
        }
    }
}