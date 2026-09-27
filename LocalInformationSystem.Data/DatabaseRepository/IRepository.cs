using LocalInformationSystem.Data.Entities;

namespace LocalInformationSystem.Data.DatabaseRepository
{
    public interface IRepository : IDisposable
    {
        // For ProvincesService.
        IEnumerable<Province> GetAllProvinces(); 

        // For ProvinceService.
        Province FindProvinceById(int id);       

        // For CitiesService.
        IQueryable<City> GetAllCities();
        City FindCityById(int id);

        // For MountainsService.
        IEnumerable<Mountain> GetAllMountains(); 

        // Common.
        int SaveChanges();
        TEntity FindEntityById<TEntity>(int id) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;
    }
}