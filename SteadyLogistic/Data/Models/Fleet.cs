namespace SteadyLogistic.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Fleet
    {
        public Fleet()
        {
            Trucks = new List<Truck>();
            Trailers = new List<Trailer>();
        }

        public int Id { get; set; }

        [Required]
        public Company Company { get; set; }

        public int CompanyId { get; set; }

        public ICollection<Truck> Trucks { get; set; }

        public ICollection<Trailer> Trailers { get; set; }
    }
}
