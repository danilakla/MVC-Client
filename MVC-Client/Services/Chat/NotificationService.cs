using MVC_Client.DTO.Server;
using MVC_Client.Infrastructure;
using MVC_Client.Models.Chat;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;

namespace MVC_Client.Services.Chat;

public class NotificationService : INotificationService
{
    private readonly HttpClient _httpClient;
    private readonly AuthorizationHttpContext _authorizationHttpContext;
    private readonly string ChatApiHost;

    public NotificationService(HttpClient httpClient, IConfiguration configuration, AuthorizationHttpContext authorizationHttpContext)

    {

        _httpClient = httpClient;
        _authorizationHttpContext = authorizationHttpContext;
        ChatApiHost = configuration["AppSettings:ApiChat"];
    }
    public async Task DeleteNotification(int id)
    {
        try
        {
            string uri = uri = API.Chat.DeleteNotification(ChatApiHost, id);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationHttpContext.GetIdentityTokoken());
            var response = await _httpClient.DeleteAsync(uri);
            response.EnsureSuccessStatusCode();



        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<Notification> GetNotification(int id)
    {
        try
        {
            string uri = uri = API.Chat.GetNotification(ChatApiHost,id);


            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationHttpContext.GetIdentityTokoken());

            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();


            var jsonResponse = await response.Content.ReadAsStringAsync();
            var notifications = JsonSerializer.Deserialize<Notification>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return notifications;

        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<List<Notification>> GetNotifications()
    {
        try
        {
            string uri = uri = API.Chat.GetNotification(ChatApiHost);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationHttpContext.GetIdentityTokoken());
            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var notifications = JsonSerializer.Deserialize<List<Notification>>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return notifications;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task SendNotification(CreateNotficationDTO createNotificationDTO)
    {
        try
        {
            createNotificationDTO.FromWhom = "";
            string uri = uri = API.Chat.SendNotification(ChatApiHost);


            var stringContent = new StringContent(JsonSerializer.Serialize(createNotificationDTO), System.Text.Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authorizationHttpContext.GetIdentityTokoken());

            var response = await _httpClient.PostAsync(uri, stringContent);
            response.EnsureSuccessStatusCode();

        }
        catch (Exception)
        {

            throw;
        }

    }
}
