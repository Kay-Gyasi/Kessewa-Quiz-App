using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.DependencyInjection;

namespace Kessewa.Quiz.Processors
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProcessors(this IServiceCollection services)
        {

            return services;
        }   
    }
}
