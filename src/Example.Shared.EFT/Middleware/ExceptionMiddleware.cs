using Example.Shared.EFT.Abstractions.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Example.Shared.EFT.Middleware
{
    internal sealed class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (EftCoreException exception)
            {
                context.Response.StatusCode = 400;
                context.Response.Headers.Add("content-type", "application/json");

                var payload = JsonSerializer.Serialize(new { Code = exception.Code, Message = exception.Message });
                await context.Response.WriteAsync(payload);
            }
        }
    }
}
