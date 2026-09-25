namespace LocalInformationSystem.Data.Common
{
    /// <summary>
    ///  Provides common constants for the repository.
    /// </summary>
    public static class Constants
    {
        #region Repository

        public const string ProvinceError = "No provinces available! Something went wrong with the database server!";

        #endregion
        #region Province Service

        public const string UnsuccessfullyMappingOfProvince = "AutoMapper could not map Province to ProvinceDTO.";

        #endregion
    }
}