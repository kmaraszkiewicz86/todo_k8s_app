namespace ToDoApi.Exceptions
{
    public class NotFoundException(string key) : Exception($"{key} not found")
    {
    }
}
