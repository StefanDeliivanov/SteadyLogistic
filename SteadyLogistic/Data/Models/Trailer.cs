namespace SteadyLogistic.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using SteadyLogistic.Data.Models.Interfaces;

    using static DataConstants.Vehicle;

    public class Trailer : IVehicle
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(plateNumbersMaxLenght)]
        public string PlateNumber { get; set; }

        [Required]
        [MaxLength(brandNameMaxLenght)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(modelNameMaxLenght)]
        public string Model { get; set; }

        [Required]
        [MaxLength(vehicleMaxWeight)]
        public int Weight { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public int Height { get; set; }

        [Required]
        public virtual Company Company { get; set; }

        public int CompanyId { get; set; }
    }
}
