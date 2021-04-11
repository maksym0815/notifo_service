// ==========================================================================
//  Notifo.io
// ==========================================================================
//  Copyright (c) Sebastian Stehle
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Notifo.Areas.Api;
using Squidex.Log;

namespace Notifo.Pipeline
{
    public sealed class ApiExceptionFilterAttribute : ActionFilterAttribute, IExceptionFilter, IAsyncActionFilter
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var resultContext = await next();

            if (resultContext.Result is ObjectResult { Value: ProblemDetails problem })
            {
                var (error, _) = problem.ToErrorDto(context.HttpContext);

                context.Result = GetResult(error);
            }
        }

        public void OnException(ExceptionContext context)
        {
            var localizer = context.HttpContext.RequestServices.GetRequiredService<IStringLocalizer<AppResources>>();

            var (error, wellKnown) = context.Exception.ToErrorDto(localizer, context.HttpContext);

            if (!wellKnown)
            {
                var log = context.HttpContext.RequestServices.GetRequiredService<ISemanticLog>();

                log.LogError(context.Exception, w => w
                    .WriteProperty("message", "An unexpected exception has occurred."));
            }

            context.Result = GetResult(error);
        }

        private static IActionResult GetResult(ErrorDto error)
        {
            if (error.StatusCode == 404)
            {
                return new NotFoundResult();
            }

            return new ObjectResult(error)
            {
                StatusCode = error.StatusCode
            };
        }
    }
}
