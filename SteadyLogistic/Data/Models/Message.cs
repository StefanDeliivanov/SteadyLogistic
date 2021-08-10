namespace SteadyLogistic.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.User;
    using static DataConstants.Global;  
    using static DataConstants.Message;

    public class Message
    {

        public int Id { get; set; }

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
        public string UserID { get; set; }

        [Required]
        [MaxLength(titleMaxLenght)]
        public string Title { get; set; }

        [Required]
        [MaxLength(bodyMaxLenght)]
        public string Body { get; set; }

        public DateTime SendOn { get; set; }
    }
}