using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShortURLAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShortLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LongUrl = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    ShortUrl = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortLinks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShortLinks");
        }
    }
}
