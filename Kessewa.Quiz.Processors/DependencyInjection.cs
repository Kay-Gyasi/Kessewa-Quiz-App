using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Kessewa.Quiz.Processors
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProcessors(this IServiceCollection services)
        {
            var attribute = typeof(ProcessorAttribute);
            var assembly = attribute.Assembly;
            var definedTypes = assembly.DefinedTypes;

            var processors = definedTypes.Where(x => x.IsClass && x.GetCustomAttribute(attribute) != null).ToList();
            foreach (var processor in processors)
            {
                services.AddScoped(processor.AsType());
            }
            return services;
        }

        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        {
            //var mapperConfig = new MapperConfiguration(x =>
            //{
            //    x.AddProfile(new MappingProfile());
            //});

            //var mapper = mapperConfig.CreateMapper();
            //services.AddSingleton(mapper);
            //return services;

            var assemblies = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assemblies);
            return services;
        }
    }
}
