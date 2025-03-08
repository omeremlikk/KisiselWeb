using KisiselBlog.Data;
using KisiselBlog.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace KisiselBlog.Repository;

public class ProjectRepository : IProjectRepository
{
    private readonly ApplicationDbContext _context;

    public ProjectRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Project>> GetAllProjectsAsync()
    {
        return await _context.Projects.OrderByDescending(p => p.Id).ToListAsync();
    }

    public async Task<Project?> GetProjectByIdAsync(int id)
    {
        return await _context.Projects.FindAsync(id);
    }

    public async Task<List<Project>> GetFeaturedProjectsAsync()
    {
        return await _context.Projects.Where(p => p.IsFeatured).ToListAsync();
    }

    public async Task<Project> AddProjectAsync(Project project)
    {
        // Features ve Technologies listesini JSON olarak kaydetmek için
        if (project.Features.Count > 0)
            project.FeaturesJson = JsonSerializer.Serialize(project.Features);
            
        if (project.Technologies.Count > 0)
            project.TechnologiesJson = JsonSerializer.Serialize(project.Technologies);

        _context.Projects.Add(project);
        await _context.SaveChangesAsync();
        return project;
    }

    public async Task<Project> UpdateProjectAsync(Project project)
    {
        // Features ve Technologies listesini JSON olarak güncellemek için
        if (project.Features.Count > 0)
            project.FeaturesJson = JsonSerializer.Serialize(project.Features);
            
        if (project.Technologies.Count > 0)
            project.TechnologiesJson = JsonSerializer.Serialize(project.Technologies);
            
        _context.Entry(project).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return project;
    }

    public async Task DeleteProjectAsync(int id)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project != null)
        {
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }
    }

    // GetAllProjects metodunu uygulayalım (senkron versiyon)
    public List<Project> GetAllProjects()
    {
        // Sadece veritabanında var olan sütunları sorgulayalım
        var projects = _context.Projects
            .Select(p => new Project {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                ShortDescription = p.ShortDescription,
                ImageUrl = p.ImageUrl,
                GifUrl = p.GifUrl,
                Category = p.Category,
                IsFeatured = p.IsFeatured,
                FeaturesJson = p.FeaturesJson,
                TechnologiesJson = p.TechnologiesJson
            })
            .ToList();
        
        // JSON dizelerini deserialize et
        foreach (var project in projects)
        {
            try
            {
                if (!string.IsNullOrEmpty(project.FeaturesJson))
                    project.Features = JsonSerializer.Deserialize<List<string>>(project.FeaturesJson);
                    
                if (!string.IsNullOrEmpty(project.TechnologiesJson))
                    project.Technologies = JsonSerializer.Deserialize<List<string>>(project.TechnologiesJson);
            }
            catch
            {
                // Hatalı JSON varsa boş liste ata
                project.Features = new List<string>();
                project.Technologies = new List<string>();
            }
        }
        
        return projects;
    }

    // GetFeaturedProjects metodunu uygulayalım (senkron versiyon)
    public List<Project> GetFeaturedProjects()
    {
        // Sadece veritabanında var olan sütunları sorgulayalım
        var projects = _context.Projects
            .Where(p => p.IsFeatured)
            .Select(p => new Project {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                ShortDescription = p.ShortDescription,
                ImageUrl = p.ImageUrl,
                GifUrl = p.GifUrl, 
                Category = p.Category,
                IsFeatured = p.IsFeatured,
                FeaturesJson = p.FeaturesJson,
                TechnologiesJson = p.TechnologiesJson
            })
            .ToList();
        
        // JSON dizilerini deserialize et
        foreach (var project in projects)
        {
            try
            {
                if (!string.IsNullOrEmpty(project.FeaturesJson))
                    project.Features = JsonSerializer.Deserialize<List<string>>(project.FeaturesJson);
                    
                if (!string.IsNullOrEmpty(project.TechnologiesJson))
                    project.Technologies = JsonSerializer.Deserialize<List<string>>(project.TechnologiesJson);
            }
            catch
            {
                // Hatalı JSON varsa boş liste ata
                project.Features = new List<string>();
                project.Technologies = new List<string>();
            }
        }
        
        return projects;
    }
} 