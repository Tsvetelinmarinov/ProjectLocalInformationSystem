using LocalInformationSystem.Data.Entities;

namespace LocalInformationSystem.Data.DatabaseRepositories.Interfaces
{
    public interface IEventRepository : IRepository
    {
        IEnumerable<HistoricalEvent> GetAllEvents();
    }
}