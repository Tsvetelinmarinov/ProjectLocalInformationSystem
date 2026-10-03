using LocalInformationSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocalInformationSystem.Data.DatabaseContext;

public partial class BgDatabaseContext
{
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        // Seed principal entities first (Provinces -> Cities), then others.
        modelBuilder.Entity<Province>().HasData(
            new Province { ProvinceId = 1, Name = "Sofia Province", AdministrativeCenter = "Sofia", AreaSqKm = 7_000.00m, Population = 1_200_000 },
            new Province { ProvinceId = 2, Name = "Plovdiv Province", AdministrativeCenter = "Plovdiv", AreaSqKm = 5_000.00m, Population = 700_000 },
            new Province { ProvinceId = 3, Name = "Varna Province", AdministrativeCenter = "Varna", AreaSqKm = 3_800.00m, Population = 470_000 },
            new Province { ProvinceId = 4, Name = "Burgas Province", AdministrativeCenter = "Burgas", AreaSqKm = 4_100.00m, Population = 420_000 },
            new Province { ProvinceId = 5, Name = "Veliko Tarnovo Province", AdministrativeCenter = "Veliko Tarnovo", AreaSqKm = 4_000.00m, Population = 260_000 },
            new Province { ProvinceId = 6, Name = "Blagoevgrad Province", AdministrativeCenter = "Blagoevgrad", AreaSqKm = 6_800.00m, Population = 320_000 },
            new Province { ProvinceId = 7, Name = "Ruse Province", AdministrativeCenter = "Ruse", AreaSqKm = 2_800.00m, Population = 210_000 },
            new Province { ProvinceId = 8, Name = "Pleven Province", AdministrativeCenter = "Pleven", AreaSqKm = 3_600.00m, Population = 250_000 }
        );

        modelBuilder.Entity<City>().HasData(
            new City { CityId = 1, Name = "Sofia", ProvinceId = 1, Population = 1_241_000, IsCapital = true, ElevationMeters = 550 },
            new City { CityId = 2, Name = "Plovdiv", ProvinceId = 2, Population = 345_000, IsCapital = false, ElevationMeters = 164 },
            new City { CityId = 3, Name = "Varna", ProvinceId = 3, Population = 335_000, IsCapital = false, ElevationMeters = 20 },
            new City { CityId = 4, Name = "Burgas", ProvinceId = 4, Population = 200_000, IsCapital = false, ElevationMeters = 15 },
            new City { CityId = 5, Name = "Veliko Tarnovo", ProvinceId = 5, Population = 70_000, IsCapital = false, ElevationMeters = 220 },
            new City { CityId = 6, Name = "Blagoevgrad", ProvinceId = 6, Population = 85_000, IsCapital = false, ElevationMeters = 350 },
            new City { CityId = 7, Name = "Ruse", ProvinceId = 7, Population = 150_000, IsCapital = false, ElevationMeters = 45 },
            new City { CityId = 8, Name = "Pleven", ProvinceId = 8, Population = 100_000, IsCapital = false, ElevationMeters = 120 },
            new City { CityId = 9, Name = "Smolyan", ProvinceId = 6, Population = 30_000, IsCapital = false, ElevationMeters = 1000 },
            new City { CityId = 10, Name = "Dobrich", ProvinceId = 3, Population = 80_000, IsCapital = false, ElevationMeters = 150 },
            new City { CityId = 11, Name = "Stara Zagora", ProvinceId = 2, Population = 140_000, IsCapital = false, ElevationMeters = 170 },
            new City { CityId = 12, Name = "Blagoevgrad Town", ProvinceId = 6, Population = 45_000, IsCapital = false, ElevationMeters = 410 }
        );

