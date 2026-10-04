namespace LocalInformationSystem.Data.Common
{
    /// <summary>
    ///  Provides common constants for the repository.
    /// </summary>
    internal static class Constants
    {
        // Province methods constants.
        internal const string ProvinceError = "No provinces available! Something went wrong with the database server!";
        internal const string ProvinceNotFound = "Province with that ID was not found in the database!";

        // Cities methods constants
        internal const string NoCitiesFromDb = "Error while retrieving information about the cities from the database!";
        internal const string NoSuchCityInDb = "No city with specified ID was found in the database.";
        internal const string NoSuchLandmarkInDb = "No landmark with specified ID was found in the database.";

        // Mountains methods constants.
        internal const string NoMountainsFromDb = "No mountains available! Something went wrong with the database!";
        internal const string UnableToMapCityToCityDTO = "Error while mapping City to CityDTO!";
        internal const string NoSuchMountainInDb = "Mountain with specified ID was not found in the database.";

        // Rivers methods constants.
        internal const string NoRiversFromDb = "No rivers available! Something went wrong with the database!";

        // Common constants.
        internal const string NoSuchEntityInDb = "Specified entity not found in the database.";
    }
}