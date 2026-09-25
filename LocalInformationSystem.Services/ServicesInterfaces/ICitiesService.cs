using LocalInformationSystem.Services.DataTransferObjects;

namespace LocalInformationSystem.Services.ServicesInterfaces
{
    public interface ICitiesService
    {
        IEnumerable<CityDTO> GetAllCities();
    }
}