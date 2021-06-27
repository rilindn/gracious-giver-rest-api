using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraciousGiver_BackEnd.Migrations
{
    public partial class OfferedProductResponse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferedProductResponse");

            migrationBuilder.DropTable(
                name: "OrganizationCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OfferedProductResponse",
                columns: table => new
                {
                    OfferedProductResponseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfferedProductId = table.Column<int>(type: "int", nullable: false),
                    OfferedProductResponseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductProviderId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    ResponseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferedProductResponse", x => x.OfferedProductResponseId);
                });

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
    }
}
