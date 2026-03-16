using portfolio_api.Models;
using portfolio_api.Data;

namespace portfolio_api.Services;

public class ProjectService
{
    private readonly AppDbContext _context;

    public ProjectService(AppDbContext context)
    {
        _context = context;
    }

    public Project Add(Project project)
    {
        _context.Projects.Add(project);
        _context.SaveChanges();

        return project;
    }

    public List<Project> GetAll()
    {
        if (_context.Projects == null) return new List<Project>();
        return _context.Projects.ToList();
    }

    public Project? GetById(int id)
    {
        if (_context.Projects == null) return null;
        return _context.Projects.FirstOrDefault(p => p.Id == id);
    }
}