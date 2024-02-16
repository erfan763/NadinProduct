using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Common;

public class MediatRValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<MediatRValidationBehavior<TRequest, TResponse>> _logger;
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public MediatRValidationBehavior(IEnumerable<IValidator<TRequest>> validators,
        ILogger<MediatRValidationBehavior<TRequest, TResponse>> logger)
    {
        _validators = validators;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any()) return await next();

        var context = new ValidationContext<TRequest>(request);

        var errors = _validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .Select(x => x.ErrorMessage)
            .Distinct()
            .ToArray();

        if (errors.Any())
        {
            _logger.LogError($"Validation failed for {typeof(TRequest).Name}: {string.Join(", ", errors)}");
            throw new BadRequestException(errors);
        }

        return await next();
    }
}