namespace SteadyLogistic.Services.Article
{
    using System;

    public class ArticleServiceModel
    {
        public int Id { get; set; }

        public string Author { get; set; }
        
        public string Category { get; set; }
   
        public string Title { get; set; }
     
        public string Body { get; set; }

        public string ImageUrl { get; set; }

        public DateTime PublishedOn { get; set; }
    }
}