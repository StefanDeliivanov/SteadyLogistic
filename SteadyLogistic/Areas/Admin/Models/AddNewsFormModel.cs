namespace SteadyLogistic.Areas.Admin.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Article;
    using static Data.DataConstants.Displays;
    using static Data.DataConstants.ErrorMessages;

    public class AddNewsFormModel
    {
        [Required(ErrorMessage = requiredErrorMessage)]
        [StringLength(authorNameMaxLength, MinimumLength = authorNameMinLength,
            ErrorMessage = defaultErrorMessage)]
        public string Author { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [StringLength(categoryMaxLength, MinimumLength = categoryMinLength,
            ErrorMessage = defaultErrorMessage)]
        public string Category { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [StringLength(articleTitleMaxLength, MinimumLength = articleTitleMinLength,
             ErrorMessage = defaultErrorMessage)]
        public string Title { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [StringLength(articleBodyMaxLength, MinimumLength = articleBodyMinLength,
            ErrorMessage = defaultErrorMessage)]
        public string Body { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [Url]
        [Display(Name = urlDisplay)]
        public string ImageUrl { get; set; }
    }
}