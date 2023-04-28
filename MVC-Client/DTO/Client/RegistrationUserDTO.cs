using MVC_Client.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC_Client.DTO;

public class RegistrationUserDTO:UserModel
{
    [Required(ErrorMessage = "AuthenticationToken is required")]

    public string AuthenticationToken { get; set; }
    [Required(ErrorMessage = "Role is required")]

    public string Role { get; set; }

}
