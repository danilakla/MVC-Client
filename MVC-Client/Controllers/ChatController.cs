using Microsoft.AspNetCore.Mvc;
using MVC_Client.Services.Chat;

namespace MVC_Client.Controllers;
public class ChatController : Controller
{
    private readonly IFriendService _friendService;

    public ChatController(IFriendService friendService)
    {
        _friendService = friendService;
    }
    public async Task<IActionResult> Index()
    {
        try
        {
            var friends = await _friendService.GetFriends();
             return View(friends);
        }
        catch (Exception)
        {

            throw;
        }
  
    }
}
