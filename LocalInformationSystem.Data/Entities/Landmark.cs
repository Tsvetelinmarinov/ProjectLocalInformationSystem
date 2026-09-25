using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LocalInformationSystem.Data.Entities;

public partial class Landmark
{
    [Key]
    [Column("LandmarkID")]
    public int LandmarkId { get; set; }

    [StringLength(150)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    public string Category { get; set; } = null!;

    [Column("CityID")]
    public int? CityId { get; set; }

    public bool? UnescoSite { get; set; }

    [ForeignKey("CityId")]
    [InverseProperty("Landmarks")]
    public virtual City? City { get; set; }
}
