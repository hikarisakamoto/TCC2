using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sakamoto.TCC2.CSU.Patients.Infrastructure.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    City = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    District = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Number = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Observation = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: true),
                    State = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true),
                    Street = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    FullName = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    HeartRate = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
