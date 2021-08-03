namespace SteadyLogistic.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.SLogisticsUser;

    public class SLogisticsUser
    {
        public SLogisticsUser()
        {
            Freights = new List<Freight>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(usernameMaxLenght)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(usernameMaxLenght)]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public virtual Company Company { get; set; }

        public int CompanyId { get; set; }

        public User User { get; set; }

        public string UserId { get; set; }

        public ICollection<Freight> Freights { get; set; }
    }
}
