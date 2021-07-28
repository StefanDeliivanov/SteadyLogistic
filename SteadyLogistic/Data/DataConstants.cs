namespace SteadyLogistic.Data
{

    public static class DataConstants
    {

        public static class City
        {
            public const int cityNameMinLenght = 3;
            public const int cityNameMaxLenght = 25;
        }

        public static class Company
        {
            public const int companyNameMinLenght = 3;
            public const int companyNameMaxLenght = 40;
            public const int vatNumberMinLenght = 4;
            public const int vatNumberMaxLenght = 15;
            public const int headquatersMinLenght = 3;
            public const int headquatersMaxLenght = 50;
            public const int phoneMinLenght = 5;
            public const int phoneMaxLenght = 15;
            public const int emailMaxLenght = 70;
        }
        public static class Country
        {
            public const int countryNameMinLenght = 4;
            public const int countryNameMaxLenght = 60;
        }
        public static class Freight
        {

        }
        public static class LoadUnloadInfo
        {

        }
        public static class SLogisticsUser
        {

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

        public static class Truck
        {

        }

        public static class Trailer
        {

        }
    }
}
