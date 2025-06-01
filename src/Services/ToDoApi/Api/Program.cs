using Carter;
using FluentValidation;
using ToDoApi.Extensions;
using ToDoApi.Middlewares;
using ToDoApi.Settings;

var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;

var frontendSettings = builder.Configuration.GetSection(nameof(FrontendSettings)).Get<FrontendSettings>()!;

builder.Services
    .AddDatabaseContext(builder.Configuration)
    .AddQueries()
    .AddRepositories()
    .AddServices();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontendSettings.FrontendHosts)
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
});

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();

var app = builder.Build();

app.UseCors();

app.UseMiddleware<ExceptionMiddleware>();
app.MapCarter();

app.Run();
