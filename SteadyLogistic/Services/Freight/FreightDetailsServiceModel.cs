namespace SteadyLogistic.Services.Freight
{
    using System;
    using SteadyLogistic.Data.Models;

    public class FreightDetailsServiceModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime PublishedOn { get; set; }

        public string TrailerType { get; set; }

        public string CargoSize { get; set; }

        public double Weight { get; set; }

        #region Dimenions
        public double Length { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }
        #endregion

        #region Loading
        public string LoadingCountryCode { get; set; }

        public string LoadingCountryName { get; set; }

        public string LoadingCityName { get; set; }

        public string LoadingCityCode { get; set; }

        public DateTime LoadingDate { get; set; }
        #endregion

        #region Unloading
        public string UnloadingCountryCode { get; set; }

        public string UnloadingCountryName { get; set; }

        public string UnloadingCityName { get; set; }

        public string UnloadingCityCode { get; set; }

        public DateTime UnloadingDate { get; set; }
        #endregion

        #region User
        public string UserId { get; set; }

        public string UserFullName { get; set; }

        public string UserPhoneNumber { get; set; }

        public string UserEmail { get; set; }
        #endregion

        #region Company
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string CompanyPhoneNumber { get; set; }

        public string CompanyEmail { get; set; }
        #endregion
    }
}