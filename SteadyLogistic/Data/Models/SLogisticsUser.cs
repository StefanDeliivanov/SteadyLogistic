namespace SteadyLogistic.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    using static DataConstants.SLogisticsUser;

    public class SLogisticsUser : IdentityUser
    {

        [Required]
        [MaxLength(usernameMaxLenght)]
        public override string UserName { get; set; }

        [Required]
        public override string Email { get; set; }

        [Required]
        public override string PhoneNumber { get; set; }

        [Required]
        public virtual Company Company { get; set; }

        public int CompanyId { get; set; }

        public ICollection<Freight> Freights { get; set; }
    }
}
