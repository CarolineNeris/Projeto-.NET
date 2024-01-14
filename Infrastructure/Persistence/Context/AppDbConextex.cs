using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Presentation.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) { }
    public DbSet<User> Users { get; set; }
}