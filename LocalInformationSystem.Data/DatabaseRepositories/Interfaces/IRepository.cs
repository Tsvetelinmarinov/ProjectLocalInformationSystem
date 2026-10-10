using LocalInformationSystem.Data.Entities;

namespace LocalInformationSystem.Data.DatabaseRepositories.Interfaces
{
    public interface IRepository : IDisposable
    {
        // For CitiesService.
        IQueryable<City> GetAllCities();
        City FindCityById(int id);
        Landmark FindLandmarkById(int id);
        void AddLandmark(Landmark landmark);
        void DeleteLandmark(Landmark landmark);

        // For MountainsService.
        IEnumerable<Mountain> GetAllMountains();
        Mountain FindMountainById(int id);
        Park FindParkById(int id);
        void AddPark(Park park);

        // For RiversService.
        IEnumerable<River> GetAllRivers();

        // For EventsService.
        IEnumerable<HistoricalEvent> GetAllEvents();

        // Common.
        int SaveChanges();
        TEntity FindEntityById<TEntity>(int id) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        void AddEntity<TEntity>(TEntity entity) where TEntity : class;
    }
}