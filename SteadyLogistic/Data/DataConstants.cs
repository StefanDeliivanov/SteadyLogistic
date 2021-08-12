namespace SteadyLogistic.Data
{

    public static class DataConstants
    {

        public static class Article
        {
            public const int authorNameMinLength = 5;
            public const int authorNameMaxLength = 50;
            public const int categoryMinLength = 3;
            public const int categoryMaxLength = 30;
            public const int articleTitleMinLength = 3;
            public const int articleTitleMaxLength = 40;
            public const int articleBodyMinLength = 5;
            public const int articleBodyMaxLength = 50000;
        }

        public static class City
        {
            public const int cityNameMinLength = 2;
            public const int cityNameMaxLength = 58;
            public const int cityPostCodeMinLength = 3;
            public const int cityPostCodeMaxLength = 10;
        }

        public static class Company
        {
            public const int companyNameMinLength = 2;
            public const int companyNameMaxLength = 40;
            public const int vatNumberMinLength = 7;
            public const int vatNumberMaxLength = 15;
            public const int addressMinLength = 5;
            public const int addressMaxLength = 50;
        }

        public static class Country
        {
            public const int countryNameMinLength = 4;
            public const int countryNameMaxLength = 56;
            public const int countryCodeLength = 2;
        }

        public static class CargoSize
        {
            public const int cargoSizeNameMinLength = 8;
            public const int cargoSizeNameMaxLength = 9;
        }

        public static class Freight
        {
            public const int descriptionMaxLength = 200;
        }

        public static class Global
        {
            public const int emailMinLength = 6;
            public const int emailMaxLength = 45;
            public const int passwordMinLength = 6;
            public const int passwordMaxLength = 50;
            public const int phoneNumberMinLength = 8;
            public const int phoneNumberMaxLength = 30;
            public const string phoneNumberRegex = @"\+\d*\-\d*";      
        }

        public static class Displays
        {
            public const string firstNameDisplay = "First Name";
            public const string lastNameDisplay = "Last Name";
            public const string phoneNumberDisplay = "Phone Number";
            public const string emailDisplay = "E-mail";
            public const string countryDisplay = "Country";
            public const string urlDisplay = "Image";
            public const string confirmPassword = "Confirm Password";
        }

        public static class ErrorMessages
        {
            public const string countryNotExistErrorMessage = "Country does not exist.";
            public const string passwordErrorMessage = "The {0} must be between {2} and {1} characters";
            public const string confirmPasswordErrorMessage = "The password and it's confirmation do not match.";
            public const string requiredErrorMessage = "The field cannot be empty!";
            public const string defaultErrorMessage = "Invalid {0}! Must be between {2} and {1} characters";
            public const string emailErrorMessage = "Enter valid Email address! 'example@email.com'"; 
            public const string phoneNumberErrorMessage = "Enter valid Phone Number! '+359-123456789'";
            public const string propertyExistsErrorMessage = "Value already exists!";
            public const string userRegisterFailedErrorMessage = "Employee registration have failed";
        }

        public static class User
        {
            public const int nameMinLength = 3;
            public const int nameMaxLength = 30;
        }

        public static class TrailerType
        {
            public const int trailerTypeNameMinLength = 3;
            public const int trailerTypeNameMaxLength = 25;
        }

        public static class Message
        {
            public const int contactNameMinLength = 2;
            public const int contactNameMaxLength = 14;
            public const int titleMinLength = 2;
            public const int titleMaxLength = 40; 
            public const int bodyMinLength = 3;
            public const int bodyMaxLength = 1000;
        }

        public static class Vehicle
        {
            public const int brandNameMinLength = 3;
            public const int brandNameMaxLength = 30;
            public const int modelNameMinLength = 3;
            public const int modelNameMaxLength = 30;
            public const int plateNumbersMinLength = 4;
            public const int plateNumbersMaxLength = 15;
            public const int vehicleMinWeight = 1000;
            public const int vehicleMaxWeight = 17000;
        }
    }
}