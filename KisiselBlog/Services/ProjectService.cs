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
        if (string.IsNullOrEmpty(project.Title))
        {
            throw new ArgumentException("Proje başlığı boş olamaz.");
        }
        
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
        existingProject.Category = updatedProject.Category;
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
            Category = "web",
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

    public List<Project> GetFeaturedProjects()
    {
        return _projectRepository.GetFeaturedProjects();
    }
} 