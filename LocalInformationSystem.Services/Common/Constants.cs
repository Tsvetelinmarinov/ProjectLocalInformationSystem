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

        // MountainsService constants.
        internal const string UnableToMapMountainDTO = "Unable to map Mountain to MountainDTO.";

    }
}