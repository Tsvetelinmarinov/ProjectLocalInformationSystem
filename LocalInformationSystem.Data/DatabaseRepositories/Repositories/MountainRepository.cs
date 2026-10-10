using LocalInformationSystem.Data.DatabaseContext;
using LocalInformationSystem.Data.DatabaseRepositories.Interfaces;
using LocalInformationSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using static LocalInformationSystem.Data.Common.Constants;

namespace LocalInformationSystem.Data.DatabaseRepositories.Repositories
{
    public class MountainRepository(BgDatabaseContext dbContext) : IMountainRepository
    {
        /// <summary>
        ///  Retrieves all the mountains from the database.
        /// </summary>
        /// <returns>
        ///  Collection with the mountains.
        /// </returns>
        public IEnumerable<Mountain> GetAllMountains()
        {
            var mountainEntities = dbContext
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
        ///  Retrieves concrete landmark with its city from the database.
        /// </summary>
        /// <param name="id">
        ///  The ID of the landmark.
        /// </param>
        /// <returns>
        ///  The landmark with the specified ID.
        /// </returns>
        public Landmark FindLandmarkById(int id)
        {
            var landmark = dbContext
                .Landmarks
                .AsNoTracking()
                .Include((lm) => lm.City)
                .FirstOrDefault((lm) => lm.LandmarkId == id)
                  ?? throw new InvalidOperationException(NoSuchLandmarkInDb);

            return landmark;
        }

        /// <summary>
        ///  Retrieves concrete mountain from the database.
        /// </summary>
        /// <param name="id">
        ///  The ID of the mountain.
        /// </param>
        /// <returns>
        ///  The mountain with the specified ID.
        /// </returns>
        public Mountain FindMountainById(int id)
        {
            var mountain = dbContext
                .Mountains
                .AsNoTracking()
                .Include((mountain) => mountain.Parks)
                .FirstOrDefault((mountain) => mountain.MountainId == id)
                  ?? throw new InvalidOperationException(NoSuchEntityInDb);

            return mountain;
        }

        /// <summary>
        ///  Retrieves concrete park from the database.
        /// </summary>
        /// <param name="id">
        ///  The ID of the park.
        /// </param>
        /// <returns>
        ///  The park with the specified ID.
        /// </returns>
        public Park FindParkById(int id)
        {
            var parkEntity = dbContext
                .Parks
                .AsNoTracking()
                .Include((park) => park.Mountain)
                .FirstOrDefault((park) => park.ParkId == id)
                  ?? throw new InvalidOperationException(NoSuchEntityInDb);

            return parkEntity;
        }

        /// <summary>
        ///  Adds new park to the database.
        /// </summary>
        /// <param name="park">
        ///  The park entity to be added to the database.
        /// </param>
        public void AddPark(Park park)
        {
            dbContext.Parks.Add(park);
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