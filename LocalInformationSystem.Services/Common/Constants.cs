namespace LocalInformationSystem.Services.Common
{
    internal static class Constants
    {
        // ProvincesService constants.
        internal const string ProvinceError = "Error while retrieving the provinces from the database.";
        internal const string UnsuccessfullyMappingOfProvince = "AutoMapper could not map Province to ProvinceDTO.";
        internal const string InvalidProvinceID = "The ID of the province should not be less than or equal to zero.";


        // CitiesService constants.
        internal const string NoCitiesFromDb = "Error while retrieving the cities from the database.";
        internal const string CannotMapCityToCityDTO = "Unable to map City to CityDTO.";
        internal const string InvalidCityID = "The ID of the city should not be negative or zero.";
        internal const string NoSuchCityInDb = "There is no city with the specified ID in the database.";
        internal const string CannotMapLandmarkToLandmarkDTO = "Unable to map Landmark to LandmarkDTO.";
        internal const string InvalidLandmarkId = "The landmark ID should not be negative or zero.";

        // MountainsService constants.
        internal const string UnableToMapMountainDTO = "Unable to map Mountain to MountainDTO.";
        internal const string InvalidMountainId = "The ID of the mountain should not be negative or zero.";
        internal const string UnableToMapMountainToMountainDTO = "Unable to map Mountain to MountainDTO.";
        internal const string UnableToMapParkToParkDTO = "Unable to map Park to ParkDTO.";
        internal const string InavlidParkId = "The ID of the park should not be negative or zero.";

    }
}