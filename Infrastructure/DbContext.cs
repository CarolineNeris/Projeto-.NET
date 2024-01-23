using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure;
public class ResTICDbContext : DbContext
{
    public DbSet<Log> Logs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var connectionString = "server=localhost;user=RestTI;password=123456;database=RestTIC";
        var serverVersion = ServerVersion.AutoDetect(connectionString);

        optionsBuilder.UseMySql(connectionString, serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Log>().ToTable("Logs").HasKey(l => l.Id);
    }
}