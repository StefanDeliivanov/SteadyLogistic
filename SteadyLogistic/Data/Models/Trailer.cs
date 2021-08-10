namespace SteadyLogistic.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using SteadyLogistic.Data.Models.Interfaces;

    using static DataConstants.Vehicle;

    public class Trailer : IVehicle
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(plateNumbersMaxLength)]
        public string PlateNumber { get; set; }

        [Required]
        [MaxLength(brandNameMaxLength)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(modelNameMaxLength)]
        public string Model { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public virtual Dimension Dimension { get; set; }

        public int DimensionId {get;set;}

        [Required]
        public virtual TrailerType Type { get; set; }

        public int TypeId { get; set; }

        [Required]
        public virtual  Fleet Fleet { get; set; }

        public int FleetId { get; set; }
    }
}