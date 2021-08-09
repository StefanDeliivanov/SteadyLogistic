namespace SteadyLogistic.Data
{

    public static class DataConstants
    {
        public static class City
        {
            public const int cityNameMinLenght = 2;
            public const int cityNameMaxLenght = 58;
            public const int cityPostCodeMinLenght = 3;
            public const int cityPostCodeMaxLenght = 10;
        }

        public static class Company
        {
            public const int companyNameMinLenght = 2;
            public const int companyNameMaxLenght = 40;
            public const int vatNumberMinLenght = 7;
            public const int vatNumberMaxLenght = 15;
            public const int addressMinLenght = 5;
            public const int addressMaxLenght = 50;
        }

        public static class Country
        {
            public const int countryNameMinLenght = 4;
            public const int countryNameMaxLenght = 56;
            public const int countryCodeLenght = 2;
        }

        public static class CargoSize
        {
            public const int cargoSizeNameMinLenght = 8;
            public const int cargoSizeNameMaxLenght = 9;
        }

        public static class Freight
        {
            public const int decriptionMaxLenght = 200;
        }

        public static class Global
        {
            public const int emailMinLenght = 6;
            public const int emailMaxLenght = 50;
            public const int passwordMinLenght = 6;
            public const int passwordMaxLenght = 50;
            public const int phoneNumberMinLenght = 8;
            public const int phoneNumberMaxLenght = 30;
            public const string phoneNumberRegex = @"\+\d*\-\d*";      
        }

        public static class Displays
        {
            public const string phoneNumberDisplay = "Phone Number";
            public const string emailDisplay = "E-mail";
            public const string countryDisplay = "Country";
        }

        public static class ErrorMessages
        {
            public const string requiredErrorMessage = "The field cannot be empty!";
            public const string defaultErrorMessage = "Invalid {0}! Must be between {2} and {1} characters";
            public const string emailErrorMessage = "Enter valid Email address! 'example@email.com'"; 
            public const string phoneNumberErrorMessage = "Enter valid Phone Number! '+359-123456789'";
            public const string propertyExistsErrorMessage = "Value already exists!";
        }

        public static class PremiumUser
        {
            public const int nameMinLenght = 3;
            public const int nameMaxLenght = 30;
        }

        public static class TrailerType
        {
            public const int trailerTypeNameMinLenght = 3;
            public const int trailerTypeNameMaxLenght = 25;
        }

        public static class Vehicle
        {
            public const int brandNameMinLenght = 3;
            public const int brandNameMaxLenght = 30;
            public const int modelNameMinLenght = 3;
            public const int modelNameMaxLenght = 30;
            public const int plateNumbersMinLenght = 4;
            public const int plateNumbersMaxLenght = 15;
            public const int vehicleMinWeight = 1000;
            public const int vehicleMaxWeight = 17000;
        }
    }
}