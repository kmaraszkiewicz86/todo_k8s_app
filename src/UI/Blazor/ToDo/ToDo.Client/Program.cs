using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Todo.Core.Extensions;
using Todo.Core.Settings;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

ToDoApiSettings apiSettings = builder.Configuration.GetSection("ToDoApiSettings")!.Get<ToDoApiSettings>()!;

builder.Services.AddHttpClientServices(apiSettings);

await builder.Build().RunAsync();