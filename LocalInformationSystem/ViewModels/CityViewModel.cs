using System.ComponentModel.DataAnnotations;

using static LocalInformationSystem.Web.Common.WebConstants;


namespace LocalInformationSystem.Web.ViewModels;

/// <summary>
///  City view model.
/// </summary>
public class CityViewModel
{
    public int CityId { get; set; }

    [Required(ErrorMessage = CityNameIsRequired)]
    [StringLength(
        CityNameMaxLen, 
        MinimumLength = CityNameMinLen, 
        ErrorMessage = InvalidCityName
    )]
    [RegularExpression(CityNameRegExValidator, ErrorMessage = InvalidCityNameConvention)]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = CityProvinceIdIsRequired)]
    [Range(
        ProvinceIdMinLen, 
        ProvinceIdMaxLen, 
        ErrorMessage = InvalidProvinceId
    )]
    public int? ProvinceId { get; set; }

    [Required(ErrorMessage = CityPopulationIsRequired)]
    [Range(
        CityPopulationMinLen,
        CityPopulationMaxLen,
        ErrorMessage = InvalidCityPopulation
    )]
    public int? Population { get; set; }

    public bool IsCapital { get; set; }

    [Required(ErrorMessage = CityElevationRequired)]
    [Range(
        CityElevationMinLen,
        CityElevationMaxLen,
        ErrorMessage = InvalidCityElevationRange
    )]
    public int? ElevationMeters { get; set; }

    public virtual ICollection<LandmarkViewModel>? Landmarks { get; set; } = new List<LandmarkViewModel>();

    public virtual ProvinceViewModel? Province { get; set; }
}