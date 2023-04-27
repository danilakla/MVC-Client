using MVC_Client.DTO.Server;
using MVC_Client.Infrastructure;
using System.Net.Http.Headers;
using System.Text.Json;
using static MVC_Client.Services.Manager.ManagerService;

namespace MVC_Client.Services.Dean;

public class DeanService : IDeanService
{

    private readonly HttpClient _httpClient;
    private readonly AuthorizationHttpContext _authorizationHttpContext;
    private readonly string UniversityApiHost;

    public DeanService(HttpClient httpClient, IConfiguration configuration, AuthorizationHttpContext authorizationHttpContext)

    {

        _httpClient = httpClient;
        _authorizationHttpContext = authorizationHttpContext;
        UniversityApiHost = configuration["AppSettings:ApiUniversity"];
    }
    public async Task CreateGroup(GroupDTO groupDTO)
    {
        try
        {
            string uri = uri = API.University.CreateGroup(UniversityApiHost);


            var stringContent = new StringContent(JsonSerializer.Serialize(groupDTO), System.Text.Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationHttpContext.GetIdentityTokoken());

            var response = await _httpClient.PostAsync(uri, stringContent);
            response.EnsureSuccessStatusCode();

        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task CreateProfession(string Name)
    {
        try
        {
            string uri = uri = API.University.CreateProfession(UniversityApiHost);


            var stringContent = new StringContent(JsonSerializer.Serialize(new {Name}), System.Text.Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationHttpContext.GetIdentityTokoken());

            var response = await _httpClient.PostAsync(uri, stringContent);
            response.EnsureSuccessStatusCode();

        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<string> GenerateTokenStudent(GroupDTO groupDTO)
    {
        try
        {
            string uri = uri = API.University.GenerateTokenStudent(UniversityApiHost);


            var stringContent = new StringContent(JsonSerializer.Serialize(groupDTO), System.Text.Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationHttpContext.GetIdentityTokoken());

            var response = await _httpClient.PostAsync(uri, stringContent);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var token = JsonSerializer.Deserialize<TokenDto>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return token.Token;

        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<List<ProfessionResDto>> GetProfessions()
    {
        try
        {
            string uri = uri = API.University.GetProfessions(UniversityApiHost);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationHttpContext.GetIdentityTokoken());
            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var professions = JsonSerializer.Deserialize<List<ProfessionResDto>>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return professions;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
