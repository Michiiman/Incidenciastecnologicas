using Dominio;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("persona");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.NombrePersona)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasOne(p => p.Genero)
            .WithMany(p => p.Personas)
            .HasForeignKey(p => p.IdGeneroFk);

            builder.HasOne(p => p.Ciudad)
            .WithMany(p => p.Personas)
            .HasForeignKey(p => p.IdCiudadFK);

            builder.HasOne(p => p.TipoPersona)
            .WithMany(p => p.Personas)
            .HasForeignKey(p => p.IdTipoPerFk);
            
            builder
            .HasMany(p=>p.Salones)
            .WithMany(p=>p.Personas)
            .UsingEntity<TrainerSalon>(
                j=>j
            .HasOne(pt=>pt.Salon)
            .WithMany(t=>t.TrainerSalones)
            .HasForeignKey(pt=>pt.IdSalonFk),
            j => j
            .HasOne(pt => pt.Persona)
            .WithMany(t => t.TrainerSalones)
            .HasForeignKey(pt => pt.IdPerTrainerFk),
            j => 
            {
            j.HasKey(t => new { t.IdSalonFk, t.IdPerTrainerFk});
            }
            );
            
        }
    }
}
