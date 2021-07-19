namespace SteadyLogistic.Data.Models
{
    using System;

    public class Freight
    {
    
        // Cargo Properties

        public int Id { get; init; }

        public string Description { get; set; }

        public string CargoType { get; set; }

        public string Dimensions { get; set; }

        public int Weight { get; set; }

        public string TransportType { get; set; }

        public decimal Price { get; set; }

        public DateTime PublishedOn { get; init; }

        // Loading Properties

        public Country LoadingCountry { get; set; }

        public int LoadingCountryId { get; set; }

        public City LoadingCity { get; set; }

        public int LoadingCityId { get; set; }

        public DateTime LoadingDate { get; set; }

        // Unloading Properties

        public Country UnloadingCountry { get; set; }

        public int UnloadingCountryId { get; set; }

        public City UnloadingCity { get; set; }

        public int UnloadingCityId { get; set; }

        public DateTime UnloadingDate { get; set; }

        //public User User { get; set; }
        
        //public int UserId { get; set; }

        //public ICollection<User> Viewers { get; set; } => Need to Implelment Logic
    }
}
