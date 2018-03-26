using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DAB2_2RDB.Migrations
{
    public partial class CountryCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryCodeId",
                table: "Cities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CountryCodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCodes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryCodeId",
                table: "Cities",
                column: "CountryCodeId",
                unique: true,
                filter: "[CountryCodeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_CountryCodes_CountryCodeId",
                table: "Cities",
                column: "CountryCodeId",
                principalTable: "CountryCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_CountryCodes_CountryCodeId",
                table: "Cities");

            migrationBuilder.DropTable(
                name: "CountryCodes");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CountryCodeId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "CountryCodeId",
                table: "Cities");
        }
    }
}
