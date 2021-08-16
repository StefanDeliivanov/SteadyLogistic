namespace SteadyLogistic.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants.Global;
    using static DataConstants.Company;  

    public class Company
    {
        public Company()
        {
            Employees = new List<PremiumUser>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(companyNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(vatNumberMaxLength)]
        public string VatNumber { get; set; }

        [Required]
        [MaxLength(addressMaxLength)]
        public string Address { get; set; }

        [Required]
        [MaxLength(phoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(emailMaxLength)]
        public string Email { get; set; }

        [MaxLength(companyDescriptionMaxLength)]
        public string Description { get; set; }

        [MaxLength(managerFullNameMaxLength)]
        public string ManagerFullName { get; set; }

        public string ManagerId { get; set; }
        
        public virtual Country Country { get; set; }

        public int CountryId { get; set; }
        
        public virtual City City { get; set; }

        public int CityId { get; set; }
        
        public virtual Fleet Fleet { get; set; }

        public int FleetId { get; set; }

        public DateTime RegisteredOn { get; set; }

        public virtual ICollection<PremiumUser> Employees { get; set; }
    }
}