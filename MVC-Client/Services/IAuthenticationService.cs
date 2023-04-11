using MVC_Client.DTO.Server;
using MVC_Client.Models;

namespace MVC_Client.Services;

public interface IAuthenticationService
{
   Task<JwtTokens> LoginUser(AuthDto userModel);
}
