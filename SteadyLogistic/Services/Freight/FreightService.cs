namespace SteadyLogistic.Services.Freight
{
    using System;
    using SteadyLogistic.Data;
    using SteadyLogistic.Data.Models;

    public class FreightService : IFreightService
    {
        private readonly SteadyLogisticDbContext data;

        public FreightService(SteadyLogisticDbContext data)
        {
            this.data = data;
        }

        public void Create(
            string description,
            double weight,
            decimal price,
            int trailerTypeId,
            int cargoSizeId,
            Dimension dimension,
            LoadUnloadInfo loading,
            LoadUnloadInfo unloading,
            string userId)
        {
            var freight = new Freight()
            {
                Description = description,
                Weight = weight,
                Price = price,
                TrailerTypeId = trailerTypeId,
                CargoSizeId = cargoSizeId,
                Dimension = dimension,
                Loading = loading,
                Unloading = unloading,
                UserId = userId,
                PublishedOn = DateTime.UtcNow,
            };

            this.data.Freights.Add(freight);
            this.data.SaveChanges();
        }
    }
}