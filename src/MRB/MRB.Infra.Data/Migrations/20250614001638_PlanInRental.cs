using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MRB.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class PlanInRental : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "plan",
                table: "rentals",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "return_date",
                table: "rentals",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "plan",
                table: "rentals");

            migrationBuilder.DropColumn(
                name: "return_date",
                table: "rentals");
        }
    }
}
