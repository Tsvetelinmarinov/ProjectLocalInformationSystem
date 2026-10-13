using LocalInformationSystem.Data.Entities;

namespace LocalInformationSystem.Data.DatabaseRepositories.Interfaces
{
    public interface IMountainRepository : IRepository
    {
        IEnumerable<Mountain> GetAllMountains();
        Mountain FindMountainById(int id);
        Park FindParkById(int id);
        void AddPark(Park park);
    }
}