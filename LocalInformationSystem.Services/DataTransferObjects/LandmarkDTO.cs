namespace LocalInformationSystem.Services.DataTransferObjects;

/// <summary>
///  DTO for transferring the data from the entity Landmark.
/// </summary>
public class LandmarkDTO
{
    public int LandmarkId { get; set; }
    public string Name { get; set; } = null!;
    public string Category { get; set; } = null!;
    public int? CityId { get; set; }
    public bool? UnescoSite { get; set; }
    public virtual CityDTO? City { get; set; }
}