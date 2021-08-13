namespace SteadyLogistic.Services.Freight
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

        public FreightQueryServiceModel All(int currentPage = 1, int freightsPerPage = int.MaxValue)
        {
            var freightsQuery = this.data.Freights
                .OrderByDescending(a => a.PublishedOn);

            var totalFreights = freightsQuery.Count();

            var freights = GetFreights(freightsQuery
                .Skip((currentPage - 1) * freightsPerPage)
                .Take(freightsPerPage)).ToList();

            return new FreightQueryServiceModel
            {
                TotalFreights = totalFreights,
                CurrentPage = currentPage,
                FreightsPerPage = freightsPerPage,
                AllFreights = freights
            };
        }

        private static IEnumerable<FreightServiceModel> GetFreights (IQueryable<Freight> query)
        {
            var freights = query
                .Select(a => new FreightServiceModel
                {
                    Id = a.Id,
                    LoadingCountryCode = a.Loading.Country.Code,
                    LoadingCityName = a.Loading.City.Name,
                    UnloadingCountryCode = a.Unloading.Country.Code,
                    UnloadingCityName = a.Unloading.City.Name,
                    UserId = a.User.Id,
                    UserFullName = a.User.FirstName + " " + a.User.LastName,
                    CompanyName = a.User.Company.Name,
                    PublishedOn = a.PublishedOn,
                    LoadingDate = a.Loading.Date
                })
                .ToList();

            return freights;
        }
    }
}