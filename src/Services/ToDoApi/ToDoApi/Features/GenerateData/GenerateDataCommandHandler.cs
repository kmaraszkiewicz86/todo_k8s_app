using ToDoApi.Features.GenerateData.Interfaces;

namespace ToDoApi.Features.GenerateData
{
    public record GenerateDataCommand(GenerateDataRequest Data) : IRequest<GenerateDataResult>;

    public record GenerateDataResult(bool IsSuccess);

    public class GenerateDataCommandHandler(IDataGeneratorService service) : IRequestHandler<GenerateDataCommand, GenerateDataResult>
    {
        public async Task<GenerateDataResult> Handle(GenerateDataCommand request, CancellationToken cancellationToken)
        {
            await service.GenerateDataAsync(request.Data);

            return new GenerateDataResult(false);
        }
    }
}
