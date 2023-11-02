using System;
using System.Linq;
using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Test.Raizen.Bootstrap.Providers.Pipelines;

namespace Test.Raizen.Bootstrap.Providers
{
    public static class MediatorConfiguration
    {

        private const string APPLICATION_NAMESPACE = "Test.Raizen.Application";

        public static IServiceCollection ConfigureMediatr(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.Load(APPLICATION_NAMESPACE));

            var currentAssemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(c => c.GetName().Name.Contains(APPLICATION_NAMESPACE));

            AssemblyScanner.FindValidatorsInAssemblies(currentAssemblies)
              .ForEach(c => services.AddScoped(c.InterfaceType, c.ValidatorType));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
