using System.ComponentModel.DataAnnotations;

using static LocalInformationSystem.Web.Common.Constants;


namespace LocalInformationSystem.Web.ViewModels;

/// <summary>
///  City view model.
/// </summary>
public class CityViewModel
{
    public int CityId { get; set; }

    [Required(ErrorMessage = CityNameIsRequired)]
    [StringLength(100, MinimumLength = 2, ErrorMessage = InvalidCityName)] 
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = CityProvinceIdIsRequired)]
    [Range(1, 100, ErrorMessage = InvalidProvinceId)]
    public int ProvinceId { get; set; }

    public int? Population { get; set; }

    public bool IsCapital { get; set; }

    public int? ElevationMeters { get; set; }

    public virtual ICollection<LandmarkViewModel>? Landmarks { get; set; } = new List<LandmarkViewModel>();

    public virtual ProvinceViewModel? Province { get; set; } = null!;
}