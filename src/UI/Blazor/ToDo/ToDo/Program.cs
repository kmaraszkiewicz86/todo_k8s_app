using ToDo.Components;
using ToDo.Services;
using ToDo.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

ToDoApiSettings apiSettings = builder.Configuration.GetSection("ToDoApiSettings")!.Get<ToDoApiSettings>()!;

builder.Services.AddHttpClient<IToDoHttpService, ToDoHttpService>(client =>
{
    client.BaseAddress = new Uri(apiSettings.BaseUrl);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(ToDo.Client._Imports).Assembly);

app.Run();
