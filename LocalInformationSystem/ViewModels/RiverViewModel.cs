using System.ComponentModel.DataAnnotations;

namespace LocalInformationSystem.Web.ViewModels;

/// <summary>
///  River view model.
/// </summary>
public class RiverViewModel
{
    public int RiverId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    public decimal LengthKm { get; set; }

    [StringLength(100)]
    public string? Outflow { get; set; }
}