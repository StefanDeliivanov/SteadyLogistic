namespace SteadyLogistic.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.CargoSize;

    public class CargoSize
    {
        public CargoSize()
        {
            Freights = new List<Freight>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(cargoSizeNameMaxLenght)]
        public string Name { get; set; }

        public virtual ICollection<Freight> Freights { get; set; }
    }
}