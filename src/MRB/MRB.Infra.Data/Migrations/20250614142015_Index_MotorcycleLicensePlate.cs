using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MRB.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Index_MotorcycleLicensePlate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_motorcycle_model",
                table: "motorcycle");

            migrationBuilder.CreateIndex(
                name: "ix_motorcycle_license_plate",
                table: "motorcycle",
                column: "license_plate",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_motorcycle_license_plate",
                table: "motorcycle");

            migrationBuilder.CreateIndex(
                name: "ix_motorcycle_model",
                table: "motorcycle",
                column: "model",
                unique: true);
        }
    }
}
