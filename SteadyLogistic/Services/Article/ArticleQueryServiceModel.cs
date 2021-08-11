namespace SteadyLogistic.Services.Article
{
    using System.Collections.Generic;

    public class ArticleQueryServiceModel
    {
        public int CurrentPage { get; init; }

        public int ArticlesPerPage { get; init; }

        public int TotalArticles { get; init; }

        public IEnumerable<ArticleServiceModel> AllArticles { get; init; }
    }
}