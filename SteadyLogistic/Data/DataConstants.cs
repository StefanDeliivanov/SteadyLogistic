namespace SteadyLogistic.Data
{

    public static class DataConstants
    {
        public static class City
        {
            public const int cityNameMinLenght = 3;
            public const int cityNameMaxLenght = 25;
            public const int cityPostCodeMinLenght = 3;
            public const int cityPostCodeMaxLenght = 10;
        }

        public static class Company
        {
            public const int companyNameMinLenght = 3;
            public const int companyNameMaxLenght = 40;
            public const int vatNumberMinLenght = 4;
            public const int vatNumberMaxLenght = 15;
            public const int addressMinLenght = 3;
            public const int addressMaxLenght = 50;
            public const int phoneMinLenght = 5;
            public const int phoneMaxLenght = 15;
            public const int emailMaxLenght = 70;
        }

        public static class Country
        {
            public const int countryNameMinLenght = 4;
            public const int countryNameMaxLenght = 60;
            public const int countryCodeLenght = 3;
        }

        public static class Freight
        {
            public const int decriptionMaxLenght = 150;
            public const int dimensionsMaxLenght = 6;
        }

        public static class TransportType
        {
            public const int tranportTypeMinLenght = 8;
            public const int tranportTypeMaxLenght = 9;
        }

        public static class CargoSizeName
        {
            public const int cargoSizeNameMaxLenght = 15;
        }


        public static class SLogisticsUser
        {
            public const int usernameMinLenght = 3;
            public const int usernameMaxLenght = 30;
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

        public static class Trailer
        {
            public const int trailerMaxCapacity = 130;
            public const int trailerMaxHeight = 315;
        }
    }
}
