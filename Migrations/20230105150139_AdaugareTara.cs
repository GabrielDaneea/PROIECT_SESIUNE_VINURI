using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROIECT_SESIUNE_VINURI.Migrations
{
    public partial class AdaugareTara : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaraID",
                table: "Vin",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tara",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tara", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vin_TaraID",
                table: "Vin",
                column: "TaraID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vin_Tara_TaraID",
                table: "Vin",
                column: "TaraID",
                principalTable: "Tara",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vin_Tara_TaraID",
                table: "Vin");

            migrationBuilder.DropTable(
                name: "Tara");

            migrationBuilder.DropIndex(
                name: "IX_Vin_TaraID",
                table: "Vin");

            migrationBuilder.DropColumn(
                name: "TaraID",
                table: "Vin");
        }
    }
}
