using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Empresa 
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("OK");
        }

        static void SeedDatabase()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                context.Database.Migrate();

                if (context.Instituciones.Any())
                {
                    return;
                }

                var empresa = new Empresa();
                empresa.Nombre = "Empresa ";

                var empleado1 = new Empleado();
                empleado1.Nombre = "Eduardo";
                empleado1.Ocupacion = "Desarrollador";
                empleado1.Detalles = new EmpleadoDetalle() { Asistencia = true, Carrera = "Ingeniería de Software", CategoriaDePago = 1 };

                var empleado2 = new Empleado();
                empleado2.Nombre = "Carl";
                empleado2.Ocupacion = "Desarrollador";
                empleado2.Detalles = new EmpleadoDetalle() { Asistencia = false, Carrera = "Ingeniería de Software", CategoriaDePago = 1 };


                var empleado3 = new Empleado();
                empleado3.Nombre = "Roberto";
                empleadoe3.Ocupacion = "Desarrollador";
                empleado3.Detalles = new EmpleadoDetalle() { Asistencia = true, Carrera = "Licenciatura en Derecho", CategoriaDePago = 2 };


                var direccion1 = new Direccion();
                direccion1.Calle = "Avenida Sincholagua 123";
                estudiante1.Direccion = direccion1;

                var categoria1 = new Curso();
                categoria1.Nombre = "Junior";

                var curso2 = new Curso();
                categoria2.Nombre = "Senior";

                var empresa2 = new Empresa();
                empresa2.Nombre = "Empresa 2";

                empresa1.Empleados.Add(empleado1);
                empresa1.Empleados.Add(empleado2);

                empresa2.Empleados.Add(empleado3);

                context.Add(empresa1);
                context.Add(empresa2);
                context.Add(categoria1);
                context.Add(categoria2);

                context.SaveChanges();

                var empleadoCategoria = new EmpleadoCategoria();
                empleadoCategoria.Activo = true;
                empleadoCategoria.CursoId = categoria1.Id;
                empleadoCategoria.EmpleadoId = empleado1.Id;

                var empleadoCategoria2 = new EstudianteCategoria();
                empleadoCategoria2.Activo = false;
                empleadoCategoria2.CursoId = categoria1.Id;
                empleadoCategoria2.EmpleadoId = empleado2.Id;

                context.Add(empleadoCategoria);
                context.Add(empleadoCategoria2);
                context.SaveChanges();
            }
        }

        static void EjemploInsertarEmpleado()
        {
            using (var context = new ApplicationDbContext())
            {
                var empleado = new Empleado();
                empleado.Nombre = "Carl";
                context.Add(empleado);
                context.SaveChanges();
            }
        }

        static void EjemploActualizarEmpleadoModeloConectado()
        {
            using (var context = new ApplicationDbContext())
            {
                var empleados = context.Empleados.Where(x => x.Nombre == "Carl").ToList();

                empleados[0].Nombre += " Apellido";

                context.SaveChanges();

            }
        }

        static void EjemploActualizarEmpleadoModeloDesconectado(Empleado empleado)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(empleado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }

        static void EjemploRemoverEmpleadoModeloConectado()
        {
            using (var context = new ApplicationDbContext())
            {
                var empleadp = context.Empleados.FirstOrDefault();
                context.Remove(context);
                context.SaveChanges();
            }
        }

        static void EjemploRemoverEmpleadoModeloDesonectado(Empleado empleado)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(empleado).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
            }
        }

        static void AgregarModeloUnoAUnoConectado()
        {
            using (var context = new ApplicationDbContext())
            {
                var empleado = new Empleado();
                empleado.Nombre = "Claudio";

                var direccion = new Direccion();
                direccion.Calle = "Ejemplo";
                empleado.Direccion = direccion;

                context.Add(empleado);
                context.SaveChanges();
            }
        }

        static void AgregarModeloUnoAUnoModeloDesconectado(Direccion direccion)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Entry(direccion).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }

        }

        static void TraerDataRelacionada()
        {
            using (var context = new ApplicationDbContext())
            {
                var empleados = context.Empleados.Include(x => x.Direccion).ToList();
            }
        }

        static void AgregarModeloMuchosAMuchosModeloDesconectado(Empleado empleado)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Add(empleado);
                context.SaveChanges();
            }
        }

        static void TraerDataRelacionadaUnoAMuchos()
        {
            using (var context = new ApplicationDbContext())
            {

                var empresasEmpleado1 = context.Empresas.Where(x => x.Id == 1).Include(x => x.Empleados).ToList();

                var EmpresasEmpleados = context.Empresas.Where(x => x.Id == 1)
                    .Select(x => new { Empresa = x, Empleados = x.Empleados.Where(e => e.Edad > 18).ToList() }).ToList();

            }
        }

        static void InsertarDataRelacionadaMuchosAMuchos()
        {
            using (var context = new ApplicationDbContext())
            {
                var empleado = context.Empleados.FirstOrDefault();
                var categoria = context.Categorias.FirstOrDefault();

                var empleadoCategoria = new EmpleadoCategoria();

                empleadoCategoria.CategoriaId = categoria.Id;
                empleadoCategoria.EmpleadoId = empleado.Id;
                empleadoCategoria.Activo = true;

                context.Add(empleadoCategoria);
                context.SaveChanges();
            }
        }

        static void TraerDataRelacionadaMuchosAMuchos()
        {
            using (var context = new ApplicationDbContext())
            {
                var categoria = context.Cursos.Where(x => x.Id == 1).Include(x => x.EmpleadosCategorias)
                    .ThenInclude(y => y.Empleado).FirstOrDefault();
            }
        }

        static void StringInterpolationEnEF2()
        {
            using (var context = new ApplicationDbContext())
            {
                var nombre = "'Felipe' or 1=1";
                var empleado = context.Empleados.FromSql($"select * from Empleados where Nombre = {nombre}").ToList();
            }
        }

        static void FiltroPorTipo()
        {
            using (var context = new ApplicationDbContext())
            {
                var empleadosCategorias = context.EmpleadosCategorias.ToList();
            }
        }

        static void BorradoSuave()
        {
            using (var context = new ApplicationDbContext())
            {
                var empleado = context.Empleados.FirstOrDefault();
                context.Remove(empleado);
                context.SaveChanges();
            }
        }

        static void EjemploConcurrencyCheck()
        {
            using (var context = new ApplicationDbContext())
            {
                var est = context.Empleados.FirstOrDefault();
                est.Nombre += " 2";
                context.SaveChanges();
            }
        }

        static void FuncionEscalarEnEF()
        {
            using (var context = new ApplicationDbContext())
            {
                var empleados = context.Empleados
                    .Where(x => ApplicationDbContext.Cantidad_De_Categorias_Activos(x.Id) > 0).ToList();
            }
        }

        static void FuncionalidadTableSplitting()
        {
            using (var context = new ApplicationDbContext())
            {
                var empleados = context.Empleados.Include(x => x.Detalles).ToList();
            }
        }
    }

    class Empresa
    {
        public Empresa()
        {
            Empleados = new List<Empleado>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Empleado> Empleados { get; set; }
    }

    class Empleado
    {
        public int Id { get; set; }
        [ConcurrencyCheck]
        public string Nombre { get; set; }
        public int EmpresaId { get; set; }
        public bool EstaBorrado { get; set; }

        private string _Apellido;

        public string Apellido
        {
            get { return _Apellido; }
            set
            {
                _Apellido = value.ToUpper();
            }
        }
        public Direccion Direccion { get; set; }
        public List<EmpleadoCategoria> EmpleadosCategorias { get; set; }
        public EmpleadoDetalle Detalles { get; set; }
    }

    class EmpleadoDetalle
    {
        public int Id { get; set; }
        public bool Asistencia { get; set; }
        public string Carrera { get; set; }
        public int CategoriaDePago { get; set; }
        public Empleado Empleado { get; set; }
    }

    class Direccion
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public int EmpleadoId { get; set; }
    }

    class Categoria
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Nombre { get; set; }
        public List<EmpleadoCategoria> EmpleadosCategorias { get; set; }
    }

    class EmpleadoCategoria
    {
        public int EmpleadoId { get; set; }
        public int CategoriaId { get; set; }
        public bool Activo { get; set; }
        public Empleado Empleado { get; set; }
        public Categoria Categoria { get; set; }
    }
}
