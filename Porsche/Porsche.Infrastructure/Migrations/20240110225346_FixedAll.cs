using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Porsche.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarCenters");

            migrationBuilder.DropTable(
                name: "CarPhotos");

            migrationBuilder.AddColumn<int>(
                name: "CarEntityId",
                table: "Photos",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Photos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_CarEntityId",
                table: "Photos",
                column: "CarEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_CarId",
                table: "Photos",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Car_CarId",
                table: "Photos",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Cars_CarEntityId",
                table: "Photos",
                column: "CarEntityId",
                principalTable: "Cars",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Car_CarId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Cars_CarEntityId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_CarEntityId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_CarId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "CarEntityId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Photos");

            migrationBuilder.CreateTable(
                name: "CarCenters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarId = table.Column<int>(type: "integer", nullable: false),
                    PorscheCenterId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarCenters_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarCenters_PorscheCenter_PorscheCenterId",
                        column: x => x.PorscheCenterId,
                        principalTable: "PorscheCenter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarId = table.Column<int>(type: "integer", nullable: false),
                    PhotoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarPhotos_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarPhotos_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarCenters_CarId",
                table: "CarCenters",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarCenters_PorscheCenterId",
                table: "CarCenters",
                column: "PorscheCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_CarPhotos_CarId",
                table: "CarPhotos",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarPhotos_PhotoId",
                table: "CarPhotos",
                column: "PhotoId");
        }
    }
}
