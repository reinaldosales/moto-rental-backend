using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MRB.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class MotorcyleInRental : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "motorcycle_id",
                table: "rentals",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "ix_rentals_motorcycle_id",
                table: "rentals",
                column: "motorcycle_id");

            migrationBuilder.AddForeignKey(
                name: "fk_rentals_motorcycles_motorcycle_id",
                table: "rentals",
                column: "motorcycle_id",
                principalTable: "motorcycle",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_rentals_motorcycles_motorcycle_id",
                table: "rentals");

            migrationBuilder.DropIndex(
                name: "ix_rentals_motorcycle_id",
                table: "rentals");

            migrationBuilder.DropColumn(
                name: "motorcycle_id",
                table: "rentals");
        }
    }
}
