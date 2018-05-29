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
    partial class UnAventonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("unAventonApi.Data.Entities.TipoTarjeta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.HasKey("Id");

                    b.ToTable("TipoTarjeta");
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

            modelBuilder.Entity("unAventonApi.Data.TipoVehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.HasKey("Id");

                    b.ToTable("TipoVehiculo");
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

                    b.Property<string>("Marca");

                    b.Property<string>("Modelo");

                    b.Property<string>("Patente");

                    b.Property<int?>("TipoVehiculoId");

                    b.Property<int?>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("TipoVehiculoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Vehiculos");
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
                    b.HasOne("unAventonApi.Data.TipoVehiculo", "TipoVehiculo")
                        .WithMany()
                        .HasForeignKey("TipoVehiculoId");

                    b.HasOne("unAventonApi.Data.User", "Usuario")
                        .WithMany("Vehiculos")
                        .HasForeignKey("UsuarioId");
                });
#pragma warning restore 612, 618
        }
    }
}
