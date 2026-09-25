using System.ComponentModel.DataAnnotations;

namespace LocalInformationSystem.Web.ViewModels;

/// <summary>
///  Mountain view model.
/// </summary>
public class MountainViewModel
{
    public int MountainId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    public string HighestPeak { get; set; } = null!;

    public int ElevationMeters { get; set; }

    public decimal? AreaSqKm { get; set; }

    public virtual ICollection<ParkViewModel> Parks { get; set; } = new List<ParkViewModel>();
}