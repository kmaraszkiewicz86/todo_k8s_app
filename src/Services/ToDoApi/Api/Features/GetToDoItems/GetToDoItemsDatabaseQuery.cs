using Microsoft.EntityFrameworkCore;
using ToDoApi.Database;
using ToDoApi.Database.Entities;
using ToDoApi.Features.GetToDoItems.Interfaces;

namespace ToDoApi.Features.GetToDoItems
{
    public class GetToDoItemsDatabaseQuery(ToDoDbContext context): IGetToDoItemsDatabaseQuery
    {
        public async Task<ToDoItem[]> GetAllItemsAsync(GetToDoItemsQuery query)
            => await context.ToDoItems
                .OrderByDescending(i => i.CreatedAt)
                .Skip(query.ItemCountOnPage * query.PageNumber)
                .Take(query.ItemCountOnPage)
                .ToArrayAsync();
    }
}
