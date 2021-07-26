namespace SteadyLogistic.Data.Models.Interfaces
{

    public interface IVehicle
    {
        public int Id { get; set; }

        public string PlateNumber { get; set; }

        public string Brand { get; set; }

        public string  Model { get; set; }

        public int Weight { get; set; }

        public Company Company { get; set; }

        public int CompanyId { get; set; }
    }
}
