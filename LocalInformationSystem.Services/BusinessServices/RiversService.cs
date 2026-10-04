using AutoMapper;
using LocalInformationSystem.Data.DatabaseRepository;
using LocalInformationSystem.Services.DataTransferObjects;
using LocalInformationSystem.Services.ServicesInterfaces;
using static LocalInformationSystem.Services.Common.ServiceConstants;

namespace LocalInformationSystem.Services.BusinessServices
{
    public class RiversService(IRepository repository, IMapper mapper) : IRiversService
    {
        /// <summary>
        ///  Gets all rivers.
        /// </summary>
        /// <returns>
        ///  The collection of RiverDTO objects representing all rivers.
        /// </returns>
        public IEnumerable<RiverDTO> GetAllRivers()
        {
            var riverEntities = repository.GetAllRivers();
            var riverDTOs = mapper.Map<IEnumerable<RiverDTO>>(riverEntities)
                ?? throw new InvalidOperationException(UnableToMapRiverToRiverDTO);

            return riverDTOs;
        }
    }
}