namespace SteadyLogistic.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Freight;

    public class Freight
    {

        public int Id { get; init; }

        [MaxLength(decriptionMaxLenght)]
        public string Description { get; set; }

        [Required]
        public string CargoType { get; set; }

        [Required]
        public double Dimensions { get; set; }

        [Required]
        public int Weight { get; set; }

        [Required]
        public string TransportType { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime PublishedOn { get; init; }

        [Required]
        public LoadUnloadInfo Loading { get; set; }

        public int LoadingId { get; set; }

        [Required]
        public LoadUnloadInfo Unloading { get; set; }

        public int UnloadingId { get; set; }

        [Required]
        public SLogisticsUser User { get; set; }

        public string UserId { get; set; }

    }
}
