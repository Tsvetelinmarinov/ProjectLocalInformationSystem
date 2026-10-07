namespace LocalInformationSystem.Web.Common
{
    /// <summary>
    ///  Provides common error messages for the controllers.
    /// </summary>
    internal static class WebConstants
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
        internal const string CannotMapLandmarkDtoToViewModel = "Unable to map LandmarkDTO to LandmarkViewModel.";
        internal const string CannotMapLandmarkViewModelToDTO = "Unable to map LandmarkViewModel to LandmarkDTO.";

        #endregion
        #region MountainsController

        internal const string UnableToMapMountainDTOsToViewModel = "Something went wrong while mapping the mountain DTO`s to ViewModels.";
        internal const string UnableToMapMountainDTOToViewModel = "Unable to map mountainDTO to MountainViewModel.";
        internal const string UnableToMapParkDTOToParkViewModel = "Unable to map ParkDTO to ParkViewModel.";
        internal const string UnableToMapParkViewModelToParkDTO = "Unable to map ParkViewModel to ParkDTO.";

        #endregion
        #region RiversController

        internal const string UnableToMapRiverDTOsToViewModels = "Something went wrong while mapping the river DTO`s to ViewModels.";
        internal const string UnableToMapRiverViewModelToRiverDTO = "Unable to map RiverViewModel to RiverDTO.";

        #endregion
        #region Validation Constants For The View Models

        #region ProvinceViewModel

        internal const int ProvinceIdMinLen = 1;
        internal const int ProvinceIdMaxLen = 100;
        internal const int ProvinceNameMinLen = 1;
        internal const int ProvinceNameMaxLen = 100;
        internal const double ProvinceAreaMin = 0.01;
        internal const double ProvinceAreaMax = 8000.00;
        internal const double ProvincePopulationMin = 1;
        internal const double ProvincePopulationMax = 10_000_000;

        internal const string InvalidProvinceNameLength = "The province name should be between {2} and {1} characters long";
        internal const string ProvinceNameRegExValidator = @"^[A-Za-zА-Яа-яЁё][A-Za-zА-Яа-яЁё\s-]*$";
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
        internal const string CityNameRegExValidator = @"^[A-Za-zА-Яа-яЁё][A-Za-zА-Яа-яЁё\s-]*$";

        #endregion
        #region LandmarkViewModel

        internal const int LandmarkNameMinLen = 2;
        internal const int LandmarkNameMaxLen = 100;
        internal const int LandmarkCategoryMinLen = 2;
        internal const int LandmarkCategoryMaxLen = 100;

        internal const string LandmarkNameIsRequired = "The name of the landmark is required";
        internal const string InvalidLandmarkNameLength = "The name of the landmark should be between {2} and {1} characters long";
        internal const string LandmarkNameRegExValidator = @"^[A-Za-zА-Яа-яЁё][A-Za-zА-Яа-яЁё\s-]*$";
        internal const string LandmarkNameShouldStartWithUppercase = "The name of the landmark should start with uppercase letter";
        internal const string LandmarkCategoryIsRequired = "The category of the landmark is required";
        internal const string InvalidLandmarkCategoryLength = "The category should be between {2} and {1} characters long";
        internal const string LandmarkCityIdIsRequired = "The city ID is required";

        #endregion
        #region ParkViewModel

        internal const int ParkNameMinLen = 2;
        internal const int ParkNameMaxLen = 100;
        internal const int ParkTypeMinLen = 2;
        internal const int ParkTypeMaxLen = 100;
        internal const double ParkAreaMin = 0.01;
        internal const double ParkAreaMax = 1_000_000;
        internal const int ParkEstablishedYearMin = 1700;
        internal const int ParkEstablishedYearMax = 2100;

        internal const string ParkNameIsRequired = "The name of the park is required";
        internal const string InvalidParkNameLength = "The name of the park should be between {2} and {1} characters long";
        internal const string ParkNameRegExValidator = @"^[A-Za-zА-Яа-яЁё][A-Za-zА-Яа-яЁё\s-]*$";
        internal const string ParkNameShouldStartWithUppercase = "The name of the park should start with uppercase letter";
        internal const string ParkTypeIsRequired = "The type of the park is required";
        internal const string InvalidParkTypeLength = "The type should be between {2} and {1} characters long";
        internal const string ParkAreaIsRequired = "The area of the park is required";
        internal const string InvalidParkAreaRange = "The area of the park should be between {1} and {2} square kilometres";
        internal const string InvalidParkEstablishedYear = "The established year should be between {1} and {2}";
        internal const string ParkMountainIdIsRequired = "The mountain ID is required";

        #endregion
        #region MountainViewModel

        internal const int MountainNameMaxLen = 100;
        internal const int MountainHighestPeakMaxLen = 100;
        internal const double MountainElevationMin = 1;
        internal const double MountainElevationMax = 9000;
        internal const double MountainAreaMin = 0.01;
        internal const double MountainAreaMax = 100_000;

        internal const string MountainNameIsRequired = "The name of the mountain is required";
        internal const string MountainNameRegExValidator = @"^[A-Za-zА-Яа-яЁё][A-Za-zА-Яа-яЁё\s-]*$";
        internal const string MountainNameShouldStartWithUppercase = "The name of the mountain should start with uppercase letter";
        internal const string MountainHighestPeakRegExValidator = @"^[A-Za-zА-Яа-яЁё][A-Za-zА-Яа-яЁё\s-]*$";
        internal const string MountainHighestPeakShouldStartWithUppercase = "The highest peak of the mountain should start with uppercase letter";
        internal const string MountainHighestPeakIsRequired = "The highest peak of the mountain is required";
        internal const string MountainElevationIsRequired = "The elevation of the mountain is required";
        internal const string InvalidMountainElevation = "The elevation of the mountain should be between {1} and {2} metres";
        internal const string MountainAreaIsRequired = "The area of the mountain is required";
        internal const string MountainAreaInvalidRange = "The area of the mountain should be between {1} and {2} square kilometres";

        #endregion
        #region RiverViewModel

        internal const int RiverNameMinLen = 2;
        internal const int RiverNameMaxLen = 100;
        internal const int RiverOutflowNameMinLen = 2;
        internal const int RiverOutflowNameMaxLen = 200;
        internal const double RiverLengthMin = 0.01;
        internal const double RiverLengthMax = 3000.00;
        
        internal const string RiverNameIsRequired = "River name is required";
        internal const string InvalidRiverNameLength = "The length of the river name should be between {1} and {2} characters";
        internal const string RiverNameRegExValidator = @"(?<FirstName>[\p{Lu}\p{L}]*)(?<OtherNames>[ -]\p{L}*)*";
        internal const string InvalidRiverName = "The name of the river should start with uppercase letter";
        internal const string RiverLengthIsRequired = "River length is required";
        internal const string InvalidRiverLength = "River length should be between {1} and {2} kilometres";

        internal const string InvalidRiverOutflowNameLength =
            "The outflow name of the river shoud be at least {1} characters";

        #endregion

        #endregion
    }
}