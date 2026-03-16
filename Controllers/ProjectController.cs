using Microsoft.AspNetCore.Mvc;
using portfolio_api.Models;
using portfolio_api.Services;

namespace portfolio_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly ProjectService _projectService;

    public ProjectsController(ProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    public ActionResult<List<Project>> GetProjects()
    {
        return _projectService.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Project> GetProject(int id)
    {
        var project = _projectService.GetById(id);

        if (project == null)
        {
            return NotFound();
        }

        return project;
    }

    [HttpPost]
    public ActionResult<Project> AddProject(Project project)
    {
        var addedProject = _projectService.Add(project);
        return CreatedAtAction(nameof(GetProject), new { id = addedProject.Id }, addedProject);
    }
}