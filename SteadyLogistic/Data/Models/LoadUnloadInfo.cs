namespace SteadyLogistic.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class LoadUnloadInfo
    {

        public int Id { get; set; }

        [Required]
        public virtual Country Country { get; set; }

        public int CountryId { get; set; }

        [Required]
        public virtual City City { get; set; }

        public int CityId { get; set; }

        public DateTime Date { get; set; }

        [InverseProperty("Loading")]
        public virtual ICollection<Freight> Loadings { get; set; }

        [InverseProperty("Unloading")]
        public virtual ICollection<Freight> Unloadings { get; set; }

    }
}
