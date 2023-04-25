using MVC_Client.DTO.Server;
using MVC_Client.Models.Chat;

namespace MVC_Client.Services.Group;

public interface IGroupService
{

    Task AcceptInviteGroup(string room, string emailRoom);
    Task CreateGroup(CreateGroupDTO createGropDto);
    Task<List<Conversation>> GetGroups();
}
