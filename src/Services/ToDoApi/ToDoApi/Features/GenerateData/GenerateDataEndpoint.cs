using Carter;

namespace ToDoApi.Features.GenerateData
{
    public class GenerateDataEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/GenerateRandomData", (GenerateDataCommand request, IMediator mediator) =>
            {
                return mediator.Send(request);
            });
        }
    }
}
