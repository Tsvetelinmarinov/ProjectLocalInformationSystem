using LocalInformationSystem.Data.Entities;

namespace LocalInformationSystem.Data.DatabaseRepositories.Interfaces
{
    public interface ICitiesRepository : IRepository
    {
        IQueryable<City> GetAllCities();
        City FindCityById(int id);
        Landmark FindLandmarkById(int id);
        void AddLandmark(Landmark landmark);
        void DeleteLandmark(Landmark landmark);
    }
}