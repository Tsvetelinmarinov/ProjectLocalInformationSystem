using System.ComponentModel.DataAnnotations;
using LocalInformationSystem.Web.Common;

namespace LocalInformationSystem.Web.ViewModels;

/// <summary>
///  Landmark view model.
/// </summary>
public class LandmarkViewModel
{
    public int LandmarkId { get; set; }

    [Required(ErrorMessage = WebConstants.LandmarkNameIsRequired)]
    [StringLength(
        WebConstants.LandmarkNameMaxLen, 
        MinimumLength = WebConstants.LandmarkNameMinLen,
        ErrorMessage = WebConstants.InvalidLandmarkNameLength
    )]
    [RegularExpression(pattern: 
        WebConstants.LandmarkNameRegExValidator, 
        ErrorMessage = WebConstants.LandmarkNameShouldStartWithUppercase
    )]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = WebConstants.LandmarkCategoryIsRequired)]
    [StringLength(
        WebConstants.LandmarkCategoryMaxLen, 
        MinimumLength = WebConstants.LandmarkCategoryMinLen,
        ErrorMessage = WebConstants.InvalidLandmarkCategoryLength
    )]
    public string Category { get; set; } = null!;

    [Required(ErrorMessage = WebConstants.LandmarkCityIdIsRequired)]
    public int? CityId { get; set; }

    public bool UnescoSite { get; set; }

    public virtual CityViewModel? City { get; set; }
}