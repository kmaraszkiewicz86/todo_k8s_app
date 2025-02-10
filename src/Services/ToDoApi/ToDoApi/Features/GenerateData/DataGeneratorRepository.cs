using ToDoApi.Database;
using ToDoApi.Database.Entities;
using ToDoApi.Features.GenerateData.Interfaces;

namespace ToDoApi.Features.GenerateData
{
    public class DataGeneratorRepository(ToDoDbContext context) : IDataGeneratorRepository
    {
        public Task AddAsync(ToDoItem item)
        {
            throw new NotImplementedException();
        }
    }
}
