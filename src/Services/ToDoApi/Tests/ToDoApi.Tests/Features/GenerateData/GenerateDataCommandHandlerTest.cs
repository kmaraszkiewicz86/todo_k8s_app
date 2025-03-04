using FluentResults;
using Shouldly;
using ToDoApi.Features.GenerateData;
using ToDoApi.Tests.Fixtures;

namespace ToDoApi.Tests.Features.GetToDoItems
{
    public class GenerateDataCommandHandlerTest
    {
        private readonly GenerateDataCommandHandlerFixture _fixture = new();

        [Fact]
        public async Task HandleAsync_WhenQueryIsValid_ReturnsSuccessResult()
        {
            // Arrange
            GenerateDataCommand query = new (1_000_000);

            GenerateDataCommandHandler handler = _fixture.GetServiceUnderTest();
            // Act
            Result result = await handler.Handle(query, CancellationToken.None);
            // Assert
            result.IsSuccess.ShouldBeTrue();
        }

        [Fact]
        public async Task HandleAsync_WhenQueryIsNotValid_ReturnsInvalidResult()
        {
            // Arrange
            GenerateDataCommand query = new (1_000_001);

            GenerateDataCommandHandler handler = _fixture.GetServiceUnderTest();
            // Act
            Result result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.IsSuccess.ShouldBeFalse();
        }
    }
}
