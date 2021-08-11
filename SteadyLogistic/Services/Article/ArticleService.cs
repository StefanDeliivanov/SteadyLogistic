namespace SteadyLogistic.Services.Article
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using SteadyLogistic.Data;
    using SteadyLogistic.Data.Models;

    public class ArticleService : IArticleService
    {
        private readonly SteadyLogisticDbContext data;

        public ArticleService(SteadyLogisticDbContext data)
        {
            this.data = data;
        }

        public void Create(string author, string category, string title, string body, string imageUrl, DateTime publishedOn)
        {
            var article = new Article
            {
                Author = author,
                Category = category,
                Title = title,
                Body = body,
                ImageUrl = imageUrl,
                PublishedOn = publishedOn
            };

            data.Articles.Add(article);

            data.SaveChanges();
        }

        public ArticleQueryServiceModel All(int currentPage = 1, int articlesPerPage = int.MaxValue)
        {
            var articlesQuery = this.data.Articles
                .OrderByDescending(a => a.PublishedOn);

            var totalArticles = articlesQuery.Count();

            var articles = GetArticles(articlesQuery
                .Skip((currentPage - 1) * articlesPerPage)
                .Take(articlesPerPage)).ToList();

            return new ArticleQueryServiceModel
            {
                TotalArticles = totalArticles,
                CurrentPage = currentPage,
                ArticlesPerPage = articlesPerPage,
                AllArticles = articles
            };
        }
        private static IEnumerable<ArticleServiceModel> GetArticles (IQueryable<Article> query)
        {
            var articles = query
                .Select(a => new ArticleServiceModel
                {
                    Id = a.Id,
                    Author = a.Author,
                    Title = a.Title,
                    Body = a.Body,
                    Category = a.Category,
                    ImageUrl = a.ImageUrl,
                    PublishedOn = a.PublishedOn
                })
                .ToList();

            return articles;
        }

        public ArticleServiceModel Details(int id)
        {
            var article = this.data.Articles
                .Where(a => a.Id == id)
                .Select(b => new ArticleServiceModel
                {
                    Id = b.Id,
                    Author = b.Author,
                    Title = b.Title,
                    Body = b.Body,
                    Category = b.Category,
                    ImageUrl = b.ImageUrl,
                    PublishedOn = b.PublishedOn
                })
                .FirstOrDefault();

            return article;
        }

        public bool Delete(int id)
        {
            var article = this.data
               .Articles
               .Where(a => a.Id == id)
               .FirstOrDefault();

            try
            {
                this.data.Articles.Remove(article);

                this.data.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
            
            return true;
        }

        public bool ArticleExists(int id)
        {
            var article = this.data
                .Articles
                .Where(a => a.Id == id)
                .FirstOrDefault();

            if(article == null)
            {
                return false;
            }

            return true;
        }
    }
}