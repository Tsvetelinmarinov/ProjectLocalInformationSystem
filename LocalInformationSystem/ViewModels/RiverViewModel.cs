using System.ComponentModel.DataAnnotations;
using static LocalInformationSystem.Web.Common.WebConstants;

namespace LocalInformationSystem.Web.ViewModels;

/// <summary>
///  River view model.
/// </summary>
public class RiverViewModel
{
    public int RiverId { get; set; }

    [Required(ErrorMessage = RiverNameIsRequired)]
    [StringLength(
        RiverNameMaxLen,
        MinimumLength = RiverNameMinLen,
        ErrorMessage = InvalidRiverNameLength
    )]
    [RegularExpression(
        RiverNameRegExValidator,
        ErrorMessage = InvalidRiverName
    )]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = RiverLengthIsRequired)]
    [Range(
        RiverLengthMin,
        RiverLengthMax,
        ErrorMessage = InvalidRiverLength
    )]
    public decimal LengthKm { get; set; }

    [StringLength(
        RiverOutflowNameMaxLen,
        MinimumLength = RiverOutflowNameMinLen,
        ErrorMessage = InvalidRiverOutflowNameLength
    )]
    public string? Outflow { get; set; }
}