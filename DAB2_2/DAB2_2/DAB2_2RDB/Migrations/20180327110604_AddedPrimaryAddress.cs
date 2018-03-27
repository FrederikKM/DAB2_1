using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DAB2_2RDB.Migrations
{
    public partial class AddedPrimaryAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "StreetName",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "PrimaryAddressId",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddressNameId",
                table: "Addresses",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AddressNames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HouseNumber = table.Column<string>(nullable: true),
                    StreetName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrimaryAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressNameId = table.Column<int>(nullable: true),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimaryAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrimaryAddresses_AddressNames_AddressNameId",
                        column: x => x.AddressNameId,
                        principalTable: "AddressNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrimaryAddresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PrimaryAddressId",
                table: "Persons",
                column: "PrimaryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AddressNameId",
                table: "Addresses",
                column: "AddressNameId");

            migrationBuilder.CreateIndex(
                name: "IX_PrimaryAddresses_AddressNameId",
                table: "PrimaryAddresses",
                column: "AddressNameId");

            migrationBuilder.CreateIndex(
                name: "IX_PrimaryAddresses_CityId",
                table: "PrimaryAddresses",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_AddressNames_AddressNameId",
                table: "Addresses",
                column: "AddressNameId",
                principalTable: "AddressNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_PrimaryAddresses_PrimaryAddressId",
                table: "Persons",
                column: "PrimaryAddressId",
                principalTable: "PrimaryAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_AddressNames_AddressNameId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_PrimaryAddresses_PrimaryAddressId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "PrimaryAddresses");

            migrationBuilder.DropTable(
                name: "AddressNames");

            migrationBuilder.DropIndex(
                name: "IX_Persons_PrimaryAddressId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_AddressNameId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "PrimaryAddressId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "AddressNameId",
                table: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "HouseNumber",
                table: "Addresses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetName",
                table: "Addresses",
                nullable: true);
        }
    }
}
