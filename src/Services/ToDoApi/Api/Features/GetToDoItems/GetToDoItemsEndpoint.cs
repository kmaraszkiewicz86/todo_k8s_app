using Carter;

namespace ToDoApi.Features.GetToDoItems
{
    public class GetToDoItemsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/GetToDoItems/{ItemCountOnPage}/{PageNumber}", async (int itemCountOnPage, int pageNumber, IMediator mediator)
                => await mediator.Send(new GetToDoItemsQuery(itemCountOnPage, pageNumber)));
        }
    }
}
