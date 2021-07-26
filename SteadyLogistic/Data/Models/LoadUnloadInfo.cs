namespace SteadyLogistic.Data.Models
{
    using System;

    public class LoadUnloadInfo
    {
        public int Id { get; set; }

        public Country Country { get; set; }

        public int CountryId { get; set; }

        public City City { get; set; }

        public int CityId { get; set; }

        public DateTime Date { get; set; }
    }
}
