using ToDoApi.Database;
using ToDoApi.Database.Entities;
using ToDoApi.Exceptions;
using ToDoApi.Features.GenerateData.Interfaces;

namespace ToDoApi.Features.GenerateData
{
    public class DataGeneratorDatabaseQuery(ToDoDbContext context) : IDataGeneratorDatabaseQuery
    {
        public async Task<ICollection<Tag>> FindTagsAsync(ToDoItem item)
        {
            HashSet<Tag> tags = new();

            foreach (Tag tag in item.Tags)
            {
                Tag? tagFromDb = await context.Tags.FindAsync(tag.Id);

                if (tagFromDb is not null)
                {
                    tags.Add(tagFromDb);
                }
            }

            return tags;
        }

        public async Task<ToDoStatus> FindStatusAsync(ToDoItem item)
        {
            ToDoStatus? toDoStatus = await context.ToDoStatuses.FindAsync(item.Status.Id);

            if (toDoStatus is not null)
            {
                return toDoStatus;
            }

            throw new NotFoundException("ToDo Status");
        }

        public async Task<TodoCategory> FindCategoryAsync(ToDoItem item)
        {
            TodoCategory? todoCategory = await context.TodoCategories.FindAsync(item.Status.Id);

            if (todoCategory is not null)
            {
                return todoCategory;
            }

            throw new NotFoundException("ToDo Category");
        }

        public async Task<PriorityLevel> FindPriorityLevelAsync(ToDoItem item)
        {
            PriorityLevel? priorityLevel = await context.PriorityLevels.FindAsync(item.Status.Id);

            if (priorityLevel is not null)
            {
                return priorityLevel;
            }

            throw new NotFoundException("ToDo Priority Level");
        }
    }
}
