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

//todo: change to a client url
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
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
