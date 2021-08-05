﻿namespace SteadyLogistic.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.TrailerType;

    public class TrailerType
    {
        public TrailerType()
        {
            Trailers = new List<Trailer>();
            Freights = new List<Freight>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(trailerTypeNameMaxLenght)]
        public string Name { get; set; }

        public virtual ICollection<Trailer> Trailers { get; set; }

        public virtual ICollection<Freight> Freights { get; set; }
    }
}