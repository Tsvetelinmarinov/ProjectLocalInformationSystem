using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalInformationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedIsDeletedPropertyToParkAndLandmarkEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Parks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Landmarks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Parks");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Landmarks");
        }
    }
}
