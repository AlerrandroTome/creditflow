using creditflow.services.creditproposal.core.Interfaces;
using creditflow.services.creditproposal.core.Repositories;
using creditflow.services.creditproposal.infrastructure.MessageBus;
using creditflow.services.creditproposal.infrastructure.Persistence;
using creditflow.services.creditproposal.infrastructure.Persistence.Repositories;
using creditflow.services.creditproposal.infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace creditflow.services.creditproposal.infrastructure
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
            string connectionString = configuration.GetConnectionString("CreditFlowDb");
            services.AddDbContext<CreditFlowDbContext>(opt => opt.UseSqlServer(connectionString));

            return services;
        }
        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPropostaRepository, PropostaRepository>();

            return services;
        }

        private static IServiceCollection AddMessageBus(this IServiceCollection services)
        {
            services.AddScoped<IMessageBusService, MessageBusService>();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();

            return services;
        }
    }
}
