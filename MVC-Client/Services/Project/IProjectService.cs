using MVC_Client.Models;

namespace MVC_Client.Services.Project;

public interface IProjectService
{
    Task<ProjectViewModel> GetProject(int id);
    Task DeleteProject(int id);
    Task AddProject(ProjectViewModel projectViewModel);

    Task UpdateProject(ProjectViewModel projectViewModel);
}
