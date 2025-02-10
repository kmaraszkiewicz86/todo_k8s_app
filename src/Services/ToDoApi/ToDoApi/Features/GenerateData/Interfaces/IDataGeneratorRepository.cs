using ToDoApi.Database.Entities;
using ToDoApi.Interfaces;

namespace ToDoApi.Features.GenerateData.Interfaces
{
    public interface IDataGeneratorRepository : IRepository
    {
        Task AddAsync(ToDoItem item);
    }
}
