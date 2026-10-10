using AutoMapper;
using LocalInformationSystem.Data.DatabaseRepository;
using LocalInformationSystem.Services.DataTransferObjects;
using LocalInformationSystem.Services.ServicesInterfaces;
using static LocalInformationSystem.Services.Common.ServiceConstants;

namespace LocalInformationSystem.Services.BusinessServices
{
    /// <summary>
    ///  Holds buissnes logic for the EventsController.
    /// </summary>
    public class EventsService(IRepository repo, IMapper mapper) : IEventsService
    {
        /// <summary>
        ///  Retrieves all the historical events from the database.
        /// </summary>
        /// <returns>
        ///  <see cref="IEnumerable{HistoricalEvent}"/> with all the events.
        /// </returns>
        public IEnumerable<HistoricalEventDTO> GetAllEvents()
        {
            var eventEntities = repo.GetAllEvents();

            var eventDtos
                = mapper.Map<IEnumerable<HistoricalEventDTO>>(eventEntities)
                  ?? throw new InvalidOperationException(UnableToMapEventToEventDTO);

            return eventDtos;
        }
    }
}
