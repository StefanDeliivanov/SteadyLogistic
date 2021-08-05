namespace SteadyLogistic.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Manager
    {
        public int Id { get; set; }

        [Required]
        public virtual SLogisticsUser User { get; set; }

        public string UserId { get; set; }

        [Required]
        public virtual Company Company { get; set; }

        public int CompanyId { get; set; }
    }
}