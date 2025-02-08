using ToDoApi.Interfaces;

namespace ToDoApi.Features.GenerateData
{
    public interface IDataGeneratorService : IService
    {
        void GenerateDataAsync();
    }
}
