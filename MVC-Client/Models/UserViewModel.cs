namespace MVC_Client.Models;

public class UserViewModel
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
}
