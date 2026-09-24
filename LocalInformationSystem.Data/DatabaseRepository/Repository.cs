using LocalInformationSystem.Data.DatabaseContext;

namespace LocalInformationSystem.Data.DatabaseRepository
{
    /// <summary>
    ///  Communicates with the database context and serves the services.
    /// </summary>
    public class Repository : IRepository
    {
        #region Private Fields

        // Database context.
        private readonly BgDatabaseContext _dbContext;

        #endregion
        #region Constructor

        /// <summary>
        ///  Constructs new Repository with the context provided from the IoC container.
        /// </summary>
        /// <param name="dbContext">The database context for this repository.</param>
#pragma warning disable IDE0290 // Use primary constructor
        public Repository(BgDatabaseContext dbContext)
        {
            this._dbContext = dbContext;
        }
#pragma warning restore IDE0290

        #endregion
        #region Functionality

        /// <summary>
        ///  Releases the resources used by the DbContext instance.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this._dbContext.Dispose();
        }

        #endregion
    }
}