using Microsoft.AspNetCore.Mvc;
using MVC_Client.Models.ViewModels;
using MVC_Client.Services.Dean;
using MVC_Client.Services.Manager;

namespace MVC_Client.Controllers;
public class ManagerController : Controller
{
    private readonly IManagerService _managerService;

    public ManagerController(IManagerService  managerService)
    {
        _managerService = managerService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFacultie(CreateFacultieViewModel createFacultieViewModel)
    {
        await _managerService.CreateFacultie(createFacultieViewModel.FacultieName);

        return Redirect("/Profile");
    }

    [HttpPost]
    public async Task<IActionResult> TeacherToken()
    {
       var token= await _managerService.GenerateTokenTeacher();

        return View(token);
    }

    [HttpPost]
    public async Task<IActionResult> DeanToken(CreateFacultieViewModel createFacultieViewModel)
    {
       var token= await _managerService.GenerateTokenDean(createFacultieViewModel.FacultieName);

        return View(token);
    }
}
