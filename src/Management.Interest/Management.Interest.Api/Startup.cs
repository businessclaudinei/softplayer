using Management.Interest.Infrastruture.Data.Query.Queries.GetInterestRate;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace Management.Interest
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            ConfigureSwagger(services);

            services.AddMediatR(typeof(GetInterestRateQueryHandler).Assembly);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Gerenciamento de Juros V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private RequestLocalizationOptions SetUpLocalization()
        {
            var culture = new CultureInfo(Configuration["AppLocale"]);

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
                    Title = "API Gerenciamento de Juros",
                    Version = "v1",
                    Description = "Api para gerenciamento de taxa de juros.",
                    TermsOfService = new Uri("https://example.com/terms")
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);
            });
        }
    }
}
