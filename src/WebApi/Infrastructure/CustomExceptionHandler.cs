using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.WebApi.Resources;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Infrastructure;

/// <summary>
/// Custom Exception Handler
/// </summary>
public class CustomExceptionHandler : IExceptionHandler
{

    private readonly Dictionary<Type, Func<HttpContext, Exception, Task>> _exceptionHandler;
    /// <summary>
    /// Custom Exception Handler
    /// </summary>
    public CustomExceptionHandler()
    {
        _exceptionHandler = new()
        {
            {typeof(NotFoundException) , HandleNotFoundException },
            {typeof(ValidationException) , HandleValidationException },
        };
    }



    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var exceptionType = exception.GetType();
        if (_exceptionHandler.ContainsKey(exceptionType))
        {
            await _exceptionHandler[exceptionType].Invoke(httpContext, exception);
            return true;
        }
        return false;
    }


    private async Task HandleNotFoundException(HttpContext httpContext, Exception ex)
    {
        var exception = (NotFoundException)ex;
        httpContext.Response.StatusCode = StatusCodes.Status404NotFound;

        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails()
        {
            Status = StatusCodes.Status404NotFound,
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
            Title = Messages.NotFoundExceptionTitle,
            Detail = exception.Message
        });
    }


    private async Task HandleValidationException(HttpContext httpContext, Exception ex)
    {

        var exception = (ValidationException)ex;
        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        await httpContext.Response.WriteAsJsonAsync(new ValidationProblemDetails()
        {
            Status = StatusCodes.Status404NotFound,
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
            Title = Messages.ValidationExceptionTitle,
            Detail = exception.Message
        });
    }
}
