using Microsoft.EntityFrameworkCore.Migrations;

namespace GraciousGiver_BackEnd.Migrations
{
    public partial class checkedR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "checkedR",
                table: "Product_Request",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
