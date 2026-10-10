using LocalInformationSystem.Data.DatabaseContext;
using LocalInformationSystem.Data.DatabaseRepositories.Interfaces;
using LocalInformationSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using static LocalInformationSystem.Data.Common.Constants;

namespace LocalInformationSystem.Data.DatabaseRepositories.Interfaces
{
    public interface IRiverRepository : IRepository
    {
        IEnumerable<River> GetAllRivers();
    }
}