namespace LocalInformationSystem.Services.DataTransferObjects;

/// <summary>
///  DTO for transferring the data from the entity Park.
/// </summary>
public class ParkDTO
{
    public int ParkId { get; set; }
    public string Name { get; set; } = null!;
    public string Type { get; set; } = null!;
    public decimal AreaSqKm { get; set; }
    public int? EstablishedYear { get; set; }
    public int? MountainId { get; set; }
    public bool? UnescoSite { get; set; }
    public virtual MountainDTO? Mountain { get; set; }
}