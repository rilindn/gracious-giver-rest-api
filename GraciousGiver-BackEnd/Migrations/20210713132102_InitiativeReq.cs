using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GraciousGiver_BackEnd.Migrations
{
    public partial class InitiativeReq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InitiativeRequest",
                columns: table => new
                {
                    IniciativeRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IniciativeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IniciativeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IniciativePhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IniciativeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    Checked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitiativeRequest", x => x.IniciativeRequestId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InitiativeRequest");
        }
    }
}
