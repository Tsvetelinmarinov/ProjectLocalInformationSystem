using LocalInformationSystem.Data.Entities;

namespace LocalInformationSystem.Data.DatabaseRepository
{
    public interface IRepository : IDisposable
    {
        IEnumerable<Province> GetAllProvinces(); // For ProvincesService.
        Province FindProvinceById(int id);       // For ProvinceService.
        
        IQueryable<City> GetAllCities();         // For CitiesService.

        IEnumerable<Mountain> GetAllMountains(); // For MountainsService.

        int SaveChanges();

        TEntity FindEntityById<TEntity>(int id) where TEntity : class;
    }
}