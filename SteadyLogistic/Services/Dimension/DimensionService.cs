namespace SteadyLogistic.Services.Dimension
{
    using SteadyLogistic.Data;
    using SteadyLogistic.Data.Models;

    public class DimensionService : IDimensionService
    {
        private readonly SteadyLogisticDbContext data;

        public DimensionService(SteadyLogisticDbContext data)
        {
            this.data = data;
        }

        public Dimension Create(double length, double width, double height)
        {
            var dimension = new Dimension
            {
                Length = length,
                Width = width,
                Height = height
            };

            this.data.Dimensions.Add(dimension);
            this.data.SaveChanges();

            return dimension;
        }
    }
}