using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace creditflow.services.client.api.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                List<IEnumerable<string>?> errors = context.ModelState.Where(w => w.Value?.Errors.Count > 0)
                                              .Select(w => w.Value?.Errors.Select(w => w.ErrorMessage))
                                              .ToList();

                context.Result = new BadRequestObjectResult(new 
                {
                    Error = string.Concat(errors)
                });

                return;
            }

            await next();
        }
    }
}
