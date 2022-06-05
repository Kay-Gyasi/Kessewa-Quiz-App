using AutoMapper;
using Kessewa.Quiz.Persistence;
using Kessewa.Quiz.Processors;
using Kessewa.Quiz.WebApi.Mapping;

namespace Kessewa.Quiz.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddQuizWebApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration)
                .AddRepositories()
                .AddProcessors()
                .AddAutoMapper();
            return services;
        }

        private static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile(new MappingProfile());
            });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
