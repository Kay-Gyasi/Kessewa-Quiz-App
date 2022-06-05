using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Kessewa.Quiz.Persistence.DatabaseContext;
using Kessewa.Quiz.Persistence.Repositories;
using Kessewa.Quiz.Processors.ExceptionHandlers;
using Kessewa.Quiz.Processors.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
        /// <exception cref="RepositoryNotRegisteredException"></exception>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            var definedTypes = typeof(DependencyInjection).Assembly.DefinedTypes;
            var repositories = definedTypes
                .Where(t => t.IsClass && t.GetCustomAttribute<RepositoryAttribute>() != null)
                .ToList();

            foreach (var repository in repositories)
            {
                services.AddScoped(
                    repository.GetInterfaces()
                        .SingleOrDefault(x => x.GetCustomAttribute<RepositoryAttribute>() != null) ??
                    throw new RepositoryNotRegisteredException("Missing [Repository] tag on repository interface"),
                    repository);
            }

            return services;
        }
    }
}
