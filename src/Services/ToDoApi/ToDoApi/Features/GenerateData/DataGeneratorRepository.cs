using ToDoApi.Database;
using ToDoApi.Database.Entities;
using ToDoApi.Features.GenerateData.Interfaces;

namespace ToDoApi.Features.GenerateData
{
    public class DataGeneratorRepository(ToDoDbContext context) : IDataGeneratorRepository
    {
        public async Task AddAsync(ToDoItem item)
        {
            await context.AddAsync(item);
        }
    }
}
