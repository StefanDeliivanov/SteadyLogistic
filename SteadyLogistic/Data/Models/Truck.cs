namespace SteadyLogistic.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using SteadyLogistic.Data.Models.Interfaces;

    using static DataConstants.Truck;
    using static DataConstants.Vehicle;

    public class Truck : IVehicle
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

        public Company Company { get; set; }

        public int CompanyId { get; set; }
    }
}
