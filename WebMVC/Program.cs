using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using WebMvc.Infrastructure;
using WebMvc.Models;
using WebMvc.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllersWithViews();
// Add services to the container.
builder.Services.AddRazorPages();

//Adding Interfaces
builder.Services.AddSingleton<IHttpClient, CustomHttpClientcs>();
builder.Services.AddTransient<IEventCatalogService, EventCatalogService>();
builder.Services.AddTransient<IIdentiyService<ApplicationUser>, IdentityService>();

var identityUrl = configuration["IdentityUrl"];
var callbackUrl = configuration["CallBackUrl"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
    {
        options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.Authority = identityUrl.ToString();
        options.SignedOutRedirectUri = callbackUrl.ToString();
        options.ClientId = "mvc";
        options.ClientSecret = "secret";
        options.RequireHttpsMetadata = false;
        options.SaveTokens = true;
        options.ResponseType = "code id_token";
        options.GetClaimsFromUserInfoEndpoint = true;
        options.Scope.Add("openid");
        options.Scope.Add("profile");
        options.Scope.Add("order");
        options.Scope.Add("basket");
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            {
            NameClaimType = "name",
            RoleClaimType = "role"
            };
    }

    );


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

//app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=EventCatalog}/{action=Index}");

app.Run();
