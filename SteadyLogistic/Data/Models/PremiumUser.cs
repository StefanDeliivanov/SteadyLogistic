namespace SteadyLogistic.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Global;
    using static DataConstants.User; 

    public class PremiumUser
    {
        public PremiumUser()
        {
            Freights = new List<Freight>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(nameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(nameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(emailMaxLength)]
        public string Email { get; set; }

        [Required]
        [MaxLength(phoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        public virtual Company Company { get; set; }

        public int CompanyId { get; set; }

        public string UserId { get; set; }

        public virtual ICollection<Freight> Freights { get; set; }
    }
}