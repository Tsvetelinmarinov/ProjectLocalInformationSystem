using LocalInformationSystem.Services.DataTransferObjects;

namespace LocalInformationSystem.Services.ServicesInterfaces
{
    public interface IRiversService
    {
        IEnumerable<RiverDTO> GetAllRivers();
        void AddRiver(RiverDTO riverDto);
        void DeleteRiver(int id);
        RiverDTO FindRiverById(int id);
    }
}