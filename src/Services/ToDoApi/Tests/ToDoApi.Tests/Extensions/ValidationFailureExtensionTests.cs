using AutoFixture;
using FluentValidation.Results;
using Shouldly;
using ToDoApi.Extensions;
using ToDoApi.Tests.Fixtures;

namespace ToDoApi.Tests.Extensions
{
    public class ValidationFailureExtensionTests
    {
        public static IEnumerable<object[]> ValidationFailuresData =>
            new List<object[]>
            {
                new object[] { null },
                new object[] { new List<ValidationFailure>() },
            };

        private readonly ValidationFailureExtensionFixture _fixture = new();

        [Theory]
        [MemberData(nameof(ValidationFailuresData))]
        public void ToErrorMessages_SchouldReturnEmptyArray_WhenErrorIsNullOrEmpty(List<ValidationFailure> data)
        {
            ICollection<string> errors = data.ToErrorMessages();

            errors.ShouldBeEmpty();
        }

        [Fact]
        public void ToErrorMessages_SchouldReturnStringArray_WhenErrorIsNotEmpty()
        {
            List<ValidationFailure> errorsData = [.. _fixture.CreateMany<ValidationFailure>(2)];

            ICollection<string> errors = errorsData.ToErrorMessages();

            errors.ShouldNotBeEmpty();
            errors.Count.ShouldBe(2);
        }
    }
}