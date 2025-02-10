
namespace ToDoApi.Database
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
