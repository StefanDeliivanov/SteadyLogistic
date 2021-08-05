﻿namespace SteadyLogistic.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Company;
    using static DataConstants.Global;

    public class Company
    {
        public Company()
        {
            Employees = new List<SLogisticsUser>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(companyNameMaxLenght)]
        public string Name { get; set; }

        [Required]
        [MaxLength(vatNumberMaxLenght)]
        public string VatNumber { get; set; }

        [Required]
        [MaxLength(addressMaxLenght)]
        public string Address { get; set; }

        [Required]
        [MaxLength(phoneNumberMaxLenght)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(emailMaxLenght)]
        public string Email { get; set; }
      
        public virtual Manager Manager { get; set; }

        public int ManagerId { get; set; }

        [Required]
        public virtual Country Country { get; set; }

        public int CountryId { get; set; }

        [Required]
        public virtual City City { get; set; }

        public int CityId { get; set; }
        
        public virtual Fleet Fleet { get; set; }

        public int FleetId { get; set; }

        public virtual ICollection<SLogisticsUser> Employees { get; set; }
    }
}