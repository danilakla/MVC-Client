using MVC_Client.Models;

namespace MVC_Client.Services.Skill;

public interface ISkillService
{

    Task<SkillViewModel> GetSkill(int id);
    Task DeleteSkill(int id);
    Task AddSkill(SkillViewModel skillViewModel);

    Task UpdateSkill(SkillViewModel skillViewModel);



}
