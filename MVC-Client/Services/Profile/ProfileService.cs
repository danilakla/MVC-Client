using MVC_Client.DTO.Server;
using MVC_Client.Infrastructure;
using MVC_Client.Models;
using MVC_Client.Models.ViewModels;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace MVC_Client.Services.Profile;

public class ProfileService : IProfileService
{
    private readonly HttpClient _httpClient;
    private readonly AuthorizationHttpContext _authorizationHttpContext;
    private readonly string ProfileApiHost;

    public ProfileService(HttpClient httpClient, IConfiguration configuration, AuthorizationHttpContext authorizationHttpContext)

    {

        _httpClient = httpClient;
        _authorizationHttpContext = authorizationHttpContext;
        ProfileApiHost = configuration["AppSettings:ApiHostProfile"];
    }
    public async Task< ProfileManagerViewModel> GetProfile()
    {
        try
        {
            string uri = uri = API.Profile.GetProfile(ProfileApiHost);


            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationHttpContext.GetIdentityTokoken());
            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var profileJson = JsonSerializer.Deserialize<GetProfileDTO>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var profile = new  ProfileManagerViewModel
            {
                
                ProjectViewModels = profileJson.Projects,
                SkillViewModels = profileJson.Skills,
                UserViewModel = new UserViewModel
                {
                    BackgroundProfile = profileJson.BackgroundProfile,
                    Description = profileJson.Description,
                    Email = profileJson.Email,
                    LastName = profileJson.LastName,
                    Name = profileJson.Name,
                    Photo = profileJson.Photo,
                    UniversityName = profileJson.UniversityName,

                }
            };
            return profile;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task UpdateProfile(UpdateProfileViewModel updateProfileViewModel)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationHttpContext.GetIdentityTokoken());

            if (updateProfileViewModel.Icon!= null)
            {

                var uri = API.Profile.UpdateIconProfile(ProfileApiHost);

                await using var stream = updateProfileViewModel.Icon.OpenReadStream();
                using var request = new HttpRequestMessage(HttpMethod.Put, uri);
                using var content = new MultipartFormDataContent
    {
        { new StreamContent(stream), "photo", updateProfileViewModel.Icon.FileName }
    };


                request.Content = content;

                var res = await _httpClient.SendAsync(request);

            }

            if (updateProfileViewModel.Bg != null)
            {

                var uri1 = API.Profile.UpdateBgProfile(ProfileApiHost);

                await using var stream1 = updateProfileViewModel.Bg.OpenReadStream();
                using var request1 = new HttpRequestMessage(HttpMethod.Put, uri1);
                using var content1 = new MultipartFormDataContent
    {
        { new StreamContent(stream1), "photo", updateProfileViewModel.Bg.FileName }
    };


                request1.Content = content1;

                var res1 = await _httpClient.SendAsync(request1);
            }
        }

        catch (Exception)
        {

            throw;
        }
    }
}
