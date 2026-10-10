using LocalInformationSystem.Data.Entities;

namespace LocalInformationSystem.Data.DatabaseRepositories.Interfaces
{
    public interface IProvinceRepository : IRepository
    {
        IEnumerable<Province> GetAllProvinces();
        Province FindProvinceById(int id);
    }
}