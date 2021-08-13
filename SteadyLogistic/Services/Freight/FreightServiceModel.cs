namespace SteadyLogistic.Services.Freight
{
    using System;

    public class FreightServiceModel
    {
        public int Id { get; set; }

        public string LoadingCountryCode { get; set; }

        public string LoadingCityName { get; set; }

        public string UnloadingCountryCode { get; set; }

        public string UnloadingCityName { get; set; }

        public string UserId { get; set; }

        public string UserFullName { get; set; }

        public string CompanyName { get; set; }

        public DateTime PublishedOn { get; set; }

        public DateTime LoadingDate { get; set; }
    }
}