namespace SteadyLogistic.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using SteadyLogistic.Infrastructure.Extensions;
    using SteadyLogistic.Models.FreightExchange;
    using SteadyLogistic.Services.CargoSize;
    using SteadyLogistic.Services.City;
    using SteadyLogistic.Services.Country;
    using SteadyLogistic.Services.Dimension;
    using SteadyLogistic.Services.Freight;
    using SteadyLogistic.Services.LoadUnloadInfo;
    using SteadyLogistic.Services.TrailerType;  

    using static Areas.AreaGlobalConstants.Roles;
    using static Data.DataConstants.ErrorMessages;
    using static WebConstants;

    [Authorize]
    public class FreightExchangeController : Controller
    {
        private readonly ICargoSizeService cargoSizes;
        private readonly ICityService cities;
        private readonly ICountryService countries;
        private readonly IDimensionService dimensions;
        private readonly IFreightService freights;
        private readonly ILoadUnloadInfoService loadUnloadInfos;
        private readonly IMemoryCache cache;
        private readonly ITrailerTypeService trailerTypes;

        public FreightExchangeController(
        ICargoSizeService cargoSizes,
        ICityService cities,
        ICountryService countries,
        IDimensionService dimensions,
        IFreightService freights,
        ILoadUnloadInfoService loadUnloadInfos,
        IMemoryCache cache,
        ITrailerTypeService trailerTypes)
        {
            this.cargoSizes = cargoSizes;
            this.cities = cities;
            this.countries = countries;
            this.dimensions = dimensions;
            this.freights = freights;
            this.loadUnloadInfos = loadUnloadInfos;
            this.cache = cache;
            this.trailerTypes = trailerTypes;                
        }

        [HttpGet]
        [Authorize(Roles = FreightBrokersRoleName)]
        public IActionResult Add()
        {
            var countriesCache = this.cache.Get<ICollection<CountryServiceModel>>(countriesCacheKey);
            var cargoSizesCache = this.cache.Get<ICollection<CargoSizeServiceModel>>(cargoSizesCacheKey);
            var trailerTypesCache = this.cache.Get<ICollection<TrailerTypeServiceModel>>(trailerTypesCacheKey);

            if (cargoSizesCache == null)
            {
                cargoSizesCache = this.cargoSizes.AllCargoSizes();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromDays(30));

                this.cache.Set(cargoSizesCacheKey, cargoSizesCache, cacheOptions);
            }

            if (countriesCache == null)
            {
                countriesCache = this.countries.AllCountries();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromDays(30));

                this.cache.Set(countriesCacheKey, countriesCache, cacheOptions);
            }     

            if (trailerTypesCache == null)
            {
                trailerTypesCache = this.trailerTypes.AllTrailerTypes();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromDays(30));

                this.cache.Set(trailerTypesCacheKey, trailerTypesCache, cacheOptions);
            }

            return View(new AddFreightFormModel
            {
                CargoSizes = cargoSizesCache,
                Countries = countriesCache,
                TrailerTypes = trailerTypesCache
            });
        }

        [HttpPost]
        [Authorize(Roles = FreightBrokersRoleName)]
        public IActionResult Add(AddFreightFormModel model)
        {
            if (!this.countries.Exists(model.LoadingCountryId))
            {
                this.ModelState.AddModelError(nameof(model.LoadingCountryId), countryNotExistErrorMessage);
            }

            if (!this.countries.Exists(model.UnloadingCountryId))
            {
                this.ModelState.AddModelError(nameof(model.UnloadingCountryId), countryNotExistErrorMessage);
            }

            if (!this.cargoSizes.Exists(model.CargoSizeId))
            {
                this.ModelState.AddModelError(nameof(model.CargoSizeId), cargoSizeNotExistErrorMessage);
            }

            if (!this.trailerTypes.Exists(model.TrailerTypeId))
            {
                this.ModelState.AddModelError(nameof(model.TrailerTypeId), trailerTypeNotExistErrorMessage);
            }

            if (!this.loadUnloadInfos.DateIsValid(model.LoadingDate))
            {
                this.ModelState.AddModelError(nameof(model.LoadingDate), invalidDateErrorMessage);
            }

            if (!this.loadUnloadInfos.DateIsValid(model.UnloadingDate))
            {
                this.ModelState.AddModelError(nameof(model.UnloadingDate), invalidDateErrorMessage);
            }

            if (model.UnloadingDate < model.LoadingDate)
            {
                this.ModelState.AddModelError(nameof(model.UnloadingDate), invalidUnloadingDateErrorMessage);
            }

            if (!this.ModelState.IsValid)
            {
                var countriesCache = this.cache.Get<ICollection<CountryServiceModel>>(countriesCacheKey);
                var cargoSizesCache = this.cache.Get<ICollection<CargoSizeServiceModel>>(cargoSizesCacheKey);
                var trailerTypesCache = this.cache.Get<ICollection<TrailerTypeServiceModel>>(trailerTypesCacheKey);

                if (cargoSizesCache == null)
                {
                    cargoSizesCache = this.cargoSizes.AllCargoSizes();

                    var cacheOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromDays(30));

                    this.cache.Set(cargoSizesCacheKey, cargoSizesCache, cacheOptions);
                }

                if (countriesCache == null)
                {
                    countriesCache = this.countries.AllCountries();

                    var cacheOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromDays(30));

                    this.cache.Set(countriesCacheKey, countriesCache, cacheOptions);
                }

                if (trailerTypesCache == null)
                {
                    trailerTypesCache = this.trailerTypes.AllTrailerTypes();

                    var cacheOptions = new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromDays(30));

                    this.cache.Set(trailerTypesCacheKey, trailerTypesCache, cacheOptions);
                }

                model.CargoSizes = cargoSizesCache;
                model.Countries = countriesCache;
                model.TrailerTypes = trailerTypesCache;

                return View(model);
            }

            var loadingCity = this.cities.GetCity(model.LoadingPostCode, model.LoadingCityName, model.LoadingCountryId);
            var unloadingCity = this.cities.GetCity(model.UnloadingPostCode, model.UnloadingCityName, model.UnloadingCountryId);
            var userId = this.User.GetUserId();
            var dimension = this.dimensions.Create(model.Length, model.Width, model.Height);
            var loading = this.loadUnloadInfos.Create(loadingCity.Id, model.LoadingCountryId, model.LoadingDate);
            var unloading = this.loadUnloadInfos.Create(unloadingCity.Id, model.UnloadingCountryId, model.UnloadingDate);

            this.freights.Create(
                model.Description,
                model.Weight,
                model.Price,
                model.TrailerTypeId,
                model.CargoSizeId,
                dimension,
                loading,
                unloading,
                userId);

            TempData[GlobalMessageKey] = "Freight was added successfully!";

            return RedirectToAction(nameof(All));
        }

        [Authorize(Roles = NotAMemberRoleName)]
        public IActionResult All([FromQuery] AllFreightsQueryModel query)
        {
            var queryResult = this.freights.All(
                query.LoadingCountryCode,
                query.UnloadingCountryCode,
                query.CargoSize,
                query.TrailerType,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllFreightsQueryModel.FreightsPerPage);

            var cargoSizeNamesCache = this.cache.Get<IEnumerable<string>>(cargoSizeNamesCacheKey);
            var countryCodesCache = this.cache.Get<IEnumerable<string>>(countryCodesCacheKey);         
            var trailerTypeNamesCache = this.cache.Get<IEnumerable<string>>(trailerTypeNamesCacheKey);

            if (cargoSizeNamesCache == null)
            {
                cargoSizeNamesCache = this.cargoSizes.AllCargoSizeNames();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromDays(30));

                this.cache.Set(cargoSizeNamesCacheKey, cargoSizeNamesCache, cacheOptions);
            }

            if (countryCodesCache == null)
            {
                countryCodesCache = this.countries.AllCountryCodes();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromDays(30));

                this.cache.Set(countryCodesCacheKey, countryCodesCache, cacheOptions);
            }

            if (trailerTypeNamesCache == null)
            {
                trailerTypeNamesCache = this.trailerTypes.AllTrailerTypeNames();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromDays(30));

                this.cache.Set(trailerTypeNamesCacheKey, trailerTypeNamesCache, cacheOptions);
            }

            query.CargoSizes = cargoSizeNamesCache;
            query.CountryCodes = countryCodesCache;        
            query.TrailerTypes = trailerTypeNamesCache;
            query.TotalFreights = queryResult.TotalFreights;
            query.Freights = queryResult.AllFreights;

            return View(query);
        }

        [Authorize(Roles = FreightBrokersRoleName)]
        public IActionResult CompanyOffers([FromQuery] AllFreightsQueryModel query)
        {
            var queryResult = this.freights.GetCompanyFreightsByUser(
                this.User.GetUserId(),
                query.CurrentPage,
                AllFreightsQueryModel.FreightsPerPage);

            query.TotalFreights = queryResult.TotalFreights;
            query.Freights = queryResult.AllFreights;

            return View(query);
        }

        [Authorize(Roles = NotAMemberRoleName)]
        public IActionResult Delete([FromQuery] int freightId, string userId)
        {
            if (!this.freights.Exists(freightId))
            {
                TempData[GlobalErrorKey] = "The freight does not exist!";
                return RedirectToAction(nameof(All));
            }

            if (!this.freights.IsAuthorized(freightId, userId) && !this.User.IsAdmin())
            {
                TempData[GlobalErrorKey] = "You are not authorized to delete this!";
                return RedirectToAction(nameof(All));
            }

            if (this.freights.Delete(freightId))
            {
                TempData[GlobalMessageKey] = "Freight was deleted successfully!";
                return RedirectToAction(nameof(All));
            }

            TempData[GlobalErrorKey] = "Something went wrong! Please try again!";

            return RedirectToAction(nameof(Details), freightId);
        }

        [Authorize(Roles = NotAMemberRoleName)]
        public IActionResult Details(int id)
        {
            var freight = this.freights.Details(id);
            if (freight == null)
            {
                TempData[GlobalErrorKey] = "This freight does not exist!";
                return RedirectToAction(nameof(All));
            }

            return View(freight);
        }

        [Authorize(Roles = FreightBrokersRoleName)]
        public IActionResult MyOffers([FromQuery] AllFreightsQueryModel query)
        {
            var queryResult = this.freights.GetFreightsByUser(
                this.User.GetUserId(),
                query.CurrentPage,
                AllFreightsQueryModel.FreightsPerPage);

            query.TotalFreights = queryResult.TotalFreights;
            query.Freights = queryResult.AllFreights;

            return View(query);
        }
    }
}