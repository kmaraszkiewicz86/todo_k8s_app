using ToDoApi.Models.Requests;

namespace ToDoApi.Features.GenerateData
{
    public record GenerateDataCommand(ToDoItemRequest request) : IRequest<GenerateDataResult>;

    public record GenerateDataResult(bool IsSuccess);

    public class GenerateDataCommandHandler(IDataGeneratorService service) : IRequestHandler<GenerateDataCommand, GenerateDataResult>
    {
        public Task<GenerateDataResult> Handle(GenerateDataCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GenerateDataResult(false));
        }
    }
}
