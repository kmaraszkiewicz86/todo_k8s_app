using ToDoApi.Interfaces;

namespace ToDoApi.Features.GenerateData.Interfaces
{
    public interface IDataGeneratorService : IService
    {
        Task GenerateDataAsync(GenerateDataCommand request);
    }
}
