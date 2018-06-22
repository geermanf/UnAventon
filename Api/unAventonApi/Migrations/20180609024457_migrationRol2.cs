using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace unAventonApi.Migrations
{
    public partial class migrationRol2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calificacion_Users_UserId1",
                table: "Calificacion");

            migrationBuilder.DropIndex(
                name: "IX_Calificacion_UserId1",
                table: "Calificacion");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Calificacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Calificacion",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Calificacion_UserId1",
                table: "Calificacion",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Calificacion_Users_UserId1",
                table: "Calificacion",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
