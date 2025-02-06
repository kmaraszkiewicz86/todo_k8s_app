using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ToDoDb>(opt => opt.UseInMemoryDatabase("ToDoList"));

var app = builder.Build();

app.MapGet("/", async (ToDoDb db) => await db.ToDoItems.ToArrayAsync());
app.MapGet("/{id}", async (int id, ToDoDb db) => await db.ToDoItems.FindAsync(id));
app.MapPost("/", async ([FromBody] ToDoItem item, ToDoDb db) =>
{
    await db.ToDoItems.AddAsync(item);
    await db.SaveChangesAsync();

    return Results.Created($"/{item.Id}", item);
});
app.MapDelete("/{id}", async (int id, ToDoDb db) =>
{
    var itemToDelete = await db.ToDoItems.FindAsync(id);

    if (itemToDelete is null)
        return Results.NotFound();

    db.ToDoItems.Remove(itemToDelete);
    await db.SaveChangesAsync();

    return Results.Ok();
});
app.MapPut("/{id}", async (int id, [FromBody] ToDoItem item, ToDoDb db) =>
{
    var itemToUpdate = await db.ToDoItems.FindAsync(id);

    if (itemToUpdate is null)
        return Results.NotFound();

    itemToUpdate.Name = item.Name;
    itemToUpdate.IsComplete = item.IsComplete;

    db.ToDoItems.Update(itemToUpdate);
    await db.SaveChangesAsync();

    return Results.Ok();
});

app.Run();
