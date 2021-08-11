namespace SteadyLogistic.Services.Article
{
    using System;

    public interface IArticleService
    {

        public void Create(string author, string category, string title, string body, string imageUrl, DateTime publishedOn);

        public ArticleQueryServiceModel All(int currentPage = 1, int articlesPerPage = int.MaxValue);

        public ArticleServiceModel Details(int id);

        public bool Delete(int id);

        public bool ArticleExists(int id);
    }
}