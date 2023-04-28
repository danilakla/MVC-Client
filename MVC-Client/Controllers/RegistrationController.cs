using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MVC_Client.DTO;
using MVC_Client.Models;
using MVC_Client.Services.Registration;
using System.Net.Http;

namespace MVC_Client.Controllers;
public class RegistrationController : Controller
{
    private readonly IRegistrationService _registrationService;

    public RegistrationController(IRegistrationService registrationService)
    {
        _registrationService = registrationService;
    }
  
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult University()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> University(CreateUniversityDTO createUniversityDTO)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View(createUniversityDTO);
            }


            await _registrationService.RegistrationUniversity(createUniversityDTO);
            return Redirect("/confirm/email");

        }
        catch (Exception)
        {
            return Redirect("/Feedback/Reject");

        }
    }




    public IActionResult RegistrationUser()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> RegistrationUser(RegistrationUserDTO registrationUserDTO)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return View(registrationUserDTO);
            }

            var tokens=await _registrationService.RegistrationUser(registrationUserDTO);
            if(tokens is null)
            {
                return Redirect("/confirm/email");

            }
            else
            {
                Response.Cookies.Append("access_token", tokens.AccessToken);
                Response.Cookies.Append("refresh_token", tokens.RefreshToken);
                return Redirect("/Profile");

            }

        }
        catch (Exception)
        {
            return Redirect("/Feedback/Reject");

            throw;
        }


    }




    [HttpGet("/confirm/email")]
    public IActionResult Confirm()
    {

        return View();
    }
}
