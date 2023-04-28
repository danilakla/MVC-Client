using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Client.DTO;
using MVC_Client.Models;
using MVC_Client.Services.Skill;

namespace MVC_Client.Controllers;
[Authorize]

public class SkillController : Controller
{
    private readonly ISkillService _skillService;

    public SkillController(ISkillService skillService)
    {
        _skillService = skillService;
    }
    [HttpPost]

    public async Task<IActionResult> AddSkill(ProfileViewModel profileViewModel)
    {
        try
        {
            

            await _skillService.AddSkill(profileViewModel.AddNewSkill);

            return Redirect("/Feedback/Success");

        }
        catch (Exception)
        {

            return Redirect("/Feedback/Reject");
        }
     
    }

    [HttpPost]

    public async Task<IActionResult> DeleteSkill(int id)
    {
        try
        {
  await _skillService.DeleteSkill(id);

            return Redirect("/Feedback/Success");

        }
        catch (Exception)
        {

            return Redirect("/Feedback/Reject");
        }
      
    }
    [HttpGet]
    public async Task<IActionResult>  UpdateSkill(int id)
    {
        try
        {
        var skill=await _skillService.GetSkill(id);

        return View(skill);
        }
        catch (Exception)
        {
            return Redirect("/Feedback/Reject");

        }

    }
    [HttpPost]
    public async Task<IActionResult> UpdateSkill(SkillViewModel skillViewModel)
    {
        try
        {
           
       
   await _skillService.UpdateSkill(skillViewModel);
            return Redirect("/Feedback/Success");

        }
        catch (Exception)
        {

            return Redirect("/Feedback/Reject");
        }

    }

}
