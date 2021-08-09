namespace SteadyLogistic.Data.Models.Interfaces
{
    public interface IVehicle
    {

        public int Id { get; set; }

        public string PlateNumber { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public double Weight { get; set; }

        public Fleet Fleet { get; set; }

        public int FleetId { get; set; }
    }
}