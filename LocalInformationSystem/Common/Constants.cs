namespace LocalInformationSystem.Web.Common
{
    /// <summary>
    ///  Provides common error messages for the controllers.
    /// </summary>
    internal static class Constants
    {
        #region Provinces Controller

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
    }
}