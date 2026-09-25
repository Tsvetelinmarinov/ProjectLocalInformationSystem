using LocalInformationSystem.Services.DataTransferObjects;

namespace LocalInformationSystem.Services.ServicesInterfaces
{
    public interface IProvinceService
    {
        IEnumerable<ProvinceDTO> GetAllProvinces();
    }
}