namespace SteadyLogistic.Services.CargoSize
{
    using System.Collections.Generic;

    public interface ICargoSizeService
    {
        public ICollection<CargoSizeServiceModel> AllCargoSizes();

        public ICollection<string> AllCargoSizeNames();

        public bool Exists(int cargoSizeId); 
    }
}