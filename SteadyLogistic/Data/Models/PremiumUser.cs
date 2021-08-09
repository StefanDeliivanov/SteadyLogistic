namespace SteadyLogistic.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.PremiumUser;
    using static DataConstants.Global;

    public class PremiumUser
    {
        public PremiumUser()
        {
            Freights = new List<Freight>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(nameMaxLenght)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(nameMaxLenght)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(emailMaxLenght)]
        public string Email { get; set; }

        [Required]
        [MaxLength(phoneNumberMaxLenght)]
        public string PhoneNumber { get; set; }

        public virtual Company Company { get; set; }

        public int CompanyId { get; set; }

        public string UserId { get; set; }

        public virtual ICollection<Freight> Freights { get; set; }
    }
}