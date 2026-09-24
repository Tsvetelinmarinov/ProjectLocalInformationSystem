using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LocalInformationSystem.Data.Entities;

public partial class Park
{
    [Key]
    [Column("ParkID")]
    public int ParkId { get; set; }

    [StringLength(150)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    public string Type { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal AreaSqKm { get; set; }

    public int? EstablishedYear { get; set; }

    [Column("MountainID")]
    public int? MountainId { get; set; }

    public bool? UnescoSite { get; set; }

    [ForeignKey("MountainId")]
    [InverseProperty("Parks")]
    public virtual Mountain? Mountain { get; set; }
}
