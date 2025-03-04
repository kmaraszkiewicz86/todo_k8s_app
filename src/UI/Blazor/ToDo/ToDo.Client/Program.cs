using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Todo.Core.Extensions;
using Todo.Core.Settings;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

//todo: put it to config file
ToDoApiSettings? apiSettings = new ()
{
    BaseUrl = "http://localhost:5116/"
};

builder.Services.AddHttpClientServices(apiSettings);

await builder.Build().RunAsync();