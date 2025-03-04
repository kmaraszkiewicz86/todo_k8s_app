using FluentValidation.Results;

namespace ToDoApi.Tests.Fixtures
{
    public class ValidationFailureExtensionFixture : BaseFixture
    {
        public ValidationFailureExtensionFixture()
        {
            this.Customize<ValidationFailure>(c => c.With(v => v.ErrorMessage, "Test message"));
        }
    }
}
