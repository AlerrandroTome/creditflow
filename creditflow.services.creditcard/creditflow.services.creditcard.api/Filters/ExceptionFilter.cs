using creditflow.services.creditcard.core.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace creditflow.services.creditcard.api.Filters
{
    public class ExceptionFilter : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            ProblemDetails result;
            switch (exception)
            {
                case CartaoNotFoundException cartaoNotFoundException:
                    result = new ProblemDetails
                    {
                        Status = (int)HttpStatusCode.BadRequest,
                        Type = cartaoNotFoundException.GetType().Name,
                        Title = "O Cartão Não foi encontrado.",
                        Detail = cartaoNotFoundException.Message,
                        Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}",
                    };
                    break;
                default:
                    result = new ProblemDetails
                    {
                        Status = (int)HttpStatusCode.InternalServerError,
                        Type = exception.GetType().Name,
                        Title = "Aconteceu um erro inesperado.",
                        Detail = exception.Message,
                        Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
                    };
                    break;
            }

            Console.WriteLine($"ErrorMessage: {exception.Message}. StackTracer: {exception.StackTrace}.");
            await httpContext.Response.WriteAsJsonAsync(result, cancellationToken: cancellationToken);
            return true;
        }
    }
}
