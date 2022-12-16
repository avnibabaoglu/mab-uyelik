using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hudayim.Uyelik.Migrations
{
	public partial class AddTableGelirTablolariEklendi_BaziTablolardaDuzenlemeYapildi : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<int>(
				name: "DonemTuru",
				table: "Donemler",
				nullable: false,
				defaultValue: 0);

			migrationBuilder.CreateTable(
				name: "GelirTurleri",
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
					SiraNo = table.Column<int>(nullable: false),
					AktifMi = table.Column<bool>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_GelirTurleri", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Gelirler",
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
					Tutar = table.Column<decimal>(nullable: false),
					Not = table.Column<string>(nullable: true),
					OdemeTarihi = table.Column<DateTime>(nullable: true),
					SonOdemeTarihi = table.Column<DateTime>(nullable: true),
					SiraNo = table.Column<int>(nullable: true),
					AktifMi = table.Column<bool>(nullable: false),
					UserId = table.Column<long>(nullable: false),
					DonemId = table.Column<int>(nullable: true),
					GelirTuruId = table.Column<int>(nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Gelirler", x => x.Id);
					table.ForeignKey(
						name: "FK_Gelirler_Donemler_DonemId",
						column: x => x.DonemId,
						principalTable: "Donemler",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Gelirler_GelirTurleri_GelirTuruId",
						column: x => x.GelirTuruId,
						principalTable: "GelirTurleri",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_Gelirler_AbpUsers_UserId",
						column: x => x.UserId,
						principalTable: "AbpUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Gelirler_DonemId",
				table: "Gelirler",
				column: "DonemId");

			migrationBuilder.CreateIndex(
				name: "IX_Gelirler_GelirTuruId",
				table: "Gelirler",
				column: "GelirTuruId");

			migrationBuilder.CreateIndex(
				name: "IX_Gelirler_UserId",
				table: "Gelirler",
				column: "UserId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Gelirler");

			migrationBuilder.DropTable(
				name: "GelirTurleri");

			migrationBuilder.DropColumn(
				name: "DonemTuru",
				table: "Donemler");
		}
	}
}