        modelBuilder.Entity<Mountain>().HasData(
            new Mountain { MountainId = 1, Name = "Rila", HighestPeak = "Musala", ElevationMeters = 2925, AreaSqKm = 2_500.00m },
            new Mountain { MountainId = 2, Name = "Pirin", HighestPeak = "Vihren", ElevationMeters = 2914, AreaSqKm = 1_450.00m },
            new Mountain { MountainId = 3, Name = "Stara Planina", HighestPeak = "Botev", ElevationMeters = 2376, AreaSqKm = 6_000.00m },
            new Mountain { MountainId = 4, Name = "Rhodope", HighestPeak = "Golyam Perelik", ElevationMeters = 2191, AreaSqKm = 3_800.00m },
            new Mountain { MountainId = 5, Name = "Vitosha", HighestPeak = "Cherni Vrah", ElevationMeters = 2290, AreaSqKm = 266.00m }
        );

        modelBuilder.Entity<Park>().HasData(
            new Park { ParkId = 1, Name = "Rila National Park", Type = "National", AreaSqKm = 810.50m, EstablishedYear = 1992, MountainId = 1, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 2, Name = "Pirin National Park", Type = "National", AreaSqKm = 400.75m, EstablishedYear = 1962, MountainId = 2, UnescoSite = true, IsDeleted = false },
            new Park { ParkId = 3, Name = "Central Balkan National Park", Type = "National", AreaSqKm = 716.00m, EstablishedYear = 1991, MountainId = 3, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 4, Name = "Rhodope Nature Park", Type = "Nature", AreaSqKm = 2000.00m, EstablishedYear = 1985, MountainId = 4, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 5, Name = "Vitosha Nature Park", Type = "Nature", AreaSqKm = 265.00m, EstablishedYear = 1934, MountainId = 5, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 6, Name = "Strandzha Nature Park", Type = "Nature", AreaSqKm = 1161.00m, EstablishedYear = 1995, MountainId = null, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 7, Name = "Bulgaria Coastal Park", Type = "Coastal", AreaSqKm = 500.00m, EstablishedYear = 2000, MountainId = null, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 8, Name = "Iskar Gorge Park", Type = "Regional", AreaSqKm = 120.00m, EstablishedYear = 1975, MountainId = 5, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 9, Name = "Vrachanski Balkan Nature Park", Type = "Nature", AreaSqKm = 500.00m, EstablishedYear = 1980, MountainId = 3, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 10, Name = "Rusenski Lom Nature Park", Type = "Nature", AreaSqKm = 340.00m, EstablishedYear = 1979, MountainId = null, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 11, Name = "Belasitsa Nature Park", Type = "Nature", AreaSqKm = 210.00m, EstablishedYear = 1999, MountainId = null, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 12, Name = "Osogovo Mountain Park", Type = "Mountain", AreaSqKm = 450.00m, EstablishedYear = 1988, MountainId = 4, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 13, Name = "Sinite Kamani Reserve", Type = "Reserve", AreaSqKm = 75.00m, EstablishedYear = 1962, MountainId = 5, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 14, Name = "Sredna Gora Park", Type = "Regional", AreaSqKm = 600.00m, EstablishedYear = 1990, MountainId = 3, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 15, Name = "Strandzha Coastal Park", Type = "Coastal", AreaSqKm = 350.00m, EstablishedYear = 2001, MountainId = null, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 16, Name = "Persina Nature Park", Type = "Nature", AreaSqKm = 150.00m, EstablishedYear = 1985, MountainId = null, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 17, Name = "Ropotamo Reserve Park", Type = "Reserve", AreaSqKm = 48.00m, EstablishedYear = 1940, MountainId = null, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 18, Name = "Pobiti Kamani Park", Type = "Geological", AreaSqKm = 5.00m, EstablishedYear = 1937, MountainId = null, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 19, Name = "Kresna Gorge Park", Type = "Regional", AreaSqKm = 110.00m, EstablishedYear = 1976, MountainId = null, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 20, Name = "Veleka River Park", Type = "River", AreaSqKm = 60.00m, EstablishedYear = 1992, MountainId = null, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 21, Name = "Kalofer Peak Park", Type = "Mountain", AreaSqKm = 95.00m, EstablishedYear = 1982, MountainId = 3, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 22, Name = "Buzludzha Area Park", Type = "Historic", AreaSqKm = 30.00m, EstablishedYear = 1970, MountainId = 3, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 23, Name = "Kamchia Reserve", Type = "Reserve", AreaSqKm = 20.00m, EstablishedYear = 1951, MountainId = null, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 24, Name = "Uzana Area", Type = "Regional", AreaSqKm = 42.00m, EstablishedYear = 1985, MountainId = 3, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 25, Name = "Maleshevo Park", Type = "Nature", AreaSqKm = 140.00m, EstablishedYear = 1992, MountainId = null, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 26, Name = "Sakar Mountain Park", Type = "Regional", AreaSqKm = 210.00m, EstablishedYear = 1990, MountainId = null, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 27, Name = "Cherni Vrah Reserve", Type = "Reserve", AreaSqKm = 18.00m, EstablishedYear = 1960, MountainId = 5, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 28, Name = "Belogradchik Rocks Park", Type = "Geological", AreaSqKm = 40.00m, EstablishedYear = 1950, MountainId = null, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 29, Name = "Shumen Plateau Nature Park", Type = "Nature", AreaSqKm = 80.00m, EstablishedYear = 1987, MountainId = null, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 30, Name = "Snezhanka Park", Type = "Recreation", AreaSqKm = 12.00m, EstablishedYear = 1994, MountainId = null, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 31, Name = "Bistritsa Forest Park", Type = "Forest", AreaSqKm = 55.00m, EstablishedYear = 1978, MountainId = 5, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 32, Name = "Beli Iskar Nature Park", Type = "Nature", AreaSqKm = 160.00m, EstablishedYear = 1983, MountainId = 1, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 33, Name = "Devol River Park", Type = "River", AreaSqKm = 35.00m, EstablishedYear = 1995, MountainId = null, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 34, Name = "Gotse Delchev Park", Type = "Regional", AreaSqKm = 25.00m, EstablishedYear = 1989, MountainId = null, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 35, Name = "Ruse Island Park", Type = "Island", AreaSqKm = 10.00m, EstablishedYear = 1998, MountainId = null, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 36, Name = "Pleven Meadows Park", Type = "Meadow", AreaSqKm = 22.00m, EstablishedYear = 1976, MountainId = null, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 37, Name = "Stara Zagora Green Park", Type = "Urban", AreaSqKm = 14.00m, EstablishedYear = 1980, MountainId = 3, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 38, Name = "Bansko Ski Area Park", Type = "Recreation", AreaSqKm = 65.00m, EstablishedYear = 1950, MountainId = 2, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 39, Name = "Smolyan Pines Park", Type = "Forest", AreaSqKm = 95.00m, EstablishedYear = 1990, MountainId = 4, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 40, Name = "Dobrich Coastal Park", Type = "Coastal", AreaSqKm = 30.00m, EstablishedYear = 2005, MountainId = null, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 41, Name = "Varna Botanical Park", Type = "Botanical", AreaSqKm = 9.00m, EstablishedYear = 1954, MountainId = 3, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 42, Name = "Plovdiv Hills Park", Type = "Urban", AreaSqKm = 28.00m, EstablishedYear = 1965, MountainId = 2, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 43, Name = "Sofia Urban Park", Type = "Urban", AreaSqKm = 40.00m, EstablishedYear = 1950, MountainId = 1, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 44, Name = "Burgas Wetlands Park", Type = "Wetland", AreaSqKm = 180.00m, EstablishedYear = 1993, MountainId = 4, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 45, Name = "Veliko Tarnovo Hills Park", Type = "Regional", AreaSqKm = 48.00m, EstablishedYear = 1986, MountainId = 5, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 46, Name = "Cherven Rocks Park", Type = "Geological", AreaSqKm = 16.00m, EstablishedYear = 1991, MountainId = null, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 47, Name = "Strandzha Forest Park", Type = "Forest", AreaSqKm = 620.00m, EstablishedYear = 1975, MountainId = null, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 48, Name = "Iskar Reservoir Park", Type = "Reservoir", AreaSqKm = 80.00m, EstablishedYear = 1982, MountainId = 1, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 49, Name = "Maritsa Riverbank Park", Type = "River", AreaSqKm = 70.00m, EstablishedYear = 1972, MountainId = 2, UnescoSite = false, IsDeleted = false },
            new Park { ParkId = 50, Name = "Mesta Valley Park", Type = "Valley", AreaSqKm = 210.00m, EstablishedYear = 1999, MountainId = 5, UnescoSite = false, IsDeleted = false }
        );

