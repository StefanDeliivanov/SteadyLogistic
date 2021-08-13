namespace SteadyLogistic.Services.LoadUnloadInfo
{
    using System;
    using SteadyLogistic.Data.Models;

    public interface ILoadUnloadInfoService
    {

        public LoadUnloadInfo Create(int cityId, int countryId, DateTime date);

        public bool DateIsValid(DateTime date);
    }
}