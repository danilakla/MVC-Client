using Microsoft.AspNetCore.Mvc;
using MVC_Client.DTO;

namespace MVC_Client.Controllers;
public class AuthenticationController : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(AddLoginUserDTO addLoginUserDTO)
    {
        Response.Cookies.Append("access_token", $"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiZGFueSIsImp0aSI6ImNiMWNjMjU0LTlhNTAtNGY0Ny04Mzg5LWU5MDc1MDU0MDUxYiIsImV4cCI6MTY4MjgzMDQ4NX0.z3_0aKiAzimYlby3ZUA85V0a6umbjTUkIUlkoojd8OM");

        return Redirect("/Home/Index");
    }
}
