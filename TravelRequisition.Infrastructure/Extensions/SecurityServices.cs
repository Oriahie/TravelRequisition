using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace TravelRequisition.Infrastructure.Extensions
{
    public static class SecurityServices
    {
        public static void AddSecurityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options => options.AddPolicy("*",
                builder =>
                {
                    builder.SetIsOriginAllowedToAllowWildcardSubdomains()
                           .WithOrigins("*")
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .Build();
                }));



            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
           
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
          .AddJwtBearer(o =>
          {
              o.RequireHttpsMetadata = false;
              o.SaveToken = true;
              o.TokenValidationParameters = new TokenValidationParameters()
              {
                  ValidateIssuer = true,
                  ValidateAudience = true,
                  ValidateLifetime = true,
                  ValidateIssuerSigningKey = true,
                  ValidIssuer = configuration["Tokens:Issuer"],
                  ValidAudience = configuration["Tokens:Issuer"],
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:SecretKey"]))
              };

          }).AddCookie("cookie");
        }

    }
}
