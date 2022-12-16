using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hudayim.Uyelik.Migrations
{
    public partial class AddTableMeslekUniversiteFakulteBolumTablolariEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "BolumId",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CalistigiDurumAciklama",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FakulteId",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MeslekId",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UniversiteId",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Meslekler",
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
                    Ad = table.Column<string>(nullable: true),
                    Kod = table.Column<string>(nullable: true),
                    SiraNo = table.Column<int>(nullable: true),
                    AktifMi = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meslekler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Universiteler",
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
                    Ad = table.Column<string>(nullable: true),
                    SiraNo = table.Column<int>(nullable: true),
                    SourceId = table.Column<int>(nullable: true),
                    AktifMi = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universiteler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fakulteler",
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
                    Ad = table.Column<string>(nullable: true),
                    SiraNo = table.Column<int>(nullable: true),
                    AktifMi = table.Column<bool>(nullable: true),
                    SourceId = table.Column<int>(nullable: true),
                    UniversiteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fakulteler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fakulteler_Universiteler_UniversiteId",
                        column: x => x.UniversiteId,
                        principalTable: "Universiteler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bolumler",
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
                    Ad = table.Column<string>(nullable: true),
                    SiraNo = table.Column<int>(nullable: true),
                    AktifMi = table.Column<bool>(nullable: true),
                    SourceId = table.Column<int>(nullable: true),
                    FakulteId = table.Column<int>(nullable: true),
                    UniversiteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bolumler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bolumler_Fakulteler_FakulteId",
                        column: x => x.FakulteId,
                        principalTable: "Fakulteler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bolumler_Universiteler_UniversiteId",
                        column: x => x.UniversiteId,
                        principalTable: "Universiteler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_BolumId",
                table: "AbpUsers",
                column: "BolumId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_FakulteId",
                table: "AbpUsers",
                column: "FakulteId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_MeslekId",
                table: "AbpUsers",
                column: "MeslekId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_UniversiteId",
                table: "AbpUsers",
                column: "UniversiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Bolumler_FakulteId",
                table: "Bolumler",
                column: "FakulteId");

            migrationBuilder.CreateIndex(
                name: "IX_Bolumler_UniversiteId",
                table: "Bolumler",
                column: "UniversiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Fakulteler_UniversiteId",
                table: "Fakulteler",
                column: "UniversiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Bolumler_BolumId",
                table: "AbpUsers",
                column: "BolumId",
                principalTable: "Bolumler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Fakulteler_FakulteId",
                table: "AbpUsers",
                column: "FakulteId",
                principalTable: "Fakulteler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Meslekler_MeslekId",
                table: "AbpUsers",
                column: "MeslekId",
                principalTable: "Meslekler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_Universiteler_UniversiteId",
                table: "AbpUsers",
                column: "UniversiteId",
                principalTable: "Universiteler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Bolumler_BolumId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Fakulteler_FakulteId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Meslekler_MeslekId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Universiteler_UniversiteId",
                table: "AbpUsers");

            migrationBuilder.DropTable(
                name: "Bolumler");

            migrationBuilder.DropTable(
                name: "Meslekler");

            migrationBuilder.DropTable(
                name: "Fakulteler");

            migrationBuilder.DropTable(
                name: "Universiteler");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_BolumId",
                table: "AbpUsers");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_FakulteId",
                table: "AbpUsers");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_MeslekId",
                table: "AbpUsers");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_UniversiteId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "BolumId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "CalistigiDurumAciklama",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "FakulteId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "MeslekId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "UniversiteId",
                table: "AbpUsers");
        }
    }
}
