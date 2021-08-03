namespace SteadyLogistic.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.TransportType;

    public class TranportType
    {
        public TranportType()
        {
            Freights = new List<Freight>();
        }
        
        public int Id { get; set; }

        public CargoSize CargoSize { get; set; }

        public int CargoSizeId { get; set; }

        public CargoType CargoType { get; set; }

        public int CargoTypeId { get; set; }

        public ICollection<Freight> Freights { get; set; }
    }
}
