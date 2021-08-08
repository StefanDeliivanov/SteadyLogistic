namespace SteadyLogistic.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Freight;

    public class Freight
    {
        public Freight()
        {
            TrailerTypes = new List<TrailerType>();
            PublishedOn = DateTime.UtcNow;
        }

        public int Id { get; set; }

        [MaxLength(decriptionMaxLenght)]
        public string Description { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime PublishedOn { get; set; }

        [Required]
        public virtual Dimension Dimension { get; set; }

        public int DimensionId { get; set; }       

        [Required]
        public virtual CargoSize CargoSize { get; set; }

        public int CargoSizeId { get; set; }

        [Required]
        public virtual LoadUnloadInfo Loading { get; set; }

        public int LoadingId { get; set; }

        [Required]
        public virtual LoadUnloadInfo Unloading { get; set; }

        public int UnloadingId { get; set; }

        [Required]
        public virtual PremiumUser User { get; set; }

        public string UserId { get; set; }

        public ICollection<TrailerType> TrailerTypes { get; set; }
    }
}