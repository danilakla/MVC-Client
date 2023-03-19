using MVC_Client.Models;

namespace MVC_Client.DTO;

public class RegistrationUserDTO:UserModel
{
    public string Token { get; set; }
}
