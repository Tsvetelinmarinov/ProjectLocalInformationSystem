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