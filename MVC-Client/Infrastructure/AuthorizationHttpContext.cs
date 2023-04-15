namespace MVC_Client.Infrastructure;

public class AuthorizationHttpContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthorizationHttpContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public string GetIdentityTokoken()
    {


        string token;
        _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("access_token", out token);



        return token;
    }
}
