using Kessewa.Quiz.Persistence.DatabaseContext;
using Kessewa.Quiz.Processors.ExceptionHandlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Kessewa.Quiz.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<KessewaDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("KessewaQuizDev"));
            });
            return services;
        }

        /// <summary>
        ///    Registers all repositories in the assembly.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        /// <exception cref="RepositoryNotFoundException"></exception>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            var definedTypes = typeof(DependencyInjection).Assembly.DefinedTypes;
            var repositories = definedTypes
                .Where(t => t.IsClass && t.GetCustomAttribute<RepositoryAttribute>() != null)
                .ToList();

            foreach (var repository in repositories)
            {
                var irepository = repository.GetInterfaces().FirstOrDefault(i => i.Name == $"I{repository.Name}") ??
                                  throw new RepositoryNotFoundException(
                                      $"{repository.Name} has no interface with name I{repository.Name}");
                services.AddScoped(irepository, repository);
            }

            return services;
        }
    }
}
