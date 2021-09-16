using DevFreela.Application.Core;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DevFreela.Api.Extensions
{
    public static class MediatRSetup
    {
        public static void AddMediatRSetup(this IServiceCollection services)
        {
            var assemblies = new System.Reflection.Assembly[]
            {
                AppDomain.CurrentDomain.Load("DevFreela.Application")
            };

            services.AddMediatR(assemblies);

            foreach (var assembly in assemblies)
            {
                AssemblyScanner
                 .FindValidatorsInAssembly(assembly)
                 .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));
            }

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(MediatorPipeline<,>));
        }
    }
}