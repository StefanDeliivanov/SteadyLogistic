namespace SteadyLogistic.Services.Freight
{
    using System.Collections.Generic;

    public class FreightQueryServiceModel
    {

        public int CurrentPage { get; init; }

        public int FreightsPerPage { get; init; }

        public int TotalFreights { get; init; }

        public IEnumerable<FreightServiceModel> AllFreights { get; init; }
    }
}