namespace MVC_Client.Services.Manager;

public interface IManagerService
{
    Task CreateFacultie(string FacultieName);
    Task<List<string>> GetFacultieList();
    Task<string> GenerateTokenTeacher();
    Task<string> GenerateTokenDean(string FacultieName);
    Task<int> GetFacultieIdByName(string name);

}
