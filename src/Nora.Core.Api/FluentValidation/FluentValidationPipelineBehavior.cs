using FluentValidation;
using MediatR;

namespace Nora.Core.Api.FluentValidation;

public sealed class FluentValidationPipelineBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) 
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ValidationEnvelope<TRequest, TResponse> _envelope = new(validators.FirstOrDefault());

    public Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_envelope.HasRules())
            return next();

        _envelope.Validate(request);

        return _envelope.HasFailures() ?
            throw new ValidationException(_envelope.GetFailures()) :
            next();
    }
}
