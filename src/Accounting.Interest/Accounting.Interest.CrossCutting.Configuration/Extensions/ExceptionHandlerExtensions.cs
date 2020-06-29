using Accounting.Interest.CrossCutting.Configuration.AppModels;
using Accounting.Interest.CrossCutting.Configuration.ExceptionModels;
using Accounting.Interest.CrossCutting.Exception.Base;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

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
        private readonly IMapper _mapper;

        public GlobalExceptionHandlerMiddleware(ILogger<GlobalExceptionHandlerMiddleware> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            using (var response = new DefaultExceptionResponse())
            {
                try
                {
                    try
                    {
                        await next(context);
                    }
                    catch (BadRequestCustomException badRequestCustomException)
                    {
                        response.Notification = _mapper.Map<BadRequestCustomException, DefaultExceptionResponse.NotificationObject>(badRequestCustomException);
                        await HandleException(response, context);
                    }
                    catch (ApiHttpCustomException apiHttpCustomException)
                    {
                        response.Notification = _mapper.Map<ApiHttpCustomException, DefaultExceptionResponse.NotificationObject>(apiHttpCustomException);
                        await HandleException(response, context);
                    }
                    catch (System.Exception ex)
                    {
                        response.Notification = _mapper.Map<System.Exception, DefaultExceptionResponse.NotificationObject>(ex);
                        await HandleException(response, context);
                    }
                }
                catch (System.Exception ex)
                {
                    var jsonError = $@"{{
                                        ""data"": null,
                                        ""notification"": {{
                                           ""responseCode"": 500,
                                           ""message"": ""Um erro fatal aconteceu. Erro: {ex.Message.Replace("\r","").Replace("\n", "")}"",
                                           ""details"": ""{ ex.StackTrace}""
                                          }}
                                       }}";
                    Console.WriteLine(jsonError);
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(jsonError);
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
