using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Client.Models;
using MVC_Client.Models.ViewModels;
using MVC_Client.Services.Profile;

namespace MVC_Client.Controllers;
[Authorize]

public class ProfileController : Controller
{
    private readonly IProfileService _profileService;

    public ProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }
    public async Task <IActionResult>Index()
    {
        try
        {
          
            var profile =await _profileService.GetProfile();



        return View(profile );
        }
        catch (Exception)
        {

            throw;
        }
       
    }
    [HttpPost]
    public async Task<IActionResult> UpdateProfile(ProfileViewModel profileViewModel)
    {
        try
        {

            await _profileService.UpdateProfile(profileViewModel.UpdateProfileViewModel);


            return Redirect("/Profile");
        }
        catch (Exception)
        {

            throw;
        }

    }




}
