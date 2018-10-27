using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxiUnicoServer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Correo = table.Column<string>(nullable: false),
                    Contraseña = table.Column<string>(nullable: false),
                    PrimerNombre = table.Column<string>(nullable: false),
                    SegundoNombre = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Correo = table.Column<string>(nullable: false),
                    Contraseña = table.Column<string>(nullable: false),
                    PrimerNombre = table.Column<string>(nullable: false),
                    SegundoNombre = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taxistas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Correo = table.Column<string>(nullable: false),
                    Contraseña = table.Column<string>(nullable: false),
                    PrimerNombre = table.Column<string>(nullable: false),
                    SegundoNombre = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    Puntuacion = table.Column<decimal>(nullable: false),
                    AdministradorId = table.Column<Guid>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    FechaModificado = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taxistas_Administradores_AdministradorId",
                        column: x => x.AdministradorId,
                        principalTable: "Administradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TarjetasCredito",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(nullable: false),
                    NumeroTarjeta = table.Column<string>(nullable: false),
                    FechaExpiracion = table.Column<string>(nullable: false),
                    CVC = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarjetasCredito", x => new { x.ClienteId, x.NumeroTarjeta });
                    table.ForeignKey(
                        name: "FK_TarjetasCredito_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Placa = table.Column<string>(nullable: false),
                    TaxistaId = table.Column<Guid>(nullable: false),
                    Marca = table.Column<string>(nullable: false),
                    Modelo = table.Column<string>(nullable: false),
                    Color = table.Column<string>(nullable: false),
                    PolizaSeguro = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Taxistas_TaxistaId",
                        column: x => x.TaxistaId,
                        principalTable: "Taxistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Viajes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Origen = table.Column<string>(nullable: false),
                    Destino = table.Column<string>(nullable: false),
                    Kilometros = table.Column<decimal>(nullable: false),
                    HoraSolicitud = table.Column<DateTime>(nullable: false),
                    HoraPartida = table.Column<DateTime>(nullable: false),
                    HoraLlegada = table.Column<DateTime>(nullable: false),
                    VehiculoId = table.Column<Guid>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: false),
                    NumeroPasajeros = table.Column<int>(nullable: false),
                    FormaPago = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viajes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Viajes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Viajes_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Taxistas_AdministradorId",
                table: "Taxistas",
                column: "AdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_TaxistaId",
                table: "Vehiculos",
                column: "TaxistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_ClienteId",
                table: "Viajes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_VehiculoId",
                table: "Viajes",
                column: "VehiculoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TarjetasCredito");

            migrationBuilder.DropTable(
                name: "Viajes");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Taxistas");

            migrationBuilder.DropTable(
                name: "Administradores");
        }
    }
}
