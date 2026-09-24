using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalInformationSystem.Data.Entities;

public partial class City
{
    [Key]
    [Column("CityID")]
    public int CityId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("ProvinceID")]
    public int ProvinceId { get; set; }

    public int? Population { get; set; }

    public bool? IsCapital { get; set; }

    public int? ElevationMeters { get; set; }

    [InverseProperty("City")]
    public virtual ICollection<Landmark> Landmarks { get; set; } = new List<Landmark>();

    [ForeignKey("ProvinceId")]
    [InverseProperty("Cities")]
    public virtual Province Province { get; set; } = null!;
}