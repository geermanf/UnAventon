using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace unAventonApi.Migrations
{
    public partial class migracionDiasDeViaje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaPartida",
                table: "Viaje");

            migrationBuilder.CreateTable(
                name: "DiaDeViaje",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ViajeId = table.Column<int>(nullable: false),
                    fechaDeViaje = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaDeViaje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiaDeViaje_Viaje_ViajeId",
                        column: x => x.ViajeId,
                        principalTable: "Viaje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiaDeViaje_ViajeId",
                table: "DiaDeViaje",
                column: "ViajeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiaDeViaje");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaPartida",
                table: "Viaje",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
