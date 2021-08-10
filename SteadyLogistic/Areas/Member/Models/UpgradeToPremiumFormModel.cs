namespace SteadyLogistic.Areas.Member.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using SteadyLogistic.Services.Country;

    using static SteadyLogistic.Data.DataConstants.Global;
    using static SteadyLogistic.Data.DataConstants.Company;
    using static SteadyLogistic.Data.DataConstants.City;
    using static SteadyLogistic.Data.DataConstants.User;
    using static SteadyLogistic.Data.DataConstants.ErrorMessages;
    using static SteadyLogistic.Data.DataConstants.Displays;

    public class UpgradeToPremiumFormModel
    {
        #region User

        [Required(ErrorMessage = requiredErrorMessage)]
        [StringLength(nameMaxLength, MinimumLength = nameMinLength,
            ErrorMessage = defaultErrorMessage)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [StringLength(nameMaxLength, MinimumLength = nameMinLength,
            ErrorMessage = defaultErrorMessage)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = emailErrorMessage)]
        [StringLength(emailMaxLength, MinimumLength = emailMinLength,
            ErrorMessage = emailErrorMessage)]
        [Display(Name = emailDisplay)]
        public string Email { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [RegularExpression(phoneNumberRegex, ErrorMessage = phoneNumberErrorMessage)]
        [StringLength(phoneNumberMaxLength, MinimumLength = phoneNumberMinLength,
            ErrorMessage = defaultErrorMessage)]
        [Display(Name = phoneNumberDisplay)]
        public string PhoneNumber { get; set; }

        #endregion

        #region Company

        [Required(ErrorMessage = requiredErrorMessage)]
        [StringLength(companyNameMaxLength, MinimumLength = companyNameMinLength,
            ErrorMessage = defaultErrorMessage)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [StringLength(vatNumberMaxLength, MinimumLength = vatNumberMinLength,
            ErrorMessage = defaultErrorMessage)]
        [Display(Name = "Vat Number")]
        public string VatNumber { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [StringLength(addressMaxLength, MinimumLength = addressMinLength,
            ErrorMessage = defaultErrorMessage)]
        public string Address { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [RegularExpression(phoneNumberRegex, ErrorMessage = phoneNumberErrorMessage)]
        [StringLength(phoneNumberMaxLength, MinimumLength = phoneNumberMinLength,
            ErrorMessage = defaultErrorMessage)]
        [Display(Name = phoneNumberDisplay)]
        public string CompanyPhoneNumber { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [EmailAddress(ErrorMessage = emailErrorMessage)]
        [StringLength(emailMaxLength, MinimumLength = emailMinLength,
            ErrorMessage = emailErrorMessage)]
        [Display(Name = emailDisplay)]
        public string CompanyEmail { get; set; }

        #endregion

        #region City

        [Required(ErrorMessage = requiredErrorMessage)]
        [StringLength(cityNameMaxLength, MinimumLength = cityNameMinLength,
            ErrorMessage = defaultErrorMessage)]
        [Display(Name = "City Name")]
        public string CityName { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [StringLength(cityPostCodeMaxLength, MinimumLength = cityPostCodeMinLength,
            ErrorMessage = defaultErrorMessage)]
        [Display(Name = "Post Code")]
        public string PostCode { get; set; }

        #endregion

        [Required(ErrorMessage = requiredErrorMessage)]
        [Display(Name = countryDisplay)]
        public int CountryId { get; set; }

        public ICollection<CountryServiceModel> Countries { get; set; }
    }
}