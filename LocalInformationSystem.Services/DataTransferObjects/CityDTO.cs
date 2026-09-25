namespace LocalInformationSystem.Services.DataTransferObjects;

/// <summary>
///  DTO for transferring the data from the entity City.
/// </summary>
public class CityDTO
{
    public int CityId { get; set; }
    public string Name { get; set; } = null!;
    public int ProvinceId { get; set; }
    public int? Population { get; set; }
    public bool? IsCapital { get; set; }
    public int? ElevationMeters { get; set; }
    public virtual ICollection<LandmarkDTO> Landmarks { get; set; } = new List<LandmarkDTO>();
    public virtual ProvinceDTO Province { get; set; } = null!;
}