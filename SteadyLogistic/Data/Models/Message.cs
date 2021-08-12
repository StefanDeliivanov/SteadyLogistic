namespace SteadyLogistic.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Global;  
    using static DataConstants.Message;

    public class Message
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(contactNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(contactNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(emailMaxLength)]
        public string Email { get; set; }

        [Required]
        public string UserID { get; set; }

        [Required]
        [MaxLength(titleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(bodyMaxLength)]
        public string Body { get; set; }

        public DateTime SendOn { get; set; }
    }
}