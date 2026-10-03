using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LocalInformationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoricalEvents",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventYear = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Historic__7944C87027AFE9F5", x => x.EventID);
                });

            migrationBuilder.CreateTable(
                name: "Mountains",
                columns: table => new
                {
                    MountainID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HighestPeak = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ElevationMeters = table.Column<int>(type: "int", nullable: false),
                    AreaSqKm = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Mountain__268FB26D2178BB2F", x => x.MountainID);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    ProvinceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdministrativeCenter = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AreaSqKm = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Population = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Province__FD0A6FA3FB7A9662", x => x.ProvinceID);
                });

            migrationBuilder.CreateTable(
                name: "Rivers",
                columns: table => new
                {
                    RiverID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LengthKm = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Outflow = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rivers__54DB03CB67C09060", x => x.RiverID);
                });

            migrationBuilder.CreateTable(
                name: "Parks",
                columns: table => new
                {
                    ParkID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AreaSqKm = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    EstablishedYear = table.Column<int>(type: "int", nullable: true),
                    MountainID = table.Column<int>(type: "int", nullable: true),
                    UnescoSite = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Parks__7D67D36C69D85A03", x => x.ParkID);
                    table.ForeignKey(
                        name: "FK__Parks__MountainI__00200768",
                        column: x => x.MountainID,
                        principalTable: "Mountains",
                        principalColumn: "MountainID");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProvinceID = table.Column<int>(type: "int", nullable: false),
                    Population = table.Column<int>(type: "int", nullable: true),
                    IsCapital = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    ElevationMeters = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cities__F2D21A965B5FE817", x => x.CityID);
                    table.ForeignKey(
                        name: "FK__Cities__Province__72C60C4A",
                        column: x => x.ProvinceID,
                        principalTable: "Provinces",
                        principalColumn: "ProvinceID");
                });

            migrationBuilder.CreateTable(
                name: "Landmarks",
                columns: table => new
                {
                    LandmarkID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: true),
                    UnescoSite = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Landmark__3195B57F7409FDD7", x => x.LandmarkID);
                    table.ForeignKey(
                        name: "FK__Landmarks__CityI__76969D2E",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "CityID");
                });

            migrationBuilder.InsertData(
                table: "HistoricalEvents",
                columns: new[] { "EventID", "Description", "EventYear", "Title" },
                values: new object[,]
                {
                    { 1, "Establishment of the Bulgarian state under Khan Asparuh.", 681, "Founding of the First Bulgarian State" },
                    { 2, "Treaty of San Stefano and subsequent Congress of Berlin.", 1878, "Liberation of Bulgaria" },
                    { 3, "Simeon I crowned Emperor (Tsar) of the Bulgarians.", 927, "Coronation of Simeon I" },
                    { 4, "Bulgaria falls under Ottoman rule after the Battle of Nicopolis.", 1396, "Ottoman Conquest" },
                    { 5, "Major uprising against Ottoman rule leading to international attention.", 1876, "April Uprising" },
                    { 6, "Political changes and establishment of the People's Republic of Bulgaria.", 1944, "End of WWII in Bulgaria" },
                    { 7, "Transition to a multi-party democratic system and market economy reforms.", 1990, "Democratic Transition" },
                    { 8, "Early formation of Bulgarian tribal unions in the Balkans.", 681, "Establishment of Early Bulgarian Settlements" }
                });

            migrationBuilder.InsertData(
                table: "Mountains",
                columns: new[] { "MountainID", "AreaSqKm", "ElevationMeters", "HighestPeak", "Name" },
                values: new object[,]
                {
                    { 1, 2500.00m, 2925, "Musala", "Rila" },
                    { 2, 1450.00m, 2914, "Vihren", "Pirin" },
                    { 3, 6000.00m, 2376, "Botev", "Stara Planina" },
                    { 4, 3800.00m, 2191, "Golyam Perelik", "Rhodope" },
                    { 5, 266.00m, 2290, "Cherni Vrah", "Vitosha" }
                });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkID", "AreaSqKm", "EstablishedYear", "IsDeleted", "MountainID", "Name", "Type", "UnescoSite" },
                values: new object[,]
                {
                    { 6, 1161.00m, 1995, false, null, "Strandzha Nature Park", "Nature", false },
                    { 7, 500.00m, 2000, false, null, "Bulgaria Coastal Park", "Coastal", false },
                    { 10, 340.00m, 1979, false, null, "Rusenski Lom Nature Park", "Nature", false },
                    { 11, 210.00m, 1999, false, null, "Belasitsa Nature Park", "Nature", false },
                    { 15, 350.00m, 2001, false, null, "Strandzha Coastal Park", "Coastal", false },
                    { 16, 150.00m, 1985, false, null, "Persina Nature Park", "Nature", false },
                    { 17, 48.00m, 1940, false, null, "Ropotamo Reserve Park", "Reserve", false },
                    { 18, 5.00m, 1937, false, null, "Pobiti Kamani Park", "Geological", false },
                    { 19, 110.00m, 1976, false, null, "Kresna Gorge Park", "Regional", false },
                    { 20, 60.00m, 1992, false, null, "Veleka River Park", "River", false },
                    { 23, 20.00m, 1951, false, null, "Kamchia Reserve", "Reserve", false },
                    { 25, 140.00m, 1992, false, null, "Maleshevo Park", "Nature", false },
                    { 26, 210.00m, 1990, false, null, "Sakar Mountain Park", "Regional", false },
                    { 28, 40.00m, 1950, false, null, "Belogradchik Rocks Park", "Geological", false },
                    { 29, 80.00m, 1987, false, null, "Shumen Plateau Nature Park", "Nature", false },
                    { 30, 12.00m, 1994, false, null, "Snezhanka Park", "Recreation", false },
                    { 33, 35.00m, 1995, false, null, "Devol River Park", "River", false },
                    { 34, 25.00m, 1989, false, null, "Gotse Delchev Park", "Regional", false },
                    { 35, 10.00m, 1998, false, null, "Ruse Island Park", "Island", false },
                    { 36, 22.00m, 1976, false, null, "Pleven Meadows Park", "Meadow", false },
                    { 40, 30.00m, 2005, false, null, "Dobrich Coastal Park", "Coastal", false },
                    { 46, 16.00m, 1991, false, null, "Cherven Rocks Park", "Geological", false },
                    { 47, 620.00m, 1975, false, null, "Strandzha Forest Park", "Forest", false }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "ProvinceID", "AdministrativeCenter", "AreaSqKm", "Name", "Population" },
                values: new object[,]
                {
                    { 1, "Sofia", 7000.00m, "Sofia Province", 1200000 },
                    { 2, "Plovdiv", 5000.00m, "Plovdiv Province", 700000 },
                    { 3, "Varna", 3800.00m, "Varna Province", 470000 },
                    { 4, "Burgas", 4100.00m, "Burgas Province", 420000 },
                    { 5, "Veliko Tarnovo", 4000.00m, "Veliko Tarnovo Province", 260000 },
                    { 6, "Blagoevgrad", 6800.00m, "Blagoevgrad Province", 320000 },
                    { 7, "Ruse", 2800.00m, "Ruse Province", 210000 },
                    { 8, "Pleven", 3600.00m, "Pleven Province", 250000 }
                });

            migrationBuilder.InsertData(
                table: "Rivers",
                columns: new[] { "RiverID", "LengthKm", "Name", "Outflow" },
                values: new object[,]
                {
                    { 1, 368.50m, "Iskar", "Danube" },
                    { 2, 480.00m, "Maritsa", "Aegean Sea" },
                    { 3, 2850.00m, "Dunav (Danube)", "Black Sea" },
                    { 4, 415.00m, "Struma", "Aegean Sea" },
                    { 5, 260.00m, "Mesta", "Aegean Sea" },
                    { 6, 290.00m, "Arda", "Maritsa" },
                    { 7, 314.00m, "Osam", "Danube" },
                    { 8, 285.00m, "Yantra", "Danube" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityID", "ElevationMeters", "IsCapital", "Name", "Population", "ProvinceID" },
                values: new object[,]
                {
                    { 1, 550, true, "Sofia", 1241000, 1 },
                    { 2, 164, false, "Plovdiv", 345000, 2 },
                    { 3, 20, false, "Varna", 335000, 3 },
                    { 4, 15, false, "Burgas", 200000, 4 },
                    { 5, 220, false, "Veliko Tarnovo", 70000, 5 },
                    { 6, 350, false, "Blagoevgrad", 85000, 6 },
                    { 7, 45, false, "Ruse", 150000, 7 },
                    { 8, 120, false, "Pleven", 100000, 8 },
                    { 9, 1000, false, "Smolyan", 30000, 6 },
                    { 10, 150, false, "Dobrich", 80000, 3 },
                    { 11, 170, false, "Stara Zagora", 140000, 2 },
                    { 12, 410, false, "Blagoevgrad Town", 45000, 6 }
                });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkID", "AreaSqKm", "EstablishedYear", "IsDeleted", "MountainID", "Name", "Type", "UnescoSite" },
                values: new object[,]
                {
                    { 1, 810.50m, 1992, false, 1, "Rila National Park", "National", false },
                    { 2, 400.75m, 1962, false, 2, "Pirin National Park", "National", true },
                    { 3, 716.00m, 1991, false, 3, "Central Balkan National Park", "National", false },
                    { 4, 2000.00m, 1985, false, 4, "Rhodope Nature Park", "Nature", false },
                    { 5, 265.00m, 1934, false, 5, "Vitosha Nature Park", "Nature", false },
                    { 8, 120.00m, 1975, false, 5, "Iskar Gorge Park", "Regional", false },
                    { 9, 500.00m, 1980, false, 3, "Vrachanski Balkan Nature Park", "Nature", false },
                    { 12, 450.00m, 1988, false, 4, "Osogovo Mountain Park", "Mountain", false },
                    { 13, 75.00m, 1962, false, 5, "Sinite Kamani Reserve", "Reserve", false },
                    { 14, 600.00m, 1990, false, 3, "Sredna Gora Park", "Regional", false },
                    { 21, 95.00m, 1982, false, 3, "Kalofer Peak Park", "Mountain", false },
                    { 22, 30.00m, 1970, false, 3, "Buzludzha Area Park", "Historic", false },
                    { 24, 42.00m, 1985, false, 3, "Uzana Area", "Regional", false },
                    { 27, 18.00m, 1960, false, 5, "Cherni Vrah Reserve", "Reserve", false },
                    { 31, 55.00m, 1978, false, 5, "Bistritsa Forest Park", "Forest", false },
                    { 32, 160.00m, 1983, false, 1, "Beli Iskar Nature Park", "Nature", false },
                    { 37, 14.00m, 1980, false, 3, "Stara Zagora Green Park", "Urban", false },
                    { 38, 65.00m, 1950, false, 2, "Bansko Ski Area Park", "Recreation", false },
                    { 39, 95.00m, 1990, false, 4, "Smolyan Pines Park", "Forest", false },
                    { 41, 9.00m, 1954, false, 3, "Varna Botanical Park", "Botanical", false },
                    { 42, 28.00m, 1965, false, 2, "Plovdiv Hills Park", "Urban", false },
                    { 43, 40.00m, 1950, false, 1, "Sofia Urban Park", "Urban", false },
                    { 44, 180.00m, 1993, false, 4, "Burgas Wetlands Park", "Wetland", false },
                    { 45, 48.00m, 1986, false, 5, "Veliko Tarnovo Hills Park", "Regional", false },
                    { 48, 80.00m, 1982, false, 1, "Iskar Reservoir Park", "Reservoir", false },
                    { 49, 70.00m, 1972, false, 2, "Maritsa Riverbank Park", "River", false },
                    { 50, 210.00m, 1999, false, 5, "Mesta Valley Park", "Valley", false }
                });

            migrationBuilder.InsertData(
                table: "Landmarks",
                columns: new[] { "LandmarkID", "Category", "CityID", "IsDeleted", "Name", "UnescoSite" },
                values: new object[,]
                {
                    { 1, "Religious", 1, false, "Alexander Nevsky Cathedral", false },
                    { 2, "Historic", 2, false, "Ancient Theatre of Philippopolis", false },
                    { 3, "Museum", 3, false, "Pottery of Varna", false },
                    { 4, "Park", 3, false, "Sea Garden", false },
                    { 5, "Historic", 4, false, "Aquae Calidae", false },
                    { 6, "Historic", 5, false, "Tsarevets Fortress", false },
                    { 7, "Historic", 6, false, "Bansko Old Town", false },
                    { 8, "Museum", 7, false, "Ruse Regional History Museum", false },
                    { 9, "Museum", 8, false, "Pleven Panorama", false },
                    { 10, "Recreation", 6, false, "Pirin Mountain Hut", false },
                    { 11, "Historic", 11, false, "Stara Zagora Roman Forum", false },
                    { 12, "Nature", 9, false, "Smolyan Lakes", false },
                    { 13, "Museum", 3, false, "Varna Archaeological Museum", false },
                    { 14, "Religious", 3, false, "Varna Cathedral", false },
                    { 15, "Park", 4, false, "Burgas Sea Garden", false },
                    { 16, "Museum", 4, false, "Burgas Archaeological Museum", false },
                    { 17, "Religious", 1, false, "Rila Monastery", true },
                    { 18, "Recreation", 6, false, "Bansko Ski Area", false },
                    { 19, "Nature", 6, false, "Melnik Pyramids", false },
                    { 20, "Spa", 9, false, "Devin Mineral Baths", false },
                    { 21, "Historic", 11, false, "Shipka Memorial Church", false },
                    { 22, "Historic", 11, false, "Kazanlak Thracian Tomb", true },
                    { 23, "Historic", 8, false, "Sveshtari Tomb", true },
                    { 24, "Museum", 1, false, "Bulgaria National Museum of History", false },
                    { 25, "Square", 2, false, "Alexander of Battenberg Square", false },
                    { 26, "Historic", 2, false, "Roman Stadium of Plovdiv", false },
                    { 27, "Historic", 3, false, "Aladzha Monastery", false },
                    { 28, "Sport", 3, false, "Ticha Stadium", false },
                    { 29, "Historic", 4, false, "Aheloy Historical Site", false },
                    { 30, "Historic", 4, false, "Tsarevo Old Harbor", false },
                    { 31, "Historic", 5, false, "Veliko Tarnovo Old Town", false },
                    { 32, "Museum", 2, false, "Archeological Complex of Plovdiv", false },
                    { 33, "Historic", 7, false, "Ruse Roman Bridge Remains", false },
                    { 34, "Religious", 8, false, "Pleven St. Cyril and Methodius Church", false },
                    { 35, "Historic", 11, false, "Koprivshtitsa Historic Area", false },
                    { 36, "Historic", 7, false, "Belogradchik Fortress", false },
                    { 37, "Nature", 1, false, "Bistritsa Waterfall", false },
                    { 38, "Museum", 8, false, "Pleven Historical Museum", false },
                    { 39, "Museum", 11, false, "Etar Architectural-Ethnographic Complex", false },
                    { 40, "Religious", 6, false, "Rozhen Monastery", false },
                    { 41, "Natural", 9, false, "Devil's Throat Cave", false },
                    { 42, "Nature", 3, false, "Cape Kaliakra", false },
                    { 43, "Historic", 7, false, "Madara Rider", true },
                    { 44, "Historic", 6, false, "Perperikon", false },
                    { 45, "Historic", 3, false, "Ahtopol Old Quarter", false },
                    { 46, "Historic", 3, false, "Old Nessebar", true },
                    { 47, "Historic", 3, false, "Kaliakra Fortress", false },
                    { 48, "Geological", 4, false, "Pobiti Kamani Site", false },
                    { 49, "Religious", 2, false, "Bachkovo Monastery", false },
                    { 50, "Culture", 1, false, "National Palace of Culture", false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceID",
                table: "Cities",
                column: "ProvinceID");

            migrationBuilder.CreateIndex(
                name: "IX_Landmarks_CityID",
                table: "Landmarks",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Parks_MountainID",
                table: "Parks",
                column: "MountainID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricalEvents");

            migrationBuilder.DropTable(
                name: "Landmarks");

            migrationBuilder.DropTable(
                name: "Parks");

            migrationBuilder.DropTable(
                name: "Rivers");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Mountains");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
