using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROIECT_SESIUNE_VINURI.Migrations
{
    public partial class AdaugatVin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    An = table.Column<int>(type: "int", nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Culoare = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vin", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vin");
        }
    }
}
