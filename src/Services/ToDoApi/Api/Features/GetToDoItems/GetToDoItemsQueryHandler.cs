using FluentResults;
using FluentValidation.Results;
using ToDoApi.Features.GetToDoItems.Interfaces;

namespace ToDoApi.Features.GetToDoItems
{
    public class GetToDoItemsQueryHandler(IGetToDoItemsService service, GetToDoItemsQueryValidator validator) : IRequestHandler<GetToDoItemsQuery, Result<GetToDoItemCollectionResponse>>
    {
        public async Task<Result<GetToDoItemCollectionResponse>> Handle(GetToDoItemsQuery request, CancellationToken cancellationToken)
        {
            ValidationResult result = validator.Validate(request);

            if (!result.IsValid)
            {
                return Result.Fail<GetToDoItemCollectionResponse>(result.Errors.Select(e => e.ErrorMessage).ToList());
            }

            GetToDoItemCollectionResponse items = await service.GetAllItemsAsync(request);

            return Result.Ok(items);
        }
    }
}
