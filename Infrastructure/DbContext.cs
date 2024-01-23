using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure;
public class ResTICDbContext : DbContext
{
    public DbSet<Log> Logs { get; set; }
    public DbSet<Perfil> Perfils { get; set; }
    public int EnderecoId { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Usuario> Usuarios { get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var connectionString = "server=localhost;user=root;password=Root12345#;database=ResTIConnect";
        var serverVersion = ServerVersion.AutoDetect(connectionString);

        optionsBuilder.UseMySql(connectionString, serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Log>().ToTable("Logs").HasKey(l => l.Id);
        modelBuilder.Entity<Perfil>().ToTable("Perfils").HasKey(p => p.Id);
        modelBuilder.Entity<Endereco>().ToTable("Enderecos").HasKey(e => e.Id);
        modelBuilder.Entity<Usuario>().ToTable("Usuarios").HasKey(u => u.Id);

        modelBuilder.Entity<Usuario>().HasOne(u => u.Endereco).WithOne(e => e.Usuario).HasForeignKey<Usuario>(u => u.EnderecoId);
        modelBuilder.Entity<Usuario>().HasMany(u => u.Perfis).WithOne(p => p.Usuario);
        modelBuilder.Entity<Perfil>().HasOne(p => p.Usuario).WithMany(u => u.Perfis).HasForeignKey(p => p.UsuarioId);
    }
}