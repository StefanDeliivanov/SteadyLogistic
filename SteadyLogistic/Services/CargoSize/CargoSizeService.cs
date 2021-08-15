namespace SteadyLogistic.Services.CargoSize
{
    using System.Linq;
    using System.Collections.Generic;
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
                        .Select(x => new CargoSizeServiceModel
                        {
                            Id = x.Id,
                            Name = x.Name
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