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
    using SteadyLogistic.Services.Company;
    using SteadyLogistic.Services.User;
    using SteadyLogistic.Infrastructure.Extensions;

    using static Areas.AreaGlobalConstants.Roles;
    using static Data.DataConstants.ErrorMessages;
    using static WebConstants;
    using SteadyLogistic.Models.Catalogue;

    public class CatalogueController : Controller
    {
        private readonly ICityService cities;
        private readonly ICountryService countries;
        private readonly ICargoSizeService cargoSizes;
        private readonly ITrailerTypeService trailerTypes;
        private readonly IDimensionService dimensions;
        private readonly IFreightService freights;
        private readonly ILoadUnloadInfoService loadUnloadInfos;
        private readonly ICompanyService companies;
        private readonly IUserService users;

        public CatalogueController(
            ICityService cities,
            ICountryService countries,
            ICargoSizeService cargoSizes,
            ITrailerTypeService trailerTypes,
            IDimensionService dimensions,
            IFreightService freights,
            ILoadUnloadInfoService loadUnloadInfos, 
            ICompanyService companies, 
            IUserService users)
        {
            this.cities = cities;
            this.countries = countries;
            this.cargoSizes = cargoSizes;
            this.trailerTypes = trailerTypes;
            this.dimensions = dimensions;
            this.freights = freights;
            this.loadUnloadInfos = loadUnloadInfos;
            this.companies = companies;
            this.users = users;
        }

        public IActionResult AllCompanies([FromQuery] AllCompaniesQueryModel query)
        {
            var queryResult = this.companies.All(
                query.SearchTerm,
                query.SearchType,
                query.Sorting,
                query.CurrentPage,
                AllFreightsQueryModel.FreightsPerPage);


            query.TotalCompanies = queryResult.TotalCompanies;
            query.Companies = queryResult.AllCompanies;

            return View(query);
        }

        public IActionResult AllUsers([FromQuery] AllUsersQueryModel query)
        {
            var queryResult = this.users.All(
                 query.SearchTerm,
                 query.SearchType,
                 query.Sorting,
                 query.CurrentPage,
                 AllFreightsQueryModel.FreightsPerPage);


            query.TotalUsers = queryResult.TotalUsers;
            query.Users = queryResult.AllUsers;

            return View(query);
        }
    }
}