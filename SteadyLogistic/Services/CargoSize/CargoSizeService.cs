namespace SteadyLogistic.Services.CargoSize
{
    using System.Collections.Generic;
    using System.Linq;
    using SteadyLogistic.Data;

    public class CargoSizeService : ICargoSizeService
    {
        private readonly SteadyLogisticDbContext data;

        public CargoSizeService(SteadyLogisticDbContext data)
        {
            this.data = data;
        }

        public ICollection<CargoSizeServiceModel> AllCargoSizes()
        {
            return this.data
                .CargoSizes
                .Select(a => new CargoSizeServiceModel
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .ToList();
        }

        public ICollection<string> AllCargoSizeNames()
        {
            return this.data
                .CargoSizes
                .Select(a => a.Name)
                .OrderBy(b => b)
                .ToList();
        }

        public bool Exists(int cargoSizeId)
        {
            return this.data
                .CargoSizes
                .Any(a => a.Id == cargoSizeId);
        }
    }
}