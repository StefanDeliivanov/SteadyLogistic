namespace SteadyLogistic.Models.FreightExchange
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using SteadyLogistic.Services.CargoSize;
    using SteadyLogistic.Services.Country;
    using SteadyLogistic.Services.TrailerType;

    using static SteadyLogistic.Data.DataConstants.City;
    using static SteadyLogistic.Data.DataConstants.Displays;
    using static SteadyLogistic.Data.DataConstants.ErrorMessages;
    using static SteadyLogistic.Data.DataConstants.Freight;

    public class AddFreightFormModel
    {
        [StringLength(descriptionMaxLength, ErrorMessage = descriptionErrorMessage)]
        public string Description { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [Range(priceMinAmount, priceMaxAmount,
            ErrorMessage = priceErrorMessage)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        public DateTime PublishedOn { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [Display(Name = cargoSizeDisplay)]
        public int CargoSizeId { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [Range(weightMinAmount, weightMaxAmount,
            ErrorMessage = weightValueErrorMessage)]
        public double Weight { get; set; }

        public int TrailerTypeId { get; set; }

        #region Dimensions
        [Required(ErrorMessage = requiredErrorMessage)]
        [Range(lengthMinAmount, lengthMaxAmount,
         ErrorMessage = dimensionValuesErrorMessage)]
        public double Length { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [Range(widthMinAmount, widthMaxAmount,
         ErrorMessage = dimensionValuesErrorMessage)]
        public double Width { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [Range(heightMinAmount, heightMaxAmount,
         ErrorMessage = dimensionValuesErrorMessage)]
        public double Height { get; set; }
        #endregion    

        #region Loading
        [Required(ErrorMessage = requiredErrorMessage)]
        public int LoadingCountryId { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [StringLength(cityNameMaxLength, MinimumLength = cityNameMinLength,
            ErrorMessage = defaultErrorMessage)]
        [Display(Name = cityNameDisplay)]
        public string LoadingCityName { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [StringLength(cityPostCodeMaxLength, MinimumLength = cityPostCodeMinLength,
            ErrorMessage = defaultErrorMessage)]
        [Display(Name = postCodeDisplay)]
        public string LoadingPostCode { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [Timestamp]
        public DateTime LoadingDate { get; set; } = DateTime.UtcNow.ToLocalTime();
        #endregion

        #region Unloading
        [Required(ErrorMessage = requiredErrorMessage)]
        public int UnloadingCountryId { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [StringLength(cityNameMaxLength, MinimumLength = cityNameMinLength,
            ErrorMessage = defaultErrorMessage)]
        [Display(Name = cityNameDisplay)]
        public string UnloadingCityName { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [StringLength(cityPostCodeMaxLength, MinimumLength = cityPostCodeMinLength,
            ErrorMessage = defaultErrorMessage)]
        [Display(Name = postCodeDisplay)]
        public string UnloadingPostCode { get; set; }

        [Required(ErrorMessage = requiredErrorMessage)]
        [Timestamp]
        public DateTime UnloadingDate { get; set; } = DateTime.UtcNow.ToLocalTime();
        #endregion

        public ICollection<CargoSizeServiceModel> CargoSizes { get; set; }

        public ICollection<CountryServiceModel> Countries { get; set; }

        public ICollection<TrailerTypeServiceModel> TrailerTypes { get; set; }
    }
}