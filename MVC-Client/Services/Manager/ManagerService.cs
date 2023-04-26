using MVC_Client.Infrastructure;
using MVC_Client.Models.Chat;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MVC_Client.Services.Manager;

public class ManagerService : IManagerService
{

    private readonly HttpClient _httpClient;
    private readonly AuthorizationHttpContext _authorizationHttpContext;
    private readonly string UniversityApiHost;

    public ManagerService(HttpClient httpClient, IConfiguration configuration, AuthorizationHttpContext authorizationHttpContext)

    {

        _httpClient = httpClient;
        _authorizationHttpContext = authorizationHttpContext;
        UniversityApiHost = configuration["AppSettings:ApiUniversity"];
    }
    public async Task CreateFacultie(string FacultieName)
    {
        try
        {
            string uri = uri = API.University.CreateFacultie(UniversityApiHost);


            var stringContent = new StringContent(JsonSerializer.Serialize(new FacultieDto { FacultieName=FacultieName}), System.Text.Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationHttpContext.GetIdentityTokoken());

            var response = await _httpClient.PostAsync(uri, stringContent);
            response.EnsureSuccessStatusCode();

        }
        catch (Exception)
        {

            throw;
        }
    }
    public class FacultieDto
    {
        public string FacultieName { get; set; }
    }
    public async Task<string> GenerateTokenDean(string FacultieName)
    {
        try
        {
            string uri = uri = API.University.GenerateTokenDean(UniversityApiHost);


            var stringContent = new StringContent(JsonSerializer.Serialize(new {  FacultieName }), System.Text.Encoding.UTF8, "application/json");
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

    public async Task<string> GenerateTokenTeacher()
    {

        try
        {
            string uri = uri = API.University.GenerateTokenTeacher(UniversityApiHost);


            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationHttpContext.GetIdentityTokoken());

            var response = await _httpClient.PostAsync(uri, null);
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

    public async Task<List<string>> GetFacultieList()
    {
        try
        {
            string uri = uri = API.University.GetFaculties(UniversityApiHost);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationHttpContext.GetIdentityTokoken());
            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var faculties = JsonSerializer.Deserialize<List<string>>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return faculties;
        }
        catch (Exception)
        {

            throw;
        }
    }
    public class TokenDto
    {
        public string Token { get; set; }
    }
}
