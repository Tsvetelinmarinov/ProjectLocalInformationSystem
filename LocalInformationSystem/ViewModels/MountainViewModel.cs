using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

using System.ComponentModel.DataAnnotations;
using static LocalInformationSystem.Web.Common.Constants;

namespace LocalInformationSystem.Web.ViewModels;

/// <summary>
///  Mountain view model.
/// </summary>
public class MountainViewModel
{
    public int MountainId { get; set; }

    [Required(ErrorMessage = MountainNameIsRequired)]
    [StringLength(MountainNameMaxLen)]
    [RegularExpression(
        MountainNameRegExValidator,
        ErrorMessage = MountainNameShouldStartWithUppercase
    )]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = MountainHighestPeakIsRequired)]
    [StringLength(MountainHighestPeakMaxLen)]
    [RegularExpression(
        MountainHighestPeakRegExValidator,
        ErrorMessage = MountainHighestPeakShouldStartWithUppercase
    )]
    public string HighestPeak { get; set; } = null!;

    [Required(ErrorMessage = MountainElevationIsRequired)]
    [Range(
        MountainElevationMin,
        MountainElevationMax, 
        ErrorMessage = InvalidMountainElevation
    )]
    public int ElevationMeters { get; set; }

    [Required(ErrorMessage = MountainAreaIsRequired)]
    [Range(
        MountainAreaMin,
        MountainAreaMax,
        ErrorMessage = MountainAreaInvalidRange
    )]
    public decimal? AreaSqKm { get; set; }

    [ValidateNever]
    public virtual ICollection<ParkViewModel> Parks { get; set; } = new List<ParkViewModel>();
}