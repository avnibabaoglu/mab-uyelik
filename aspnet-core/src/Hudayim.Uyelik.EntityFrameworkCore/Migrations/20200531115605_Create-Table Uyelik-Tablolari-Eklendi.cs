using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hudayim.Uyelik.Migrations
{
    public partial class CreateTableUyelikTablolariEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AbpOrganizationUnits_TenantId_Code",
                table: "AbpOrganizationUnits");

            migrationBuilder.AddColumn<bool>(
                name: "AktifMi",
                table: "AbpUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "BirimId",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CalistigiGorev",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CalistigiKurum",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CalistigiPozisyon",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DonemId",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IkinciTelefon",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IlId",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IlceId",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KategoriId",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "KvkkOnayliMi",
                table: "AbpUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MahalleId",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MezunOlduguBolum",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MezunOlduguOkul",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MezuniyetYili",
                table: "AbpUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UlkeId",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UyelikBaslangiçTarihi",
                table: "AbpUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UyelikBitisTarihi",
                table: "AbpUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Birim",
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
                    SiraNo = table.Column<int>(nullable: false),
                    AktifMi = table.Column<bool>(nullable: false),
                    PlatformMu = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Donem",
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
                    SiraNo = table.Column<int>(nullable: false),
                    BaslangicTarihi = table.Column<DateTime>(nullable: false),
                    BitisTarihi = table.Column<DateTime>(nullable: false),
                    AktifMi = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategori",
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
                    SiraNo = table.Column<int>(nullable: false),
                    AktifMi = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ulke",
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
                    SiraNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ulke", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aidat",
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
                    Tutar = table.Column<decimal>(nullable: false),
                    TaksitSayisi = table.Column<int>(nullable: false),
                    Turu = table.Column<string>(nullable: true),
                    SonOdemeTarihi = table.Column<DateTime>(nullable: false),
                    DonemId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aidat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aidat_Donem_DonemId",
                        column: x => x.DonemId,
                        principalTable: "Donem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aidat_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Il",
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
                    PlakaKodu = table.Column<string>(nullable: true),
                    SiraNo = table.Column<int>(nullable: false),
                    UlkeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Il", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Il_Ulke_UlkeId",
                        column: x => x.UlkeId,
                        principalTable: "Ulke",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ilce",
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
                    SiraNo = table.Column<int>(nullable: false),
                    IlId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilce", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ilce_Il_IlId",
                        column: x => x.IlId,
                        principalTable: "Il",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mahalle",
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
                    SiraNo = table.Column<int>(nullable: false),
                    IlceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mahalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mahalle_Ilce_IlceId",
                        column: x => x.IlceId,
                        principalTable: "Ilce",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_BirimId",
                table: "AbpUsers",
                column: "BirimId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_DonemId",
                table: "AbpUsers",
                column: "DonemId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_IlId",
                table: "AbpUsers",
                column: "IlId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_IlceId",
                table: "AbpUsers",
                column: "IlceId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_KategoriId",
                table: "AbpUsers",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_MahalleId",
                table: "AbpUsers",
                column: "MahalleId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_UlkeId",
                table: "AbpUsers",
                column: "UlkeId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrganizationUnits_TenantId_Code",
                table: "AbpOrganizationUnits",
                columns: new[] { "TenantId", "Code" });

            migrationBuilder.CreateIndex(
                name: "IX_Aidat_DonemId",
                table: "Aidat",
                column: "DonemId");

            migrationBuilder.CreateIndex(
                name: "IX_Aidat_UserId",
                table: "Aidat",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Il_UlkeId",
                table: "Il",
                column: "UlkeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ilce_IlId",
                table: "Ilce",
                column: "IlId");

            migrationBuilder.CreateIndex(
                name: "IX_Mahalle_IlceId",
                table: "Mahalle",
                column: "IlceId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "Aidat");

            migrationBuilder.DropTable(
                name: "Birim");

            migrationBuilder.DropTable(
                name: "Kategori");

            migrationBuilder.DropTable(
                name: "Mahalle");

            migrationBuilder.DropTable(
                name: "Donem");

            migrationBuilder.DropTable(
                name: "Ilce");

            migrationBuilder.DropTable(
                name: "Il");

            migrationBuilder.DropTable(
                name: "Ulke");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_BirimId",
                table: "AbpUsers");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_DonemId",
                table: "AbpUsers");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_IlId",
                table: "AbpUsers");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_IlceId",
                table: "AbpUsers");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_KategoriId",
                table: "AbpUsers");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_MahalleId",
                table: "AbpUsers");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_UlkeId",
                table: "AbpUsers");

            migrationBuilder.DropIndex(
                name: "IX_AbpOrganizationUnits_TenantId_Code",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "AktifMi",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "BirimId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "CalistigiGorev",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "CalistigiKurum",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "CalistigiPozisyon",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "DonemId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "IkinciTelefon",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "IlId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "IlceId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "KategoriId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "KvkkOnayliMi",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "MahalleId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "MezunOlduguBolum",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "MezunOlduguOkul",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "MezuniyetYili",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "UlkeId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "UyelikBaslangiçTarihi",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "UyelikBitisTarihi",
                table: "AbpUsers");

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrganizationUnits_TenantId_Code",
                table: "AbpOrganizationUnits",
                columns: new[] { "TenantId", "Code" },
                unique: true,
                filter: "[TenantId] IS NOT NULL");
        }
    }
}
