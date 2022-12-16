using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hudayim.Uyelik.Migrations
{
    public partial class ChangeColumn_UsersTabloAlanDuzenlemesiYapildi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AktifMi",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "UyelikBaslangiçTarihi",
                table: "AbpUsers");

            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UyelikBaslangicTarihi",
                table: "AbpUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adres",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "UyelikBaslangicTarihi",
                table: "AbpUsers");

            migrationBuilder.AddColumn<bool>(
                name: "AktifMi",
                table: "AbpUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UyelikBaslangiçTarihi",
                table: "AbpUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
