using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sakamoto.TCC2.CSU.Practitioners.Infrastructure.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Practitioners");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Practitioners",
                table => new
                {
                    Id = table.Column<Guid>(),
                    CRM = table.Column<string>("varchar(30)", maxLength: 30),
                    Email = table.Column<string>("varchar(100)", maxLength: 100, nullable: true),
                    Expertise = table.Column<string>("varchar(300)", maxLength: 300),
                    FullName = table.Column<string>("varchar(150)", maxLength: 150),
                    IsActive = table.Column<bool>("bit"),
                    Phone = table.Column<string>("varchar(20)", maxLength: 20)
                },
                constraints: table => { table.PrimaryKey("PK_Practitioners", x => x.Id); });
        }
    }
}