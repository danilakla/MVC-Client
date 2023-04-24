using MVC_Client.Models.Chat;

namespace MVC_Client.Services.Chat;

public interface IFriendService
{
    Task<List<Friend>> GetFriends();
    Task AddFriend(int idNotification);

    Task DeleteFriend(string ConversationName);
}
