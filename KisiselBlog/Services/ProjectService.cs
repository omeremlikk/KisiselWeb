using KisiselBlog.Models;
using KisiselBlog.Repository;

namespace KisiselBlog.Services;

public class ProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Project> CreateProjectAsync(Project project)
    {
        // Yeni proje için temel ayarlar
        if (string.IsNullOrEmpty(project.Title))
        {
            throw new ArgumentException("Proje başlığı boş olamaz.");
        }

        // CreatedDate alanı artık kullanılmıyor
        // project.CreatedDate = DateTime.Now;

        return await _projectRepository.AddProjectAsync(project);
    }

    public async Task<List<Project>> GetAllProjectsAsync()
    {
        return await _projectRepository.GetAllProjectsAsync();
    }

    public async Task<Project?> GetProjectByIdAsync(int id)
    {
        return await _projectRepository.GetProjectByIdAsync(id);
    }

    public async Task<Project> UpdateProjectAsync(int id, Project updatedProject)
    {
        var existingProject = await _projectRepository.GetProjectByIdAsync(id);

        if (existingProject == null)
        {
            throw new KeyNotFoundException($"ID {id} ile proje bulunamadı.");
        }

        // Güncellenmiş alanları mevcut projeye kopyala
        existingProject.Title = updatedProject.Title;
        existingProject.Description = updatedProject.Description;
        existingProject.ShortDescription = updatedProject.ShortDescription;
        existingProject.ImageUrl = updatedProject.ImageUrl;
        existingProject.GifUrl = updatedProject.GifUrl;
        // CreatedDate alanı artık kullanılmıyor
        // existingProject.CreatedDate = updatedProject.CreatedDate;
        existingProject.Category = updatedProject.Category;
        existingProject.TechStack = updatedProject.TechStack;
        existingProject.IsFeatured = updatedProject.IsFeatured;
        existingProject.Features = updatedProject.Features;
        existingProject.Technologies = updatedProject.Technologies;

        return await _projectRepository.UpdateProjectAsync(existingProject);
    }

    public async Task<Project> CreateDefaultProjectAsync()
    {
        // Test projesi oluşturma
        var project = new Project
        {
            Title = "Örnek Proje",
            Description = "Bu bir örnek proje açıklamasıdır.",
            ShortDescription = "Örnek proje kısa açıklama",
            ImageUrl = "/images/ornek-proje.jpg",
            GifUrl = "/images/ornek-proje.gif",
            // CreatedDate alanı artık kullanılmıyor
            // CreatedDate = DateTime.Now,
            Category = "web",
            TechStack = "ASP.NET Core, Bootstrap",
            IsFeatured = true,
            Features = new List<string> { "Özellik 1", "Özellik 2", "Özellik 3" },
            Technologies = new List<string> { "ASP.NET Core", "Bootstrap", "Entity Framework Core" }
        };

        return await _projectRepository.AddProjectAsync(project);
    }

    public async Task DeleteProjectAsync(int id)
    {
        var project = await _projectRepository.GetProjectByIdAsync(id);

        if (project == null)
        {
            throw new KeyNotFoundException($"ID {id} ile proje bulunamadı.");
        }

        await _projectRepository.DeleteProjectAsync(id);
    }

    // Örnek proje verilerini döndüren metot
    public List<Project> GetProjects()
    {
        // Test için örnek veriler
        return new List<Project>
        {
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
                TechStack = "ASP.NET Core MVC, Bootstrap 5, Entity Framework Core",
                Features = new List<string> 
                { 
                    "Responsive tasarım", 
                    "Modern UI/UX", 
                    "Blog yazı yönetimi",
                    "SEO uyumlu yapı", 
                    "Performans optimizasyonu" 
                },
                Technologies = new List<string> 
                { 
                    "ASP.NET Core MVC", 
                    "Bootstrap 5", 
                    "Entity Framework Core", 
                    "SQL Server", 
                    "JavaScript/jQuery" 
                }
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
                TechStack = "React.js, .NET Core Web API, Entity Framework Core",
                Features = new List<string> 
                { 
                    "Görev ekleme, düzenleme, silme", 
                    "Görev kategorileri", 
                    "Görev önceliklendirme"
                },
                Technologies = new List<string> 
                { 
                    "React.js", 
                    "Redux", 
                    ".NET Core Web API", 
                    "Entity Framework Core", 
                    "SQL Server"
                }
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
                TechStack = "ASP.NET Core, Angular, MS SQL, Redis",
                Features = new List<string> 
                { 
                    "Kullanıcı kayıt ve giriş sistemi", 
                    "Ürün kataloğu ve arama", 
                    "Sepet ve ödeme işlemleri",
                    "Sipariş takibi", 
                    "Admin paneli"
                },
                Technologies = new List<string> 
                { 
                    "ASP.NET Core", 
                    "Angular 13", 
                    "MS SQL Server", 
                    "Redis Cache", 
                    "Azure Deployment"
                }
            }
        };
    }

    // Belirli bir projeyi ID'ye göre getiren metot
    public Project GetProjectById(int id)
    {
        return GetProjects().FirstOrDefault(p => p.Id == id) ?? new Project();
    }

    // Ana sayfada gösterilecek öne çıkan projeleri getiren metot
    public List<Project> GetFeaturedProjects()
    {
        return GetProjects().Where(p => p.IsFeatured).ToList();
    }
} 