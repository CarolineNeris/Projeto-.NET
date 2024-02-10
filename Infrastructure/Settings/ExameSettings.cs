using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Settings;
public class ExameSettings : IEntityTypeConfiguration<Exame>
{
   public void Configure(EntityTypeBuilder<Exame> builder)
   {
     builder
         .ToTable("Exames")
         .HasKey(m => m.Id);

      builder
         .HasOne(m => m.Atendimento)
         .WithMany(m => m.Exames)
         .HasForeignKey(m => m.AtendimentoId);
   }
}