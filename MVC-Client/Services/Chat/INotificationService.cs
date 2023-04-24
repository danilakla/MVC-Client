using MVC_Client.DTO.Server;
using MVC_Client.Models.Chat;

namespace MVC_Client.Services.Chat;

public interface INotificationService
{
    Task SendNotification(CreateNotficationDTO createNotificationDTO);
    Task<List<Notification>> GetNotifications();

    Task DeleteNotification(int id);
    Task<Notification> GetNotification(int id);

}
