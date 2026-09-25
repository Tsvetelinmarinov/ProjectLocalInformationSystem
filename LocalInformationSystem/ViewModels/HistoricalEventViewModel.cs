using System.ComponentModel.DataAnnotations;

namespace LocalInformationSystem.Web.ViewModels;

/// <summary>
///  HistoricalEvent view model.
/// </summary>
public class HistoricalEventViewModel
{
    public int EventId { get; set; }

    public int EventYear { get; set; }

    [StringLength(200)]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }
}