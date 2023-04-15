using MVC_Client.Models;

namespace MVC_Client.Services.Profile;

public interface IProfileService
{
    Task<ProfileViewModel> GetProfile();
    Task UpdateProfile(UpdateProfileViewModel updateProfileViewModel);

}
