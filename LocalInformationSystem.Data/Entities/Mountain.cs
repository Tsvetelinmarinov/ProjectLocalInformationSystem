using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LocalInformationSystem.Data.Entities;

public partial class Mountain
{
    [Key]
    [Column("MountainID")]
    public int MountainId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    public string HighestPeak { get; set; } = null!;

    public int ElevationMeters { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? AreaSqKm { get; set; }

    [InverseProperty("Mountain")]
    public virtual ICollection<Park> Parks { get; set; } = new List<Park>();
}
