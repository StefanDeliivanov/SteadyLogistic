namespace SteadyLogistic.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.SLogisticsUser;
    using static DataConstants.Global;

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
        [MaxLength(emailMaxLenght)]
        public string Email { get; set; }

        [Required]
        [MaxLength(phoneNumberMaxLenght)]
        public string PhoneNumber { get; set; }

        [Required]
        public virtual Company Company { get; set; }

        public int CompanyId { get; set; }

        public string UserId { get; set; }

        //public virtual Manager Manager { get; set; }

        //public int ManagerId { get; set; }

        public virtual ICollection<Freight> Freights { get; set; }

        //public virtual ICollection<Manager> Managers { get; set; }
    }
}