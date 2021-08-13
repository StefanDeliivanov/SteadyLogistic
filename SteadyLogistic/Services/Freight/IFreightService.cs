﻿namespace SteadyLogistic.Services.Freight
{
    using System;
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
    }
}