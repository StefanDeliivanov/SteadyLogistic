namespace SteadyLogistic.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    public class SLogisticsUser : IdentityUser
    {
        [ProtectedPersonalData]
        public override string UserName { get; set; }

        [ProtectedPersonalData]
        public override string Email { get; set; }

        [ProtectedPersonalData]
        public override string PhoneNumber { get; set; }

        public Company Company { get; set; }

        public int CompanyId { get; set; }

        public ICollection<Freight> Freights { get; set; }
    }
}
