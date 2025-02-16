using Carter;
using FluentValidation;
using ToDoApi.Extensions;
using ToDoApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;

builder.Services
    .AddDatabaseContext(builder.Configuration)
    .AddQueries()
    .AddRepositories()
    .AddServices();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
});

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.MapCarter();

app.Run();
