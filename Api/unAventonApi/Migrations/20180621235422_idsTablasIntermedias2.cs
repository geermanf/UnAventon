using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace unAventonApi.Migrations
{
    public partial class idsTablasIntermedias2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Viajeros_Id",
                table: "Viajeros",
                column: "Id");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Postulantes_Id",
                table: "Postulantes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Viajeros_Id",
                table: "Viajeros");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Postulantes_Id",
                table: "Postulantes");
        }
    }
}
