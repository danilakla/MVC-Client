using MVC_Client.DTO.Server;

namespace MVC_Client.Services.Dean;

public interface IDeanService
{

    Task<List<ProfessionResDto>> GetProfessions();

    Task CreateGroup(GroupDTO groupDTO);



    Task CreateProfession(string Name);
    Task<string> GenerateTokenStudent(GroupDTO groupDTO);


}
