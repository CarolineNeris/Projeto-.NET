using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;
public class TechMedDbContext : DbContext
{
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Atendimento> Atendimentos { get; set; }
    public DbSet<Exame> Exames { get; set; }

    public TechMedDbContext(DbContextOptions<TechMedDbContext> options) : base(options)
   {
      //Database.EnsureCreated();
   }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);

      modelBuilder.ApplyConfigurationsFromAssembly(typeof(TechMedDbContext).Assembly);
   }

}