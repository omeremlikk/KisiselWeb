using KisiselBlog.Models;

namespace KisiselBlog.Repository;

public interface IProjectRepository
{
    Task<List<Project>> GetAllProjectsAsync();
    List<Project> GetAllProjects();
    Task<Project?> GetProjectByIdAsync(int id);
    Task<Project> AddProjectAsync(Project project);
    Task<Project> UpdateProjectAsync(Project project);
    Task DeleteProjectAsync(int id);
    List<Project> GetFeaturedProjects();
    Task<List<Project>> GetFeaturedProjectsAsync();
} 