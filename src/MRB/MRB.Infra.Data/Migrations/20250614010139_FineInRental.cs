using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MRB.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class FineInRental : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "fine",
                table: "rentals",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fine",
                table: "rentals");
        }
    }
}
