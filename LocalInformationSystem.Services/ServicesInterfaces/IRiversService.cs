using LocalInformationSystem.Services.DataTransferObjects;

namespace LocalInformationSystem.Services.ServicesInterfaces
{
    public interface IRiversService
    {
        IEnumerable<RiverDTO> GetAllRivers();
    }
}