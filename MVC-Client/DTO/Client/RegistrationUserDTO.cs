using MVC_Client.Models;

namespace MVC_Client.DTO;

public class RegistrationUserDTO:UserModel
{
    public string AuthenticationToken { get; set; }
    public string Role { get; set; }

}
