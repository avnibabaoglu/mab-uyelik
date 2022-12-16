using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hudayim.Uyelik.Migrations
{
    public partial class AddColumn_UserTablosunaLogoAlanlariEklendiChangeTableName_ContextTabloIsimlerGuncellendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Birim_BirimId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Donem_DonemId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Il_IlId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Ilce_IlceId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Kategori_KategoriId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Mahalle_MahalleId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Ulke_UlkeId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Aidat_Donem_DonemId",
                table: "Aidat");

            migrationBuilder.DropForeignKey(
                name: "FK_Aidat_AbpUsers_UserId",
                table: "Aidat");

            migrationBuilder.DropForeignKey(
                name: "FK_Il_Ulke_UlkeId",
                table: "Il");

            migrationBuilder.DropForeignKey(
                name: "FK_Ilce_Il_IlId",
                table: "Ilce");

            migrationBuilder.DropForeignKey(
                name: "FK_Mahalle_Ilce_IlceId",
                table: "Mahalle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ulke",
                table: "Ulke");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mahalle",
                table: "Mahalle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kategori",
                table: "Kategori");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ilce",
                table: "Ilce");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Il",
                table: "Il");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Donem",
                table: "Donem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Birim",
                table: "Birim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aidat",
                table: "Aidat");

            migrationBuilder.RenameTable(
                name: "Ulke",
                newName: "Ulkeler");

            migrationBuilder.RenameTable(
                name: "Mahalle",
                newName: "Mahalleler");

            migrationBuilder.RenameTable(
                name: "Kategori",
                newName: "Kategoriler");

            migrationBuilder.RenameTable(
                name: "Ilce",
                newName: "Ilceler");

            migrationBuilder.RenameTable(
                name: "Il",
                newName: "Iller");

            migrationBuilder.RenameTable(
                name: "Donem",
                newName: "Donemler");

            migrationBuilder.RenameTable(
                name: "Birim",
                newName: "Birimler");

            migrationBuilder.RenameTable(
                name: "Aidat",
                newName: "Aidatlar");

            migrationBuilder.RenameIndex(
                name: "IX_Mahalle_IlceId",
                table: "Mahalleler",
                newName: "IX_Mahalleler_IlceId");

            migrationBuilder.RenameIndex(
                name: "IX_Ilce_IlId",
                table: "Ilceler",
                newName: "IX_Ilceler_IlId");

            migrationBuilder.RenameIndex(
                name: "IX_Il_UlkeId",
                table: "Iller",
                newName: "IX_Iller_UlkeId");

            migrationBuilder.RenameIndex(
                name: "IX_Aidat_UserId",
                table: "Aidatlar",
                newName: "IX_Aidatlar_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Aidat_DonemId",
                table: "Aidatlar",
                newName: "IX_Aidatlar_DonemId");

            migrationBuilder.AlterColumn<int>(
                name: "MezuniyetYili",
                table: "AbpUsers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "KvkkOnayliMi",
                table: "AbpUsers",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "AktifMi",
                table: "AbpUsers",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<byte[]>(
                name: "Logo",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoMimeType",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ulkeler",
                table: "Ulkeler",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mahalleler",
                table: "Mahalleler",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kategoriler",
                table: "Kategoriler",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ilceler",
                table: "Ilceler",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Iller",
                table: "Iller",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donemler",
                table: "Donemler",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Birimler",
                table: "Birimler",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aidatlar",
                table: "Aidatlar",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Firmalar",
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
                    Ad = table.Column<string>(nullable: false),
                    WebAdresi = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    Adres = table.Column<string>(nullable: true),
                    ResimDosyaYolu = table.Column<string>(nullable: true),
                    SiraNo = table.Column<int>(nullable: false),
                    AktifMi = table.Column<bool>(nullable: false),
                    IlId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firmalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Firmalar_Iller_IlId",
                        column: x => x.IlId,
                        principalTable: "Iller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kampanyalar",
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
                    Ad = table.Column<int>(nullable: false),
                    Icerik = table.Column<string>(nullable: true),
                    BaslangicTarihi = table.Column<DateTime>(nullable: false),
                    BitisTarihi = table.Column<DateTime>(nullable: false),
                    SiraNo = table.Column<int>(nullable: false),
                    IndirimOrani = table.Column<int>(nullable: false),
                    ResimDosyaYolu = table.Column<string>(nullable: true),
                    AktifMi = table.Column<bool>(nullable: false),
                    FirmaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kampanyalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kampanyalar_Firmalar_FirmaId",
                        column: x => x.FirmaId,
                        principalTable: "Firmalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Firmalar_IlId",
                table: "Firmalar",
                column: "IlId");

            migrationBuilder.CreateIndex(
                name: "IX_Kampanyalar_FirmaId",
                table: "Kampanyalar",
                column: "FirmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Birimler_BirimId",
                table: "AbpUsers",
                column: "BirimId",
                principalTable: "Birimler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Donemler_DonemId",
                table: "AbpUsers",
                column: "DonemId",
                principalTable: "Donemler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Iller_IlId",
                table: "AbpUsers",
                column: "IlId",
                principalTable: "Iller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Ilceler_IlceId",
                table: "AbpUsers",
                column: "IlceId",
                principalTable: "Ilceler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Kategoriler_KategoriId",
                table: "AbpUsers",
                column: "KategoriId",
                principalTable: "Kategoriler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Mahalleler_MahalleId",
                table: "AbpUsers",
                column: "MahalleId",
                principalTable: "Mahalleler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Ulkeler_UlkeId",
                table: "AbpUsers",
                column: "UlkeId",
                principalTable: "Ulkeler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Ilceler_Iller_IlId",
                table: "Ilceler",
                column: "IlId",
                principalTable: "Iller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Iller_Ulkeler_UlkeId",
                table: "Iller",
                column: "UlkeId",
                principalTable: "Ulkeler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mahalleler_Ilceler_IlceId",
                table: "Mahalleler",
                column: "IlceId",
                principalTable: "Ilceler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Birimler_BirimId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Donemler_DonemId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Iller_IlId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Ilceler_IlceId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Kategoriler_KategoriId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Mahalleler_MahalleId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Ulkeler_UlkeId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Aidatlar_Donemler_DonemId",
                table: "Aidatlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Aidatlar_AbpUsers_UserId",
                table: "Aidatlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Ilceler_Iller_IlId",
                table: "Ilceler");

            migrationBuilder.DropForeignKey(
                name: "FK_Iller_Ulkeler_UlkeId",
                table: "Iller");

            migrationBuilder.DropForeignKey(
                name: "FK_Mahalleler_Ilceler_IlceId",
                table: "Mahalleler");

            migrationBuilder.DropTable(
                name: "Kampanyalar");

            migrationBuilder.DropTable(
                name: "Firmalar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ulkeler",
                table: "Ulkeler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mahalleler",
                table: "Mahalleler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kategoriler",
                table: "Kategoriler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Iller",
                table: "Iller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ilceler",
                table: "Ilceler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Donemler",
                table: "Donemler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Birimler",
                table: "Birimler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aidatlar",
                table: "Aidatlar");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "LogoMimeType",
                table: "AbpUsers");

            migrationBuilder.RenameTable(
                name: "Ulkeler",
                newName: "Ulke");

            migrationBuilder.RenameTable(
                name: "Mahalleler",
                newName: "Mahalle");

            migrationBuilder.RenameTable(
                name: "Kategoriler",
                newName: "Kategori");

            migrationBuilder.RenameTable(
                name: "Iller",
                newName: "Il");

            migrationBuilder.RenameTable(
                name: "Ilceler",
                newName: "Ilce");

            migrationBuilder.RenameTable(
                name: "Donemler",
                newName: "Donem");

            migrationBuilder.RenameTable(
                name: "Birimler",
                newName: "Birim");

            migrationBuilder.RenameTable(
                name: "Aidatlar",
                newName: "Aidat");

            migrationBuilder.RenameIndex(
                name: "IX_Mahalleler_IlceId",
                table: "Mahalle",
                newName: "IX_Mahalle_IlceId");

            migrationBuilder.RenameIndex(
                name: "IX_Iller_UlkeId",
                table: "Il",
                newName: "IX_Il_UlkeId");

            migrationBuilder.RenameIndex(
                name: "IX_Ilceler_IlId",
                table: "Ilce",
                newName: "IX_Ilce_IlId");

            migrationBuilder.RenameIndex(
                name: "IX_Aidatlar_UserId",
                table: "Aidat",
                newName: "IX_Aidat_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Aidatlar_DonemId",
                table: "Aidat",
                newName: "IX_Aidat_DonemId");

            migrationBuilder.AlterColumn<int>(
                name: "MezuniyetYili",
                table: "AbpUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "KvkkOnayliMi",
                table: "AbpUsers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AktifMi",
                table: "AbpUsers",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ulke",
                table: "Ulke",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mahalle",
                table: "Mahalle",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kategori",
                table: "Kategori",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Il",
                table: "Il",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ilce",
                table: "Ilce",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donem",
                table: "Donem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Birim",
                table: "Birim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aidat",
                table: "Aidat",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Birim_BirimId",
                table: "AbpUsers",
                column: "BirimId",
                principalTable: "Birim",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Donem_DonemId",
                table: "AbpUsers",
                column: "DonemId",
                principalTable: "Donem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Il_IlId",
                table: "AbpUsers",
                column: "IlId",
                principalTable: "Il",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Ilce_IlceId",
                table: "AbpUsers",
                column: "IlceId",
                principalTable: "Ilce",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Kategori_KategoriId",
                table: "AbpUsers",
                column: "KategoriId",
                principalTable: "Kategori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Mahalle_MahalleId",
                table: "AbpUsers",
                column: "MahalleId",
                principalTable: "Mahalle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Ulke_UlkeId",
                table: "AbpUsers",
                column: "UlkeId",
                principalTable: "Ulke",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Aidat_Donem_DonemId",
                table: "Aidat",
                column: "DonemId",
                principalTable: "Donem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Aidat_AbpUsers_UserId",
                table: "Aidat",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Il_Ulke_UlkeId",
                table: "Il",
                column: "UlkeId",
                principalTable: "Ulke",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ilce_Il_IlId",
                table: "Ilce",
                column: "IlId",
                principalTable: "Il",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mahalle_Ilce_IlceId",
                table: "Mahalle",
                column: "IlceId",
                principalTable: "Ilce",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
