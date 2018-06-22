using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace unAventonApi.Migrations
{
    public partial class idsTablasIntermedias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vencido",
                table: "Viaje");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Viajeros",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Postulantes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Viajeros");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Postulantes");

            migrationBuilder.AddColumn<bool>(
                name: "Vencido",
                table: "Viaje",
                nullable: false,
                defaultValue: false);
        }
    }
}
