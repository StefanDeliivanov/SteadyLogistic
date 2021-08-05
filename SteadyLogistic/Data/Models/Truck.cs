namespace SteadyLogistic.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using SteadyLogistic.Data.Models.Interfaces;

    using static DataConstants.Vehicle;

    public class Truck : IVehicle
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
        public double Weight { get; set; }

        [Required]
        public Fleet Fleet { get; set; }

        public int FleetId { get; set; }
    }
}