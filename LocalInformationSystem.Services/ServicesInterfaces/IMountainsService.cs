using LocalInformationSystem.Services.DataTransferObjects;

namespace LocalInformationSystem.Services.ServicesInterfaces
{
    public interface IMountainsService
    {
        IEnumerable<MountainDTO> GetAllMountains();
    }
}