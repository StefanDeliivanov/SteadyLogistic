namespace SteadyLogistic.Services.CargoSize
{
    using System.Collections.Generic;

    public interface ICargoSizeService
    {

        public ICollection<CargoSizeServiceModel> AllCargoSizes();

        public bool Exists(int cargoSizeId);

        public ICollection<string> AllCargoSizeNames();
    }
}
