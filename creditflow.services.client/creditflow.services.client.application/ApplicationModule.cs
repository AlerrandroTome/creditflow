using AutoMapper;
using creditflow.services.client.application.Consumers;
using creditflow.services.client.application.Services.Implementations;
using creditflow.services.client.application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace creditflow.services.client.application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddServices()
                    .AddAutoMapper()
                    .AddConsumers();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();

            return services;
        }
        
        private static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Profile));

            return services;
        }

        private static IServiceCollection AddConsumers(this IServiceCollection services)
        {
            services.AddHostedService<PropostaAceitaConsumer>();

            return services;
        }
    }
}
