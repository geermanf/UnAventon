using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace unAventonApi.Migrations
{
    public partial class m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoCalificacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCalificacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoTarjeta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTarjeta", x => x.Id);
                });

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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Apellido = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    FotoPerfil = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    fechaDeNacimiento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("Email", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Calificacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Comentario = table.Column<string>(nullable: true),
                    PuntuacionId = table.Column<int>(nullable: true),
                    RolId = table.Column<int>(nullable: true),
                    UsuarioCalificadoId = table.Column<int>(nullable: false),
                    UsuarioPuntuadorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calificacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calificacion_TipoCalificacion_PuntuacionId",
                        column: x => x.PuntuacionId,
                        principalTable: "TipoCalificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Calificacion_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Calificacion_Users_UsuarioCalificadoId",
                        column: x => x.UsuarioCalificadoId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calificacion_Users_UsuarioPuntuadorId",
                        column: x => x.UsuarioPuntuadorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarjetas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BancoId = table.Column<int>(nullable: true),
                    FechaVencimiento = table.Column<DateTime>(nullable: false),
                    NombreTitular = table.Column<string>(nullable: true),
                    NumeroTarjeta = table.Column<int>(nullable: false),
                    TipoId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarjetas_Banco_BancoId",
                        column: x => x.BancoId,
                        principalTable: "Banco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tarjetas_TipoTarjeta_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TipoTarjeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tarjetas_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CantidadPlazas = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    Foto = table.Column<string>(nullable: true),
                    Marca = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    Patente = table.Column<string>(nullable: true),
                    TipoVehiculo = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Viaje",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CantidadDePlazas = table.Column<int>(nullable: false),
                    Costo = table.Column<double>(nullable: false),
                    CreadorId = table.Column<int>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Destino = table.Column<string>(nullable: true),
                    Duracion = table.Column<TimeSpan>(nullable: false),
                    HoraPartida = table.Column<TimeSpan>(nullable: false),
                    Origen = table.Column<string>(nullable: true),
                    TipoViajeId = table.Column<int>(nullable: true),
                    VehiculoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viaje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Viaje_Users_CreadorId",
                        column: x => x.CreadorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "ViajesPendientes",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ViajeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViajesPendientes", x => new { x.UserId, x.ViajeId });
                    table.ForeignKey(
                        name: "FK_ViajesPendientes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ViajesPendientes_Viaje_ViajeId",
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
                name: "IX_Calificacion_PuntuacionId",
                table: "Calificacion",
                column: "PuntuacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Calificacion_RolId",
                table: "Calificacion",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Calificacion_UsuarioCalificadoId",
                table: "Calificacion",
                column: "UsuarioCalificadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Calificacion_UsuarioPuntuadorId",
                table: "Calificacion",
                column: "UsuarioPuntuadorId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaDeViaje_ViajeId",
                table: "DiaDeViaje",
                column: "ViajeId");

            migrationBuilder.CreateIndex(
                name: "IX_Postulantes_ViajeId",
                table: "Postulantes",
                column: "ViajeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjetas_BancoId",
                table: "Tarjetas",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjetas_TipoId",
                table: "Tarjetas",
                column: "TipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjetas_UserId",
                table: "Tarjetas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_UserId",
                table: "Vehiculos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Viaje_CreadorId",
                table: "Viaje",
                column: "CreadorId");

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
                name: "IX_ViajesPendientes_ViajeId",
                table: "ViajesPendientes",
                column: "ViajeId");

            migrationBuilder.CreateIndex(
                name: "IX_ViajesRealizados_ViajeId",
                table: "ViajesRealizados",
                column: "ViajeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calificacion");

            migrationBuilder.DropTable(
                name: "DiaDeViaje");

            migrationBuilder.DropTable(
                name: "Postulantes");

            migrationBuilder.DropTable(
                name: "Tarjetas");

            migrationBuilder.DropTable(
                name: "Viajeros");

            migrationBuilder.DropTable(
                name: "ViajesPendientes");

            migrationBuilder.DropTable(
                name: "ViajesRealizados");

            migrationBuilder.DropTable(
                name: "TipoCalificacion");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Banco");

            migrationBuilder.DropTable(
                name: "TipoTarjeta");

            migrationBuilder.DropTable(
                name: "Viaje");

            migrationBuilder.DropTable(
                name: "TipoViaje");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
