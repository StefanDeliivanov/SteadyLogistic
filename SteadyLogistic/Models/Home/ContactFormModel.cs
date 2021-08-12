namespace SteadyLogistic.Models.Home
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Message;
    using static Data.DataConstants.Displays;
    using static Data.DataConstants.ErrorMessages;

    public class ContactFormModel
    {

        [Required(ErrorMessage = requiredErrorMessage)]
        [StringLength(contactNameMaxLength, MinimumLength = contactNameMinLength,
            ErrorMessage = defaultErrorMessage)]
        [Display(Name = firstNameDisplay)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [StringLength(contactNameMaxLength, MinimumLength = contactNameMinLength,
            ErrorMessage = defaultErrorMessage)]
        [Display(Name = lastNameDisplay)]
        public string LastName { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [StringLength(titleMaxLength, MinimumLength = titleMinLength,
            ErrorMessage = defaultErrorMessage)]
        public string Title { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [StringLength(bodyMaxLength, MinimumLength = bodyMinLength,
            ErrorMessage = defaultErrorMessage)]
        public string Body { get; set; }
    }
}