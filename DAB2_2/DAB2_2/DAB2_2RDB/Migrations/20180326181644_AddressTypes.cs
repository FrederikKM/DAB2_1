using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DAB2_2RDB.Migrations
{
    public partial class AddressTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressTypes_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonAddressTypes",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    AddressTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAddressTypes", x => new { x.PersonId, x.AddressTypeId });
                    table.ForeignKey(
                        name: "FK_PersonAddressTypes_AddressTypes_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalTable: "AddressTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonAddressTypes_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressTypes_AddressId",
                table: "AddressTypes",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddressTypes_AddressTypeId",
                table: "PersonAddressTypes",
                column: "AddressTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonAddressTypes");

            migrationBuilder.DropTable(
                name: "AddressTypes");
        }
    }
}
