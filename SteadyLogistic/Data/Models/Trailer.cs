namespace SteadyLogistic.Data.Models
{
    using SteadyLogistic.Data.Models.Interfaces;

    using static DataConstants.Vehicle;
    using static DataConstants.Trailer;
    using System.ComponentModel.DataAnnotations;

    public class Trailer : IVehicle
    {
        [Required]
        [Key]
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
        public Company Company { get; set; }

        public int CompanyId { get; set; }
    }
}
