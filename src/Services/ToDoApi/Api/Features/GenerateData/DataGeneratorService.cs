using ToDoApi.Database;
using ToDoApi.Database.Entities;
using ToDoApi.Features.GenerateData.Helpers;
using ToDoApi.Features.GenerateData.Interfaces;

namespace ToDoApi.Features.GenerateData
{
    public class DataGeneratorService(
        IDataGeneratorRepository repository,
        IDataGeneratorDatabaseQuery databaseQuery,
        IUnitOfWork unitOfWork) : IDataGeneratorService
    {
        public async Task GenerateDataAsync(GenerateDataCommand request)
        {
            IEnumerable<ToDoItem> items = DataGeneratorHelper.GenerateToDoItems(request.ItemLength);

            foreach (ToDoItem item in items)
            {
                await FindAllTodoReferencesFromDb(item);
                await repository.AddAsync(item);
            }

            await unitOfWork.SaveChangesAsync();
        }

        private async Task FindAllTodoReferencesFromDb(ToDoItem item)
        {
            item.PriorityLevel = await databaseQuery.FindPriorityLevelAsync(item);
            item.Category = await databaseQuery.FindCategoryAsync(item);
            item.Status = await databaseQuery.FindStatusAsync(item);
            item.Tags = await databaseQuery.FindTagsAsync(item);
        }
    }
}
