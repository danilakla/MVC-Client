using MVC_Client.Models.Chat;

namespace MVC_Client.Models.ViewModels;

public class ChatRoomViewModel
{
    public List<Friend>  Friends{ get; set; }
    public List<Conversation>  Groups{ get; set; }
}
