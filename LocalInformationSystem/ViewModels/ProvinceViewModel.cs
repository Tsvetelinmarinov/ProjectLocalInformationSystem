using System.ComponentModel.DataAnnotations;

using static LocalInformationSystem.Web.Common.Constants;

namespace LocalInformationSystem.Web.ViewModels;

/// <summary>
///  Province view model.
/// </summary>
public class ProvinceViewModel
{
    public int ProvinceId { get; set; }

    [Required(ErrorMessage = ProvinceNameIsRequired)]
    [StringLength(
        ProvinceNameMaxLen,
        MinimumLength = ProvinceNameMinLen,
        ErrorMessage = InvalidProvinceNameLength
    )]
    [RegularExpression(
        ProvinceNameRegExValidator,
        ErrorMessage = ProvinceShouldStartWithUppercase
    )]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = ProvinceAdminCentreIsRequired)]
    [StringLength(
        ProvinceNameMaxLen,
        MinimumLength = ProvinceNameMinLen,
        ErrorMessage = InvalidProvinceNameLength
    )]
    [RegularExpression(
        ProvinceNameRegExValidator, 
        ErrorMessage = ProvinceShouldStartWithUppercase
    )]
    public string AdministrativeCenter { get; set; } = null!;

    [Required(ErrorMessage = ProvinceAreaIsRequired)]
    [Range(
        ProvinceAreaMin,
        ProvinceAreaMax,
        ErrorMessage = InvalidProvinceAreaSpan
    )]
    public decimal? AreaSqKm { get; set; }

    [Required(ErrorMessage = ProvincePopulationIsRequired)]
    [Range(
        ProvincePopulationMin,
        ProvincePopulationMax,
        ErrorMessage = InvalidProvincePopulation
    )]
    public int? Population { get; set; }

    public virtual ICollection<CityViewModel>? Cities { get; set; } = new List<CityViewModel>();
}