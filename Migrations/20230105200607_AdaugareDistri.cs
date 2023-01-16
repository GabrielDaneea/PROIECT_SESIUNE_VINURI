using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROIECT_SESIUNE_VINURI.Migrations
{
    public partial class AdaugareDistri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "Tara",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Distribuitor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume_Firma = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distribuitor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DistribuitorVinuri",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VinID = table.Column<int>(type: "int", nullable: false),
                    DistribuitorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistribuitorVinuri", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DistribuitorVinuri_Distribuitor_DistribuitorID",
                        column: x => x.DistribuitorID,
                        principalTable: "Distribuitor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DistribuitorVinuri_Vin_VinID",
                        column: x => x.VinID,
                        principalTable: "Vin",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DistribuitorVinuri_DistribuitorID",
                table: "DistribuitorVinuri",
                column: "DistribuitorID");

            migrationBuilder.CreateIndex(
                name: "IX_DistribuitorVinuri_VinID",
                table: "DistribuitorVinuri",
                column: "VinID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DistribuitorVinuri");

            migrationBuilder.DropTable(
                name: "Distribuitor");

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "Tara",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
