using Microsoft.AspNetCore.Mvc;
using MVC_Client.Services.Group;
using MVC_Client.Services.Manager;

namespace MVC_Client.Controllers;
public class TeacherController : Controller
{
    private readonly IGroupService _groupService;
    private readonly IManagerService _managerService;

    public TeacherController(IGroupService groupService, IManagerService managerService)
    {
        _groupService = groupService;
        _managerService = managerService;
    }
    [HttpPost]
    public async Task<IActionResult> CreateChatGroup(ChatGroupDto chatGroupDto)
    {
        var id = await _managerService.GetFacultieIdByName(chatGroupDto.FacultieName);
        await _groupService.CreateGroup(new()
        {
            Desription = chatGroupDto.Desription,
            FromWhom = "",
            RoomName = chatGroupDto.RoomName,
            SearchString = $"{id}_{(DateTime.Now.Year- chatGroupDto.NumberCourse)}_{chatGroupDto.NumberCourse}"
        });
        return Redirect("/Profile/Index");
    }

    public class ChatGroupDto
    {
        public string RoomName { get; set; }
        public string Desription { get; set; }
        public string FacultieName { get; set; }
        public int NumberGroup { get; set; }
        public int NumberCourse { get; set; }
    }
}
