using MVC_Client.DTO;

namespace MVC_Client.Services;

public interface IRegistrationService
{
    Task RegistrationUniversity(CreateUniversityDTO createUniversityDTO);

    Task RegistrationUser(RegistrationUserDTO createUniversityDTO);

}
