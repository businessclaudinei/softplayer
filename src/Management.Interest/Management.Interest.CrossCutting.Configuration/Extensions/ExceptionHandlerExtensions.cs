using Management.Interest.CrossCutting.Configuration.AppModels;
using Management.Interest.CrossCutting.Configuration.ExceptionModels;
using Management.Interest.CrossCutting.Exception.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;

namespace Management.Interest.CrossCutting.Configuration.Extensions
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
            using (var response = new DefaultExceptionResponse())
            {
                try
                {
                    await next(context);
                }
                catch (BadRequestCustomException badRequestCustomException)
                {
                    response.Notification.Message = badRequestCustomException.Message;
                    response.Notification.ResponseCode = badRequestCustomException.ResponseCode;
                    response.Notification.InvalidFields = badRequestCustomException.InvalidFields;
                    await HandleException(response, context);
                }
                catch (ApiHttpCustomException apiHttpCustomException)
                {
                    response.Notification.Message = apiHttpCustomException.Message;
                    response.Notification.ResponseCode = apiHttpCustomException.ResponseCode;
                    response.Notification.Details = apiHttpCustomException;
                    await HandleException(response, context);
                }
                catch (System.Exception ex)
                {
                    response.Notification.Message = ex.Message;
                    response.Notification.ResponseCode = HttpStatusCode.InternalServerError;
                    response.Notification.Details = ex;
                    await HandleException(response, context);
                }
            }
        }

        private async Task HandleException(DefaultExceptionResponse response, HttpContext context)
        {
            if (!AppSettings.Settings.Error.Detailed)
                response.Notification.Details = null;

            var serializedResponse = JsonConvert.SerializeObject(response);

            _logger.LogError($"Error: {serializedResponse}");

            context.Response.StatusCode = (int)response.Notification.ResponseCode;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(serializedResponse);
        }
    }
}
