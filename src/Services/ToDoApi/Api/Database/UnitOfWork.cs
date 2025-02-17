namespace ToDoApi.Database
{
    public class UnitOfWork(ToDoDbContext context) : IUnitOfWork
    {
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
