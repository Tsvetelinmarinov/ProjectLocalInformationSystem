using LocalInformationSystem.Data.DatabaseContext;
using LocalInformationSystem.Data.DatabaseRepositories.Interfaces;
using LocalInformationSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using static LocalInformationSystem.Data.Common.Constants;

namespace LocalInformationSystem.Data.DatabaseRepositories.Repositories
{
    internal class CitiesRepository(BgDatabaseContext dbContext) : ICitiesRepository
    {
        /// <summary>
        ///  Retrieves all the cities from the database.
        /// </summary>
        /// <returns>Collection of the cities.</returns>
        public IQueryable<City> GetAllCities()
        {
            var cities = dbContext
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
        ///  Retrieves specific city from the database by its ID.
        /// </summary>
        /// <param name="id">
        ///  The ID of the city
        /// </param>
        /// <returns>
        ///  The city with the specified ID.
        /// </returns>
        public City FindCityById(int id)
        {
            var city = dbContext
                .Cities
                .AsNoTracking()
                .Include((city) => city.Landmarks)
                .FirstOrDefault((city) => city.CityId == id)
                  ?? throw new InvalidOperationException(NoSuchCityInDb);

            return city;
        }

        /// <summary>
        ///  Adds new landmark to the database.
        /// </summary>
        /// <param name="landmark">
        ///  The landmark entity to be added to the database.
        /// </param>
        public void AddLandmark(Landmark landmark)
        {
            dbContext.Landmarks.Add(landmark);
            this.SaveChanges();
        }

        /// <summary>
        ///  Deletes landmark from the database.
        /// </summary>
        /// <param name="landmark">
        ///  The landmark entity to be deleted from the database.
        /// </param>
        public void DeleteLandmark(Landmark landmark)
        {
            dbContext.Landmarks.Remove(landmark);
            this.SaveChanges();
        }

        /// <summary>
        ///  Saves changes made to the entities.
        /// </summary>
        /// <returns>
        ///  Total changes saved(total record affected).
        /// </returns>
        public int SaveChanges()
            => dbContext.SaveChanges();

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
            var entity = dbContext.Find<TEntity>([id])
                ?? throw new InvalidOperationException(NoSuchEntityInDb);

            return entity;
        }

        /// <summary>
        ///  Deletes entity from the database.
        /// </summary>
        /// <param name="entity">
        /// The entity to be deleted.
        /// </param>
        /// <typeparam name="TEntity">
        ///  The data type of the entity.
        /// </typeparam>
        public void Delete<TEntity>(TEntity entity)
            where TEntity : class
        {
            _ = dbContext.Remove(entity);
            _ = this.SaveChanges();
        }

        /// <summary>
        ///  Adds entity to the database.
        /// </summary>
        /// <param name="entity">
        /// The entity to be added.
        /// </param>
        /// <typeparam name="TEntity">
        /// The data type of the entity.
        /// </typeparam>
        public void AddEntity<TEntity>(TEntity entity)
            where TEntity : class
        {
            /*Entry not needed*/
            _ = dbContext
            .Set<TEntity>()
            .Add(entity);

            this.SaveChanges();
        }

        /// <summary>
        ///  Releases the resources used by the DbContext instance.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            dbContext.Dispose();
        }
    }
}