namespace SteadyLogistic.Models.Home
{
    using System.Collections.Generic;
    using SteadyLogistic.Services.Article;

    public class NewsViewModel
    {
        public const int ArticlesPerPage = 6;

        public int CurrentPage { get; init; } = 1;

        public int TotalNews { get; set; }

        public IEnumerable<ArticleServiceModel> News { get; set; }
    }
}