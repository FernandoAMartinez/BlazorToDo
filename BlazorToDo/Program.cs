using BlazorToDo;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using Blazored.LocalStorage;
using BlazorToDo.Repositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Configure custom services
ConfigureServices(builder.Services);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

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
}