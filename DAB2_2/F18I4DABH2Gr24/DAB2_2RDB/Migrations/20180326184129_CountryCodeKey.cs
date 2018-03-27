using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DAB2_2RDB.Migrations
{
    public partial class CountryCodeKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_CountryCodes_CountryCodeId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CountryCodeId",
                table: "Cities");

            migrationBuilder.AlterColumn<int>(
                name: "CountryCodeId",
                table: "Cities",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryCodeId",
                table: "Cities",
                column: "CountryCodeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_CountryCodes_CountryCodeId",
                table: "Cities",
                column: "CountryCodeId",
                principalTable: "CountryCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_CountryCodes_CountryCodeId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CountryCodeId",
                table: "Cities");

            migrationBuilder.AlterColumn<int>(
                name: "CountryCodeId",
                table: "Cities",
                nullable: true,
                oldClrType: typeof(int));

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
    }
}
