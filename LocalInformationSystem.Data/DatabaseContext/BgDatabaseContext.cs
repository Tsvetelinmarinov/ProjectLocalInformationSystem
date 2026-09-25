using LocalInformationSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocalInformationSystem.Data.DatabaseContext;

public partial class BgDatabaseContext : DbContext
{
    #region Constructor

#pragma warning disable IDE0290 // Use primary constructor
    public BgDatabaseContext(DbContextOptions<BgDatabaseContext> options)
        : base(options)
    {
    }
#pragma warning restore IDE0290

    #endregion
    #region Tables

    public virtual DbSet<City> Cities { get; set; }
    public virtual DbSet<HistoricalEvent> HistoricalEvents { get; set; }
    public virtual DbSet<Landmark> Landmarks { get; set; }
    public virtual DbSet<Mountain> Mountains { get; set; }
    public virtual DbSet<Park> Parks { get; set; }
    public virtual DbSet<Province> Provinces { get; set; }
    public virtual DbSet<River> Rivers { get; set; }

    #endregion
    #region Fluent API

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=DESKTOP-SVT1AQQ\\SQLEXPRESS;Database=BgDatabase;Trusted_Connection=true;TrustServerCertificate=true;Encrypt=false;"
        );
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__Cities__F2D21A965B5FE817");
            entity.Property(e => e.IsCapital).HasDefaultValue(false);
            entity.HasOne(d => d.Province).WithMany(p => p.Cities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cities__Province__72C60C4A");
        });
        modelBuilder.Entity<HistoricalEvent>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Historic__7944C87027AFE9F5");
        });
        modelBuilder.Entity<Landmark>(entity =>
        {
            entity.HasKey(e => e.LandmarkId).HasName("PK__Landmark__3195B57F7409FDD7");
            entity.Property(e => e.UnescoSite).HasDefaultValue(false);
            entity.HasOne(d => d.City).WithMany(p => p.Landmarks).HasConstraintName("FK__Landmarks__CityI__76969D2E");
        });
        modelBuilder.Entity<Mountain>(entity =>
        {
            entity.HasKey(e => e.MountainId).HasName("PK__Mountain__268FB26D2178BB2F");
        });
        modelBuilder.Entity<Park>(entity =>
        {
            entity.HasKey(e => e.ParkId).HasName("PK__Parks__7D67D36C69D85A03");
            entity.Property(e => e.UnescoSite).HasDefaultValue(false);
            entity.HasOne(d => d.Mountain).WithMany(p => p.Parks).HasConstraintName("FK__Parks__MountainI__00200768");
        });
        modelBuilder.Entity<Province>(entity =>
        {
            entity.HasKey(e => e.ProvinceId).HasName("PK__Province__FD0A6FA3FB7A9662");
        });
        modelBuilder.Entity<River>(entity =>
        {
            entity.HasKey(e => e.RiverId).HasName("PK__Rivers__54DB03CB67C09060");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    #endregion
}