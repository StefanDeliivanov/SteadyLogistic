namespace SteadyLogistic.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Dimension
    {
        public Dimension()
        {
            Freights = new List<Freight>();
        }

        public int Id { get; set; }

        [Required]
        public double Length { get; set; }

        [Required]
        public double Width { get; set; }

        [Required]
        public double Height { get; set; }

        public virtual ICollection<Freight> Freights { get; set; }
    }
}