using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROIECT_SESIUNE_VINURI.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vanzari",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    VinID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vanzari", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vanzari_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Vanzari_Vin_VinID",
                        column: x => x.VinID,
                        principalTable: "Vin",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vanzari_UserID",
                table: "Vanzari",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Vanzari_VinID",
                table: "Vanzari",
                column: "VinID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vanzari");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
