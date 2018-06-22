﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using unAventonApi.Data;

namespace unAventonApi.Migrations
{
    [DbContext(typeof(UnAventonDbContext))]
    [Migration("20180621234639_idsTablasIntermedias")]
    partial class idsTablasIntermedias
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("unAventonApi.Data.Entities.Banco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.HasKey("Id");

                    b.ToTable("Banco");
                });

            modelBuilder.Entity("unAventonApi.Data.Entities.Calificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comentario");

                    b.Property<int?>("PuntuacionId");

                    b.Property<int?>("RolId");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PuntuacionId");

                    b.HasIndex("RolId");

                    b.HasIndex("UserId");

                    b.ToTable("Calificacion");
                });

            modelBuilder.Entity("unAventonApi.Data.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.HasKey("Id");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("unAventonApi.Data.Entities.TablasIntermedias.Postulantes", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("ViajeId");

                    b.Property<int>("Id");

                    b.HasKey("UserId", "ViajeId");

                    b.HasIndex("ViajeId");

                    b.ToTable("Postulantes");
                });

            modelBuilder.Entity("unAventonApi.Data.Entities.TablasIntermedias.Viajeros", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("ViajeId");

                    b.Property<int>("Id");

                    b.HasKey("UserId", "ViajeId");

                    b.HasIndex("ViajeId");

                    b.ToTable("Viajeros");
                });

            modelBuilder.Entity("unAventonApi.Data.Entities.TablasIntermedias.ViajesPendientes", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("ViajeId");

                    b.HasKey("UserId", "ViajeId");

                    b.HasIndex("ViajeId");

                    b.ToTable("ViajesPentiendes");
                });

            modelBuilder.Entity("unAventonApi.Data.Entities.TablasIntermedias.ViajesRealizados", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("ViajeId");

                    b.HasKey("UserId", "ViajeId");

                    b.HasIndex("ViajeId");

                    b.ToTable("ViajesRealizados");
                });

            modelBuilder.Entity("unAventonApi.Data.Entities.TipoCalificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.HasKey("Id");

                    b.ToTable("TipoCalificacion");
                });

            modelBuilder.Entity("unAventonApi.Data.Entities.TipoTarjeta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.HasKey("Id");

                    b.ToTable("TipoTarjeta");
                });

            modelBuilder.Entity("unAventonApi.Data.Entities.TipoViaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.HasKey("Id");

                    b.ToTable("TipoViaje");
                });

            modelBuilder.Entity("unAventonApi.Data.Entities.Viaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Costo");

                    b.Property<string>("Destino");

                    b.Property<TimeSpan>("Duracion");

                    b.Property<DateTime>("FechaPartida");

                    b.Property<TimeSpan>("HoraPartida");

                    b.Property<string>("Origen");

                    b.Property<int?>("TipoViajeId");

                    b.Property<int?>("VehiculoId");

                    b.HasKey("Id");

                    b.HasIndex("TipoViajeId");

                    b.HasIndex("VehiculoId");

                    b.ToTable("Viaje");
                });

            modelBuilder.Entity("unAventonApi.Data.Tarjeta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BancoId");

                    b.Property<DateTime>("FechaVencimiento");

                    b.Property<string>("NombreTitular");

                    b.Property<int>("NumeroTarjeta");

                    b.Property<int?>("TipoId");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BancoId");

                    b.HasIndex("TipoId");

                    b.HasIndex("UserId");

                    b.ToTable("Tarjetas");
                });

            modelBuilder.Entity("unAventonApi.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apellido");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FotoPerfil");

                    b.Property<string>("Nombre");

                    b.Property<string>("Password");

                    b.Property<DateTime>("fechaDeNacimiento");

                    b.HasKey("Id");

                    b.HasAlternateKey("Email")
                        .HasName("Email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("unAventonApi.Data.Vehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CantidadPlazas");

                    b.Property<string>("Color");

                    b.Property<string>("Foto");

                    b.Property<string>("Marca");

                    b.Property<string>("Modelo");

                    b.Property<string>("Patente");

                    b.Property<string>("TipoVehiculo");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("unAventonApi.Data.Entities.Calificacion", b =>
                {
                    b.HasOne("unAventonApi.Data.Entities.TipoCalificacion", "Puntuacion")
                        .WithMany()
                        .HasForeignKey("PuntuacionId");

                    b.HasOne("unAventonApi.Data.Entities.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId");

                    b.HasOne("unAventonApi.Data.User")
                        .WithMany("Calificaciones")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("unAventonApi.Data.Entities.TablasIntermedias.Postulantes", b =>
                {
                    b.HasOne("unAventonApi.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("unAventonApi.Data.Entities.Viaje", "Viaje")
                        .WithMany("Postulantes")
                        .HasForeignKey("ViajeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("unAventonApi.Data.Entities.TablasIntermedias.Viajeros", b =>
                {
                    b.HasOne("unAventonApi.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("unAventonApi.Data.Entities.Viaje", "Viaje")
                        .WithMany("Viajeros")
                        .HasForeignKey("ViajeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("unAventonApi.Data.Entities.TablasIntermedias.ViajesPendientes", b =>
                {
                    b.HasOne("unAventonApi.Data.User", "User")
                        .WithMany("ViajesPendientes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("unAventonApi.Data.Entities.Viaje", "Viaje")
                        .WithMany()
                        .HasForeignKey("ViajeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("unAventonApi.Data.Entities.TablasIntermedias.ViajesRealizados", b =>
                {
                    b.HasOne("unAventonApi.Data.User", "User")
                        .WithMany("ViajesRealizados")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("unAventonApi.Data.Entities.Viaje", "Viaje")
                        .WithMany()
                        .HasForeignKey("ViajeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("unAventonApi.Data.Entities.Viaje", b =>
                {
                    b.HasOne("unAventonApi.Data.Entities.TipoViaje", "TipoViaje")
                        .WithMany()
                        .HasForeignKey("TipoViajeId");

                    b.HasOne("unAventonApi.Data.Vehiculo", "Vehiculo")
                        .WithMany()
                        .HasForeignKey("VehiculoId");
                });

            modelBuilder.Entity("unAventonApi.Data.Tarjeta", b =>
                {
                    b.HasOne("unAventonApi.Data.Entities.Banco", "Banco")
                        .WithMany()
                        .HasForeignKey("BancoId");

                    b.HasOne("unAventonApi.Data.Entities.TipoTarjeta", "Tipo")
                        .WithMany()
                        .HasForeignKey("TipoId");

                    b.HasOne("unAventonApi.Data.User")
                        .WithMany("Tarjetas")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("unAventonApi.Data.Vehiculo", b =>
                {
                    b.HasOne("unAventonApi.Data.User")
                        .WithMany("Vehiculos")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
