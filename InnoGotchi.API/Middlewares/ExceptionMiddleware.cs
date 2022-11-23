using InnoGotchi.API.Logging;
using System.Text.Json;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using InnoGotchi.API.ViewModels.Base;
using InnoGotchi.Application.Models.Base;

namespace InnoGotchi.API.Middlewares
{
    internal sealed class ExceptionMiddleware : IMiddleware
    {
        private readonly ILoggerManager _loggerManager;

        public ExceptionMiddleware(ILoggerManager loggerManager)
        {
            _loggerManager = loggerManager;
        }
         
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(Exception e)
            {
                _loggerManager.LogError($"Something went wrong: {e}");
                await HandleExceptionAsync(context);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            var response = GetResponse(context);

            await context.Response.WriteAsync(new ErrorDetailsViewModel
            {
                Message = JsonSerializer.Serialize(response),
                StatusCode = context.Response.StatusCode
            }.ToString());

        }

        private static ApiResult<string> GetResponse(HttpContext context)
        {
            var exception = context.Features.Get<IExceptionHandlerFeature>();

            var errorMessage = exception != null
                ? exception.Error.Message
                : "Internal server error";

            var respose = ApiResult<string>.Failure(new[] { errorMessage });
            return respose;
        
        
        
        }
    }
}
