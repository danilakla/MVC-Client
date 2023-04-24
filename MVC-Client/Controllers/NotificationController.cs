using Microsoft.AspNetCore.Mvc;
using MVC_Client.Services.Chat;

namespace MVC_Client.Controllers;
public class NotificationController : Controller
{
    private readonly INotificationService _notificationService;
    private readonly IFriendService _friendService;

    public NotificationController(INotificationService notificationService, IFriendService friendService)
    {
        _notificationService = notificationService;
        _friendService = friendService;
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

            throw;
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

            throw;
        }
 
    }

    [HttpPost("/notificaiton-delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _notificationService.DeleteNotification(id);
           return Redirect("/Notification/Index");
        }
        catch (Exception)
        {

            throw;
        }

    }


    [HttpPost("/accept-notification/{id}")]
    public async Task<IActionResult> Accept(int id)
    {
        try
        {
            await _friendService.AddFriend(id);
            await _notificationService.DeleteNotification(id);

            return Redirect("/Notification/Index");
        }
        catch (Exception)
        {

            throw;
        }

    }

}
