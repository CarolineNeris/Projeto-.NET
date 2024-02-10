using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Settings;
public class MedicoConfigurations : IEntityTypeConfiguration<Medico>
{
   public void Configure(EntityTypeBuilder<Medico> builder)
   {

      builder
         .ToTable("Medicos")
         .HasKey(m => m.Id);
   }
}