using MVC_Client.DTO.Client;

namespace MVC_Client.Models.ViewModels;

public class ProfileManagerViewModel: ProfileViewModel
{
    public string FacultieName { get; set; }
    public int NumberCourse { get; set; }
    public int NumberGroup { get; set; }
    public string ProfessionName { get; set; }
    public string Name { get; set; }


    public string Desription { get; set; }

    public string RoomName { get; set; }
}
