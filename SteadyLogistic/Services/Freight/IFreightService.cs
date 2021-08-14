namespace SteadyLogistic.Services.Freight
{
    using System.Collections.Generic;
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

        public bool Delete(int id);

        public bool Exists(int id);

        public bool IsAuthorized(int freightId, string userId);

        public FreightQueryServiceModel GetFreightsByUser(string userId, int currentPage = 1, int freightsPerPage = int.MaxValue);

        public FreightQueryServiceModel GetCompanyFreightsByUser(string userId, int currentPage = 1, int freightsPerPage = int.MaxValue);
    } 
}