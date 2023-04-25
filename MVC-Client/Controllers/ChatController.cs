using Microsoft.AspNetCore.Mvc;
using MVC_Client.Models.ViewModels;
using MVC_Client.Services.Chat;
using MVC_Client.Services.Group;

namespace MVC_Client.Controllers;
public class ChatController : Controller
{
    private readonly IFriendService _friendService;
    private readonly IGroupService _groupService;

    public ChatController(IFriendService friendService, IGroupService groupService)
    {
        _friendService = friendService;
        _groupService = groupService;
    }
    public async Task<IActionResult> Index()
    {
        try
        {
            var friends = await _friendService.GetFriends();
            var groups = await _groupService.GetGroups();

            return View(new ChatRoomViewModel { Friends=friends, Groups=groups});
        }
        catch (Exception)
        {

            throw;
        }
  
    }
}
