using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hudayim.Uyelik.Migrations
{
    public partial class AddTableAddColumn_AidatTaksitleriTablosuEklendiveBazıTablolardaAlanDuzenlemeleriYapildi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aidatlar_Donemler_DonemId",
                table: "Aidatlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Aidatlar_AbpUsers_UserId",
                table: "Aidatlar");

            migrationBuilder.DropIndex(
                name: "IX_Aidatlar_DonemId",
                table: "Aidatlar");

            migrationBuilder.DropIndex(
                name: "IX_Aidatlar_UserId",
                table: "Aidatlar");

            migrationBuilder.DropColumn(
                name: "Icerik",
                table: "Kampanyalar");

            migrationBuilder.DropColumn(
                name: "ResimDosyaYolu",
                table: "Kampanyalar");

            migrationBuilder.DropColumn(
                name: "ResimDosyaYolu",
                table: "Firmalar");

            migrationBuilder.DropColumn(
                name: "DonemId",
                table: "Aidatlar");

            migrationBuilder.DropColumn(
                name: "SonOdemeTarihi",
                table: "Aidatlar");

            migrationBuilder.DropColumn(
                name: "TaksitSayisi",
                table: "Aidatlar");

            migrationBuilder.DropColumn(
                name: "Tutar",
                table: "Aidatlar");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "LogoMimeType",
                table: "AbpUsers");

            migrationBuilder.AlterColumn<int>(
                name: "IndirimOrani",
                table: "Kampanyalar",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Kampanyalar",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "Kampanyalar",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResimAdi",
                table: "Kampanyalar",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResimYolu",
                table: "Kampanyalar",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "Firmalar",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResimAdi",
                table: "Firmalar",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResimYolu",
                table: "Firmalar",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Aidatlar",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BolunecekTaksitSayisi",
                table: "Aidatlar",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "KalanTutar",
                table: "Aidatlar",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ToplamTutar",
                table: "Aidatlar",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "Aidatlar",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Not",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilFotografAdi",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilFotografYolu",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AidatTaksitleri",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OdenecekTutar = table.Column<decimal>(nullable: false),
                    KacinciTaksit = table.Column<int>(nullable: false),
                    OdemeTarihi = table.Column<DateTime>(nullable: false),
                    SonOdemeTarihi = table.Column<DateTime>(nullable: false),
                    SiraNo = table.Column<int>(nullable: true),
                    AktifMi = table.Column<bool>(nullable: false),
                    AidatId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AidatTaksitleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AidatTaksitleri_Aidatlar_AidatId",
                        column: x => x.AidatId,
                        principalTable: "Aidatlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aidatlar_UserId1",
                table: "Aidatlar",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AidatTaksitleri_AidatId",
                table: "AidatTaksitleri",
                column: "AidatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aidatlar_AbpUsers_UserId1",
                table: "Aidatlar",
                column: "UserId1",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aidatlar_AbpUsers_UserId1",
                table: "Aidatlar");

            migrationBuilder.DropTable(
                name: "AidatTaksitleri");

            migrationBuilder.DropIndex(
                name: "IX_Aidatlar_UserId1",
                table: "Aidatlar");

            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "Kampanyalar");

            migrationBuilder.DropColumn(
                name: "ResimAdi",
                table: "Kampanyalar");

            migrationBuilder.DropColumn(
                name: "ResimYolu",
                table: "Kampanyalar");

            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "Firmalar");

            migrationBuilder.DropColumn(
                name: "ResimAdi",
                table: "Firmalar");

            migrationBuilder.DropColumn(
                name: "ResimYolu",
                table: "Firmalar");

            migrationBuilder.DropColumn(
                name: "BolunecekTaksitSayisi",
                table: "Aidatlar");

            migrationBuilder.DropColumn(
                name: "KalanTutar",
                table: "Aidatlar");

            migrationBuilder.DropColumn(
                name: "ToplamTutar",
                table: "Aidatlar");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Aidatlar");

            migrationBuilder.DropColumn(
                name: "Not",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "ProfilFotografAdi",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "ProfilFotografYolu",
                table: "AbpUsers");

            migrationBuilder.AlterColumn<int>(
                name: "IndirimOrani",
                table: "Kampanyalar",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Ad",
                table: "Kampanyalar",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Icerik",
                table: "Kampanyalar",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResimDosyaYolu",
                table: "Kampanyalar",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResimDosyaYolu",
                table: "Firmalar",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Aidatlar",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DonemId",
                table: "Aidatlar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SonOdemeTarihi",
                table: "Aidatlar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TaksitSayisi",
                table: "Aidatlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Tutar",
                table: "Aidatlar",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<byte[]>(
                name: "Logo",
                table: "AbpUsers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoMimeType",
                table: "AbpUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aidatlar_DonemId",
                table: "Aidatlar",
                column: "DonemId");

            migrationBuilder.CreateIndex(
                name: "IX_Aidatlar_UserId",
                table: "Aidatlar",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aidatlar_Donemler_DonemId",
                table: "Aidatlar",
                column: "DonemId",
                principalTable: "Donemler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Aidatlar_AbpUsers_UserId",
                table: "Aidatlar",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
