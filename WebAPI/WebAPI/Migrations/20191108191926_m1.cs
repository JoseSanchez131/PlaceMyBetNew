﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Local = table.Column<string>(nullable: true),
                    Visitant = table.Column<string>(nullable: true),
                    Goles = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Mercados",
                columns: table => new
                {
                    MercadoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipo_mercado = table.Column<int>(nullable: false),
                    Cuota_over = table.Column<double>(nullable: false),
                    Cuota_under = table.Column<double>(nullable: false),
                    Dinero_over = table.Column<double>(nullable: false),
                    Dinero_under = table.Column<double>(nullable: false),
                    EventoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercados", x => x.MercadoId);
                    table.ForeignKey(
                        name: "FK_Mercados_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    CuentaId = table.Column<string>(nullable: false),
                    SaldoActual = table.Column<string>(nullable: true),
                    NombreBanco = table.Column<string>(nullable: true),
                    NumeroTarjeta = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.CuentaId);
                    table.ForeignKey(
                        name: "FK_Cuentas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Apuestas",
                columns: table => new
                {
                    ApuestaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TipoApuesta = table.Column<int>(nullable: false),
                    Cuota = table.Column<double>(nullable: false),
                    DineroApostado = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<string>(nullable: true),
                    MercadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apuestas", x => x.ApuestaId);
                    table.ForeignKey(
                        name: "FK_Apuestas_Mercados_MercadoId",
                        column: x => x.MercadoId,
                        principalTable: "Mercados",
                        principalColumn: "MercadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apuestas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "EventoId", "Goles", "Local", "Visitant" },
                values: new object[] { 1, 2, "Madrid", "Barcelona" });

            migrationBuilder.CreateIndex(
                name: "IX_Apuestas_MercadoId",
                table: "Apuestas",
                column: "MercadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Apuestas_UsuarioId",
                table: "Apuestas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_UsuarioId",
                table: "Cuentas",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mercados_EventoId",
                table: "Mercados",
                column: "EventoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apuestas");

            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "Mercados");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
