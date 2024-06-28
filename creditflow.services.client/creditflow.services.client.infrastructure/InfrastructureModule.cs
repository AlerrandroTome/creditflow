using creditflow.services.client.core.Interfaces;
using creditflow.services.client.core.Repositories;
using creditflow.services.client.infrastructure.MessageBus;
using creditflow.services.client.infrastructure.Persistence;
using creditflow.services.client.infrastructure.Persistence.Repositories;
using creditflow.services.client.infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace creditflow.services.client.infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddPersistence(configuration)
                .AddRepositories()
                .AddMessageBus()
                .AddServices();

            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("ClientFlowDb");
            services.AddDbContext<CreditFlowDbContext>(opt => opt.UseSqlServer(connectionString));

            return services;
        }
        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();

            return services;
        }

        private static IServiceCollection AddMessageBus(this IServiceCollection services)
        {
            services.AddScoped<IMessageBusService, MessageBusService>();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICartaoService, CartaoService>();
            services.AddScoped<IPropostaService, PropostaService>();

            return services;
        }
    }
}
