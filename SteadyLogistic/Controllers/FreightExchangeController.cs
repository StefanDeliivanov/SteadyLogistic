namespace SteadyLogistic.Controllers
{
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SteadyLogistic.Models.FreightExchange;
    using SteadyLogistic.Services.CargoSize;
    using SteadyLogistic.Services.City;
    using SteadyLogistic.Services.Country;
    using SteadyLogistic.Services.TrailerType;
    using SteadyLogistic.Services.Dimension;
    using SteadyLogistic.Services.LoadUnloadInfo;
    using SteadyLogistic.Services.Freight;

    using SteadyLogistic.Data.Models;

    using static Areas.AreaGlobalConstants.Roles;
    using static Data.DataConstants.ErrorMessages;
    using static WebConstants;

    [Authorize]
    public class FreightExchangeController : Controller
    {
        private readonly ICityService cities;
        private readonly ICountryService countries;
        private readonly ICargoSizeService cargoSizes;
        private readonly ITrailerTypeService trailerTypes;
        private readonly IDimensionService dimensions;
        private readonly IFreightService freights;
        private readonly ILoadUnloadInfoService loadUnloadInfos;

        public FreightExchangeController(
            ICityService cities,
            ICountryService countries,
            ICargoSizeService cargoSizes,
            ITrailerTypeService trailerTypes,
            IDimensionService dimensions,
            IFreightService freights,
            ILoadUnloadInfoService loadUnloadInfos)
        {
            this.cities = cities;
            this.countries = countries;
            this.cargoSizes = cargoSizes;
            this.trailerTypes = trailerTypes;
            this.dimensions = dimensions;
            this.freights = freights;
            this.loadUnloadInfos = loadUnloadInfos;
        }

        public IActionResult All()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = FreightBrokersRoleName)]
        public IActionResult Add()
        {
            return View(new AddFreightFormModel
            {
                Countries = countries.AllCountries(),
                CargoSizes = cargoSizes.AllCargoSizes(),
                TrailerTypes = trailerTypes.AllTrailerTypes()
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

            if (!ModelState.IsValid)
            {
                model.Countries = this.countries.AllCountries();
                model.CargoSizes = this.cargoSizes.AllCargoSizes();
                model.TrailerTypes = this.trailerTypes.AllTrailerTypes();

                return View(model);
            }

            var loadingCity = cities.GetCity(model.LoadingPostCode, model.LoadingCityName, model.LoadingCountryId);
            var unloadingCity = cities.GetCity(model.UnloadingPostCode, model.UnloadingCityName, model.UnloadingCountryId);
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var dimension = dimensions.Create(model.Length, model.Width, model.Height);
            var loading = loadUnloadInfos.Create(loadingCity.Id, model.LoadingCountryId, model.LoadingDate);
            var unloading = loadUnloadInfos.Create(unloadingCity.Id, model.UnloadingCountryId, model.UnloadingDate);
            
            freights.Create(
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
    }
}