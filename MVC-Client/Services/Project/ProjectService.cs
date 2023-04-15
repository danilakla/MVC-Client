using MVC_Client.Infrastructure;
using MVC_Client.Models;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using MVC_Client.DTO.Server;

namespace MVC_Client.Services.Project;

public class ProjectService : IProjectService
{
    private readonly HttpClient _httpClient;
    private readonly AuthorizationHttpContext _authorizationHttpContext;
    private readonly string ProfileApiHost;

    public ProjectService(HttpClient httpClient, IConfiguration configuration, AuthorizationHttpContext authorizationHttpContext)
    {
        _httpClient = httpClient;
        _authorizationHttpContext = authorizationHttpContext;
        ProfileApiHost = configuration["AppSettings:ApiHostProfile"];
    }
    public async Task AddProject(ProjectViewModel projectViewModel)
    {
        try
        {
            string uri = uri = API.Profile.AddProject(ProfileApiHost);

            var reqBody = new CreateProjectDTO
            {
Description= projectViewModel.Description,
Name= projectViewModel.Name,
NameUsingTech= projectViewModel.NameUsingTech,
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

    public async Task DeleteProject(int id)
    {
        try
        {
            string uri = uri = API.Profile.DeleteProject(ProfileApiHost, id);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationHttpContext.GetIdentityTokoken());


            var response = await _httpClient.DeleteAsync(uri);
            response.EnsureSuccessStatusCode();

        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<ProjectViewModel> GetProject(int id)
    {
        try
        {
            string uri = uri = API.Profile.GetProject(ProfileApiHost, id);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationHttpContext.GetIdentityTokoken());


            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var project = JsonSerializer.Deserialize<ProjectViewModel>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return project;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task UpdateProject(ProjectViewModel projectViewModel)
    {
        try
        {
            string uri = uri = API.Profile.UpdateProject(ProfileApiHost);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationHttpContext.GetIdentityTokoken());

            var stringContent = new StringContent(JsonSerializer.Serialize(projectViewModel), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(uri, stringContent);
            response.EnsureSuccessStatusCode();

        }
        catch (Exception)
        {

            throw;
        }
    }
}
