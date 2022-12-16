using Microsoft.EntityFrameworkCore.Migrations;

namespace Hudayim.Uyelik.Migrations
{
    public partial class AddColumn_AdresTablolarinaKaynakIdAlanlariEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SourceId",
                table: "Ulkeler",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SourceId",
                table: "Mahalleler",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SourceId",
                table: "Iller",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SourceId",
                table: "Ilceler",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "Ulkeler");

            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "Mahalleler");

            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "Iller");

            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "Ilceler");
        }
    }
}
