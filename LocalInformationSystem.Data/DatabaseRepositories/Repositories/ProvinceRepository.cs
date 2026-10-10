using LocalInformationSystem.Data.DatabaseContext;
using LocalInformationSystem.Data.DatabaseRepositories.Interfaces;
using LocalInformationSystem.Data.Entities;

using static LocalInformationSystem.Data.Common.Constants;

using Microsoft.EntityFrameworkCore;

namespace LocalInformationSystem.Data.DatabaseRepositories.Repositories
{
    public class ProvinceRepository(BgDatabaseContext dbContext) : IProvinceRepository
    {
        /// <summary>
        ///  Retrieves all the provinces from the database.
        /// </summary>
        /// <returns>Collection of provinces.</returns>
        public IEnumerable<Province> GetAllProvinces()
        {
            var allProvinces = dbContext
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
            var province = dbContext
                .Provinces
                .AsNoTracking()
                .Include((province) => province.Cities)
                .FirstOrDefault((province) => province.ProvinceId == id)
                  ?? throw new InvalidOperationException(ProvinceNotFound);

            return province;
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
