using Microsoft.EntityFrameworkCore.Migrations;

namespace GraciousGiver_BackEnd.Migrations
{
    public partial class OrganizationLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Organization",
                newName: "State");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Organization",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Organization");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Organization",
                newName: "Location");
        }
    }
}
