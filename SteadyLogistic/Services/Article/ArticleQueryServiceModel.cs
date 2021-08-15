namespace SteadyLogistic.Services.Article
{
    using System.Collections.Generic;

    public class ArticleQueryServiceModel
    {
        public int CurrentPage { get; set; }

        public int ArticlesPerPage { get; set; }

        public int TotalArticles { get; set; }

        public IEnumerable<ArticleServiceModel> AllArticles { get; set; }
    }
}