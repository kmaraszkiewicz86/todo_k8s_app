using System.Globalization;
using FluentResults;

namespace ToDoApi.Features.GetToDoItems
{
    public record GetToDoItemsQuery(int ItemCountOnPage, int PageNumber) : IRequest<Result<GetToDoItemsResponse[]>>
    {
    }
}
