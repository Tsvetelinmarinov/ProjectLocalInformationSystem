using LocalInformationSystem.Data.DatabaseContext;
using LocalInformationSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using static LocalInformationSystem.Data.Common.Constants;

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
        ///  Retrieves all the provinces from the database.
        /// </summary>
        /// <returns>Collection of provinces.</returns>
        public IEnumerable<Province> GetAllProvinces()
        {
            var allProvinces = this._dbContext
                .Provinces
                .AsNoTracking()
                .Include((province) => province.Cities) //=> Need to get the total count of the cities per province.
                .OrderBy((province) => province.ProvinceId)
                .ThenBy((province) => province.Name);

            if (allProvinces.Any() is false)
            {
                throw new InvalidOperationException(ProvinceError);
            }

            return allProvinces;
        }

        /// <summary>
        ///  Finds specific province by its ID.
        /// </summary>
        /// <param name="id">
        ///  The ID of the province.
        /// </param>
        /// <returns>
        ///  The province with the specified ID.
        ///  If there are no found province, InvalidOperationException is thrown.
        /// </returns>
        public Province FindProvinceById(int id)
        {
            var province = this._dbContext
                .Provinces
                .AsNoTracking()
                .Include((province) => province.Cities)
                .FirstOrDefault((province) => province.ProvinceId == id) 
                  ?? throw new InvalidOperationException(ProvinceNotFound);

            return province;
        }

        /// <summary>
        ///  Retrieves all the cities from the database.
        /// </summary>
        /// <returns>Collection of the cities.</returns>
        public IQueryable<City> GetAllCities()
        {
            var cities = this._dbContext
                .Cities
                .AsNoTracking()
                .Include((city) => city.Landmarks)
                .Include((city) => city.Province)
                .OrderBy((city) => city.Name)
                .ThenBy((city) => city.Province.Name)
                .ThenBy((city) => city.ProvinceId)
                ?? throw new InvalidOperationException(NoCitiesFromDb);

            return cities;
        }

        /// <summary>
        ///  Retrieves all the mountains from the database.
        /// </summary>
        /// <returns>
        ///  Collection with the mountains.
        /// </returns>
        public IEnumerable<Mountain> GetAllMountains()
        {
            var mountainEntities = this._dbContext
                .Mountains
                .AsNoTracking()
                .Include((mountain) => mountain.Parks) //=> Needed to get the count of the parks per mountain.
                .OrderByDescending((mountain) => mountain.ElevationMeters)
                .ThenBy((mountain) => mountain.Name)
                .ThenBy((mountain) => mountain.MountainId) 
                  ?? throw new InvalidOperationException(NoMountainsFromDb);

            return mountainEntities;
        }

        /// <summary>
        ///  Saves changes made to the entities.
        /// </summary>
        /// <returns>
        ///  Total changes saved(total record affected).
        /// </returns>
        public int SaveChanges()
            => this._dbContext.SaveChanges();

        /// <summary>
        ///  Retrieves entity in from the database by its ID.
        /// </summary>
        /// <typeparam name="TEntity">
        ///  The type of the entity.
        /// </typeparam>
        /// <param name="id">
        ///  The ID of the entity.
        /// </param>
        /// <returns>
        ///  The entity that is found. If not found any - throws InvalidOperationException().
        /// </returns>
        public TEntity FindEntityById<TEntity>(int id)
            where TEntity : class
        {
            var entity = this._dbContext.Find<TEntity>([id])
                ?? throw new InvalidOperationException(NoSuchEntityInDb);

            return entity;
        }

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