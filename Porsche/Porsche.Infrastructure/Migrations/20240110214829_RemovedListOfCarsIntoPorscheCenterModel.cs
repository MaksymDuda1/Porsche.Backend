using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Porsche.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedListOfCarsIntoPorscheCenterModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_PorscheCenters_PorscheCenterEntityId",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_PorscheCenterEntityId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "PorscheCenterEntityId",
                table: "Car");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PorscheCenterEntityId",
                table: "Car",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Car_PorscheCenterEntityId",
                table: "Car",
                column: "PorscheCenterEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_PorscheCenters_PorscheCenterEntityId",
                table: "Car",
                column: "PorscheCenterEntityId",
                principalTable: "PorscheCenters",
                principalColumn: "Id");
        }
    }
}
