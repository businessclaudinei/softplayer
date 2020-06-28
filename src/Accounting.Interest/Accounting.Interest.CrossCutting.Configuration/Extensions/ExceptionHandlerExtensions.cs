using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using Accounting.Interest.CrossCutting.Exceptions.Base;
using Accounting.Interest.CrossCutting.Configuration.ExceptionModels;
using Accounting.Interest.CrossCutting.Configuration.AppModels;

namespace Accounting.Interest.CrossCutting.Configuration.Extensions
{
    public static class GlobalExceptionHandlerMiddlewareExtensions
    {
        public static IServiceCollection AddGlobalExceptionHandlerMiddleware(this IServiceCollection services)
        {
            return services.AddTransient<GlobalExceptionHandlerMiddleware>();
        }

        public static void UseGlobalExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        }
    }

    public class GlobalExceptionHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ApiHttpCustomException ApiHttpCustomException)
            {
                _logger.LogError($"Unexpected error: {ApiHttpCustomException}");
                await HandleExceptionAsync(context, ApiHttpCustomException);
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Unexpected error: {ex}");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, System.Exception exception)
        {
            var httpStatusCode = exception is ApiHttpCustomException ? ((ApiHttpCustomException)exception).ResponseCode: HttpStatusCode.InternalServerError;

            DefaultExceptionResponse response;

            if (AppSettings.Settings.Error.Detailed)
                response = new DefaultExceptionResponse(exception, exception.Message, httpStatusCode);
            else
                response = new DefaultExceptionResponse(exception.Message, httpStatusCode);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpStatusCode;

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
