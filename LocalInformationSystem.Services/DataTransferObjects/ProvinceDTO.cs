namespace LocalInformationSystem.Services.DataTransferObjects;

/// <summary>
///  DTO for transferring the data from the entity Province.
/// </summary>
public class ProvinceDTO
{
    public int ProvinceId { get; set; }
    public string Name { get; set; } = null!;
    public string AdministrativeCenter { get; set; } = null!;
    public decimal? AreaSqKm { get; set; }
    public int? Population { get; set; }
    public virtual ICollection<CityDTO> Cities { get; set; } = new List<CityDTO>();
}