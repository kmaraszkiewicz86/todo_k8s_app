using AutoFixture;
using ToDoApi.Features.GenerateData;
using ToDoApi.Features.GenerateData.Interfaces;
using ToDoApi.Features.GetToDoItems;
using ToDoApi.Features.GetToDoItems.Interfaces;

namespace ToDoApi.Tests.Fixtures
{
    public class GenerateDataCommandHandlerFixture : BaseFixture
    {
        public GenerateDataCommandHandler GetServiceUnderTest()
        {
            var service = this.Freeze<IDataGeneratorService>();
            var validator = new GenerateDataCommandValidator();

            var handler = new GenerateDataCommandHandler(service, validator);

            return handler;
        }
    }
}
