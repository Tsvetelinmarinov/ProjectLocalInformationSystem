using System.ComponentModel.DataAnnotations;

namespace LocalInformationSystem.Web.ViewModels;

/// <summary>
///  City view model.
/// </summary>
public class CityViewModel
{
    public int CityId { get; set; }

    [StringLength(100)] 
    public string Name { get; set; } = null!;

    public int ProvinceId { get; set; }

    public int? Population { get; set; }

    public bool? IsCapital { get; set; }

    public int? ElevationMeters { get; set; }

    public virtual ICollection<LandmarkViewModel> Landmarks { get; set; } = new List<LandmarkViewModel>();

    public virtual ProvinceViewModel Province { get; set; } = null!;
}