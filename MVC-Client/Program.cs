using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MVC_Client.Controllers;
using MVC_Client.Infrastructure;
using MVC_Client.Services.Authentication;
using MVC_Client.Services.Chat;
using MVC_Client.Services.Dean;
using MVC_Client.Services.Group;
using MVC_Client.Services.Manager;
using MVC_Client.Services.Profile;
using MVC_Client.Services.Project;
using MVC_Client.Services.Registration;
using MVC_Client.Services.Skill;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
int coun = 0;
// Add services to the container.

builder.Services.AddScoped<IRegistrationService, RegistrationService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IFriendService, FriendService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IManagerService, ManagerService>();
builder.Services.AddScoped<IDeanService,  DeanService>();


builder.Services.AddHttpClient<RegistrationController>().AddHttpMessageHandler<AuthorizationDelegatingHandler>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<AuthorizationDelegatingHandler>();
builder.Services.AddTransient<AuthorizationHttpContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {

        ValidateIssuerSigningKey = false,
        ValidateIssuer = false,
        ValidateAudience = false,
        RequireExpirationTime = true,
        ValidateLifetime = true,
        LifetimeValidator = CustomLifetimeValidator,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AppSettings:Token"]))
    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.Use(async (context, next) =>
{
    if (string.IsNullOrEmpty(context.Request.Headers.Authorization))
    {
 string token;
    context.Request.Cookies.TryGetValue("access_token",out token);

       
        context.Request.Headers.Authorization = "Bearer "+token;
    }
   
    await next.Invoke();
});
app.UseAuthentication();
app.UseStatusCodePages(async context =>
{
    var response = context.HttpContext.Response;

    if ((response.StatusCode == (int)HttpStatusCode.Unauthorized ||
            response.StatusCode == (int)HttpStatusCode.Forbidden)&& coun == 0)
    { 
      
            //redirect to refre token;
            coun++; 
       // context.HttpContext.Response.Cookies.Append("access_token", $"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiZGFueSIsImp0aSI6ImNiMWNjMjU0LTlhNTAtNGY0Ny04Mzg5LWU5MDc1MDU0MDUxYiIsImV4cCI6MTY4MjgzMDQ4NX0.z3_0aKiAzimYlby3ZUA85V0a6umbjTUkIUlkoojd8OM");

        //if good so redirect to home if bad

        response.Redirect("/Profile/Index");
    }
    else {
        coun++;
        response.Redirect("/Preview/Index");
    }


});

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

 bool CustomLifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken tokenToValidate, TokenValidationParameters @param)
{
    if (expires != null)
    {
        return expires > DateTime.UtcNow;
    }
    return false;

}