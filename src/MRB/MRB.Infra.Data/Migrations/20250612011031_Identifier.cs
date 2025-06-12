using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MRB.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Identifier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "identifier",
                table: "rentals",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "identifier",
                table: "motorcycle",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "identifier",
                table: "delivery_person",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "identifier",
                table: "rentals");

            migrationBuilder.DropColumn(
                name: "identifier",
                table: "motorcycle");

            migrationBuilder.DropColumn(
                name: "identifier",
                table: "delivery_person");
        }
    }
}
