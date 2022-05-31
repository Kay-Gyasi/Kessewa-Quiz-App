using Kessewa.Quiz.Persistence;

namespace Kessewa.Quiz.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddQuizWebApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            return services;
        }
    }
}
