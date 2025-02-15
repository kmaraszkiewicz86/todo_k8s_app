using FluentValidation;

namespace ToDoApi.Features.GetToDoItems
{
    public class GetToDoItemsQueryValidator : AbstractValidator<GetToDoItemsQuery>
    {
        public GetToDoItemsQueryValidator()
        {
            RuleFor(x => x.PageNumber)
                .InclusiveBetween(1, 100000)
                .WithMessage("PageNumber must be between 1 and 100.");

            RuleFor(x => x.ItemCountOnPage)
                .InclusiveBetween(10, 150)
                .WithMessage("ItemCountOnPage must be between 10 and 150.");
        }
    }
}
