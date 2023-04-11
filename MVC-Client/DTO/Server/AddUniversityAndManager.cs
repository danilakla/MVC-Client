namespace MVC_Client.DTO.Server;

public class AddUniversityAndManager
{

    public string Name { get; set; }

    public string LastName { get; set; }
    public string Email { get; set; }

    public string Password { get; set; }
    public University University { get; set; }
    public string Role { get; set; }
}

public class University
{
    public string Name { get; set; }
    public string Address { get; set; }
}
