namespace SteadyLogistic.Models.FreightExchange
{
    using System.Collections.Generic;
    using SteadyLogistic.Services.Freight;

    using SteadyLogistic.Data.Models;

    public class AllFreightsQueryModel
    {
        public const int FreightsPerPage = 10;

        public int CurrentPage { get; init; } = 1;

        public int TotalFreights { get; set; }

        public IEnumerable<FreightServiceModel> Freights { get; set; }
    }
}