using Microsoft.Extensions.DependencyInjection;
using PeopleDDD.Application.AutoMapper;
using System;

namespace PeopleDDD.UI.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile));
        }
    }
}
