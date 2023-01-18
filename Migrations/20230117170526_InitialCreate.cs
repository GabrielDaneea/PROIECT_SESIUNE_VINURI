using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PROIECT_SESIUNE_VINURI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tip",
                table: "Vin",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "Vin",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DistribuitorID",
                table: "Vin",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vin_DistribuitorID",
                table: "Vin",
                column: "DistribuitorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vin_Distribuitor_DistribuitorID",
                table: "Vin",
                column: "DistribuitorID",
                principalTable: "Distribuitor",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vin_Distribuitor_DistribuitorID",
                table: "Vin");

            migrationBuilder.DropIndex(
                name: "IX_Vin_DistribuitorID",
                table: "Vin");

            migrationBuilder.DropColumn(
                name: "DistribuitorID",
                table: "Vin");

            migrationBuilder.AlterColumn<string>(
                name: "Tip",
                table: "Vin",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "Vin",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);
        }
    }
}
