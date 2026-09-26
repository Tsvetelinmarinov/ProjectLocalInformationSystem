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
    }
}