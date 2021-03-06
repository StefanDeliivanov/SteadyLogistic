namespace SteadyLogistic.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Freight;

    public class Freight
    {
        public int Id { get; set; }

        [MaxLength(descriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime PublishedOn { get; set; }

        [Required]
        public virtual TrailerType TrailerType { get; set; }

        public int TrailerTypeId { get; set; }

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
    }
}