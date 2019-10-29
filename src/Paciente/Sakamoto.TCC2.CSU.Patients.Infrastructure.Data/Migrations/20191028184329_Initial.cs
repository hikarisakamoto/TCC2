using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sakamoto.TCC2.CSU.Patients.Infrastructure.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Patients");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Patients",
                table => new
                {
                    Id = table.Column<Guid>(),
                    City = table.Column<string>("varchar(100)", maxLength: 100, nullable: true),
                    District = table.Column<string>("varchar(255)", maxLength: 255, nullable: true),
                    Number = table.Column<string>("varchar(10)", maxLength: 10, nullable: true),
                    Observation = table.Column<string>("varchar(255)", maxLength: 255, nullable: true),
                    PostalCode = table.Column<string>("varchar(8)", maxLength: 8, nullable: true),
                    State = table.Column<string>("varchar(2)", maxLength: 2, nullable: true),
                    Street = table.Column<string>("varchar(255)", maxLength: 255, nullable: true),
                    BirthDate = table.Column<DateTime>("datetime"),
                    CPF = table.Column<string>("varchar(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>("varchar(100)", maxLength: 100, nullable: true),
                    FullName = table.Column<string>("varchar(150)", maxLength: 150),
                    Gender = table.Column<byte>("tinyint"),
                    HeartRate = table.Column<int>(),
                    IsActive = table.Column<bool>("bit"),
                    Phone = table.Column<string>("varchar(20)", maxLength: 20),
                    Photo = table.Column<byte[]>("varbinary(max)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Patients", x => x.Id); });
        }
    }
}