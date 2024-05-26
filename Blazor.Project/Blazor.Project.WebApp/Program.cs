using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using Blazor.Project.WebApp;
using Blazor.Project.WebApp.Authentication.Services;
using Blazor.Project.WebApp.Doctor.Services;
using Blazor.Project.WebApp.Hospital.Services;
using Blazor.Project.WebApp.Shared.Services;
using Blazor.Project.WebApp.User.Services;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("API", options =>
{
    // options.BaseAddress = new Uri(builder.Configuration.GetValue<string>("profiles.http.environmentVariables.API_ENDPOINT")!);
    options.BaseAddress = new Uri("https://localhost:7215/");
}).AddHttpMessageHandler<AuthenticationHttpHandler>();

builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


builder.Services.AddScoped<AuthenticationHttpHandler>();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddScoped<IApiIntegrationService, ApiIntegrationService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IHospitalService, HospitalService>();
builder.Services.AddScoped<IUserService, UserService>();

await builder.Build().RunAsync();