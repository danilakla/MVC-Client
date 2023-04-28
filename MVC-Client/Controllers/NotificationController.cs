using Microsoft.AspNetCore.Mvc;
using MVC_Client.Services.Chat;
using MVC_Client.Services.Group;

namespace MVC_Client.Controllers;
public class NotificationController : Controller
{
    private readonly INotificationService _notificationService;
    private readonly IFriendService _friendService;
    private readonly IGroupService _groupService;

    public NotificationController(INotificationService notificationService, IFriendService friendService, IGroupService groupService)
    {
        _notificationService = notificationService;
        _friendService = friendService;
        _groupService = groupService;
    }
    public async Task<IActionResult> Index()
    {
        try
        {
       var notifications=await _notificationService.GetNotifications();
        return View(notifications);
        }
        catch (Exception)
        {

            return Redirect("/Feedback/Reject");
        }

    }
    [Route("/notificaiton-get/{id:int}")]
    public async Task<IActionResult> Notification(int id)
    {
        try
        {
       var notification=await _notificationService.GetNotification(id);
        return View(notification);
        }
        catch (Exception)
        {

            return Redirect("/Feedback/Reject");
        }

    }

    [HttpPost("/notificaiton-delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _notificationService.DeleteNotification(id);
            return Redirect("/Feedback/Success");
        }
        catch (Exception)
        {

            return Redirect("/Feedback/Reject");
        }

    }


    [HttpPost("/accept-notification/{id}")]
    public async Task<IActionResult> Accept(int id)
    {
        try
        {
            await _friendService.AddFriend(id);
            await _notificationService.DeleteNotification(id);

            return Redirect("/Feedback/Success");
        }
        catch (Exception)
        {

            return Redirect("/Feedback/Reject");
        }

    }

    [HttpPost("/accept-notification-group")]
    public async Task<IActionResult> AcceptGroup(string roomName, string emailForRoom)
    {
        try
        {
            await _groupService.AcceptInviteGroup(roomName, emailForRoom);

            return Redirect("/Feedback/Success");
        }
        catch (Exception)
        {

            return Redirect("/Feedback/Reject");
        }

    }

}
