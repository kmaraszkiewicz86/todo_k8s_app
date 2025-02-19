using ToDoApi.Database;
using ToDoApi.Database.Entities;
using ToDoApi.Interfaces;

namespace ToDoApi.Features.GenerateData.Interfaces
{
    public interface IDataGeneratorDatabaseQuery : IQuery
    {
        Task<TodoCategory> FindCategoryAsync(ToDoItem item);
        Task<PriorityLevel> FindPriorityLevelAsync(ToDoItem item);
        Task<ToDoStatus> FindStatusAsync(ToDoItem item);
        Task<ICollection<Tag>> FindTagsAsync(ToDoItem item);
    }
}
