using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiAzure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numAvion = table.Column<string>(nullable: true),
                    model = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numVol = table.Column<string>(nullable: true),
                    dateHist = table.Column<DateTime>(nullable: false),
                    lat = table.Column<float>(nullable: false),
                    longe = table.Column<float>(nullable: false),
                    speed = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vols",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numVol = table.Column<string>(nullable: true),
                    code_comp = table.Column<string>(nullable: true),
                    numAvion = table.Column<string>(nullable: true),
                    dep = table.Column<string>(nullable: true),
                    arr = table.Column<string>(nullable: true),
                    statu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vols", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avions");

            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "Vols");
        }
    }
}
