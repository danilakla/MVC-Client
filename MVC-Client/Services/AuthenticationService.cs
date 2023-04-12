using MVC_Client.DTO;
using MVC_Client.DTO.Server;
using MVC_Client.Infrastructure;
using MVC_Client.Models;
using System.Text.Json;

namespace MVC_Client.Services;

public class AuthenticationService : IAuthenticationService
{

    private readonly HttpClient _httpClient;
    private readonly string IdentityApiHost;

    public AuthenticationService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        IdentityApiHost = configuration["AppSettings:ApiHost"];
    }

    public async Task<JwtTokens> LoginUser(AuthDto userModel)
    {
        try
        {
            string uri = uri = API.Identity.AuthUser(IdentityApiHost);

            var reqBody = new UserModel
            {
                Email =userModel.Email,
                LastName="em",
                Name="em",
                Password=userModel.Password,
                };
            var stringContent = new StringContent(JsonSerializer.Serialize(reqBody), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, stringContent);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var tokens=JsonSerializer.Deserialize<JwtTokens>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return tokens;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
