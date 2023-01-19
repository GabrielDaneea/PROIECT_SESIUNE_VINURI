using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROIECT_SESIUNE_VINURI.Migrations
{
    public partial class pentrufunctia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vin_Tara_TaraID",
                table: "Vin");

            migrationBuilder.AlterColumn<int>(
                name: "TaraID",
                table: "Vin",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Culoare",
                table: "Vin",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Vin_Tara_TaraID",
                table: "Vin",
                column: "TaraID",
                principalTable: "Tara",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vin_Tara_TaraID",
                table: "Vin");

            migrationBuilder.AlterColumn<int>(
                name: "TaraID",
                table: "Vin",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Culoare",
                table: "Vin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vin_Tara_TaraID",
                table: "Vin",
                column: "TaraID",
                principalTable: "Tara",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
