namespace LocalInformationSystem.Data.DatabaseRepositories.Interfaces
{
    public interface IRepository : IDisposable
    {
        int SaveChanges();
        TEntity FindEntityById<TEntity>(int id) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        void AddEntity<TEntity>(TEntity entity) where TEntity : class;
    }
}