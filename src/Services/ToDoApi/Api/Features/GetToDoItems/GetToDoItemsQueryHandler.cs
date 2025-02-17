using FluentResults;
using FluentValidation.Results;
using ToDoApi.Features.GetToDoItems.Interfaces;

namespace ToDoApi.Features.GetToDoItems
{
    public class GetToDoItemsQueryHandler(IGetToDoItemsService service, GetToDoItemsQueryValidator validator) : IRequestHandler<GetToDoItemsQuery, Result<GetToDoItemsResponse[]>>
    {
        public async Task<Result<GetToDoItemsResponse[]>> Handle(GetToDoItemsQuery request, CancellationToken cancellationToken)
        {
            ValidationResult result = validator.Validate(request);

            if (!result.IsValid)
            {
                return Result.Fail<GetToDoItemsResponse[]>(result.Errors.Select(e => e.ErrorMessage).ToList());
            }

            GetToDoItemsResponse[] items = await service.GetAllItemsAsync(request);

            return Result.Ok<GetToDoItemsResponse[]>(items);
        }
    }
}
