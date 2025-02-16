using FluentResults;
using FluentValidation.Results;
using ToDoApi.Extensions;
using ToDoApi.Features.GenerateData.Interfaces;

namespace ToDoApi.Features.GenerateData
{
    public record GenerateDataCommand(int ItemLength) : IRequest<Result>;

    public class GenerateDataCommandHandler(IDataGeneratorService service, GenerateDataCommandValidator validator) : IRequestHandler<GenerateDataCommand, Result>
    {
        public async Task<Result> Handle(GenerateDataCommand request, CancellationToken cancellationToken)
        {
            ValidationResult result = validator.Validate(request);

            if (!result.IsValid)
            {
                return Result.Fail(result.Errors.ToErrorMessages());
            }

            await service.GenerateDataAsync(request);

            return Result.Ok();
        }
    }
}
