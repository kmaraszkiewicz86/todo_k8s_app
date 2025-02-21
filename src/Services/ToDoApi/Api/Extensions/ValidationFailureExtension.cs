using FluentValidation.Results;

namespace ToDoApi.Extensions
{
    public static class ValidationFailureExtension
    {
        public static ICollection<string> ToErrorMessages(this List<ValidationFailure> errors)
        {
            if (errors is null || !errors.Any())
            {
                return [];
            }

            return [.. errors!.Select(e => e.ErrorMessage)];
        }
    }
}
