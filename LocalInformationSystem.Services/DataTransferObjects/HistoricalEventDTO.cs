namespace LocalInformationSystem.Services.DataTransferObjects;

/// <summary>
///  DTO for transferring the data from the entity HistoricalEvent.
/// </summary>
public class HistoricalEventDTO
{
    public int EventId { get; set; }
    public int EventYear { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
}