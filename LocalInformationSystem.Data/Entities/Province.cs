using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LocalInformationSystem.Data.Entities;

public partial class Province
{
    [Key]
    [Column("ProvinceID")]
    public int ProvinceId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    public string AdministrativeCenter { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? AreaSqKm { get; set; }

    public int? Population { get; set; }

    [InverseProperty("Province")]
    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
