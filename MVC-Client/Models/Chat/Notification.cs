namespace MVC_Client.Models.Chat;

public class Notification
{
    public int Id { get; set; }
    public string MessageText { get; set; } = string.Empty;
    public string RoomName { get; set; } = string.Empty;
    public string FromWhom { get; set; } = string.Empty;
}
