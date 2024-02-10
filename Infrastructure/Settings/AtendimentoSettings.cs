using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Settings;
public class AtendimentoSettings : IEntityTypeConfiguration<Atendimento>
{
   public void Configure(EntityTypeBuilder<Atendimento> builder)
   {
      builder
         .ToTable("Atendimentos")
         .HasKey(m => m.Id);

      builder
         .HasOne(m => m.Medico)
         .WithMany(m => m.Atendimentos)
         .HasForeignKey(m => m.MedicoId);

      builder
         .HasOne(m => m.Paciente)
         .WithMany(m => m.Atendimentos)
         .HasForeignKey(m => m.PacienteId);
   }
}