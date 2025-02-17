using FluentValidation;

namespace ToDoApi.Features.GenerateData
{
    public class GenerateDataCommandValidator : AbstractValidator<GenerateDataCommand>
    {
        public GenerateDataCommandValidator()
        {
            RuleFor(x => x.ItemLength).InclusiveBetween(1, 1_000_000);
        }
    }
}
