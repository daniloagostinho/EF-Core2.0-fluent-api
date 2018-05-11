using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FluentApi.Migrations
{
    public partial class AppStart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Galaxias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 100, nullable: true),
                    Tamanho = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galaxias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuracosNegros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GalaxiaId = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(maxLength: 100, nullable: true),
                    Tamanho = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuracosNegros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuracosNegros_Galaxias_GalaxiaId",
                        column: x => x.GalaxiaId,
                        principalTable: "Galaxias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Planetas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GalaxiaId = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(maxLength: 100, nullable: true),
                    Tamanho = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planetas_Galaxias_GalaxiaId",
                        column: x => x.GalaxiaId,
                        principalTable: "Galaxias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuracosNegros_GalaxiaId",
                table: "BuracosNegros",
                column: "GalaxiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Planetas_GalaxiaId",
                table: "Planetas",
                column: "GalaxiaId",
                unique: true,
                filter: "[GalaxiaId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuracosNegros");

            migrationBuilder.DropTable(
                name: "Planetas");

            migrationBuilder.DropTable(
                name: "Galaxias");
        }
    }
}
