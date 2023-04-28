using Microsoft.AspNetCore.Mvc;
using MVC_Client.Models;
using MVC_Client.Services.Group;
using MVC_Client.Services.Manager;
using System.ComponentModel.DataAnnotations;

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
        try
        {

          

            var id = await _managerService.GetFacultieIdByName(chatGroupDto.FacultieName);
            await _groupService.CreateGroup(new()
            {
                Desription = chatGroupDto.Desription,
                FromWhom = "",
                RoomName = chatGroupDto.RoomName,
                SearchString = $"{id}_{(DateTime.Now.Year - chatGroupDto.NumberCourse)}_{chatGroupDto.NumberCourse}"
            });
            return Redirect("/Feedback/Success");

        }
        catch (Exception)
        {

            return Redirect("/Feedback/Reject");
        }

    }

    public class ChatGroupDto
    {
        [Required(ErrorMessage = "RoomName is required")]

        public string RoomName { get; set; }
        [Required(ErrorMessage = "Desription is required")]

        public string Desription { get; set; }
        [Required(ErrorMessage = "FacultieName is required")]

        public string FacultieName { get; set; }
        [Range(1, 12, ErrorMessage = "NumberGroup must be between 1 and 12")]

        public int NumberGroup { get; set; }
        [Range(1, 4, ErrorMessage = "NumberCourse must be between 1 and 4")]

        public int NumberCourse { get; set; }
    }
}
