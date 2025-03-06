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
} 