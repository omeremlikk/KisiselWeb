using KisiselBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace KisiselBlog.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        // Database.EnsureCreated() burada çağrılabilir,
        // ancak migrasyon kullanıyorsanız bu çağrıyı kaldırın
    }

    public DbSet<Project> Projects { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // SQLite özelliklerini ayarlayalım
        modelBuilder.Entity<Project>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }
} 