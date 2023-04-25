namespace MVC_Client.Models.Chat;

public class Conversation
{
    public int Id { get; set; }
    public string ConversationName { get; set; } = string.Empty;
    public string RoomName { get; set; } = string.Empty;

    public bool IsGroup { get; set; }
}
