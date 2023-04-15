namespace MVC_Client.DTO.Server;

public class GetProfileDTO
{


    public string Description { get; set; } = "Empty";
    public int UserId { get; set; }
    public byte[] Photo { get; set; }
    public string LastName { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }

    public string UniversityName { get; set; }
    public byte[] BackgroundProfile { get; set; }

    public List<GetProjectDto> Projects { get; set; }
    public List<GetSkillDto> Skills { get; set; }
}
