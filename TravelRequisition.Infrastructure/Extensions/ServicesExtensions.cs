using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using TravelRequisition.Core.Interface.Repositories;
using TravelRequisition.Core.Interface.Services;
using TravelRequisition.Infrastructure.Repositories;
using TravelRequisition.Infrastructure.Services;

namespace TravelRequisition.Infrastructure.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddAppServices(this IServiceCollection services, 
                                               IConfiguration configuration)
        {

            services.AddScoped<ITravelRequestRepository, TravelRequestRepository>();

            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IWeatherService, WeatherService>();
            services.AddScoped<ITokenService, TokenService>();


            services.AddHttpClient();
        }

        public static void AddDocumentationServices(this IServiceCollection services, string swaggerTitle = "")
        {
            services.AddSwaggerGen(c =>
            {
                string title = !string.IsNullOrEmpty(swaggerTitle) ? swaggerTitle : "Travel Requisition";
                c.SwaggerDoc("v1", new OpenApiInfo { Title = $"{ title }", Version = "V1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                  {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });
        }

    }
}
