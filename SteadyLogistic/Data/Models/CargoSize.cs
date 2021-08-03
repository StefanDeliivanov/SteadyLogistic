namespace SteadyLogistic.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.CargoSize;

    public class CargoSize
    {

        public int Id { get; set; }

        [Required]
        [MaxLenght(cargoSizeNameMaxLenght)]
        public string Name { get; set; }
    }
}
