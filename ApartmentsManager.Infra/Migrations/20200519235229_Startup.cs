using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApartmentsManager.Infra.Migrations
{
    public partial class Startup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Condominium",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    Name = table.Column<string>(type: "varchar(160)", maxLength: 160, nullable: true),
                    Street = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    Number = table.Column<int>(nullable: false),
                    Neighborhood = table.Column<string>(type: "varchar(160)", maxLength: 160, nullable: true),
                    City = table.Column<string>(type: "varchar(160)", maxLength: 160, nullable: true),
                    State = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true),
                    Country = table.Column<string>(type: "varchar(160)", maxLength: 160, nullable: true),
                    ZipCode = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: true),
                    User = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condominium", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Apartment",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    CondominiumId = table.Column<byte[]>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    Block = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    User = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartment_Condominium_CondominiumId",
                        column: x => x.CondominiumId,
                        principalTable: "Condominium",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Resident",
                columns: table => new
                {
                    Id = table.Column<byte[]>(nullable: false),
                    ApartmentId = table.Column<byte[]>(nullable: true),
                    Name = table.Column<string>(type: "varchar(160)", maxLength: 160, nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Phone = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true),
                    Cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    User = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resident", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resident_Apartment_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_CondominiumId",
                table: "Apartment",
                column: "CondominiumId");

            migrationBuilder.CreateIndex(
                name: "IX_Condominium_User",
                table: "Condominium",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "IX_Resident_ApartmentId",
                table: "Resident",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Resident_User",
                table: "Resident",
                column: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resident");

            migrationBuilder.DropTable(
                name: "Apartment");

            migrationBuilder.DropTable(
                name: "Condominium");
        }
    }
}
