using KisiselBlog.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace KisiselBlog.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Project> Projects { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // SQLite özelliklerini ayarlayalım
        modelBuilder.Entity<Project>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

        // Örnek projeler kaldırıldı (HasData çağrıları silindi)
        // Veritabanına verileri manuel olarak ekleyeceksiniz
        
        // Project Features ve Technologies için bir çözüm bulunması gerekiyor
        // SQLite doğrudan List<string> desteklemediği için ek bir model yapısı oluşturalım
    }
} 