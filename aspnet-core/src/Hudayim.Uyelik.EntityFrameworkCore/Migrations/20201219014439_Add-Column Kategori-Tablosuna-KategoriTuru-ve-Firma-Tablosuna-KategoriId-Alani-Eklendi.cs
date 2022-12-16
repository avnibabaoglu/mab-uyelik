using Microsoft.EntityFrameworkCore.Migrations;

namespace Hudayim.Uyelik.Migrations
{
    public partial class AddColumnKategoriTablosunaKategoriTuruveFirmaTablosunaKategoriIdAlaniEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KategoriTuru",
                table: "Kategoriler",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KategoriId",
                table: "Firmalar",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Firmalar_KategoriId",
                table: "Firmalar",
                column: "KategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Firmalar_Kategoriler_KategoriId",
                table: "Firmalar",
                column: "KategoriId",
                principalTable: "Kategoriler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Firmalar_Kategoriler_KategoriId",
                table: "Firmalar");

            migrationBuilder.DropIndex(
                name: "IX_Firmalar_KategoriId",
                table: "Firmalar");

            migrationBuilder.DropColumn(
                name: "KategoriTuru",
                table: "Kategoriler");

            migrationBuilder.DropColumn(
                name: "KategoriId",
                table: "Firmalar");
        }
    }
}
