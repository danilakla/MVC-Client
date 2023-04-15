using Microsoft.AspNetCore.Mvc;
using MVC_Client.Models;
using MVC_Client.Services.Project;
using MVC_Client.Services.Skill;

namespace MVC_Client.Controllers;
public class ProjectController : Controller
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService  projectService)
    {
        _projectService = projectService;
    }
    [HttpPost]

    public async Task<IActionResult> AddProject(ProfileViewModel profileViewModel)
    {
        await _projectService.AddProject(profileViewModel.AddNewProject);

        return Redirect("/Profile");
    }

    [HttpPost]

    public async Task<IActionResult> DeleteProject(int id)
    {
        await _projectService.DeleteProject(id);

        return Redirect("/Profile");
    }
    [HttpGet]
    public async Task<IActionResult> UpdateProject(int id)
    {
        var skill = await _projectService.GetProject(id);

        return View(skill);
    }
    [HttpPost]
    public async Task<IActionResult> UpdateProject(ProjectViewModel projectViewModel)
    {
        await _projectService.UpdateProject(projectViewModel);

        return Redirect("/Profile");
    }
}
