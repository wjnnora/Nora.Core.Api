using Microsoft.AspNetCore.Http;
using System.Net;

namespace Nora.Core.Api.Responses;

public sealed class FailureResponse
{
    private readonly HttpContext _context;

    public FailureResponse(
        HttpContext context,
        int statusCode = (int)HttpStatusCode.BadRequest)
    {
        _context = context;

        _context.Response.ContentType = "application/json";
        _context.Response.StatusCode = statusCode;
    }

    public async Task WriteAsync(string text) => await _context.Response.WriteAsync(text);
}