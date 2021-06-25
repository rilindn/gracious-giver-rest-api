using Microsoft.EntityFrameworkCore.Migrations;

namespace GraciousGiver_BackEnd.Migrations
{
    public partial class OrganizationCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrganizationCategory",
                columns: table => new
                {
                    OrganizationCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationCategory", x => x.OrganizationCategoryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizationCategory");
        }
    }
}
