using Carter;
using ToDoApi.Database.Entities;
using ToDoApi.Interfaces;
using ToDoApi.Models.Requests;

namespace ToDoApi.Features.GenerateData
{
    public class GenerateDataEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/GenerateData", (ToDoItemRequest request, IMediator mediator) =>
            {
                return mediator.Send(new GenerateDataCommand(request));
            });
        }
    }
}
