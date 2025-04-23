using FluentValidation;
using Microsoft.AspNetCore.Http;
using Nora.Core.Api.Responses;
using System.Text.Json;

namespace Nora.Core.Api.FluentValidation;

public sealed class FailureValidationMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            var response = new FailureResponse(context);

            var text = JsonSerializer.Serialize(GetErrorMessages(ex));

            await response.WriteAsync(text);
        }
    }

    private static IEnumerable<string> GetErrorMessages(ValidationException exception) => exception.Errors.Select(error => error.ErrorMessage);
}