﻿// <auto-generated />
using EFCoreEjemplos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Empresa.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180311155208_EstaBorrado-Empleado")]
    partial class EstaBorradoEmpleado
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCoreEjemplos.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("EFCoreEjemplos.Direccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Calle");

                    b.Property<int>("EmpleadoId");

                    b.HasKey("Id");

                    b.HasIndex("EmpleadoId")
                        .IsUnique();

                    b.ToTable("Direcciones");
                });

            modelBuilder.Entity("EFCoreEjemplos.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("EstaBorrado");

                    b.Property<int>("EmpresaId");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("EFCoreEjemplos.EstudianteCurso", b =>
                {
                    b.Property<int>("CategoriaId");

                    b.Property<int>("EmpleadoId");

                    b.Property<bool>("Activo");

                    b.HasKey("CategoriaId", "EmpleadoId");

                    b.HasIndex("EmpleadoId");

                    b.ToTable("EmpleadosCategorias");
                });

            modelBuilder.Entity("EFCoreEjemplos.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("EFCoreEjemplos.Direccion", b =>
                {
                    b.HasOne("EFCoreEjemplos.Empleado")
                        .WithOne("Direccion")
                        .HasForeignKey("EFCoreEjemplos.Direccion", "EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFCoreEjemplos.Empleado", b =>
                {
                    b.HasOne("EFCoreEjemplos.Empresa")
                        .WithMany("Empleados")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFCoreEjemplos.EmpleadoCategoria", b =>
                {
                    b.HasOne("EFCoreEjemplos.Categoria", "Categoria")
                        .WithMany("EstudiantesCategorias")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFCoreEjemplos.Empleado", "Empleado")
                        .WithMany("EmpleadosCategorias")
                        .HasForeignKey("EmpleadoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
