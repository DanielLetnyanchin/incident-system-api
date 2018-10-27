using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationalProject.Migrations
{
    public partial class IncidentModelAddIModificationHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Incidents",
                newName: "DateModified");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Incidents",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Incidents");

            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "Incidents",
                newName: "Created");
        }
    }
}
