namespace SteadyLogistic.Areas.Member.Models
{
    using System.ComponentModel.DataAnnotations;

    using static SteadyLogistic.Data.DataConstants.Global;
    using static SteadyLogistic.Data.DataConstants.PremiumUser;

    public class UpgradeToPremiumFormModel
    {

        public string Id { get; set; }

        [Required]
        [StringLength(nameMaxLenght, MinimumLength = nameMinLenght)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(nameMaxLenght, MinimumLength = nameMinLenght)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(emailMaxLenght, MinimumLength = emailMinLenght)]
        public string Email { get; set; }

        [Required]
        [RegularExpression(phoneNumberRegex)]
        [StringLength(phoneNumberMaxLenght, MinimumLength = phoneNumberMinLenght)]
        public string PhoneNumber { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
