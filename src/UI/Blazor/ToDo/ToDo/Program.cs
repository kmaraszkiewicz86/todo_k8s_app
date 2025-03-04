using Todo.Core.Extensions;
using Todo.Core.Settings;
using ToDo.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

ToDoApiSettings apiSettings = builder.Configuration.GetSection("ToDoApiSettings")!.Get<ToDoApiSettings>()!;

builder.Services.AddHttpClientServices(apiSettings);

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

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(ToDo.Client._Imports).Assembly);

app.Run();
