using Microsoft.EntityFrameworkCore.Migrations;

namespace GraciousGiver_BackEnd.Migrations
{
    public partial class offerprod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Offer",
                table: "OfferProduct",
                newName: "RequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestId",
                table: "OfferProduct",
                newName: "Offer");
        }
    }
}
