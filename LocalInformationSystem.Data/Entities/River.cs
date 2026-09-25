using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LocalInformationSystem.Data.Entities;

public partial class River
{
    [Key]
    [Column("RiverID")]
    public int RiverId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "decimal(8, 2)")]
    public decimal LengthKm { get; set; }

    [StringLength(100)]
    public string? Outflow { get; set; }
}
