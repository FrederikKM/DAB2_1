using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DAB2_2RDB.Migrations
{
    public partial class AddingTelephoneCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "PhoneNumbers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TelephoneCompanyId",
                table: "PhoneNumbers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TelephoneCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelephoneCompanies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_TelephoneCompanyId",
                table: "PhoneNumbers",
                column: "TelephoneCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumbers_TelephoneCompanies_TelephoneCompanyId",
                table: "PhoneNumbers",
                column: "TelephoneCompanyId",
                principalTable: "TelephoneCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumbers_TelephoneCompanies_TelephoneCompanyId",
                table: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "TelephoneCompanies");

            migrationBuilder.DropIndex(
                name: "IX_PhoneNumbers_TelephoneCompanyId",
                table: "PhoneNumbers");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "PhoneNumbers");

            migrationBuilder.DropColumn(
                name: "TelephoneCompanyId",
                table: "PhoneNumbers");
        }
    }
}
