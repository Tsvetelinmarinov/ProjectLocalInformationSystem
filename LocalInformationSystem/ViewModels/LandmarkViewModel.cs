using System.ComponentModel.DataAnnotations;
using LocalInformationSystem.Web.Common;

namespace LocalInformationSystem.Web.ViewModels;

/// <summary>
///  Landmark view model.
/// </summary>
public class LandmarkViewModel
{
    public int LandmarkId { get; set; }

    [Required(ErrorMessage = Constants.LandmarkNameIsRequired)]
    [StringLength(
        Constants.LandmarkNameMaxLen, 
        MinimumLength = Constants.LandmarkNameMinLen,
        ErrorMessage = Constants.InvalidLandmarkNameLength
    )]
    [RegularExpression(pattern: 
        Constants.LandmarkNameRegExValidator, 
        ErrorMessage = Constants.LandmarkNameShouldStartWithUppercase
    )]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = Constants.LandmarkCategoryIsRequired)]
    [StringLength(
        Constants.LandmarkCategoryMaxLen, 
        MinimumLength = Constants.LandmarkCategoryMinLen,
        ErrorMessage = Constants.InvalidLandmarkCategoryLength
    )]
    public string Category { get; set; } = null!;

    [Required(ErrorMessage = Constants.LandmarkCityIdIsRequired)]
    public int? CityId { get; set; }

    public bool? UnescoSite { get; set; }

    public virtual CityViewModel? City { get; set; }
}