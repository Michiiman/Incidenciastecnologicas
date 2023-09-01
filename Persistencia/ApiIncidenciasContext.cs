
using Microsoft.EntityFrameworkCore;
using Dominio.Entities;
using System.Reflection;

namespace Persistencia;

    public class ApiIncidenciasContext: DbContext
    {
        public ApiIncidenciasContext(DbContextOptions<ApiIncidenciasContext>options):base(options)
        {

        }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Salon> Salones { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<TipoPersona> TipoPersonas{ get; set; }
        public DbSet<TrainerSalon> TrainerSalones { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Genero> Generos { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }


    }
