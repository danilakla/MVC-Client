using MVC_Client.DTO;
using MVC_Client.DTO.Server;
using MVC_Client.Infrastructure;
using MVC_Client.Models;
using System.Text.Json;

namespace MVC_Client.Services;

public class RegistrationService : IRegistrationService
{
    private readonly HttpClient _httpClient;
    private readonly string  IdentityApiHost;

    public RegistrationService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        IdentityApiHost = configuration["AppSettings:ApiHost"];
    }


    public async  Task RegistrationUniversity(CreateUniversityDTO createUniversityDTO)
    {
        try
        {
            var uri = API.Identity.RegistrationUniversity(IdentityApiHost);
            var reqBody = new AddUniversityAndManager
            {
                University = new University { Address = createUniversityDTO.Address, Name = createUniversityDTO.NameOfUniversity },
                Email= createUniversityDTO.Email,
                Name= createUniversityDTO.Name,
                LastName=createUniversityDTO.LastName,
                Password=createUniversityDTO.Password,
                Role="Manager"
            
            };
            var stringContent = new StringContent(JsonSerializer.Serialize(reqBody), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, stringContent);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception e)
        {

            throw new BadHttpRequestException(e.Message);
        }
    

    }

    public async Task<JwtTokens> RegistrationUser(RegistrationUserDTO  registrationUserDTO)
    {
        try
        {
            string uri = "";
            if (registrationUserDTO.Role == "Student")
            {
                uri = API.Identity.RegistrationStudent(IdentityApiHost);
            }
            else
            {
                uri = API.Identity.RegistrationUser(IdentityApiHost);
            }

            var stringContent = new StringContent(JsonSerializer.Serialize(registrationUserDTO), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, stringContent);
            response.EnsureSuccessStatusCode();
            if (registrationUserDTO.Role == "Student") {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var tokens = JsonSerializer.Deserialize<JwtTokens>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return tokens;
            }
            else {
                return null;
                    
                    }
        }
        catch (Exception)
        {

            throw;
        }

 
    }
}
