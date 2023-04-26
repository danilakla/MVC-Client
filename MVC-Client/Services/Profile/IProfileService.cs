using MVC_Client.Models;
using MVC_Client.Models.ViewModels;

namespace MVC_Client.Services.Profile;

public interface IProfileService
{
    Task<ProfileManagerViewModel> GetProfile();
    Task UpdateProfile(UpdateProfileViewModel updateProfileViewModel);

}