        modelBuilder.Entity<River>().HasData(
            new River { RiverId = 1, Name = "Iskar", LengthKm = 368.50m, Outflow = "Danube" },
            new River { RiverId = 2, Name = "Maritsa", LengthKm = 480.00m, Outflow = "Aegean Sea" },
            new River { RiverId = 3, Name = "Dunav (Danube)", LengthKm = 2_850.00m, Outflow = "Black Sea" },
            new River { RiverId = 4, Name = "Struma", LengthKm = 415.00m, Outflow = "Aegean Sea" },
            new River { RiverId = 5, Name = "Mesta", LengthKm = 260.00m, Outflow = "Aegean Sea" },
            new River { RiverId = 6, Name = "Arda", LengthKm = 290.00m, Outflow = "Maritsa" },
            new River { RiverId = 7, Name = "Osam", LengthKm = 314.00m, Outflow = "Danube" },
            new River { RiverId = 8, Name = "Yantra", LengthKm = 285.00m, Outflow = "Danube" }
        );

        modelBuilder.Entity<Landmark>().HasData(
            new Landmark { LandmarkId = 1, Name = "Alexander Nevsky Cathedral", Category = "Religious", CityId = 1, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 2, Name = "Ancient Theatre of Philippopolis", Category = "Historic", CityId = 2, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 3, Name = "Pottery of Varna", Category = "Museum", CityId = 3, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 4, Name = "Sea Garden", Category = "Park", CityId = 3, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 5, Name = "Aquae Calidae", Category = "Historic", CityId = 4, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 6, Name = "Tsarevets Fortress", Category = "Historic", CityId = 5, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 7, Name = "Bansko Old Town", Category = "Historic", CityId = 6, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 8, Name = "Ruse Regional History Museum", Category = "Museum", CityId = 7, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 9, Name = "Pleven Panorama", Category = "Museum", CityId = 8, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 10, Name = "Pirin Mountain Hut", Category = "Recreation", CityId = 6, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 11, Name = "Stara Zagora Roman Forum", Category = "Historic", CityId = 11, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 12, Name = "Smolyan Lakes", Category = "Nature", CityId = 9, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 13, Name = "Varna Archaeological Museum", Category = "Museum", CityId = 3, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 14, Name = "Varna Cathedral", Category = "Religious", CityId = 3, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 15, Name = "Burgas Sea Garden", Category = "Park", CityId = 4, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 16, Name = "Burgas Archaeological Museum", Category = "Museum", CityId = 4, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 17, Name = "Rila Monastery", Category = "Religious", CityId = 1, UnescoSite = true, IsDeleted = false },
            new Landmark { LandmarkId = 18, Name = "Bansko Ski Area", Category = "Recreation", CityId = 6, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 19, Name = "Melnik Pyramids", Category = "Nature", CityId = 6, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 20, Name = "Devin Mineral Baths", Category = "Spa", CityId = 9, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 21, Name = "Shipka Memorial Church", Category = "Historic", CityId = 11, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 22, Name = "Kazanlak Thracian Tomb", Category = "Historic", CityId = 11, UnescoSite = true, IsDeleted = false },
            new Landmark { LandmarkId = 23, Name = "Sveshtari Tomb", Category = "Historic", CityId = 8, UnescoSite = true, IsDeleted = false },
            new Landmark { LandmarkId = 24, Name = "Bulgaria National Museum of History", Category = "Museum", CityId = 1, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 25, Name = "Alexander of Battenberg Square", Category = "Square", CityId = 2, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 26, Name = "Roman Stadium of Plovdiv", Category = "Historic", CityId = 2, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 27, Name = "Aladzha Monastery", Category = "Historic", CityId = 3, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 28, Name = "Ticha Stadium", Category = "Sport", CityId = 3, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 29, Name = "Aheloy Historical Site", Category = "Historic", CityId = 4, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 30, Name = "Tsarevo Old Harbor", Category = "Historic", CityId = 4, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 31, Name = "Veliko Tarnovo Old Town", Category = "Historic", CityId = 5, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 32, Name = "Archeological Complex of Plovdiv", Category = "Museum", CityId = 2, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 33, Name = "Ruse Roman Bridge Remains", Category = "Historic", CityId = 7, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 34, Name = "Pleven St. Cyril and Methodius Church", Category = "Religious", CityId = 8, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 35, Name = "Koprivshtitsa Historic Area", Category = "Historic", CityId = 11, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 36, Name = "Belogradchik Fortress", Category = "Historic", CityId = 7, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 37, Name = "Bistritsa Waterfall", Category = "Nature", CityId = 1, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 38, Name = "Pleven Historical Museum", Category = "Museum", CityId = 8, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 39, Name = "Etar Architectural-Ethnographic Complex", Category = "Museum", CityId = 11, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 40, Name = "Rozhen Monastery", Category = "Religious", CityId = 6, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 41, Name = "Devil's Throat Cave", Category = "Natural", CityId = 9, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 42, Name = "Cape Kaliakra", Category = "Nature", CityId = 3, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 43, Name = "Madara Rider", Category = "Historic", CityId = 7, UnescoSite = true, IsDeleted = false },
            new Landmark { LandmarkId = 44, Name = "Perperikon", Category = "Historic", CityId = 6, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 45, Name = "Ahtopol Old Quarter", Category = "Historic", CityId = 3, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 46, Name = "Old Nessebar", Category = "Historic", CityId = 3, UnescoSite = true, IsDeleted = false },
            new Landmark { LandmarkId = 47, Name = "Kaliakra Fortress", Category = "Historic", CityId = 3, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 48, Name = "Pobiti Kamani Site", Category = "Geological", CityId = 4, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 49, Name = "Bachkovo Monastery", Category = "Religious", CityId = 2, UnescoSite = false, IsDeleted = false },
            new Landmark { LandmarkId = 50, Name = "National Palace of Culture", Category = "Culture", CityId = 1, UnescoSite = false, IsDeleted = false }
        );

