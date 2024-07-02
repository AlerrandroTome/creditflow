using creditflow.services.client.application.Services.Implementations;
using creditflow.services.client.application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace creditflow.services.client.application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddServices();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();

            return services;
        }
    }
}
