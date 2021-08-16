namespace SteadyLogistic.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.TrailerType;

    public class TrailerType
    {
        public TrailerType()
        {
            Freights = new List<Freight>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(trailerTypeNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Freight> Freights { get; set; }
    }
}