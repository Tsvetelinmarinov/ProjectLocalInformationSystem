using LocalInformationSystem.Data.Entities;

namespace LocalInformationSystem.Data.DatabaseRepository
{
    public interface IRepository : IDisposable
    {
        IEnumerable<Province> GetAllProvinces(); //=> For ProvincesService.
        IEnumerable<City> GetAllCities(); //=> For CitiesService.
    }
}