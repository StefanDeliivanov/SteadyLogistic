namespace SteadyLogistic.Services.Dimension
{
    using SteadyLogistic.Data.Models;

    public interface IDimensionService
    {
        public Dimension Create(double length, double width, double height);
    }
}