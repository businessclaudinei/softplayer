using Accounting.Interest.CrossCutting.Configuration.AppModels;
using Accounting.Interest.CrossCutting.Configuration.Extensions;
using Accounting.Interest.Domain.Commands.CalculateInterest;
using Accounting.Interest.Infrastructure.Data.Query.Queries.ShowMeTheCode;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace Accounting.Interest.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => {
                options.Filters.Add<ValidatorFilter>();
            })
                .AddFluentValidation(fvc =>
                   fvc.RegisterValidatorsFromAssemblyContaining<CalculateInterestCommandValidator>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddGlobalExceptionHandlerMiddleware();

            ConfigureSwagger(services);

            services.AddMediatR(typeof(CalculateInterestCommandHandler).Assembly);
            services.AddMediatR(typeof(ShowMeTheCodeQueryHandler).Assembly);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseRequestLocalization(SetUpLocalization());

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Contabilização de Juros V1");
            });

            app.UseGlobalExceptionHandlerMiddleware();
            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private RequestLocalizationOptions SetUpLocalization()
        {
            var culture = new CultureInfo(AppSettings.Settings.AppLocale);

            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture: culture, uiCulture: culture)
            };

            localizationOptions.SupportedCultures.Add(culture);
            localizationOptions.SupportedUICultures.Add(culture);

            return localizationOptions;
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API Contabilização de Juros",
                    Version = "v1",
                    Description = "Api para calcular taxa de juros.",
                    TermsOfService = new Uri("https://example.com/terms")
                });
                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);
            });
        }
    }
}
