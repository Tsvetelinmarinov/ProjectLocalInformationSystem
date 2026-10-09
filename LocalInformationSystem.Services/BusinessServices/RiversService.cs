using AutoMapper;
using LocalInformationSystem.Data.DatabaseRepository;
using LocalInformationSystem.Data.Entities;
using LocalInformationSystem.Services.DataTransferObjects;
using LocalInformationSystem.Services.ServicesInterfaces;
using static LocalInformationSystem.Services.Common.ServiceConstants;

// ReSharper disable SuggestVarOrType_SimpleTypes
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

        /// <summary>
        ///  Adds new river to the database.
        /// </summary>
        /// <param name="riverDto">
        /// The RiverDTO with the new information.
        /// </param>
        public void AddRiver(RiverDTO riverDto)
        {
            River riverEntity = mapper.Map<River>(riverDto);
            repository.AddEntity(riverEntity);
        }

        /// <summary>
        ///  Deletes a river from the database by its ID.
        /// </summary>
        /// <param name="id">
        ///  The ID of the river to delete.
        /// </param>
        public void DeleteRiver(int id)
        {
            if (id <= 0)
            {
                throw new InvalidOperationException(InvalidRiverId);
            }

            var riverEntity = repository.FindEntityById<River>(id);
            repository.Delete(riverEntity);
        }

        /// <summary>
        ///  Retrieves a river by its ID and returns it as a RiverDTO.
        /// </summary>
        /// <param name="id">
        ///  The ID of the river to retrieve.
        /// </param>
        /// <returns>
        ///  The RiverDTO representing the retrieved river.
        /// </returns>
        public RiverDTO FindRiverById(int id)
        {
            if (id <= 0)
            {
                throw new InvalidOperationException(InvalidRiverId);
            }

            River riverEntity = repository.FindEntityById<River>(id);

            RiverDTO riverDto 
                = mapper.Map<RiverDTO>(riverEntity)
                  ?? throw new InvalidOperationException(UnableToMapRiverToRiverDTO);

            return riverDto;
        }
    }
}