using creditflow.services.creditcard.core.Repositories;
using creditflow.services.creditcard.infrastructure.Persistence;
using creditflow.services.creditcard.infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace creditflow.services.creditcard.infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddPersistence(configuration)
                .AddRepositories();

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
            services.AddScoped<ICartaoRepository, CartaoRepository>();

            return services;
        }
    }
}