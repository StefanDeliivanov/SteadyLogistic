namespace SteadyLogistic.Models.Home
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.User;
    using static Data.DataConstants.Message;
    using static Data.DataConstants.ErrorMessages;

    public class ContactFormModel
    {

        [Required(ErrorMessage = requiredErrorMessage)]
        [StringLength(nameMaxLenght, MinimumLength = nameMinLenght,
            ErrorMessage = defaultErrorMessage)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [StringLength(nameMaxLenght, MinimumLength = nameMinLenght,
            ErrorMessage = defaultErrorMessage)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [StringLength(titleMaxLenght, MinimumLength = titleMinLenght,
            ErrorMessage = defaultErrorMessage)]
        public string Title { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [StringLength(bodyMaxLenght, MinimumLength = bodyMinLenght,
            ErrorMessage = defaultErrorMessage)]
        public string Body { get; set; }
    }
}