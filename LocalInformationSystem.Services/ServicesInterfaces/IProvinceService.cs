using LocalInformationSystem.Services.DataTransferObjects;

namespace LocalInformationSystem.Services.ServicesInterfaces
{
    public interface IProvinceService
    {
        IEnumerable<ProvinceDTO> GetAllProvinces(string sortingKeyword);
        ProvinceDTO FindProvinceById(int id);
        void Update(ProvinceDTO provinceDTO);
    }
}