using ToDoApi.Database;
using ToDoApi.Database.Entities;

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
