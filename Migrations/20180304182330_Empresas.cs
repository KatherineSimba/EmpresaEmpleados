using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Empresa.Migrations
{
    public partial class Empresas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Empresarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresarios_EmpresaId",
                table: "Empresarios",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresarios_Empresas_EmpresaId",
                table: "Empresarios",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresarios_Empresas_EmpresaId",
                table: "Empresarios");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Empresarios_EmpresaId",
                table: "Empresarios");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Empresarios");
        }
    }
}
