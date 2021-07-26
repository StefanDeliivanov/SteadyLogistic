namespace SteadyLogistic.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Freight
    {
        public Freight()
        {
            this.Viewers = new List<SLogisticsUser>();
        }

        public int Id { get; init; }

        public string Description { get; set; }

        public string CargoType { get; set; }

        public string Dimensions { get; set; }

        public int Weight { get; set; }

        public string TransportType { get; set; }

        public decimal Price { get; set; }

        public DateTime PublishedOn { get; init; }

        public LoadUnloadInfo Loading { get; set; }

        public int LoadingId { get; set; }

        public LoadUnloadInfo Unloading { get; set; }

        public int UnloadingId { get; set; }

        public SLogisticsUser User { get; set; }
        
        public string UserId { get; set; }

        public ICollection<SLogisticsUser> Viewers { get; set; }
    }
}
