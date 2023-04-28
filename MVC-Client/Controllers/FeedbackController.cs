using Microsoft.AspNetCore.Mvc;

namespace MVC_Client.Controllers;
public class FeedbackController : Controller
{
    [HttpGet]
    public IActionResult Success()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Reject()
    {
        return View();
    }
}
