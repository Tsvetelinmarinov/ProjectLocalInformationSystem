using System.ComponentModel.DataAnnotations;

namespace LocalInformationSystem.Web.ViewModels;

/// <summary>
///  Province view model.
/// </summary>
public class ProvinceViewModel
{
    public int ProvinceId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    public string AdministrativeCenter { get; set; } = null!;

    public decimal? AreaSqKm { get; set; }

    public int? Population { get; set; }

    public virtual ICollection<CityViewModel> Cities { get; set; } = new List<CityViewModel>();
}