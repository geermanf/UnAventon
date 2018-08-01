using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace unAventonApi.Migrations
{
    public partial class pagosFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pago_Users_UserId1",
                table: "Pago");

            migrationBuilder.DropIndex(
                name: "IX_Pago_UserId1",
                table: "Pago");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Pago");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Pago",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pago_UserId1",
                table: "Pago",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Pago_Users_UserId1",
                table: "Pago",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
