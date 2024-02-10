using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Settings;
public class PacienteConfigurations : IEntityTypeConfiguration<Paciente>
{
   public void Configure(EntityTypeBuilder<Paciente> builder)
   {
      builder
         .ToTable("Pacientes")
         .HasKey(m => m.Id);
   }
}