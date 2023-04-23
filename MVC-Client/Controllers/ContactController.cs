using Microsoft.AspNetCore.Mvc;

namespace MVC_Client.Controllers;
public class ContactController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
