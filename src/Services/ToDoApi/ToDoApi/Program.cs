using Carter;
using FluentValidation;
using ToDoApi.Extensions;

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

app.MapCarter();

app.Run();
