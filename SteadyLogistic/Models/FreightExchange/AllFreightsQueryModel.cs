namespace SteadyLogistic.Models.FreightExchange
{
    using System.Collections.Generic;
    using SteadyLogistic.Services.Freight;

    using SteadyLogistic.Data.Models;

    public class AllFreightsQueryModel
    {
        public const int FreightsPerPage = 10;

        public string LoadingCountryCode { get; set; }

        public string UnloadingCountryCode { get; set; }

        public string CargoSize { get; set; }

        public string TrailerType { get; set; }

        public string SearchTerm { get; set; }

        public FreightSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalFreights { get; set; }

        public IEnumerable<string> CountryCodes { get; set; }

        public IEnumerable<string> CargoSizes { get; set; }

        public IEnumerable<string> TrailerTypes { get; set; }

        public IEnumerable<FreightServiceModel> Freights { get; set; }
    }
}