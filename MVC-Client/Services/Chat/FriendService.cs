using MVC_Client.Infrastructure;
using MVC_Client.Models.Chat;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MVC_Client.Services.Chat;

public class FriendService : IFriendService
{
    private readonly HttpClient _httpClient;
    private readonly AuthorizationHttpContext _authorizationHttpContext;
    private readonly string ChatApiHost;

    public FriendService(HttpClient httpClient, IConfiguration configuration, AuthorizationHttpContext authorizationHttpContext)

    {

        _httpClient = httpClient;
        _authorizationHttpContext = authorizationHttpContext;
        ChatApiHost = configuration["AppSettings:ApiChat"];
    }
    public async Task AddFriend(int idNotification)
    {

        try
        {
            string uri = uri = API.Chat.AddFriend(ChatApiHost);


            var stringContent = new StringContent(JsonSerializer.Serialize(new { NotificationId = idNotification }), System.Text.Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationHttpContext.GetIdentityTokoken());

            var response = await _httpClient.PostAsync(uri, stringContent);
            response.EnsureSuccessStatusCode();

        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task DeleteFriend(string ConversationName)
    {
        try
        {
            string uri = uri = API.Chat.DeleteFriend(ChatApiHost, ConversationName);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationHttpContext.GetIdentityTokoken());
            var response = await _httpClient.DeleteAsync(uri);
            response.EnsureSuccessStatusCode();

        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<List<Friend>> GetFriends()
    {
        try
        {
            string uri = uri = API.Chat.GetFriends(ChatApiHost);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationHttpContext.GetIdentityTokoken());
            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var friends = JsonSerializer.Deserialize<List<Friend>>(jsonResponse, new JsonSerializerOptions
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
