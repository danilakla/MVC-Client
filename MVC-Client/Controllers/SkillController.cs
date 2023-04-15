using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        await _skillService.AddSkill(profileViewModel.AddNewSkill);

        return Redirect("/Profile");
    }

    [HttpPost]

    public async Task<IActionResult> DeleteSkill(int id)
    {
        await _skillService.DeleteSkill(id);

        return Redirect("/Profile");
    }
    [HttpGet]
    public async Task<IActionResult>  UpdateSkill(int id)
    {
        var skill=await _skillService.GetSkill(id);

        return View(skill);
    }
    [HttpPost]
    public async Task<IActionResult> UpdateSkill(SkillViewModel skillViewModel)
    {
        await _skillService.UpdateSkill(skillViewModel);

        return Redirect("/Profile");
    }

}
