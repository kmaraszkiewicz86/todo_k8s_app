using Carter;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Database;
using ToDoApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;

builder.Services
    .AddDatabaseContext(builder.Configuration)
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
