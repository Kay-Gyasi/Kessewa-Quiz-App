using System;
using System.Collections.Generic;
using System.Text;
using Kessewa.Quiz.Persistence.DatabaseContext;
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

        
    }
}
