using AutoMapper;
using LocalInformationSystem.Data.Entities;
using LocalInformationSystem.Services.DataTransferObjects;

namespace LocalInformationSystem.Services.Mappers
{
    /// <summary>
    ///  Maps Entity -> EntityDTO. 
    /// </summary>
    public class DTOAutoMapper : Profile
    {
        public DTOAutoMapper()
        {
            #region Province -> ProvinceDTO Mapping

            CreateMap<Province, ProvinceDTO>()
                .ReverseMap();

            #endregion
            #region City -> CityDTO Mapping

            CreateMap<City, CityDTO>()
                .ReverseMap();

            #endregion
            #region Landmark -> LandmarkDTO Mapping

            CreateMap<Landmark, LandmarkDTO>()
                .ReverseMap();

            #endregion
            #region Mountain -> MountainDTO Mapping

            CreateMap<Mountain, MountainDTO>()
                .ReverseMap();

            #endregion
            #region Park -> ParkDTO Mapping

            CreateMap<Park, ParkDTO>()
                .ReverseMap();

            #endregion
        }
    }
}