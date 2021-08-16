namespace SteadyLogistic.Services.Freight
{
    using System.Collections.Generic;

    public class FreightQueryServiceModel
    {
        public int CurrentPage { get; set; }

        public int FreightsPerPage { get; set; }

        public int TotalFreights { get; set; }

        public IEnumerable<FreightServiceModel> AllFreights { get; set; }
    }
}