using System.ComponentModel.DataAnnotations;

namespace LocalInformationSystem.Web.ViewModels;

/// <summary>
///  Landmark view model.
/// </summary>
public class LandmarkViewModel
{
    public int LandmarkId { get; set; }

    [StringLength(150)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    public string Category { get; set; } = null!;

    public int? CityId { get; set; }

    public bool? UnescoSite { get; set; }

    public virtual CityViewModel? City { get; set; }
}