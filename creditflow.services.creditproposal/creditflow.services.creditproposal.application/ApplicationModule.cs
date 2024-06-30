using creditflow.services.creditproposal.application.Consumers;
using creditflow.services.creditproposal.application.Services.Implementations;
using creditflow.services.creditproposal.application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace creditflow.services.creditproposal.application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddServices()
                    .AddConsumers();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPropostaService, PropostaService>();

            return services;
        }

        private static IServiceCollection AddConsumers(this IServiceCollection services)
        {
            services.AddHostedService<CreatePropostaConsumer>();

            return services;
        }
    }
}
