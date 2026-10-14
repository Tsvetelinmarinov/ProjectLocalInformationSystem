using LocalInformationSystem.Data.Entities;

namespace LocalInformationSystem.Data.DatabaseRepositories.Interfaces
{
    public interface IProvinceRepository : IRepository
    {
        IEnumerable<Province> GetAllProvinces(string sortingKeyword);
        Province FindProvinceById(int id);
    }
}