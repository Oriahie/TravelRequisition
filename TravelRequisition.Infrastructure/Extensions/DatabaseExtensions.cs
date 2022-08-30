using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TravelRequisition.Core.EFContext;

namespace TravelRequisition.Infrastructure.Extensions
{
    public static class DatabaseExtensions
    {
        public static void AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionstring = configuration.GetConnectionString("DataDbContext");


            services.AddDbContextPool<DataDbContext>((serviceProvider, optionsBuilder) =>
            {
                optionsBuilder.UseSqlServer(connectionstring, optionsBuilder => optionsBuilder.EnableRetryOnFailure());
                optionsBuilder.UseInternalServiceProvider(serviceProvider);
            });

            services.AddEntityFrameworkSqlServer();
            services.AddTransient<DbContext, DataDbContext>();
        }
    }
}
