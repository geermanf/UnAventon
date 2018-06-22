using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace unAventonApi.Migrations
{
    public partial class migrationTablasIntermedias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoViaje",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoViaje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Viaje",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Costo = table.Column<double>(nullable: false),
                    Destino = table.Column<string>(nullable: true),
                    Duracion = table.Column<TimeSpan>(nullable: false),
                    FechaPartida = table.Column<DateTime>(nullable: false),
                    HoraPartida = table.Column<TimeSpan>(nullable: false),
                    Origen = table.Column<string>(nullable: true),
                    TipoViajeId = table.Column<int>(nullable: true),
                    VehiculoId = table.Column<int>(nullable: true),
                    Vencido = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viaje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Viaje_TipoViaje_TipoViajeId",
                        column: x => x.TipoViajeId,
                        principalTable: "TipoViaje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Viaje_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Postulantes",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ViajeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postulantes", x => new { x.UserId, x.ViajeId });
                    table.ForeignKey(
                        name: "FK_Postulantes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Postulantes_Viaje_ViajeId",
                        column: x => x.ViajeId,
                        principalTable: "Viaje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Viajeros",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ViajeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viajeros", x => new { x.UserId, x.ViajeId });
                    table.ForeignKey(
                        name: "FK_Viajeros_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Viajeros_Viaje_ViajeId",
                        column: x => x.ViajeId,
                        principalTable: "Viaje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ViajesPentiendes",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ViajeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViajesPentiendes", x => new { x.UserId, x.ViajeId });
                    table.ForeignKey(
                        name: "FK_ViajesPentiendes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ViajesPentiendes_Viaje_ViajeId",
                        column: x => x.ViajeId,
                        principalTable: "Viaje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ViajesRealizados",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ViajeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViajesRealizados", x => new { x.UserId, x.ViajeId });
                    table.ForeignKey(
                        name: "FK_ViajesRealizados_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ViajesRealizados_Viaje_ViajeId",
                        column: x => x.ViajeId,
                        principalTable: "Viaje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Postulantes_ViajeId",
                table: "Postulantes",
                column: "ViajeId");

            migrationBuilder.CreateIndex(
                name: "IX_Viaje_TipoViajeId",
                table: "Viaje",
                column: "TipoViajeId");

            migrationBuilder.CreateIndex(
                name: "IX_Viaje_VehiculoId",
                table: "Viaje",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajeros_ViajeId",
                table: "Viajeros",
                column: "ViajeId");

            migrationBuilder.CreateIndex(
                name: "IX_ViajesPentiendes_ViajeId",
                table: "ViajesPentiendes",
                column: "ViajeId");

            migrationBuilder.CreateIndex(
                name: "IX_ViajesRealizados_ViajeId",
                table: "ViajesRealizados",
                column: "ViajeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Postulantes");

            migrationBuilder.DropTable(
                name: "Viajeros");

            migrationBuilder.DropTable(
                name: "ViajesPentiendes");

            migrationBuilder.DropTable(
                name: "ViajesRealizados");

            migrationBuilder.DropTable(
                name: "Viaje");

            migrationBuilder.DropTable(
                name: "TipoViaje");
        }
    }
}
