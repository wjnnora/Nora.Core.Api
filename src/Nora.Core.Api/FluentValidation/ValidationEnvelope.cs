using FluentValidation.Results;
using FluentValidation;
using MediatR;

namespace Nora.Core.Api.FluentValidation;

public sealed class ValidationEnvelope<TRequest, TResponse>(IValidator<TRequest> validator) 
    where TRequest : IRequest<TResponse>
{
    private readonly IValidator<TRequest> _validator = validator;

    private ValidationResult _result;

    public bool HasRules() => _validator != null;

    public void Validate(TRequest request) => _result = _validator.Validate(request);

    public bool HasFailures() => _result != null && _result.Errors.Count != 0;

    public IEnumerable<ValidationFailure> GetFailures() => _result.Errors;
}