using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Empresa
{
    class ApplicationDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // El connectionString debe venir de un archivo de configuraciones!
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=PruebaEfCoreConsola;Integrated Security=True")
                .EnableSensitiveDataLogging(true)
                .UseLoggerFactory(new LoggerFactory().AddConsole((category, level) => level == LogLevel.Information && category == DbLoggerCategory.Database.Command.Name, true));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmpleadoCategoria>().HasKey(x => new { x.CursoId, x.EmpleadoId });

            modelBuilder.Entity<Empleado>().HasOne(x => x.Detalles)
                .WithOne(x => x.Empleado)
                .HasForeignKey<EmpleadoDetalle>(x => x.Id);
            modelBuilder.Entity<EmpleadoDetalle>().ToTable("Empleados");

            modelBuilder.Entity<Empleado>().Property(x => x.Apellido).HasField("_Apellido");
        }

        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Deleted &&
               e.Metadata.GetProperties().Any(x => x.Name == "EstaBorrado")))
            {
                item.State = EntityState.Unchanged;
                item.CurrentValues["EstaBorrado"] = true;
            }

            return base.SaveChanges();
        }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<EmpleadoCategoria> EmpleadosCategorias { get; set; }

        [DbFunction(Schema = "dbo")]
        public static int Cantidad_De_Categorias_Activos(int EmpleadoId)
        {
            throw new Exception();
        }

    }
}
