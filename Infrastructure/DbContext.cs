using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure;
public class ResTICDbContext : DbContext
{
    public DbSet<Log> Logs { get; set; }
    public DbSet<Perfil> Perfils { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var connectionString = "server=localhost;user=root;password=Ricardo_dev_1991;database=ResTIConnect";
        var serverVersion = ServerVersion.AutoDetect(connectionString);

        optionsBuilder.UseMySql(connectionString, serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Log>().ToTable("Logs").HasKey(l => l.Id);
        modelBuilder.Entity<Perfil>().ToTable("Perfils").HasKey(p => p.Id);
        modelBuilder.Entity<Endereco>().ToTable("Enderecos").HasKey(e => e.Id);
    }
}