﻿namespace SteadyLogistic.Data.Models
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
        public virtual Company Company { get; set; }

        public int CompanyId { get; set; }

        public virtual ICollection<Truck> Trucks { get; set; }

        public virtual ICollection<Trailer> Trailers { get; set; }
    }
}