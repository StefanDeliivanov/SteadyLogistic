namespace SteadyLogistic.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Article;

    public class Article
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(authorNameMaxLength)]
        public string Author { get; set; }  

        [Required]
        [MaxLength(categoryMaxLength)]
        public string Category { get; set; }

        [Required]
        [MaxLength(articleTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(articleBodyMaxLength)]
        public string Body { get; set; }

        public string ImageUrl { get; set; }

        public DateTime PublishedOn { get; set; }
    }
}