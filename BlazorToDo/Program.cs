using BlazorToDo;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using Blazored.LocalStorage;
using BlazorToDo.Repositories;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorToDo.Providers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Configure custom services
ConfigureServices(builder.Services);

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.Services .AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7258") });
builder.Services.AddHttpClient("TodosAPI", client =>
{
    var api = Environment.GetEnvironmentVariable("API_ENDPOINT");
    //client.BaseAddress = new Uri("https://blazors-todo.herokuapp.com/");
    client.BaseAddress = new Uri(api);
}).AddHttpMessageHandler<AuthorizationMessageHandler>();

builder.Services.AddTransient<AuthorizationMessageHandler>();
builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("TodosAPI"));

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>();

await builder.Build().RunAsync();

static void ConfigureServices(IServiceCollection services)
{
    //Add MudBlazor Reference
    services.AddMudServices(config =>
    {
        config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopCenter;
        config.SnackbarConfiguration.ShowCloseIcon = true;
        config.SnackbarConfiguration.NewestOnTop = true;
    });  

    //Add LocalStorage Service
    services.AddBlazoredLocalStorage();

    services.AddScoped<ITaskRepository, TaskRepository>();
    services.AddScoped<ICommentRepository, CommentRepository>();
    services.AddScoped<IAuthRepository, AuthRepository>();
}
