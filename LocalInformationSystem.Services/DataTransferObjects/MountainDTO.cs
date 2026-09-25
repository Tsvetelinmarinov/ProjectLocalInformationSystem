namespace LocalInformationSystem.Services.DataTransferObjects;

/// <summary>
///  DTO for transferring the data from the entity Mountain.
/// </summary>
public class MountainDTO
{
    public int MountainId { get; set; }
    public string Name { get; set; } = null!;
    public string HighestPeak { get; set; } = null!;
    public int ElevationMeters { get; set; }
    public decimal? AreaSqKm { get; set; }
    public virtual ICollection<ParkDTO> Parks { get; set; } = new List<ParkDTO>();
}