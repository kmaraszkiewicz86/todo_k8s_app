using Shouldly;
using ToDoApi.Features.GetToDoItems;
using ToDoApi.Tests.Fixtures;

namespace ToDoApi.Tests.Features.GetToDoItems
{
    public class GetToDoItemsQueryHandlerTests
    {
        private readonly GetToDoItemsQueryHandlerFixture _fixture = new();

        [Fact]
        public async Task HandleAsync_WhenQueryIsValid_ReturnsSuccessResult()
        {
            // Arrange
            var query = new GetToDoItemsQuery(10, 1);

            GetToDoItemsQueryHandler handler = _fixture.GetServiceUnderTest();
            // Act
            var result = await handler.Handle(query, CancellationToken.None);
            // Assert
            result.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task HandleAsync_WhenQueryIsNotValid_ReturnsInvalidResult()
        {
            // Arrange
            var query = new GetToDoItemsQuery(5, 1);

            GetToDoItemsQueryHandler handler = _fixture.GetServiceUnderTest();
            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.IsSuccess.ShouldBeFalse();
        }
    }
}
