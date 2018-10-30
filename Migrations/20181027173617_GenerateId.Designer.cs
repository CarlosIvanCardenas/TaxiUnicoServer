﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaxiUnicoServer.Models;

namespace TaxiUnicoServer.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20181027173617_GenerateId")]
    partial class GenerateId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TaxiUnicoServer.Models.Classes.Administrador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apellidos")
                        .IsRequired();

                    b.Property<string>("Contraseña")
                        .IsRequired();

                    b.Property<string>("Correo")
                        .IsRequired();

                    b.Property<string>("PrimerNombre")
                        .IsRequired();

                    b.Property<string>("SegundoNombre");

                    b.Property<string>("Telefono")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("TaxiUnicoServer.Models.Classes.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apellidos")
                        .IsRequired();

                    b.Property<string>("Contraseña")
                        .IsRequired();

                    b.Property<string>("Correo")
                        .IsRequired();

                    b.Property<string>("Direccion");

                    b.Property<string>("PrimerNombre")
                        .IsRequired();

                    b.Property<string>("SegundoNombre");

                    b.Property<string>("Telefono")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("TaxiUnicoServer.Models.Classes.TarjetaCredito", b =>
                {
                    b.Property<Guid>("ClienteId");

                    b.Property<string>("NumeroTarjeta");

                    b.Property<string>("CVC")
                        .IsRequired();

                    b.Property<string>("FechaExpiracion")
                        .IsRequired();

                    b.HasKey("ClienteId", "NumeroTarjeta");

                    b.ToTable("TarjetasCredito");
                });

            modelBuilder.Entity("TaxiUnicoServer.Models.Classes.Taxista", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AdministradorId");

                    b.Property<string>("Apellidos")
                        .IsRequired();

                    b.Property<string>("Contraseña")
                        .IsRequired();

                    b.Property<string>("Correo")
                        .IsRequired();

                    b.Property<string>("Direccion");

                    b.Property<DateTime>("FechaModificado");

                    b.Property<DateTime>("FechaRegistro");

                    b.Property<string>("PrimerNombre")
                        .IsRequired();

                    b.Property<decimal>("Puntuacion");

                    b.Property<string>("SegundoNombre");

                    b.Property<string>("Telefono")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AdministradorId");

                    b.ToTable("Taxistas");
                });

            modelBuilder.Entity("TaxiUnicoServer.Models.Classes.Vehiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color")
                        .IsRequired();

                    b.Property<string>("Marca")
                        .IsRequired();

                    b.Property<string>("Modelo")
                        .IsRequired();

                    b.Property<string>("Placa")
                        .IsRequired();

                    b.Property<string>("PolizaSeguro");

                    b.Property<Guid>("TaxistaId");

                    b.HasKey("Id");

                    b.HasIndex("TaxistaId");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("TaxiUnicoServer.Models.Classes.Viaje", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ClienteId");

                    b.Property<string>("Destino")
                        .IsRequired();

                    b.Property<string>("FormaPago")
                        .IsRequired();

                    b.Property<DateTime>("HoraLlegada");

                    b.Property<DateTime>("HoraPartida");

                    b.Property<DateTime>("HoraSolicitud");

                    b.Property<decimal>("Kilometros");

                    b.Property<int>("NumeroPasajeros");

                    b.Property<string>("Origen")
                        .IsRequired();

                    b.Property<Guid>("VehiculoId");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("VehiculoId");

                    b.ToTable("Viajes");
                });

            modelBuilder.Entity("TaxiUnicoServer.Models.Classes.TarjetaCredito", b =>
                {
                    b.HasOne("TaxiUnicoServer.Models.Classes.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TaxiUnicoServer.Models.Classes.Taxista", b =>
                {
                    b.HasOne("TaxiUnicoServer.Models.Classes.Administrador", "Administrador")
                        .WithMany()
                        .HasForeignKey("AdministradorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TaxiUnicoServer.Models.Classes.Vehiculo", b =>
                {
                    b.HasOne("TaxiUnicoServer.Models.Classes.Taxista", "Taxista")
                        .WithMany()
                        .HasForeignKey("TaxistaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TaxiUnicoServer.Models.Classes.Viaje", b =>
                {
                    b.HasOne("TaxiUnicoServer.Models.Classes.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TaxiUnicoServer.Models.Classes.Vehiculo", "Vehiculo")
                        .WithMany()
                        .HasForeignKey("VehiculoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
