using ToDoApi.Database;
using ToDoApi.Database.Entities;
using ToDoApi.Features.GenerateData.Interfaces;
using ToDoApi.Helpers;

namespace ToDoApi.Features.GenerateData
{
    public class DataGeneratorService(IDataGeneratorRepository repository, IUnitOfWork unitOfWork) : IDataGeneratorService
    {
        public async Task GenerateDataAsync(GenerateDataRequest request)
        {
            IEnumerable<ToDoItem> items = FakeDataGenerator.GenerateToDoItems(request.ItemLength);

            foreach (ToDoItem item in items) 
            {
                await repository.AddAsync(item);
            }

            await unitOfWork.SaveChangesAsync();
        }
    }
}
