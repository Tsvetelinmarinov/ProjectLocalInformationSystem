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
        }
    }
}