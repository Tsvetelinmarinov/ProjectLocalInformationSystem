using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LocalInformationSystem.Data.Entities;

public partial class HistoricalEvent
{
    [Key]
    [Column("EventID")]
    public int EventId { get; set; }

    public int EventYear { get; set; }

    [StringLength(200)]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }
}
