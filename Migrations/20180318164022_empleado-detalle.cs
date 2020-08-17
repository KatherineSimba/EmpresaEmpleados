using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Empresa.Migrations
{
    public partial class empleadodetalle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Asistencia",
                table: "Empleados",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Carrera",
                table: "Empleados",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaDePago",
                table: "Empleados",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Asistencia",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "Carrera",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "CategoriaDePago",
                table: "Empleados");
        }
    }
}
