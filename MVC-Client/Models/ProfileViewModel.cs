using MVC_Client.DTO.Server;

namespace MVC_Client.Models;

public class ProfileViewModel
{
    public UserViewModel UserViewModel { get; set; }

    public UpdateProfileViewModel  UpdateProfileViewModel { get; set; }

    public List<GetSkillDto> SkillViewModels{ get; set; }
    public List<GetProjectDto> ProjectViewModels  { get; set; }
    public  SkillViewModel AddNewSkill{ get; set; }
    public  ProjectViewModel AddNewProject { get; set; }

}
