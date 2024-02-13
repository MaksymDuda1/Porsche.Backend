using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Porsche.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NormalizePhotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Photos",
                newName: "MainPhotoPath");

            migrationBuilder.AddColumn<string[]>(
                name: "PhotosPaths",
                table: "Photos",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotosPaths",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "MainPhotoPath",
                table: "Photos",
                newName: "Address");
        }
    }
}
