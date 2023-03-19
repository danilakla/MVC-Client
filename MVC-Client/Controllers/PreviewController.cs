using Microsoft.AspNetCore.Mvc;

namespace MVC_Client.Controllers;
public class PreviewController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
