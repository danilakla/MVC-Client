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
        try
        {
       
   await _projectService.AddProject(profileViewModel.AddNewProject);

            return Redirect("/Feedback/Success");

        }
        catch (Exception)
        {

            return Redirect("/Feedback/Reject");
        }
     
    }

    [HttpPost]

    public async Task<IActionResult> DeleteProject(int id)
    {
        try
        {
      await _projectService.DeleteProject(id);

            return Redirect("/Feedback/Success");

        }
        catch (Exception)
        {

            return Redirect("/Feedback/Reject");
        }
  
    }
    [HttpGet]
    public async Task<IActionResult> UpdateProject(int id)
    {
        try
        {
    var skill = await _projectService.GetProject(id);

        return View(skill);
        }
        catch (Exception)
        {

            return Redirect("/Feedback/Reject");
        }

    }
    [HttpPost]
    public async Task<IActionResult> UpdateProject(ProjectViewModel projectViewModel)
    {
        try
        {


         

            await _projectService.UpdateProject(projectViewModel);

            return Redirect("/Feedback/Success");

        }
        catch (Exception)
        {

            return Redirect("/Feedback/Reject");
        }
    
    }
}
