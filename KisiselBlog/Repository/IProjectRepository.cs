using KisiselBlog.Models;

namespace KisiselBlog.Repository;

public interface IProjectRepository
{
    Task<List<Project>> GetAllProjectsAsync();
    Task<Project?> GetProjectByIdAsync(int id);
    Task<List<Project>> GetFeaturedProjectsAsync();
    Task<Project> AddProjectAsync(Project project);
    Task<Project> UpdateProjectAsync(Project project);
    Task DeleteProjectAsync(int id);
} 