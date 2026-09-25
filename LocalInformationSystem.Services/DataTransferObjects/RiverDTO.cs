namespace LocalInformationSystem.Services.DataTransferObjects;

/// <summary>
///  DTO for transferring the data from the entity River.
/// </summary>
public class RiverDTO
{
    public int RiverId { get; set; }
    public string Name { get; set; } = null!;
    public decimal LengthKm { get; set; }
    public string? Outflow { get; set; }
}