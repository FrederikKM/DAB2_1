using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DAB2_2RDB.Migrations
{
    public partial class EnabledLazyLoading : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumbers_TelephoneCompanies_TelephoneCompanyId",
                table: "PhoneNumbers");

            migrationBuilder.AlterColumn<int>(
                name: "TelephoneCompanyId",
                table: "PhoneNumbers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumbers_TelephoneCompanies_TelephoneCompanyId",
                table: "PhoneNumbers",
                column: "TelephoneCompanyId",
                principalTable: "TelephoneCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumbers_TelephoneCompanies_TelephoneCompanyId",
                table: "PhoneNumbers");

            migrationBuilder.AlterColumn<int>(
                name: "TelephoneCompanyId",
                table: "PhoneNumbers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumbers_TelephoneCompanies_TelephoneCompanyId",
                table: "PhoneNumbers",
                column: "TelephoneCompanyId",
                principalTable: "TelephoneCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
