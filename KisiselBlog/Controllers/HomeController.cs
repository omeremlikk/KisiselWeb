using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KisiselBlog.Models;
using KisiselBlog.Repository;

namespace KisiselBlog.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProjectRepository _projectRepository;

    public HomeController(ILogger<HomeController> logger, IProjectRepository projectRepository)
    {
        _logger = logger;
        _projectRepository = projectRepository;
    }

    public async Task<IActionResult> Index()
    {
        // Ana sayfada yalnızca öne çıkan projeleri gösterelim
        var featuredProjects = await _projectRepository.GetFeaturedProjectsAsync();
        return View(featuredProjects);
    }

    public async Task<IActionResult> Portfolio()
    {
        // Portfolio sayfasında tüm projeleri gösterelim
        var allProjects = await _projectRepository.GetAllProjectsAsync();
        return View(allProjects);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
