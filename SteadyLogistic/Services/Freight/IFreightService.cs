namespace SteadyLogistic.Services.Freight
{
    using SteadyLogistic.Data.Models;

    public interface IFreightService
    {

        public void Create(
            string Description, 
            double Weight, 
            decimal Price, 
            int trailerTypeId, 
            int cargoSizeId, 
            Dimension dimension,
            LoadUnloadInfo loading, 
            LoadUnloadInfo unloading, 
            string userId);

        public FreightQueryServiceModel All(int currentPage = 1, int freightsPerPage = int.MaxValue);

        public FreightDetailsServiceModel Details(int id);
    } 
}