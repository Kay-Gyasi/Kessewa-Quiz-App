using System.Reflection;
using AutoMapper;
using Kessewa.Quiz.Persistence;
using Kessewa.Quiz.Processors;

namespace Kessewa.Quiz.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddQuizWebApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration)
                .AddRepositories()
                .AddProcessors()
                .RegisterAutoMapper();
            return services;
        }
    }
}
