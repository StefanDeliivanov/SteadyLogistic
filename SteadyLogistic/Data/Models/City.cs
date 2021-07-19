namespace SteadyLogistic.Data.Models
{

    public class City
    {
        public int Id { get; init; }

        public string Name { get; set; }

        public Country Country { get; set; }

        public int CountryId { get; set; }
    }
}
