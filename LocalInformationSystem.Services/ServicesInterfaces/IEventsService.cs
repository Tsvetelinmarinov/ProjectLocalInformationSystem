using LocalInformationSystem.Services.DataTransferObjects;

namespace LocalInformationSystem.Services.ServicesInterfaces
{
    public interface IEventsService
    {
        IEnumerable<HistoricalEventDTO> GetAllEvents(); 
    }
}