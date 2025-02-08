using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApi;
using ToDoApi.Database;

var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
});
builder.Services.AddValidatorsFromAssembly(assembly);

//builder.Services.AddCarter();

builder.Services.AddDbContext<ToDoDbContext>(opt => opt.UseSqlServer("ToDoList"));

var app = builder.Build();

app.Run();
