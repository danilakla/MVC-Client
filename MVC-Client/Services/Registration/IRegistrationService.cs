using MVC_Client.DTO;
using MVC_Client.Models;

namespace MVC_Client.Services.Registration;

public interface IRegistrationService
{
    Task RegistrationUniversity(CreateUniversityDTO createUniversityDTO);

    Task<JwtTokens> RegistrationUser(RegistrationUserDTO createUniversityDTO);

}
