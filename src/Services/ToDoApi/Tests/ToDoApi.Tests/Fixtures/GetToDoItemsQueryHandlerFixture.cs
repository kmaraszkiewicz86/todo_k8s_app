using AutoFixture;
using ToDoApi.Features.GetToDoItems;
using ToDoApi.Features.GetToDoItems.Interfaces;

namespace ToDoApi.Tests.Fixtures
{
    public class GetToDoItemsQueryHandlerFixture : BaseFixture
    {
        public GetToDoItemsQueryHandler GetServiceUnderTest()
        {
            var service = this.Freeze<IGetToDoItemsService>();
            var validator = new GetToDoItemsQueryValidator();

            var handler = new GetToDoItemsQueryHandler(service, validator);

            return handler;
        }
    }
}
