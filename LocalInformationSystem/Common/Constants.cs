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
        #region Validation Constants For The View Models

        #region ProvinceViewModel

        internal const int ProvinceIdMinLen = 0;
        internal const int ProvinceIdMaxLen = 100;
        internal const int ProvinceNameMinLen = 1;
        internal const int ProvinceNameMaxLen = 100;
        internal const double ProvinceAreaMin = 0.01;
        internal const double ProvinceAreaMax = 8000.00;
        internal const double ProvincePopulationMin = 1;
        internal const double ProvincePopulationMax = 10_000_000;

        internal const string InvalidProvinceNameLength = "The province name should be between {2} and {1} characters long";
        internal const string ProvinceNameRegExValidator = @"^[\p{Lu}][\p{L}]*$";
        internal const string ProvinceShouldStartWithUppercase = "The name of the province should start with uppercase letter";
        internal const string ProvinceNameIsRequired = "The name of the province is required";
        internal const string ProvinceAdminCentreIsRequired = "The province administrative centre name is required";
        internal const string ProvinceAreaIsRequired = "The province area is required";
        internal const string InvalidProvinceAreaSpan = "The province area should be between {1} and {2} square kilometres";
        internal const string ProvincePopulationIsRequired = "The population of the province is required";
        internal const string InvalidProvincePopulation = "The population of the province should be at least one person";

        #endregion
        #region CityViewModel

        internal const int CityNameMinLen = 2;
        internal const int CityNameMaxLen = 100;
        internal const int CityPopulationMinLen = 1;
        internal const int CityPopulationMaxLen = 3_000_000;
        internal const int CityElevationMinLen = 1;
        internal const int CityElevationMaxLen = 5000;

        internal const string InvalidCityName = "The name of the city should be at least {2} character long";
        internal const string CityNameIsRequired = "The name of the city is required";
        internal const string CityProvinceIdIsRequired = "The province ID is required";
        internal const string InvalidProvinceId = "The province ID should be between {1} and {2}";
        internal const string InvalidCityNameConvention = "The name of the city should start with uppercase letter";
        internal const string CityPopulationIsRequired = "The population is required";
        internal const string InvalidCityPopulation = "The population of the city should be between {1} and {2} people";
        internal const string InvalidCityElevationRange = "The elevation should be between {1} and {2} metres";
        internal const string CityElevationRequired = "The elevation of the city is required";
        internal const string CityNameRegExValidator = @"^[\p{Lu}][\p{L}]*$";

        #endregion

        #endregion
    }
}