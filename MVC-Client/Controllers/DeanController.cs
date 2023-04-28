using Microsoft.AspNetCore.Mvc;
using MVC_Client.DTO;
using MVC_Client.DTO.Client;
using MVC_Client.DTO.Server;
using MVC_Client.Services.Dean;

namespace MVC_Client.Controllers;
public class DeanController : Controller
{
    private readonly IDeanService _deanService;

    public DeanController(IDeanService deanService)
    {
        _deanService = deanService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProfession(CreateProfessionDTO createProfessionDTO)
    {
        try
        {
            
            await _deanService.CreateProfession(createProfessionDTO.ProfessionName);

            return Redirect("/Feedback/Success");
        }
        catch (Exception)
        {
            return Redirect("/Feedback/Reject");

            throw;
        }
    }



    [HttpPost]
    public async Task<IActionResult> CreateGroup(GroupDTO   groupDTO)
    {
        try

        {

         
            await _deanService.CreateGroup(groupDTO);

            return Redirect("/Feedback/Success");
        }
        catch (Exception)
        {
            return Redirect("/Feedback/Reject");

            throw;
        }
    }


    [HttpPost]
    public async Task<IActionResult> CreateStudentToken(GroupDTO groupDTO)
    {
        try
        {
            
            var token= await _deanService.GenerateTokenStudent(groupDTO);

            return View(new  {Token=token });
        }
        catch (Exception)
        {

            return Redirect("/Feedback/Reject");
        }
    }
    public IActionResult Index()
    {
        return View();
    }
}
