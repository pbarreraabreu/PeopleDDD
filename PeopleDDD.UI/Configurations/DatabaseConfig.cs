using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeopleDDD.Infra.Data.Context;
using System;

namespace PeopleDDD.UI.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<PeopleDDDContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));            
        }
    }
}
