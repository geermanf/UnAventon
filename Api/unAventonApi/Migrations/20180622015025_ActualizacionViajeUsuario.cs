using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace unAventonApi.Migrations
{
    public partial class ActualizacionViajeUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoraPartida",
                table: "Viaje");

            migrationBuilder.AddColumn<int>(
                name: "CreadorId",
                table: "Viaje",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Viaje_CreadorId",
                table: "Viaje",
                column: "CreadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Viaje_Users_CreadorId",
                table: "Viaje",
                column: "CreadorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Viaje_Users_CreadorId",
                table: "Viaje");

            migrationBuilder.DropIndex(
                name: "IX_Viaje_CreadorId",
                table: "Viaje");

            migrationBuilder.DropColumn(
                name: "CreadorId",
                table: "Viaje");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraPartida",
                table: "Viaje",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
