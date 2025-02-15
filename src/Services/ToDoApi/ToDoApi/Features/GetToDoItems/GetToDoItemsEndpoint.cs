using Carter;
using Microsoft.AspNetCore.Mvc;

namespace ToDoApi.Features.GetToDoItems
{
    public class GetToDoItemsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/GenerateRandomData/{ItemCountOnPage}/{PageNumber}", async ([FromQuery] GetToDoItemsQuery reqesut, IMediator mediator)
                => await mediator.Send(reqesut));
        }
    }
}
