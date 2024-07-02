using creditflow.services.creditproposal.core.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace creditflow.services.creditproposal.api.Filters
{
    public class ExceptionFilter : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            ProblemDetails result;
            switch (exception)
            {
                case PropostaNotFoundException propostaNotFoundException:
                    result = new ProblemDetails
                    {
                        Status = (int)HttpStatusCode.BadRequest,
                        Type = propostaNotFoundException.GetType().Name,
                        Title = "A Proposta Não foi encontrado.",
                        Detail = propostaNotFoundException.Message,
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
