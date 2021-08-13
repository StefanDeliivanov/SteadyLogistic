namespace SteadyLogistic.Services.LoadUnloadInfo
{
    using System;
    using SteadyLogistic.Data;
    using SteadyLogistic.Data.Models;

    public class LoadUnloadInfoService : ILoadUnloadInfoService
    {
        private readonly SteadyLogisticDbContext data;

        public LoadUnloadInfoService(SteadyLogisticDbContext data)
        {
            this.data = data;
        }

        public LoadUnloadInfo Create(int cityId, int countryId, DateTime date)
        {
            var loadUnloadInfo = new LoadUnloadInfo
            {
                CityId = cityId,
                CountryId = countryId,
                Date = date
            };

            this.data.LoadUnloadInfos.Add(loadUnloadInfo);
            this.data.SaveChanges();

            return loadUnloadInfo;
        }

        public bool DateIsValid(DateTime date)
        {
            return date.ToLocalTime() > DateTime.UtcNow.ToLocalTime();
        }
    }
}