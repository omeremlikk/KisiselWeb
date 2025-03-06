using KisiselBlog.Models;
using Microsoft.EntityFrameworkCore;

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

        // İlk proje verilerini ekleyelim (seed data)
        modelBuilder.Entity<Project>().HasData(
            new Project
            {
                Id = 1,
                Title = "Kişisel Blog Projesi",
                ShortDescription = "ASP.NET Core MVC ile geliştirilmiş modern blog sitesi",
                Description = "ASP.NET Core MVC kullanılarak geliştirilen modern ve responsive bir kişisel blog sitesi.",
                ImageUrl = "/images/proje1.png",
                GifUrl = "/images/proje1.gif",
                Category = "frontend",
                IsFeatured = true,
                TechStack = "ASP.NET Core MVC, Bootstrap 5, Entity Framework Core"
            },
            new Project
            {
                Id = 2,
                Title = "To-Do List Uygulaması",
                ShortDescription = "React ve .NET Core Web API ile geliştirilmiş görev yönetim uygulaması",
                Description = "React ve .NET Core Web API kullanılarak geliştirilen modern bir görev yönetim uygulaması.",
                ImageUrl = "/images/proje2.png",
                GifUrl = "/images/proje2.gif",
                Category = "all",
                IsFeatured = true,
                TechStack = "React.js, .NET Core Web API, Entity Framework Core"
            },
            new Project
            {
                Id = 3,
                Title = "E-Ticaret Platformu",
                ShortDescription = "ASP.NET Core ve Angular ile geliştirilmiş e-ticaret platformu",
                Description = "ASP.NET Core backend ve Angular frontend ile geliştirilmiş, tam kapsamlı bir e-ticaret platformu.",
                ImageUrl = "/images/proje3.png",
                GifUrl = "/images/proje3.gif",
                Category = "web",
                IsFeatured = false,
                TechStack = "ASP.NET Core, Angular, MS SQL, Redis"
            }
        );

        // Project Features ve Technologies için bir çözüm bulunması gerekiyor
        // SQLite doğrudan List<string> desteklemediği için ek bir model yapısı oluşturalım
    }
} 