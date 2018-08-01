using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace unAventonApi.Migrations
{
    public partial class preguntasYpagos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaDePago = table.Column<DateTime>(nullable: true),
                    Monto = table.Column<int>(nullable: false),
                    TarjetaId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    UserId1 = table.Column<int>(nullable: true),
                    ViajeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pago_Tarjetas_TarjetaId",
                        column: x => x.TarjetaId,
                        principalTable: "Tarjetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pago_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pago_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pago_Viaje_ViajeId",
                        column: x => x.ViajeId,
                        principalTable: "Viaje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pregunta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Enunciado = table.Column<string>(nullable: true),
                    FechaDeEmision = table.Column<DateTime>(nullable: false),
                    Respuesta = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: true),
                    ViajeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pregunta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pregunta_Users_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pregunta_Viaje_ViajeId",
                        column: x => x.ViajeId,
                        principalTable: "Viaje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pago_TarjetaId",
                table: "Pago",
                column: "TarjetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_UserId",
                table: "Pago",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_UserId1",
                table: "Pago",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_ViajeId",
                table: "Pago",
                column: "ViajeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregunta_UsuarioId",
                table: "Pregunta",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregunta_ViajeId",
                table: "Pregunta",
                column: "ViajeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "Pregunta");
        }
    }
}
