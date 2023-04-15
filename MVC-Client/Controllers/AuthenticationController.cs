using Microsoft.AspNetCore.Mvc;
using MVC_Client.DTO;
using MVC_Client.DTO.Server;
using MVC_Client.Services.Authentication;

namespace MVC_Client.Controllers;
public class AuthenticationController : Controller
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(AuthDto addLoginUserDTO)
    {
        try
        {
            var tokens = await _authenticationService.LoginUser(addLoginUserDTO);
            Response.Cookies.Append("access_token", tokens.AccessToken);
            Response.Cookies.Append("refresh_token", tokens.RefreshToken);
            return Redirect("/Profile/Index");
        }
        catch (Exception)
        {
            return Redirect("/Preview");

            throw;
        }

   
    }
}
