namespace SteadyLogistic.Services.Freight
{
    using SteadyLogistic.Data.Models;
    using SteadyLogistic.Models.FreightExchange;

    public interface IFreightService
    {
        public FreightQueryServiceModel All(
            string loadingCountryCode = null,
            string unloadingCountryCode = null,
            string cargoSize = null,
            string trailerType = null,
            string searchTerm = null,
            FreightSorting sorting = FreightSorting.PublishedOnDescending,
            int currentPage = 1,
            int freightsPerPage = int.MaxValue);

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

        public bool Delete(int id);

        public FreightDetailsServiceModel Details(int id);     

        public bool Exists(int id);

        public FreightQueryServiceModel GetCompanyFreightsByUser(string userId, int currentPage = 1, int freightsPerPage = int.MaxValue);

        public FreightQueryServiceModel GetFreightsByUser(string userId, int currentPage = 1, int freightsPerPage = int.MaxValue);

        public bool IsAuthorized(int freightId, string userId);       
    }
}