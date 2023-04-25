using MVC_Client.DTO.Server;
using MVC_Client.Infrastructure;
using MVC_Client.Models.Chat;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MVC_Client.Services.Group;

public class GroupService : IGroupService
{
    private readonly HttpClient _httpClient;
    private readonly AuthorizationHttpContext _authorizationHttpContext;
    private readonly string ChatApiHost;

    public GroupService(HttpClient httpClient, IConfiguration configuration, AuthorizationHttpContext authorizationHttpContext)

    {

        _httpClient = httpClient;
        _authorizationHttpContext = authorizationHttpContext;
        ChatApiHost = configuration["AppSettings:ApiChat"];
    }
    public async Task AcceptInviteGroup(string room, string emailRoom)
    {
        try
        {
            string uri = uri = API.Chat.AcceptInviteGroup(ChatApiHost,room, emailRoom);


            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationHttpContext.GetIdentityTokoken());

            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task CreateGroup(CreateGroupDTO createGropDto)
    {
        try
        {
            string uri = uri = API.Chat.CreateGroup(ChatApiHost);


            var stringContent = new StringContent(JsonSerializer.Serialize(createGropDto), System.Text.Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationHttpContext.GetIdentityTokoken());

            var response = await _httpClient.PostAsync(uri, stringContent);
            response.EnsureSuccessStatusCode();

        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<List<Conversation>> GetGroups()
    {
        try
        {
            string uri = uri = API.Chat.GetGroups(ChatApiHost);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationHttpContext.GetIdentityTokoken());
            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var friends = JsonSerializer.Deserialize<List<Conversation>>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return friends;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
