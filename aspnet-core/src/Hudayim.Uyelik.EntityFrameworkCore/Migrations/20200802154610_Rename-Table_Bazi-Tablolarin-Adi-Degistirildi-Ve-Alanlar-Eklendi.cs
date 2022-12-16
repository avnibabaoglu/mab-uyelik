using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hudayim.Uyelik.Migrations
{
    public partial class RenameTable_BaziTablolarinAdiDegistirildiVeAlanlarEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Bolumler_BolumId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Fakulteler_FakulteId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_Kategoriler_KategoriId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Bolumler_Fakulteler_FakulteId",
                table: "Bolumler");

            migrationBuilder.DropForeignKey(
                name: "FK_Bolumler_Universiteler_UniversiteId",
                table: "Bolumler");

            migrationBuilder.DropForeignKey(
                name: "FK_Fakulteler_Universiteler_UniversiteId",
                table: "Fakulteler");

            migrationBuilder.DropIndex(
                name: "IX_AbpUsers_KategoriId",
                table: "AbpUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fakulteler",
                table: "Fakulteler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bolumler",
                table: "Bolumler");

            migrationBuilder.DropColumn(
                name: "KategoriId",
                table: "AbpUsers");

            migrationBuilder.RenameTable(
                name: "Fakulteler",
                newName: "UniversiteFakulteler");

            migrationBuilder.RenameTable(
                name: "Bolumler",
                newName: "UniversiteBolumler");

            migrationBuilder.RenameIndex(
                name: "IX_Fakulteler_UniversiteId",
                table: "UniversiteFakulteler",
                newName: "IX_UniversiteFakulteler_UniversiteId");

            migrationBuilder.RenameIndex(
                name: "IX_Bolumler_UniversiteId",
                table: "UniversiteBolumler",
                newName: "IX_UniversiteBolumler_UniversiteId");

            migrationBuilder.RenameIndex(
                name: "IX_Bolumler_FakulteId",
                table: "UniversiteBolumler",
                newName: "IX_UniversiteBolumler_FakulteId");


            migrationBuilder.AddPrimaryKey(
                name: "PK_UniversiteFakulteler",
                table: "UniversiteFakulteler",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UniversiteBolumler",
                table: "UniversiteBolumler",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserKategoriRelations",
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
                    UserId = table.Column<int>(nullable: false),
                    KategoriId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    UserId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserKategoriRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserKategoriRelations_Kategoriler_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserKategoriRelations_AbpUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserKategoriRelations_KategoriId",
                table: "UserKategoriRelations",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_UserKategoriRelations_UserId1",
                table: "UserKategoriRelations",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_UniversiteBolumler_BolumId",
                table: "AbpUsers",
                column: "BolumId",
                principalTable: "UniversiteBolumler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpUsers_UniversiteFakulteler_FakulteId",
                table: "AbpUsers",
                column: "FakulteId",
                principalTable: "UniversiteFakulteler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UniversiteBolumler_UniversiteFakulteler_FakulteId",
                table: "UniversiteBolumler",
                column: "FakulteId",
                principalTable: "UniversiteFakulteler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UniversiteBolumler_Universiteler_UniversiteId",
                table: "UniversiteBolumler",
                column: "UniversiteId",
                principalTable: "Universiteler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UniversiteFakulteler_Universiteler_UniversiteId",
                table: "UniversiteFakulteler",
                column: "UniversiteId",
                principalTable: "Universiteler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_UniversiteBolumler_BolumId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpUsers_UniversiteFakulteler_FakulteId",
                table: "AbpUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_UniversiteBolumler_UniversiteFakulteler_FakulteId",
                table: "UniversiteBolumler");

            migrationBuilder.DropForeignKey(
                name: "FK_UniversiteBolumler_Universiteler_UniversiteId",
                table: "UniversiteBolumler");

            migrationBuilder.DropForeignKey(
                name: "FK_UniversiteFakulteler_Universiteler_UniversiteId",
                table: "UniversiteFakulteler");

            migrationBuilder.DropTable(
                name: "UserKategoriRelations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UniversiteFakulteler",
                table: "UniversiteFakulteler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UniversiteBolumler",
                table: "UniversiteBolumler");

            migrationBuilder.RenameTable(
                name: "UniversiteFakulteler",
                newName: "Fakulteler");

            migrationBuilder.RenameTable(
                name: "UniversiteBolumler",
                newName: "Bolumler");

            migrationBuilder.RenameIndex(
                name: "IX_UniversiteFakulteler_UniversiteId",
                table: "Fakulteler",
                newName: "IX_Fakulteler_UniversiteId");

            migrationBuilder.RenameIndex(
                name: "IX_UniversiteBolumler_UniversiteId",
                table: "Bolumler",
                newName: "IX_Bolumler_UniversiteId");

            migrationBuilder.RenameIndex(
                name: "IX_UniversiteBolumler_FakulteId",
                table: "Bolumler",
                newName: "IX_Bolumler_FakulteId");

            migrationBuilder.AddColumn<int>(
                name: "KategoriId",
                table: "AbpUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fakulteler",
                table: "Fakulteler",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bolumler",
                table: "Bolumler",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_KategoriId",
                table: "AbpUsers",
                column: "KategoriId");

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
                name: "FK_AbpUsers_Kategoriler_KategoriId",
                table: "AbpUsers",
                column: "KategoriId",
                principalTable: "Kategoriler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bolumler_Fakulteler_FakulteId",
                table: "Bolumler",
                column: "FakulteId",
                principalTable: "Fakulteler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bolumler_Universiteler_UniversiteId",
                table: "Bolumler",
                column: "UniversiteId",
                principalTable: "Universiteler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fakulteler_Universiteler_UniversiteId",
                table: "Fakulteler",
                column: "UniversiteId",
                principalTable: "Universiteler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
