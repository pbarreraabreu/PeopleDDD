using Microsoft.Extensions.DependencyInjection;
using PeopleDDD.Application.Interfaces;
using PeopleDDD.Application.Services;
using PeopleDDD.Domain.Interfaces;
using PeopleDDD.Infra.Data.Context;
using PeopleDDD.Infra.Data.Repository;
using System;

namespace PeopleDDD.Infra.CrossCutting.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IPeopleAppService, PeopleAppService>();

            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddScoped<PeopleDDDContext>();
        }
    }
}
