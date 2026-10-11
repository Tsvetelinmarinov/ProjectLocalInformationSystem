using AutoMapper;
using LocalInformationSystem.Data.DatabaseRepositories.Interfaces;
using LocalInformationSystem.Data.Entities;
using LocalInformationSystem.Services.DataTransferObjects;
using LocalInformationSystem.Services.ServicesInterfaces;
using static LocalInformationSystem.Services.Common.ServiceConstants;

namespace LocalInformationSystem.Services.BusinessServices
{
    /// <summary>
    ///  Holds buissnes logic for the EventsController.
    /// </summary>
    public class EventsService(IEventRepository repo, IMapper mapper) : IEventsService
    {
        /// <summary>
        ///  Adds new event to the HistoricalEvents table.
        /// </summary>
        /// <param name="eventDTO">
        ///  The HistoricalEventDTO with the new information.
        /// </param>
        public void AddEvent(HistoricalEventDTO eventDTO)
        {
            HistoricalEvent eventEntity = mapper.Map<HistoricalEvent>(eventDTO)
                ?? throw new InvalidOperationException(UnableToMapEventDTOToEvent);

            repo.AddEntity(eventEntity);
        }

        /// <summary>
        ///  Deletes Historical event from the database.
        /// </summary>
        /// <param name="id">
        ///  The ID of the HistoricalEvent.
        /// </param>
        public void DeleteEvent(int id)
        {
            if (id <= 0)
            {
                throw new InvalidOperationException(InvalidEventId);
            }

            var eventEntity = repo.FindEntityById<HistoricalEvent>(id);
            repo.Delete(eventEntity);
        }

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
