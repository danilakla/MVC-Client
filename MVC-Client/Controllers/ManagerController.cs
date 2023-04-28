using Microsoft.AspNetCore.Mvc;
using MVC_Client.DTO.Client;
using MVC_Client.Models.ViewModels;
using MVC_Client.Services.Dean;
using MVC_Client.Services.Manager;

namespace MVC_Client.Controllers;
public class ManagerController : Controller
{
    private readonly IManagerService _managerService;

    public ManagerController(IManagerService managerService)
    {
        _managerService = managerService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFacultie(CreateFacultieViewModel createFacultieViewModel)
    {
        try
        {
            
            await _managerService.CreateFacultie(createFacultieViewModel.FacultieName);

            return Redirect("/Feedback/Success");
        }
        catch (Exception)
        {
            return Redirect("/Feedback/Reject");

            throw;
        }

    }

    [HttpPost]
    public async Task<IActionResult> TeacherToken()
    {
        try
        {


            var token = await _managerService.GenerateTokenTeacher();

            return View(new { Token = token });
        }
        catch (Exception)
        {

            return Redirect("/Feedback/Reject");
        }

    }

    [HttpPost]
    public async Task<IActionResult> DeanToken(CreateFacultieViewModel createFacultieViewModel)
    {
        try
        {
          
            var token = await _managerService.GenerateTokenDean(createFacultieViewModel.FacultieName);

            return View(new { Token = token });
        }
        catch (Exception)
        {

            return Redirect("/Feedback/Reject");
        }

    }
}