        modelBuilder.Entity<HistoricalEvent>().HasData(
            new HistoricalEvent { EventId = 1, EventYear = 681, Title = "Founding of the First Bulgarian State", Description = "Establishment of the Bulgarian state under Khan Asparuh." },
            new HistoricalEvent { EventId = 2, EventYear = 1878, Title = "Liberation of Bulgaria", Description = "Treaty of San Stefano and subsequent Congress of Berlin." },
            new HistoricalEvent { EventId = 3, EventYear = 927, Title = "Coronation of Simeon I", Description = "Simeon I crowned Emperor (Tsar) of the Bulgarians." },
            new HistoricalEvent { EventId = 4, EventYear = 1396, Title = "Ottoman Conquest", Description = "Bulgaria falls under Ottoman rule after the Battle of Nicopolis." },
            new HistoricalEvent { EventId = 5, EventYear = 1876, Title = "April Uprising", Description = "Major uprising against Ottoman rule leading to international attention." },
            new HistoricalEvent { EventId = 6, EventYear = 1944, Title = "End of WWII in Bulgaria", Description = "Political changes and establishment of the People's Republic of Bulgaria." },
            new HistoricalEvent { EventId = 7, EventYear = 1990, Title = "Democratic Transition", Description = "Transition to a multi-party democratic system and market economy reforms." },
            new HistoricalEvent { EventId = 8, EventYear = 681, Title = "Establishment of Early Bulgarian Settlements", Description = "Early formation of Bulgarian tribal unions in the Balkans." }
        );
    }
}
