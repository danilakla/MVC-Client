using MVC_Client.DTO.Server;
using MVC_Client.Infrastructure;
using MVC_Client.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MVC_Client.Services.Skill;

public class SkillService : ISkillService
{

    private readonly HttpClient _httpClient;
    private readonly AuthorizationHttpContext _authorizationHttpContext;
    private readonly string ProfileApiHost;

    public SkillService(HttpClient httpClient, IConfiguration configuration, AuthorizationHttpContext authorizationHttpContext)
    {
        _httpClient = httpClient;
        _authorizationHttpContext = authorizationHttpContext;
        ProfileApiHost = configuration["AppSettings:ApiHostProfile"];
    }
    public async Task AddSkill(SkillViewModel skillViewModel)
    {
        try
        {
            string uri = uri = API.Profile.AddSkill(ProfileApiHost);

            var reqBody = new CreateSkillDto
            {
                Text = skillViewModel.Text,
            };
            var stringContent = new StringContent(JsonSerializer.Serialize(reqBody), System.Text.Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationHttpContext.GetIdentityTokoken());

            var response = await _httpClient.PostAsync(uri, stringContent);
            response.EnsureSuccessStatusCode();

        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task DeleteSkill(int id)
    {
        try
        {
            string uri = uri = API.Profile.DeleteSkill(ProfileApiHost, id);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationHttpContext.GetIdentityTokoken());


            var response = await _httpClient.DeleteAsync(uri);
            response.EnsureSuccessStatusCode();

        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<SkillViewModel> GetSkill(int id)
    {
        try
        {
            string uri = uri = API.Profile.GetSkill(ProfileApiHost, id);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationHttpContext.GetIdentityTokoken());


            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var skill = JsonSerializer.Deserialize<SkillViewModel>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return skill;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task UpdateSkill(SkillViewModel skillViewModel)
    {
        try
        {
            string uri = uri = API.Profile.UpdateSkill(ProfileApiHost);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationHttpContext.GetIdentityTokoken());

            var stringContent = new StringContent(JsonSerializer.Serialize(skillViewModel), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(uri, stringContent);
            response.EnsureSuccessStatusCode();

        }
        catch (Exception)
        {

            throw;
        }
    }
}




