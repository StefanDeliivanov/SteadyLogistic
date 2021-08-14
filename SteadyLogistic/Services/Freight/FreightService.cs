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

        public FreightDetailsServiceModel Details(int id)
        {
            var freight = this.data.Freights
                .Where(a => a.Id == id)
                .Select(b => new FreightDetailsServiceModel
                {
                    Id = b.Id,
                    Description = b.Description,
                    Price = b.Price,                 
                    TrailerType = b.TrailerType.Name,
                    CargoSize = b.CargoSize.Name,
                    Weight = b.Weight,
                    Length = b.Dimension.Length,
                    Width = b.Dimension.Width,
                    Height = b.Dimension.Height,
                    LoadingCountryCode = b.Loading.Country.Code,
                    LoadingCountryName = b.Loading.Country.Name,
                    LoadingCityName = b.Loading.City.Name,
                    LoadingCityCode = b.Loading.City.PostCode,
                    LoadingDate = b.Loading.Date,
                    UnloadingCountryCode = b.Unloading.Country.Code,
                    UnloadingCountryName = b.Unloading.Country.Name,
                    UnloadingCityName = b.Unloading.City.Name,
                    UnloadingCityCode = b.Unloading.City.PostCode,
                    UnloadingDate = b.Unloading.Date,
                    PublishedOn = b.PublishedOn,
                    UserId = b.User.Id,
                    UserFullName = b.User.FirstName + " " + b.User.LastName,
                    UserPhoneNumber = b.User.PhoneNumber,
                    UserEmail = b.User.Email,
                    CompanyId = b.User.Company.Id,
                    CompanyName = b.User.Company.Name,
                    CompanyPhoneNumber = b.User.Company.PhoneNumber,
                    CompanyEmail = b.User.Company.Email
                })
                .FirstOrDefault();

            return freight;
        }

        public bool Delete(int id)
        {
            var freight = this.data
               .Freights
               .Where(a => a.Id == id)
               .FirstOrDefault();

            try
            {
                this.data.Freights.Remove(freight);
                this.data.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool Exists(int id)
        {
            var freight = this.data
                .Freights
                .Where(a => a.Id == id)
                .FirstOrDefault();

            if (freight == null)
            {
                return false;
            }

            return true;
        }

        public bool IsAuthorized(int freightId, string userId)
        {
            var freight = this.data.Freights
                .Where(a => a.Id == freightId)
                .FirstOrDefault();

            if (freight.UserId == userId)
            {
                return true;
            }

            return false;            
        }

        public FreightQueryServiceModel GetFreightsByUser(string userId, int currentPage = 1, int freightsPerPage = int.MaxValue)
        {
            var freightsQuery = this.data.Freights
                .Where(a => a.UserId == userId)
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

        public FreightQueryServiceModel GetCompanyFreightsByUser(string userId, int currentPage = 1, int freightsPerPage = int.MaxValue)
        {
            var company = this.data.Companies
                .Where(a => a.ManagerId == userId
                    || a.Employees.Any(
                        b => b.UserId == userId))
                .FirstOrDefault();

            var freightsQuery = this.data.Freights
                .Where(a => a.User.Company.Id == company.Id)
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