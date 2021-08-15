namespace SteadyLogistic.Controllers
{
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
    using SteadyLogistic.Infrastructure.Extensions;

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

            query.CountryCodes = countries.AllCountryCodes();
            query.CargoSizes = cargoSizes.AllCargoSizeNames();
            query.TrailerTypes = trailerTypes.AllTrailerTypeNames();
            query.TotalFreights = queryResult.TotalFreights;
            query.Freights = queryResult.AllFreights;

            return View(query);
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

            if (!loadUnloadInfos.DateIsValid(model.LoadingDate))
            {
                this.ModelState.AddModelError(nameof(model.LoadingDate), invalidDateErrorMessage);
            }

            if (!loadUnloadInfos.DateIsValid(model.UnloadingDate))
            {
                this.ModelState.AddModelError(nameof(model.UnloadingDate), invalidDateErrorMessage);
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
            var userId = this.User.GetUserId();
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


        public IActionResult Delete([FromQuery]int freightId, string userId)
        {
            if (!this.freights.Exists(freightId))
            {
                TempData[GlobalErrorKey] = "The freight does not exist!";

                return RedirectToAction(nameof(All));
            }

            if (!freights.IsAuthorized(freightId, userId) && !this.User.IsAdmin())
            {
                TempData[GlobalErrorKey] = "You are not authorized to delete this";

                return RedirectToAction(nameof(All));
            }        

            if (this.freights.Delete(freightId))
            {
                TempData[GlobalMessageKey] = "Freight was deleted successfully!";

                return RedirectToAction(nameof(All));
            }

            TempData[GlobalErrorKey] = "Something went wrong! Please try again";

            return RedirectToAction(nameof(Details), freightId);
        }

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
    }
}