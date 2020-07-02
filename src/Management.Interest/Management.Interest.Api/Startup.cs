using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using AutoMapper;
using FluentValidation.AspNetCore;
using Management.Interest.Api.Filters;
using Management.Interest.CrossCutting.Configuration.AppModels;
using Management.Interest.CrossCutting.Configuration.Extensions;
using Management.Interest.CrossCutting.Configuration.Mapper;
using Management.Interest.Infrastructure.Data.Query.Queries.v1.GetInterestRate;
using Management.Interest.Infrastructure.Data.Query.v1.Mappers;
using Management.Interest.Infrastruture.Service.Resources.Cache;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Management.Interest {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices (IServiceCollection services) {
            services.AddMvc (options => {
                    options.Filters.Add<ValidatorFilter> ();
                })
                .AddFluentValidation (fvc =>
                    fvc.RegisterValidatorsFromAssemblyContaining<GetInterestRateQueryValidator> ())
                .SetCompatibilityVersion (CompatibilityVersion.Version_2_2);

            services.Configure<ApiBehaviorOptions> (options => {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddGlobalExceptionHandlerMiddleware ();

            ConfigureSwagger (services);

            services.AddAutoMapper ();
            services.AddMediatR (typeof (GetInterestRateQueryHandler).Assembly);
            ConfigureRedis (services);
        }

        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseHsts ();
            }

            app.UseRequestLocalization (SetUpLocalization ());

            app.UseSwagger ();
            app.UseSwaggerUI (c => {
                c.SwaggerEndpoint ("/swagger/v1/swagger.json", "API Gerenciamento de Juros V1");
            });

            app.UseGlobalExceptionHandlerMiddleware ();
            app.UseHttpsRedirection ();
            app.UseMvc ();
        }

        private void ConfigureRedis (IServiceCollection services) {
            var redisCacheSettings = AppSettings.Settings.RedisCache;
            services.AddSingleton (redisCacheSettings);

            if (!redisCacheSettings.Enabled)
                return;

            var redisConnectionString = Environment.GetEnvironmentVariable ("REDIS_CONNECTION_STRING");
            if (string.IsNullOrEmpty (redisConnectionString))
                redisConnectionString = redisCacheSettings.ConnectionString;

            services.AddStackExchangeRedisCache (options => options.Configuration = redisConnectionString);
            services.AddSingleton<ICacheService, CacheService> ();
        }

        private RequestLocalizationOptions SetUpLocalization () {
            var culture = new CultureInfo (AppSettings.Settings.AppLocale);

            var localizationOptions = new RequestLocalizationOptions {
                DefaultRequestCulture = new RequestCulture (culture: culture, uiCulture: culture)
            };

            localizationOptions.SupportedCultures.Add (culture);
            localizationOptions.SupportedUICultures.Add (culture);

            return localizationOptions;
        }

        private void ConfigureSwagger (IServiceCollection services) {
            services.AddSwaggerGen (options => {
                options.DescribeAllEnumsAsStrings ();
                options.SwaggerDoc ("v1", new Swashbuckle.AspNetCore.Swagger.Info {
                    Title = "API Gerenciamento de Juros",
                        Version = "v1",
                        Description = "Api para gerenciamento de taxa de juros.",
                        TermsOfService = "https://example.com/terms"
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine (AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments (xmlPath);
            });
        }
    }

    public static class CustomMvcServiceCollectionExtensions {
        public static void AddAutoMapper (this IServiceCollection services) {
            if (services == null) {
                throw new ArgumentNullException (nameof (services));
            }
            var config = new AutoMapperConfiguration ().Configure ();
            services.AddSingleton (sp => config.CreateMapper ());
        }
    }

    public class AutoMapperConfiguration {
        public MapperConfiguration Configure () {
            var config = new MapperConfiguration (cfg => {
                cfg.AddProfile<ExceptionProfile> ();
                cfg.AddProfile<GetInterestRateProfile> ();
            });
            return config;
        }
    }
}