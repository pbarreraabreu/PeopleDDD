using Microsoft.Extensions.DependencyInjection;
using PeopleDDD.Application.Interfaces;
using PeopleDDD.Application.Services;
using PeopleDDD.Infra.CrossCutting.IoC;

namespace PeopleDDD.UI.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            NativeInjector.RegisterServices(services);
        }
    }
}
