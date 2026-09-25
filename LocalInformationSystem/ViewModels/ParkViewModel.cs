using System.ComponentModel.DataAnnotations;

namespace LocalInformationSystem.Web.ViewModels;

/// <summary>
///  Park view model.
/// </summary>
public class ParkViewModel
{
    public int ParkId { get; set; }

    [StringLength(150)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    public string Type { get; set; } = null!;

    public decimal AreaSqKm { get; set; }

    public int? EstablishedYear { get; set; }

    public int? MountainId { get; set; }

    public bool? UnescoSite { get; set; }
    public virtual MountainViewModel? Mountain { get; set; }
}