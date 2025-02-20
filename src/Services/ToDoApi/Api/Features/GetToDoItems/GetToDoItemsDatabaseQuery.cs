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
                .Include(i => i.PriorityLevel)
                .Include(i => i.Category)
                .Include(i => i.Status)
                .Include(i => i.Tags)
                .OrderByDescending(i => i.CreatedAt)
                .Skip(query.ItemCountOnPage * query.PageNumber)
                .Take(query.ItemCountOnPage)
                .ToArrayAsync();
    }
}
