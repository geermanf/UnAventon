using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace unAventonApi.Migrations
{
    public partial class horaPartida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraPartida",
                table: "Viaje",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoraPartida",
                table: "Viaje");
        }
    }
}
