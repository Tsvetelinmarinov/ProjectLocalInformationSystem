using LocalInformationSystem.Services.DataTransferObjects;

namespace LocalInformationSystem.Services.ServicesInterfaces
{
    public interface ICitiesService
    {
        IEnumerable<CityDTO> GetAllCities(string? sortingKeyword);
        CityDTO FindCityById(int id);
        void UpdateCity(CityDTO newCity);
        LandmarkDTO FindLandmarkById(int id);
        void UpdateLandmark(LandmarkDTO landmarkDTO);
        void AddLandmark(LandmarkDTO landmarkDTO);
        void DeleteLandmark(int id);
    }
}