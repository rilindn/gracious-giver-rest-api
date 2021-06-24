using Microsoft.EntityFrameworkCore.Migrations;

namespace GraciousGiver_BackEnd.Migrations
{
    public partial class Msg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "ProductRequestResponse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Request",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.RequestId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Request");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "ProductRequestResponse");
        }
    }
}
