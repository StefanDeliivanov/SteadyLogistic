namespace SteadyLogistic.Data.Models
{
    using SteadyLogistic.Data.Models.Interfaces;

    public class Trailer : IVehicle
    {
        public int Id { get; set; }

        public string PlateNumber { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Weight { get; set; }

        public string Type { get; set; }

        public int Capacity { get; set; }

        public int Height { get; set; }

        public Company Company { get; set; }

        public int CompanyId { get; set; }
    }
}
