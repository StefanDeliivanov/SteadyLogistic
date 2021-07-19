namespace SteadyLogistic.Data.Models
{
    using SteadyLogistic.Data.Models.Interfaces;

    public class Truck : IVehicle
    {
        public int Id { get; set; }

        public string PlateNumber { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Weight { get; set; }
    }
}
