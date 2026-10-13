using System.ComponentModel.DataAnnotations;
using static LocalInformationSystem.Web.Common.WebConstants;

namespace LocalInformationSystem.Web.ViewModels;

/// <summary>
///  HistoricalEvent view model.
/// </summary>
public class HistoricalEventViewModel
{
    public int EventId { get; set; }

    [Required(ErrorMessage = EventYearIsRequired)]
    [Range(
        EventYearMin,
        EventYearMax,
        ErrorMessage = InvalidEventYear
    )]
    public int EventYear { get; set; }

    [Required(ErrorMessage = EventTitleIsRequired)]
    [StringLength(
        EventTitleMaxLen,
        MinimumLength = EventTitleMinLen,
        ErrorMessage = InvalidTitleLength
    )]
    [RegularExpression(
        EventTitleRegExValidator,
        ErrorMessage = EventTitleShouldBeUppercase
    )]
    public string Title { get; set; } = null!;

    [StringLength(
        EventDescriptionMaxLen,
        MinimumLength = EventDescriptionMinLen,
        ErrorMessage = InvalidEventDescriptionLength
    )]
    public string? Description { get; set; }
}