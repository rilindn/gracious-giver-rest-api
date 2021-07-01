using Microsoft.EntityFrameworkCore.Migrations;

namespace GraciousGiver_BackEnd.Migrations
{
    public partial class PendingOrg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "PendingOrganizationsRequest",
                newName: "State");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "PendingOrganizationsRequest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Documentation",
                table: "PendingOrganizationsRequest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "PendingOrganizationsRequest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "PendingOrganizationsRequest");

            migrationBuilder.DropColumn(
                name: "Documentation",
                table: "PendingOrganizationsRequest");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "PendingOrganizationsRequest");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "PendingOrganizationsRequest",
                newName: "Location");
        }
    }
}
