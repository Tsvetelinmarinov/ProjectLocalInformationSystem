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
            #region Province -> ProvinceDTO Mapping

            CreateMap<ProvinceDTO, ProvinceViewModel>()
                .ReverseMap();

            #endregion
        }
    }
}