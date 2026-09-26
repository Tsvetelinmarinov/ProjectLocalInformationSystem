using AutoMapper;
using LocalInformationSystem.Services.DataTransferObjects;
using LocalInformationSystem.Web.ViewModels;

namespace LocalInformationSystem.Web.Mappers
{
    /// <summary>
    ///  Maps EntityDTO -> ViewModel
    /// </summary>
    public class ViewModelAutoMapper : Profile
    {
        public ViewModelAutoMapper()
        {
            #region ProvinceDTO -> ProvinceViewModel Mapping

            CreateMap<ProvinceDTO, ProvinceViewModel>()
                .ReverseMap();

            #endregion
            #region CityDTO -> CityViewModel Mapping

            CreateMap<CityDTO, CityViewModel>()
                .ReverseMap();

            #endregion
            #region LandmarkDTO -> LandmarkViewModel Mapping

            CreateMap<LandmarkDTO, LandmarkViewModel>()
                .ReverseMap();

            #endregion
            #region MountainDTO -> MountainViewModel Mapping

            CreateMap<MountainDTO, MountainViewModel>()
                .ReverseMap();

            #endregion
            #region ParkDTO -> ParkViewModel Mapping

            CreateMap<ParkDTO, ParkViewModel>()
                .ReverseMap();

            #endregion
        }
    }
}