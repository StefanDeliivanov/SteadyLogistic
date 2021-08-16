namespace SteadyLogistic.Services.Article
{
    using System;

    public interface IArticleService
    {
        public ArticleQueryServiceModel All(int currentPage = 1, int articlesPerPage = int.MaxValue);

        public bool ArticleExists(int id);

        public void Create(string author, string category, string title, string body, string imageUrl, DateTime publishedOn);

        public bool Delete(int id);

        public ArticleServiceModel Details(int id);  
    }
}