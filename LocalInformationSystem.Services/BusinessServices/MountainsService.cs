using AutoMapper;

using LocalInformationSystem.Data.DatabaseRepository;
using LocalInformationSystem.Data.Entities;
using LocalInformationSystem.Services.DataTransferObjects;
using LocalInformationSystem.Services.ServicesInterfaces;

using static LocalInformationSystem.Services.Common.Constants;

namespace LocalInformationSystem.Services.BusinessServices
{
    /// <summary>
    ///  Communicates with the database repository and serves the MountainsController.
    /// </summary>
    public class MountainsService(IRepository repository, IMapper mapper) : IMountainsService
    {
        /// <summary>
        ///  Retrieves all the mountains from the database.
        /// </summary>
        /// <returns>
        ///  Collection of MountainsDTO`s.
        /// </returns>
        public IEnumerable<MountainDTO> GetAllMountains()
        {
            var mountainEntities = repository.GetAllMountains();

            var mountainDTOs 
                = mapper.Map<IEnumerable<MountainDTO>>(mountainEntities) 
                ?? throw new InvalidOperationException(UnableToMapMountainDTO);

            return mountainDTOs;
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
        public MountainDTO FindMountainById(int id)
        {
            if (id <= 0)
            {
                throw new InvalidOperationException(InvalidMountainId);
            }

            var mountainEntity = repository.FindMountainById(id);

            var mountainDTO 
                = mapper.Map<MountainDTO>(mountainEntity)
                   ?? throw new InvalidOperationException(UnableToMapMountainDTO);

            return mountainDTO;
        }

        /// <summary>
        ///  Updates the mountain in the database.
        /// </summary>
        /// <param name="mountainDTO">
        ///  The mountain DTO to be updated.
        /// </param>
        public void UpdateMountain(MountainDTO mountainDTO)
        {
            var mountainEntity = repository.FindEntityById<Mountain>(mountainDTO.MountainId);

            mountainEntity.Name = mountainDTO.Name;
            mountainEntity.HighestPeak = mountainDTO.HighestPeak;
            mountainEntity.ElevationMeters = mountainDTO.ElevationMeters;
            mountainEntity.AreaSqKm = mountainDTO.AreaSqKm;

            _ = repository.SaveChanges();
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
        public ParkDTO FindParkById(int id)
        {
            if (id <= 0)
            {
                throw new InvalidOperationException(InavlidParkId);
            }

            var parkEntity = repository.FindParkById(id);

            var parkDTO
                = mapper.Map<ParkDTO>(parkEntity)
                   ?? throw new InvalidOperationException(UnableToMapParkToParkDTO);

            return parkDTO;
        }
    }
}