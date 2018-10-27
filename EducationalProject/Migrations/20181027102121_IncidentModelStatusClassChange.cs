using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationalProject.Migrations
{
    public partial class IncidentModelStatusClassChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Incidents",
                newName: "IncidentId");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Incidents",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IncidentId",
                table: "Incidents",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Incidents",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
