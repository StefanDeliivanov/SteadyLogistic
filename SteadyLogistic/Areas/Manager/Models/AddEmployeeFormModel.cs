namespace SteadyLogistic.Areas.Manager.Models
{
    using System.ComponentModel.DataAnnotations;

    using static SteadyLogistic.Data.DataConstants.Displays;
    using static SteadyLogistic.Data.DataConstants.ErrorMessages;
    using static SteadyLogistic.Data.DataConstants.Global;
    using static SteadyLogistic.Data.DataConstants.User;

    public class AddEmployeeFormModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [StringLength(nameMaxLength, MinimumLength = nameMinLength,
                    ErrorMessage = defaultErrorMessage)]
        [Display(Name = firstNameDisplay)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [StringLength(nameMaxLength, MinimumLength = nameMinLength,
            ErrorMessage = defaultErrorMessage)]
        [Display(Name = lastNameDisplay)]
        public string LastName { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [EmailAddress(ErrorMessage = emailErrorMessage)]
        [StringLength(emailMaxLength, MinimumLength = emailMinLength,
            ErrorMessage = emailErrorMessage)]
        [Display(Name = emailDisplay)]
        public string Email { get; set; }

        [Required]
        [StringLength(passwordMaxLength, MinimumLength = passwordMinLength,
                ErrorMessage = passwordErrorMessage)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = confirmPassword)]
        [Compare("Password", ErrorMessage = confirmPasswordErrorMessage)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [RegularExpression(phoneNumberRegex, ErrorMessage = phoneNumberErrorMessage)]
        [StringLength(phoneNumberMaxLength, MinimumLength = phoneNumberMinLength,
            ErrorMessage = defaultErrorMessage)]
        [Display(Name = phoneNumberDisplay)]
        public string PhoneNumber { get; set; }

        public int CompanyId { get; set; }

        public string UserId { get; set; }
    }
}