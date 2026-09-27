namespace LocalInformationSystem.Web.Common
{
    /// <summary>
    ///  Provides common error messages for the controllers.
    /// </summary>
    internal static class Constants
    {
        #region ProvincesController

        internal const string NoProvincesFromService = "No provinces provided from the service!";
        internal const string UnsuccessfullyMappingOfProvincesViewModels 
            = "Unsuccessfully mapping of ProvinceDTO to ProvinceViewModel!";

        #endregion
        #region CitiesController

        internal const string NoCitiesFromService = "Something went wrong while retrieving the cities from the service!";
        internal const string UnableToMapCityDTOsToViewModels = "Something went wrong while mapping the cities DTO`s to ViewModels!";
        internal const string UnableToMapCityDTOToViewModel = "Unable to map CityDTO to CityViewModel.";

        #endregion
        #region MountainsController

        internal const string UnableToMapMountainDTOToViewModel = "Something went wrong while mapping the mountain DTO`s to ViewModels!";

        #endregion
        #region Validation Constants

        internal const string InvalidCityName = "The name of the city should be at least {2} character long";
        internal const string CityNameIsRequired = "The name of the city is required";
        internal const string CityProvinceIdIsRequired = "The province ID is required";
        internal const string InvalidProvinceId = "The province ID should be between {1} and {2}";

        #endregion
    }
}