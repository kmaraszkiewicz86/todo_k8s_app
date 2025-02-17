using ToDoApi.Database;
using ToDoApi.Database.Entities;
using ToDoApi.Features.GenerateData.Helpers;
using ToDoApi.Features.GenerateData.Interfaces;

namespace ToDoApi.Features.GenerateData
{
    public class DataGeneratorService(IDataGeneratorRepository repository, IUnitOfWork unitOfWork) : IDataGeneratorService
    {
        public async Task GenerateDataAsync(GenerateDataCommand request)
        {
            IEnumerable<ToDoItem> items = DataGeneratorHelper.GenerateToDoItems(request.ItemLength);

            foreach (ToDoItem item in items) 
            {
                await repository.AddAsync(item);
            }

            await unitOfWork.SaveChangesAsync();
        }
    }
}
