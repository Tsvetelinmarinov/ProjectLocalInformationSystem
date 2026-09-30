using AutoMapper;

using LocalInformationSystem.Data.DatabaseRepository;
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
    }
}