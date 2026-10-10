using LocalInformationSystem.Data.Entities;

namespace LocalInformationSystem.Data.DatabaseRepositories.Interfaces
{
    public interface IRepository : IDisposable
    {
        // For CitiesService.
       

        // For MountainsService.
        

        // For RiversService.
        

        // For EventsService.
        IEnumerable<HistoricalEvent> GetAllEvents();

        // Common.
        int SaveChanges();
        TEntity FindEntityById<TEntity>(int id) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        void AddEntity<TEntity>(TEntity entity) where TEntity : class;
    }
}