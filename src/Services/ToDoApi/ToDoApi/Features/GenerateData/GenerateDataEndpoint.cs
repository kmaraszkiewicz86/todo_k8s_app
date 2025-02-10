using Carter;

namespace ToDoApi.Features.GenerateData
{
    public class GenerateDataEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/GenerateRandomData", (GenerateDataRequest request, IMediator mediator) =>
            {
                return mediator.Send(new GenerateDataCommand(request));
            });
        }
    }
}
